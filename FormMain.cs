using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalTest
{
    public partial class FormMain : Form
    {
        FormModeSwitch mFormModeSwitch = new FormModeSwitch();      //模式设置页面
        FormNIBP mFormNIBP;                                         //血压界面类
        FormResp mFormResp;                                         //呼吸界面类
        FormSPO2 mFormSPO2;                                         //血氧界面类

        public const int PACK_QUEUE_CNT = 2000;    //缓冲的长度

        public const int WAVE_X_SIZE = 1080;       //绘制波形区域的长，如果绘图区域长度更改，更改此值       
        public const int WAVE_Y_SIZE = 130;        //绘制波形区域的宽，如果绘图区域宽度更改，更改此值 

        //引入动态链接库，保存串口的配置信息
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val,
          string filepath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def,
          StringBuilder retVal, int size, string filepath);

        //保存串口配置信息的文件名
        private string mFileName = System.AppDomain.CurrentDomain.BaseDirectory + "Config.ini";

        //返回（retrieve）从操作系统启动所经过（elapsed）的毫秒数
        [DllImport("kernel32")]
        static extern uint GetTickCount();
        private uint mLastTick = 0;                //保存上一次获得的毫秒数

        //定义一个串口配置信息结构体变量，该结构体在串口界面声明
        private StructUARTInfo mUARTInfo = new StructUARTInfo();

        PackUnpack mPackUnpack = new PackUnpack();                   //定义一个打包解包类对象
        private List<byte> mPackAfterUnpackList = new List<byte>();  //线性链表，内容为解包后数据

        int mPackHead = -1;                        //当前需要处理的缓冲包的序号
        //最后处理的缓冲包的序号，packHeadIndex不能追上mPackTail,追上的话表示收到的数据超出1000的缓冲
        int mPackTail = -1;

        private object mLockObj = new object();    //用于锁死计数,多线程访问数据时避免出错
        byte[][] mPackAfterUnpackArr;              //定义一个二维数组作为接收数据的缓冲，在窗口加载时初始化

        private SendData mSendData = null;         //声明串口，用于发送命令给从机（单片机）


        //界面显示需要的一些变量
        //血压
        public string mNIBPMeasMode = "手动";      //血压测量模式

        //呼吸
        private string mRespGainSet = "X1";                          //呼吸增益设置
        private List<ushort> mRespWaveList = new List<ushort>();     //线性链表，内容为Resp的波形数据
        private Pen mRespWavePen = new Pen(Color.Blue, 1);         //Resp波形画笔
        private float mRespXStep = 0.0F;                             //Resp横坐标

        //血氧
        private string mSPO2SensSet = "中";                          //血氧灵敏度设置
        private List<ushort> mSPO2WaveList = new List<ushort>();     //线性链表，内容为血氧的波形数据
        private Pen mSPO2WavePen = new Pen(Color.Red, 1);           //SPO2波形画笔
        private float mSPO2XStep = 0.0F;                             //SPO2横坐标


        //数据存储
        StoreSetting mStoreSetting;                                  //文件存储类

        //以下变量用于数据存储，用于设置保存数据的文件名及存储路径  
        StreamWriter mNIBPDirectory;
        StreamWriter mRespDirectory;
        StreamWriter mSPO2Directory;
        StreamWriter mSWUART = null;

        //用于存储的参数
        //血压
        ushort mMaxNIBPData;
        ushort mMinNIBPData;
        //呼吸
        ushort mMaxRespWave;
        ushort mMinRespWave;
        //血氧
        ushort mMaxSPO2Wave;
        ushort mMinSPO2Wave;


        //模式设置
        public bool mIsRealMode = true;                                 //模式选择的监护模式变量
        public bool mIsLoadMode = false;                                //回放模式
        public bool mIsDisplayMode = false;                             //演示模式
        private string mUARTFile = "";                                  //回放或演示的数据文件 

        Boolean mThreadStartFlag = false;                               //procLoadDataThread线程启动标志 默认串口关闭=>false
        Task mProcLoadDataTask = null;                                  //线程
        Boolean mDisplayModeFlag = false;                               //演示模式的标志位，true为演示模式
        private List<string> mUARTLoadDataList = new List<string>();    //加载的串口数据

        /***********************************************************************************************
        * 方法名称: MainForm
        * 功能说明: 构造函数
        * 参数说明：输入参数 (1)userAccount 当前登录用户的账号
        * 注    意:
        ***********************************************************************************************/
        public FormMain(string userAccount)
        {
            InitializeComponent();

            //创建存储当前用户爱好设置 和 数据的文件夹
            string storeSettingFileDirectory = @".\Data\" + userAccount;
            if (!Directory.Exists(storeSettingFileDirectory))
            {
                Directory.CreateDirectory(storeSettingFileDirectory);
            }

            string saveFolderDirectory = @".\RcvData\" + userAccount;
            if (!Directory.Exists(saveFolderDirectory))
            {
                Directory.CreateDirectory(saveFolderDirectory);
            }


            labelAccount.Text = userAccount;                    //将用户名显示到主界面的欢迎界面label中           
            labelTime.Text = DateTime.Now.ToString();           //将时间显示到主界面中


            mPackAfterUnpackArr = new byte[PACK_QUEUE_CNT][];   //二维数组，作为接收数据缓冲
            for (int i = 0; i < PACK_QUEUE_CNT; i++)            //将数组初始化为0
            {
                mPackAfterUnpackArr[i] = new byte[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            }

            mSendData = new SendData(serialPort);        //将串口传递到界面，为了把命令发送给单片机

            mFormNIBP = new FormNIBP(mSendData, mNIBPMeasMode, mFormModeSwitch); //实例化血压界面
            mFormResp = new FormResp(mSendData, mRespGainSet, mFormModeSwitch); //实例化呼吸界面
            mFormSPO2 = new FormSPO2(mSendData, mSPO2SensSet, mFormModeSwitch); //实例化血氧界面

            mFormModeSwitch.SwitchModeEvent += new SwitchModeDelegate(switchMode); //给模式设置界面添加委托事件触发的方法

            mStoreSetting = new StoreSetting(userAccount, "#参数设置");            //定义一个存储数据类
        }

        /***********************************************************************************************
        * 方法名称: MainForm_Load
        * 功能说明: 界面刚加载时将文件Config.ini内的值赋值给有关串口配置的结构体
        * 参数说明：
        * 注    意:
        ***********************************************************************************************/
        private void MainForm_Load(object sender, EventArgs e)
        {
            //新建存储字符串的对象，内存空间的大小为255，用于存放读到的串口号和波特率
            StringBuilder portNum = new StringBuilder(255);
            StringBuilder baudRate = new StringBuilder(255);

            GetPrivateProfileString("PortData", "PortNum", "COM1", portNum, 255, mFileName);
            GetPrivateProfileString("PortData", "BaudRate", "115200", baudRate, 255, mFileName);

            mUARTInfo.portNumItem = new List<string>();
            //将保存的ini文件中的串口号取出并赋值给comboBox控件
            mUARTInfo.portNum = portNum.ToString();
            //将保存的ini文件中的波特率取出并赋值给comboBox控件
            mUARTInfo.baudRate = baudRate.ToString();
            mUARTInfo.dataBits = "8";         //数据位
            mUARTInfo.stopBits = "1";         //停止位
            mUARTInfo.parity = "NONE";        //校验位
            mUARTInfo.isOpened = false;       //刚打开界面默认串口是关闭的

            //初始化所存储的数据
            mMaxNIBPData = 0;                 //血压数据的范围为0到300
            mMinNIBPData = 300;

            mMaxRespWave = 0;                 //呼吸波形数据范围为0到255
            mMinRespWave = 255;

            mMaxSPO2Wave = 0;                 //血氧波形数据范围为0到127
            mMinSPO2Wave = 127;
        }
        /***********************************************************************************************
        * 方法名称: MainForm_FormClosing
        * 功能说明: 界面关闭时将本次使用的串口的串口号和波特率写到Config.ini文件内
        * 参数说明：
        * 注    意:
        ***********************************************************************************************/
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                serialPort.Close();        //关闭串口

                mThreadStartFlag = false;         //清除线程标志
                mDisplayModeFlag = false;         //清除演示模式

                mRespWaveList.Clear();            //清除mRespWaveList
                mSPO2WaveList.Clear();            //清除mSPO2WaveList
            }
            catch            //一般情况下关闭串口不会出错，所以不需要加处理程序
            {
                MessageBox.Show("串口关闭错误", "错误");
            }

            WritePrivateProfileString("PortData", "PortNum", mUARTInfo.portNum, mFileName);     //将本次的使用的串口号写入Config.ini文件中
            WritePrivateProfileString("PortData", "BaudRate", mUARTInfo.baudRate, mFileName);   //将本次的使用的波特率写入Config.ini文件中
        }

        /***********************************************************************************************
        * 方法名称: ToolStripMenuItemUART_Click
        * 功能说明: 当点击ToolStripMenuItemUART时调用,显示串口设置界面
        * 参数说明：
        * 注    意:
        ***********************************************************************************************/
        private void ToolStripMenuItemUART_Click(object sender, EventArgs e)
        {
            if (!mUARTInfo.isOpened)
            {
                searchAndAddSerialToComboBox(serialPort, mUARTInfo.portNumItem);  //扫描串口
            }

            FormUARTSetting mUARTSetForm = new FormUARTSetting(mUARTInfo);
            mUARTSetForm.StartPosition = FormStartPosition.CenterParent;   //界面生成位置在主界面的正中间

            //向openUARTHandler委托的事件openUARTEvent中添加procUARTInfo方法，添加额外的方法使用+=
            //功能：将UART设置界面的串口参数传至主界面，并根据当前串口状态决定是否打开串口，然后将对应
            //      信息显示到主界面的状态栏
            mUARTSetForm.openUARTEvent += new openUARTHandler(procUARTInfo);

            mUARTSetForm.ShowDialog();                                     //显示串口设置界面
        }

        /***********************************************************************************************
        * 方法名称: searchAndAddSerialToComboBox
        * 功能说明: 串口扫描方法
        * 参数说明：输入参数（1）serialPort-串口类，输入参数（2）list-下拉列表
        * 注    意:
        ***********************************************************************************************/
        private void searchAndAddSerialToComboBox(SerialPort serialPort, List<string> list)
        {
            string[] myString = new string[20];           //最多容纳20个端口，太多会影响调试效率
            string buffer;                                //缓存串口号
            list.Clear();                                 //清空ComboBox内容
            int count = 0;
            for (int i = 1; i < 20; i++)                  //循环扫描电脑的端口
            {
                try                                       //核心原理是依靠try和catch完成遍历
                {
                    buffer = "COM" + i.ToString();        //得到串口号
                    serialPort.PortName = buffer;         //将串口号存入串口类变量
                    serialPort.Open();                    //如果失败，后面的代码不会执行
                    myString[count] = buffer;
                    list.Add(buffer);                     //打开成功，添加至下拉列表
                    serialPort.Close();                   //关闭
                    count++;
                }
                catch
                {
                }
            }
        }

        /***********************************************************************************************
        * 方法名称: procUARTInfo
        * 功能说明: 将UART设置界面的串口参数传至主界面，并根据当前串口状态决定是否打开串口，然后将对应
        *           信息显示到主界面的状态栏
        * 参数说明：输入参数info-串口信息结构体
        * 注    意:
        ***********************************************************************************************/
        private void procUARTInfo(StructUARTInfo info)
        {
            mUARTInfo = info;  //将UART设置界面的串口参数传至主界面

            if (!serialPort.IsOpen)
            {
                //打开串口读取
                setUARTState(true);

                if (!mIsRealMode)
                {
                    mFormNIBP.ToolStripLabelNIBPModeSwitchText = "模式：监护";
                    mFormResp.ToolStripLabelRespModeSwitchText = "模式：监护";
                    mFormSPO2.ToolStripLabelSPO2ModeSwitchText = "模式：监护";

                    //关闭演示线程
                    mThreadStartFlag = false;
                    if (null != mProcLoadDataTask)
                    {
                        mProcLoadDataTask.Wait();
                        mProcLoadDataTask = null;
                    }
                }
            }
            else
            {
                //关闭串口读取
                setUARTState(false);
            }
        }

        /***********************************************************************************************
        * 方法名称: setUARTState
        * 功能说明: 打开/关闭串口控件
        * 参数说明：输入参数IsOpen-串口状态
        * 注    意:
        ***********************************************************************************************/
        private void setUARTState(bool isOpen)
        {
            string strUARTInfo;

            if (isOpen)      //如果当前串口的状态是关闭状态
            {
                try
                {
                    setDataSaveWriter(true);      //使能存储方法

                    serialPort.PortName = mUARTInfo.portNum;                   //串口号
                    serialPort.BaudRate = Convert.ToInt32(mUARTInfo.baudRate); //波特率
                    serialPort.Open();             //打开串口
                    mUARTInfo.isOpened = true;            //串口状态设置为打开

                    //显示串口状态
                    strUARTInfo = mUARTInfo.portNum + "已打开," + mUARTInfo.baudRate + "," + mUARTInfo.dataBits + "," + mUARTInfo.stopBits + "," + mUARTInfo.parity;
                }
                catch
                {
                    strUARTInfo = "串口打开异常";
                    MessageBox.Show("端口错误,请检查串口", "错误");   //跳出错误窗口 
                }
            }
            else           //如果当前串口的状态是打开状态，则关闭串口
            {
                mUARTInfo.isOpened = false;  //串口状态设置为关闭
                try
                {
                    serialPort.Close();      //关闭串口

                    mThreadStartFlag = false;

                    mRespWaveList.Clear();
                    mSPO2WaveList.Clear();

                    strUARTInfo = "串口已关闭";     //显示串口状态
                }
                catch       //一般情况下关闭串口不会出错，所以不需要加处理程序
                {
                    strUARTInfo = "串口关闭异常";
                }

                setDataSaveWriter(false);     //关闭存储方法的功能
            }

            toolStripStatusLabelUART.Text = strUARTInfo;  //在主界面窗口的状态栏显示串口配置信息
        }

        /***********************************************************************************************
        * 方法名称: timerForSec_Tick
        * 功能说明: 定时器任务，30ms调用一次
        * 注    意:
        ***********************************************************************************************/
        private void timerForSec_Tick(object sender, EventArgs e)
        {
            //1000决定定时器的定时时间，或者更改定时器属性栏的Interval，数字越大定时越长
            if (GetTickCount() - mLastTick > 1000)
            {
                mLastTick = GetTickCount();

                //更新主界面显示时间
                labelTime.Text = DateTime.Now.ToString();
            }
            dealRcvPackData();
        }

        /***********************************************************************************************
        * 方法名称: dealRcvPackData
        * 功能说明: 处理当前的数据帧，不管是收到的还是演示数据
        * 注    意:
        ***********************************************************************************************/
        private void dealRcvPackData()
        {
            uint start = GetTickCount();

            int iHeadIndex = -1;
            int iTailIndex = -1;

            lock (mLockObj)                        //运行计数，加锁，避免数据出错
            {
                iHeadIndex = mPackHead;
                iTailIndex = mPackTail;
            }

            if (iHeadIndex < iTailIndex)           //如果出现缓冲溢出则增加数据存储内存
            {
                iHeadIndex = iHeadIndex + PACK_QUEUE_CNT;
            }

            int index;
            int cnt = iHeadIndex - iTailIndex;     //获取当前接收到的数据长度
            for (int i = iTailIndex; i < iHeadIndex; i++)
            {
                index = i % PACK_QUEUE_CNT;

                if (mPackAfterUnpackArr[index][0] == 0x14)    //血压相关的数据包
                {
                    analyzeNIBPData(mPackAfterUnpackArr[index]);
                }
                else if (mPackAfterUnpackArr[index][0] == 0x11)    //呼吸相关的数据包
                {
                    analyzeRespData(mPackAfterUnpackArr[index]);
                }
                else if (mPackAfterUnpackArr[index][0] == 0x13)    //血氧相关的数据包
                {
                    analyzeSPO2Data(mPackAfterUnpackArr[index]);
                }
            }

            lock (mLockObj)
            {
                //每次处理cnt个数据，处理完之后，数据要往后移cnt个
                mPackTail = (mPackTail + cnt) % PACK_QUEUE_CNT;
            }

            if (mRespWaveList.Count > 2)     //呼吸波形数据超过两个才开始画波形
            {
                drawRespWave();
            }

            if (mSPO2WaveList.Count > 2)     //血氧波形数据超过两个才开始画波形
            {
                drawSPO2Wave();
            }

            if (mDisplayModeFlag)            //演示模式，就让血压的各项值显示标准值
            {
                mFormNIBP.LabelNIBPCufPreText = "0";
                mFormNIBP.LabelNIBPMeanText = "93";
                mFormNIBP.LabelNIBPSysText = "128";
                mFormNIBP.LabelNIBPDiaText = "85";
                mFormNIBP.LabelNIBPPRText = "59";
            }
        }

        /***********************************************************************************************
        * 方法名称: analyzeNIBPData
        * 功能说明: 分析血压数据包，并显示到界面上
        * 参数说明：输入参数packAfterUnpack-解包后数据包
        * 注    意:
        ***********************************************************************************************/
        private void analyzeNIBPData(byte[] packAfterUnpack)
        {
            byte cufPresHByte;          //袖带压高字节
            byte cufPresLByte;          //袖带压低字节

            byte sysPresHByte;          //收缩压高字节
            byte sysPresLByte;          //收缩压低字节

            byte diaPresHByte;          //舒张压高字节
            byte diaPresLByte;          //舒张压低字节

            byte mapPresHByte;          //平均压高字节
            byte mapPresLByte;          //平均压低字节

            byte pulseRateHByte;        //脉率高字节
            byte pulseRateLByte;        //脉率低字节

            ushort cufPres = 0;         //袖带压
            ushort sysPres = 0;         //收缩压
            ushort diaPres = 0;         //舒张压
            ushort mapPres = 0;         //平均压
            ushort pulseRate = 0;       //脉率

            switch (packAfterUnpack[1])     //判断二级ID
            {
                case 0x02:  //袖带压
                    cufPresHByte = packAfterUnpack[2];
                    cufPresLByte = packAfterUnpack[3];

                    //将高低字节合并
                    cufPres = (ushort)(cufPres | cufPresHByte);
                    cufPres = (ushort)(cufPres << 8);
                    cufPres = (ushort)(cufPres | cufPresLByte);

                    if (cufPres >= 300)
                    {
                        cufPres = 0;     //最大不超过300，超过300则视为无效值，给其赋0即可
                    }
                    mFormNIBP.LabelNIBPCufPreText = cufPres.ToString();   //显示袖带压
                    break;

                case 0x04:  //收缩压、舒张压、平均压
                    sysPresHByte = packAfterUnpack[2];
                    sysPresLByte = packAfterUnpack[3];
                    sysPres = (ushort)(sysPres | sysPresHByte);
                    sysPres = (ushort)(sysPres << 8);
                    sysPres = (ushort)(sysPres | sysPresLByte);

                    if (sysPres >= 300)
                    {
                        sysPres = 0;     //最大不超过300，超过300则视为无效值，给其赋0即可
                    }
                    mFormNIBP.LabelNIBPSysText = sysPres.ToString();    //显示收缩压  


                    diaPresHByte = packAfterUnpack[4];
                    diaPresLByte = packAfterUnpack[5];
                    diaPres = (ushort)(diaPres | diaPresHByte);
                    diaPres = (ushort)(diaPres << 8);
                    diaPres = (ushort)(diaPres | diaPresLByte);
                    if (diaPres >= 300)
                    {
                        diaPres = 0;      //最大不超过300，超过300则视为无效值，给其赋0即可
                    }
                    mFormNIBP.LabelNIBPDiaText = diaPres.ToString();    //显示舒张压

                    mapPresHByte = packAfterUnpack[6];
                    mapPresLByte = packAfterUnpack[7];
                    mapPres = (ushort)(mapPres | mapPresHByte);
                    mapPres = (ushort)(mapPres << 8);
                    mapPres = (ushort)(mapPres | mapPresLByte);
                    if (mapPres >= 300)
                    {
                        mapPres = 0;      //最大不超过300，超过300则视为无效值，给其赋0即可
                    }
                    mFormNIBP.LabelNIBPMeanText = mapPres.ToString();   //显示平均压
                    break;

                case 0x05:  //脉率
                    pulseRateHByte = packAfterUnpack[2];
                    pulseRateLByte = packAfterUnpack[3];
                    pulseRate = (ushort)(pulseRate | pulseRateHByte);
                    pulseRate = (ushort)(pulseRate << 8);
                    pulseRate = (ushort)(pulseRate | pulseRateLByte);
                    if (pulseRate >= 300)
                    {
                        pulseRate = 0;    //脉率值最大不超过300，超过300则视为无效值，给其赋0即可
                    }
                    mFormNIBP.LabelNIBPPRText = pulseRate.ToString();   //显示脉率
                    break;
            }
        }

        /***********************************************************************************************
        * 方法名称: analyzeRespData
        * 功能说明: 分析呼吸数据包
        * 参数说明：输入参数packAfterUnpack-解包后数据包
        * 注    意:
        ***********************************************************************************************/
        private void analyzeRespData(byte[] packAfterUnpack)
        {
            byte respWave;          //呼吸波形数据
            byte respRateHByte;     //呼吸率高字节
            byte respRateLByte;     //呼吸率低字节
            ushort respRate = 0;    //呼吸值

            Rectangle rct = new Rectangle(0, 0, WAVE_X_SIZE, WAVE_Y_SIZE);

            switch (packAfterUnpack[1])
            {
                case 0x02:                            //呼吸波形数据
                    for (int i = 2; i < 7; i++)       //一个包有5个数据
                    {
                        respWave = packAfterUnpack[i];
                        mRespWaveList.Add(respWave);

                        //当存储数据界面勾选呼吸数据且成功创建存储呼吸数据文件，就开始存储呼吸数据
                        if (mStoreSetting.bSaveResp && (mRespDirectory != null))
                        {
                            if (respWave > mMaxRespWave)
                            {
                                mMaxRespWave = respWave;
                            }
                            if (respWave < mMinRespWave)
                            {
                                mMinRespWave = respWave;
                            }

                            mRespDirectory.Write(respWave + " ");
                        }
                    }

                    if (mDisplayModeFlag)         //演示模式，将呼吸的各项值显示标准值
                    {
                        mFormResp.LabelRespRRText = "20";
                    }
                    break;

                case 0x03:               //呼吸率
                    respRateHByte = packAfterUnpack[2];
                    respRateLByte = packAfterUnpack[3];
                    respRate = (ushort)(respRate | respRateHByte);
                    respRate = (ushort)(respRate << 8);
                    respRate = (ushort)(respRate | respRateLByte);
                    if (respRate >= 300)
                    {
                        respRate = 0;    //呼吸率值最大不超过300，超过300则视为无效值，给其赋0即可
                    }

                    mFormResp.LabelRespRRText = respRate.ToString();        //显示呼吸率
                    break;
            }
        }

        /***********************************************************************************************
        * 方法名称: analyzeSPO2Data
        * 功能说明: 分析血氧数据包
        * 参数说明：输入参数packAfterUnpack-解包后数据包
        * 注    意:
        ***********************************************************************************************/
        private void analyzeSPO2Data(byte[] packAfterUnpack)
        {
            ushort spo2Wave;            //血氧波形数据
            byte fingerLead;            //手指连接信息
            byte sensorLead;            //传感器连接信息
            byte pulseRateHByte;        //脉率高字节
            byte pulseRateLByte;        //脉率低字节
            ushort pulseRate = 0;       //脉率值
            byte spo2Value;             //血氧饱和度

            Rectangle rct = new Rectangle(0, 0, WAVE_X_SIZE, WAVE_Y_SIZE);

            switch (packAfterUnpack[1])
            {
                case 0x02:              //血氧波形数据、探头、手指导联
                    for (int i = 2; i < 7; i++)
                    {
                        spo2Wave = (ushort)packAfterUnpack[i];
                        mSPO2WaveList.Add(spo2Wave);

                        //当存储数据界面勾选血氧数据且成功创建存储血氧数据文件，就开始存储血氧数据
                        if (mStoreSetting.bSaveSPO2 && (mSPO2Directory != null))
                        {
                            if (spo2Wave > mMaxSPO2Wave)
                            {
                                mMaxSPO2Wave = spo2Wave;
                            }

                            if (spo2Wave < mMinSPO2Wave)
                            {
                                mMinSPO2Wave = spo2Wave;
                            }

                            mSPO2Directory.Write(spo2Wave + " ");
                        }
                    }

                    fingerLead = (byte)((packAfterUnpack[7] & 0x80) >> 7);      //手指脱落信息
                    sensorLead = (byte)((packAfterUnpack[7] & 0x10) >> 4);      //探头脱落信息

                    if (fingerLead == 0x01)
                    {
                        mFormSPO2.LabelSPO2FingerOffForeColor = Color.Red;
                        mFormSPO2.LabelSPO2FingerOffText = "手指脱落";
                    }
                    else
                    {
                        mFormSPO2.LabelSPO2FingerOffForeColor = Color.Black;
                        mFormSPO2.LabelSPO2FingerOffText = "手指连接";
                    }
                    if (sensorLead == 0x01)
                    {
                        mFormSPO2.LabelSPO2PrbOffForeColor = Color.Red;
                        mFormSPO2.LabelSPO2PrbOffText = "探头脱落";
                    }
                    else
                    {
                        mFormSPO2.LabelSPO2PrbOffForeColor = Color.Black;
                        mFormSPO2.LabelSPO2PrbOffText = "探头连接";
                    }

                    if (mDisplayModeFlag)                //演示模式，将血氧的各项值显示标准值
                    {
                        mFormSPO2.LabelSPO2PRText = "75";
                        mFormSPO2.LabelSPO2DataText = "96";
                        mFormSPO2.LabelSPO2PrbOffForeColor = Color.Black;
                        mFormSPO2.LabelSPO2PrbOffText = "手指连接";
                    }
                    break;

                case 0x03:                  //脉率、血氧饱和度
                    pulseRateHByte = packAfterUnpack[3];
                    pulseRateLByte = packAfterUnpack[4];
                    pulseRate = (ushort)(pulseRate | pulseRateHByte);
                    pulseRate = (ushort)(pulseRate << 8);
                    pulseRate = (ushort)(pulseRate | pulseRateLByte);
                    if (pulseRate >= 300)
                    {
                        pulseRate = 0;      //脉率值最大不超过300，超过300则视为无效值，给其赋0即可
                    }

                    mFormSPO2.LabelSPO2PRText = pulseRate.ToString();           //显示脉率

                    spo2Value = packAfterUnpack[5];

                    if (0 < spo2Value && 100 > spo2Value)
                    {
                        mFormSPO2.LabelSPO2DataText = spo2Value.ToString();     //显示血氧饱和度
                    }
                    else
                    {
                        mFormSPO2.LabelSPO2DataText = "--";
                    }
                    break;
            }
        }

        /***********************************************************************************************
        * 方法名称：drawRespWave
        * 功能说明: 绘制Resp波形
        * 注    意:
        ***********************************************************************************************/
        private void drawRespWave()
        {
            int iCnt = mRespWaveList.Count - 1;          //获取list列表中存储的所有呼吸数据
            if (iCnt < 2)                                //如果数据少于两个就不绘制波形
            {
                return;
            }
            //通过窗口句柄创建一个Graphics对象,用于后面的绘图操作
            Graphics graphics = Graphics.FromHwnd(mFormResp.DataGridViewResp.Handle);

            Brush br = new SolidBrush(Color.White);      //给绘制波形区域刷成白色 

            //当要画的点数大于画布剩余长度时，就要把画布的剩余长度画完，然后在起始处将剩余的数据画完
            if (iCnt > WAVE_X_SIZE - mRespXStep)
            {
                //指定的位置(左上角x坐标和y坐标)和大小(width和height)
                Rectangle rct = new Rectangle((int)mRespXStep, 3, (int)(WAVE_X_SIZE - mRespXStep), WAVE_Y_SIZE);

                //用指定画笔填充指定区域
                graphics.FillRectangle(br, rct);
                rct = new Rectangle(0, 3, 10 + (int)(iCnt + mRespXStep - WAVE_X_SIZE), WAVE_Y_SIZE);
                graphics.FillRectangle(br, rct);
            }
            else
            {
                int xEnd = (int)(iCnt + 10);
                if (xEnd > WAVE_X_SIZE - mRespXStep)
                {
                    xEnd = (int)(WAVE_X_SIZE - mRespXStep);
                }
                Rectangle rct = new Rectangle((int)mRespXStep, 3, xEnd, WAVE_Y_SIZE);
                graphics.FillRectangle(br, rct);
            }

            for (int i = 0; i < iCnt; i++)
            {
                //每一个点画一次波形，呼吸数据压缩1/2
                graphics.DrawLine(mRespWavePen, mRespXStep - 1, mRespWaveList[i] / 2,
                    mRespXStep, mRespWaveList[i + 1] / 2);

                //F:float型，每次移动1
                mRespXStep += 1F;

                //绘制完整个长度后回到起始点接着画
                if (mRespXStep >= WAVE_X_SIZE)
                {
                    mRespXStep = 0;
                }
            }
            //绘制完之后把已经绘制过的数据移除
            mRespWaveList.RemoveRange(0, iCnt);
        }

        /***********************************************************************************************
        * 方法名称：drawSPO2Wave
        * 功能说明: 绘制Spo2波形
        * 注    意:
        ***********************************************************************************************/
        private void drawSPO2Wave()
        {
            int iCnt = mSPO2WaveList.Count - 1;      //获取list列表中存储的所有血氧波形数据
            if (iCnt < 2)                            //如果数据少于两个就不绘制波形
            {
                return;
            }

            //通过窗口句柄创建一个Graphics对象,用于后面的绘图操作
            Graphics graphics = Graphics.FromHwnd(mFormSPO2.DataGridViewSPO2.Handle);

            Brush br = new SolidBrush(Color.White);  //给绘制波形区域刷成白色 

            //当要画的点数大于画布剩余长度时，就要把画布的剩余长度画完，然后在起始处将剩余的数据画完
            if (iCnt > WAVE_X_SIZE - mSPO2XStep)
            {
                Rectangle rct = new Rectangle((int)mSPO2XStep, 3, (int)(WAVE_X_SIZE - mSPO2XStep), WAVE_Y_SIZE);
                graphics.FillRectangle(br, rct);
                rct = new Rectangle(0, 3, 10 + (int)(iCnt + mSPO2XStep - WAVE_X_SIZE), WAVE_Y_SIZE);
                graphics.FillRectangle(br, rct);
            }
            else
            {
                int xEnd = (int)(iCnt + 10);
                if (xEnd > WAVE_X_SIZE - mSPO2XStep)
                {
                    xEnd = (int)(WAVE_X_SIZE - mSPO2XStep);
                }

                Rectangle rct = new Rectangle((int)mSPO2XStep, 3, xEnd, WAVE_Y_SIZE);
                graphics.FillRectangle(br, rct);
            }

            for (int i = 0; i < iCnt; i++)
            {
                graphics.DrawLine(mSPO2WavePen, mSPO2XStep - 1, WAVE_Y_SIZE / 2 + 70 - mSPO2WaveList[i] / 3 * 2,
                    mSPO2XStep, WAVE_Y_SIZE / 2 + 70 - mSPO2WaveList[i + 1] / 3 * 2);

                mSPO2XStep += 1F;

                if (mSPO2XStep >= WAVE_X_SIZE)
                {
                    mSPO2XStep = 0;
                }
            }

            mSPO2WaveList.RemoveRange(0, iCnt);
        }

        /***********************************************************************************************
        * 方法名称: serialPort_DataReceived
        * 功能说明: 串口接收到数据时自动触发
        * 注    意:
        ***********************************************************************************************/
        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            byte[] data = new byte[100];
            int len;
            try
            {
                if (serialPort.BytesToRead != 0)
                {
                    //强制类型转换，将(int)类型数据转换为(byte类型数据，不必考虑是否会丢失数据
                    len = serialPort.Read(data, 0, 100);

                    for (int i = 0; i < len; i++)
                    {
                        if (unpackRcvData(data[i]))//处理接收到的数据
                        {
                        }
                    }
                }
            }
            catch
            {
            }
        }
        /***********************************************************************************************
        * 方法名称: unpackRcvData
        * 功能说明: 解包数据，如果解包成功，则根据需要保存解包的数据
        * 参数说明：输入参数data-待解包数据（1个字节），输出参数(1)mPackAfterUnpackList-解包后数据包，
        *           输出参数(2)mPackAfterUnpackArr-解包后数据缓冲二维数组，返回值0-解包不成功，1-解
        *           包成功
        * 注    意:
        ***********************************************************************************************/
        private bool unpackRcvData(byte recData)
        {
            bool findPack;
            int packLen;

            findPack = mPackUnpack.unpackData(recData);                //findPack不为0表示解包成功

            if (findPack)
            {
                mPackAfterUnpackList = mPackUnpack.getUnpackRslt();    //获取解包结果
                packLen = mPackAfterUnpackList.Count;                  //获取包长

                if (mPackAfterUnpackList.Count > 10)
                {
                    MessageBox.Show("长度异常");
                }

                //%PACK_QUEUE_CNT：为了数据序号范围在0到PACK_QUEUE_CNT之间
                int iHead = (mPackHead + 1) % PACK_QUEUE_CNT;
                int iTail;

                lock (mLockObj)
                {
                    iTail = mPackTail;
                }

                if (iHead == iTail)
                {
                    MessageBox.Show("缓冲溢出。");
                }

                //包长减去2，即解包后已经没有了数据头和校验和，但是ID还在
                if (packLen > 2)
                {
                    for (int i = 0; i < packLen - 2; i++)
                    {
                        mPackAfterUnpackArr[iHead][i] = mPackAfterUnpackList[i];
                    }
                }
                else if (packLen == 2)
                {
                    mPackAfterUnpackArr[iHead][0] = mPackAfterUnpackList[0];
                }

                lock (mLockObj)
                {
                    mPackHead = (mPackHead + 1) % PACK_QUEUE_CNT;  //添加数据，mPackHead加一
                    if (mPackTail == -1)
                    {
                        mPackTail = 0;
                    }
                }

                //保存解包数据
                if (mStoreSetting.bSaveUART)
                {
                    string packStr = "";

                    if (packLen > 2)
                    {
                        for (int j = 0; j < packLen - 2; j++)
                        {
                            packStr = packStr + mPackAfterUnpackList[j].ToString() + ",";
                        }
                    }
                    else if (packLen == 2)
                    {
                        packStr = mPackAfterUnpackList[0].ToString();
                    }

                    packStr.TrimEnd(' ');
                    mSWUART.WriteLine(packStr);
                }
            }
            return findPack;
        }


        /***********************************************************************************************
        * 方法名称: buttonToNIBP_Click
        * 功能说明: 点击血压功能按钮时出发 显示血压界面
        * 参数说明：
        * 注    意:
        ***********************************************************************************************/
        private void buttonToNIBP_Click(object sender, EventArgs e)
        {
            mFormNIBP.StartPosition = FormStartPosition.CenterParent;
            mFormNIBP.ShowDialog();
        }

        /***********************************************************************************************
        * 方法名称: buttonToResp_Click
        * 功能说明: 点击呼吸功能按钮时出发 显示呼吸界面
        * 参数说明：
        * 注    意:
        ***********************************************************************************************/
        private void buttonToResp_Click(object sender, EventArgs e)
        {
            mFormResp.StartPosition = FormStartPosition.CenterParent;
            mFormResp.ShowDialog();
        }

        /***********************************************************************************************
        * 方法名称: buttonToSPO2_Click
        * 功能说明: 点击血氧功能按钮时出发 显示血压界面
        * 参数说明：
        * 注    意:
        ***********************************************************************************************/
        private void buttonToSPO2_Click(object sender, EventArgs e)
        {
            mFormSPO2.StartPosition = FormStartPosition.CenterParent;
            mFormSPO2.ShowDialog();
        }

        /***********************************************************************************************
        * 方法名称: timeToolStripMenuItemAbout_Click
        * 功能说明: 点击有关菜单 按钮时出发 显示作者相关信息
        * 参数说明：
        * 注    意:
        ***********************************************************************************************/
        private void timeToolStripMenuItemAbout_Click(object sender, EventArgs e)
        {
            FormAbout aboutForm = new FormAbout();
            aboutForm.StartPosition = FormStartPosition.CenterParent;
            aboutForm.ShowDialog();
        }

        /***********************************************************************************************
        * 方法名称: ToolStripMenuItemExit_Click
        * 功能说明: 点击退出菜单栏 此时存储响应数据 并退出MainForm界面
        * 参数说明：
        * 注    意:
        ***********************************************************************************************/
        private void ToolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /***********************************************************************************************
        * 方法名称: ToolStripMenuItemStoreSetting_Click
        * 功能说明: 点击数据存储菜单栏时触发 显示数据存储设置界面
        * 参数说明：
        * 注    意:
        ***********************************************************************************************/
        private void ToolStripMenuItemStoreSetting_Click(object sender, EventArgs e)
        {
            FormStoreSetting storeSettingForm = new FormStoreSetting();       //实例化数据存储类界面变量 
            storeSettingForm.StartPosition = FormStartPosition.CenterParent;

            //数据存储界面4个复选框设置为与数据存储配置文件的设置一致
            storeSettingForm.saveNIBPdata = mStoreSetting.bSaveNIBP;
            storeSettingForm.saveRespdata = mStoreSetting.bSaveResp;
            storeSettingForm.saveSPO2data = mStoreSetting.bSaveSPO2;
            storeSettingForm.saveUARTdata = mStoreSetting.bSaveUART;
            //文件存储路径的内容设置为与数据存储配置文件的设置一致
            storeSettingForm.saveFolder = mStoreSetting.saveFolder;

            //如果FormStoreData窗口单击了“确定”，执行如下代码
            if (storeSettingForm.ShowDialog() == DialogResult.OK)
            {
                //将数据存储界面中4个复选框的选中情况赋值给数据存储配置文件类变量
                mStoreSetting.bSaveNIBP = storeSettingForm.saveNIBPdata;
                mStoreSetting.bSaveResp = storeSettingForm.saveRespdata;
                mStoreSetting.bSaveSPO2 = storeSettingForm.saveSPO2data;
                mStoreSetting.bSaveUART = storeSettingForm.saveUARTdata;
                //将文件存储路径的内容赋值给数据存储配置文件类变量
                mStoreSetting.saveFolder = storeSettingForm.saveFolder;

                //将更新的4个复选框的选中情况和文件存储路径保存到配置文件
                mStoreSetting.saveToFile();
            }
        }

        /***********************************************************************************************
        * 方法名称: setDataSaveWriter
        * 功能说明: 设置文件读取的streamWriter，打开/关闭串口时调用此方法
        * 参数说明：输入参数startSave-串口状态
        * 注    意:
        ***********************************************************************************************/
        private void setDataSaveWriter(bool startSave)
        {
            if (startSave)            //串口打开才能进行存储，串口关闭则不会进行数据存储
            {
                //系统的当前时间，在存储数据文件名加上时间可以方便分清楚不同的文件
                string currentTime = DateTime.Now.ToString("yyyyMMddhhmmss");

                //血压
                if (mStoreSetting.bSaveNIBP && (mNIBPDirectory == null))
                {
                    //设置文件名及保存位置
                    mNIBPDirectory = new StreamWriter(mStoreSetting.saveFolder + @"\" + currentTime + "-NIBP" + ".csv");
                }
                //呼吸
                if (mStoreSetting.bSaveResp && (mRespDirectory == null))
                {
                    //设置文件名及保存位置
                    mRespDirectory = new StreamWriter(mStoreSetting.saveFolder + @"\" + currentTime + "-RESP" + ".csv");
                }

                //血氧
                if (mStoreSetting.bSaveSPO2 && (mSPO2Directory == null))
                {
                    //设置文件保存位置
                    mSPO2Directory = new StreamWriter(mStoreSetting.saveFolder + @"\" + currentTime + "-SPO2" + ".csv");
                }

                //解包后的数据，包括心电、血氧、呼吸、体温、血压
                if (mStoreSetting.bSaveUART && (null == mSWUART))
                {
                    //设置文件名及保存位置
                    mSWUART = new StreamWriter(mStoreSetting.saveFolder + @"\" + currentTime + "Uart.csv");
                }
            }
            else                     //串口关闭,最大/最小的数据,并清理内存
            {
                //血压
                if (mNIBPDirectory != null)
                {
                    mNIBPDirectory.WriteLine("Max:" + mMaxNIBPData + "," + "Min:" + mMinNIBPData);
                    try
                    {
                        mNIBPDirectory.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    mNIBPDirectory.Dispose();
                    mNIBPDirectory = null;
                }

                //呼吸
                if (mRespDirectory != null)
                {
                    mRespDirectory.WriteLine("Max:" + mMaxRespWave + "," + "Min:" + mMinRespWave);
                    try
                    {
                        mRespDirectory.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    mRespDirectory.Dispose();
                    mRespDirectory = null;
                }

                //血氧
                if (mSPO2Directory != null)
                {
                    mSPO2Directory.WriteLine("Max:" + mMaxSPO2Wave + "," + "Min:" + mMinSPO2Wave);
                    try
                    {
                        mSPO2Directory.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    mSPO2Directory.Dispose();
                    mSPO2Directory = null;
                }

                //解包后的数据，包括心电、血氧、呼吸、体温、血压
                if (mSWUART != null)
                {
                    mSWUART.Close();
                    mSWUART.Dispose();
                    mSWUART = null;
                }
            }
        }

        /***********************************************************************************************
        * 方法名称: loadUartFile
        * 功能说明: 读取保存的串口数据
        * 参数说明：输入参数fileName-回放或演示的数据文件名
        * 注    意: 
        ***********************************************************************************************/
        private void loadUARTFile(string fileName)
        {
            if ((fileName.Equals("")) || (!File.Exists(fileName)))
            {
                return;
            }

            StreamReader fileReader = new StreamReader(fileName);
            mUARTLoadDataList.Clear();
            string strLine = fileReader.ReadLine();               //读取一行数据
            while (strLine != null)
            {
                if (strLine.Length > 0)
                {
                    strLine = strLine.Replace(',', ' ');          //将csv文件的逗号替换为空格
                    mUARTLoadDataList.Add(strLine);               //mUARTLoadDataList：存储的是一行行的数据
                }
                strLine = fileReader.ReadLine();
            }
            fileReader.Close();
        }

        /***********************************************************************************************
        * 方法名称: procLoadDataThread
        * 功能说明: 处理加载数据线程，每一类数据定义各自的演示速度
        * 注    意: 
        ***********************************************************************************************/
        private void procLoadDataThread()
        {
            int iDataIndex = 0;

            while (mThreadStartFlag)
            {
                if (mUARTLoadDataList.Count > iDataIndex)
                {
                    //该字符串为一帧原始指令，以空格分开，将一行行的数据赋给strData
                    string strData = mUARTLoadDataList[iDataIndex];

                    string[] dataArr = strData.Split(' ');      //将上面一行行的数据一个个分开来，以空格分开

                    int iHead = (mPackHead + 1) % PACK_QUEUE_CNT;
                    int iTail;

                    lock (mLockObj)
                    {
                        iTail = mPackTail;
                    }

                    if (iHead == iTail)
                    {
                        MessageBox.Show("缓冲溢出。");
                    }

                    for (int i = 0; i < dataArr.Length; i++)
                    {
                        if (!dataArr[i].Equals(""))
                        {
                            try
                            {
                                //int.Parse：转换为整型
                                mPackAfterUnpackArr[iHead][i] = (byte)int.Parse(dataArr[i]);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }

                    lock (mLockObj)
                    {
                        mPackHead = (mPackHead + 1) % PACK_QUEUE_CNT;
                        if (mPackTail == -1)
                        {
                            mPackTail = 0;
                        }
                    }

                    iDataIndex++;
                }
                else
                {
                    if (mDisplayModeFlag)      //演示模式，当演示数据读完时再从头开始读取数据
                    {
                        iDataIndex = 0;
                    }
                    else                       //不是演示模式，读完数据就停止画波形和显示数值
                    {
                        break;
                    }
                }

                Thread.Sleep(2);               //间隔2ms发一帧需要添加命名空间
            }
        }

        /***********************************************************************************************
        * 方法名称: switchMode
        * 功能说明: 模式设置界面事件触发时调用的方法
        * 注    意: 
        ***********************************************************************************************/
        private void switchMode(bool isRealMode, bool isLoadMode, bool isDisplayMode)
        {
            mIsRealMode = isRealMode;
            mIsLoadMode = isLoadMode;
            mIsDisplayMode = isDisplayMode;

            if (mIsRealMode)                         //监护模式
            {
                mFormNIBP.ToolStripLabelNIBPModeSwitchText = "模式：监护";
                mFormResp.ToolStripLabelRespModeSwitchText = "模式：监护";
                mFormSPO2.ToolStripLabelSPO2ModeSwitchText = "模式：监护";

                //关闭演示线程
                mThreadStartFlag = false;
                mDisplayModeFlag = false;

                if (null != mProcLoadDataTask)
                {
                    mProcLoadDataTask.Wait();
                    mProcLoadDataTask = null;
                }

                //打开串口读取
                setUARTState(true);
            }
            else if (mIsLoadMode)                    //回放模式
            {
                string currentTime = DateTime.Now.ToString("yyyyMMddhhmmss");

                mFormNIBP.ToolStripLabelNIBPModeSwitchText = "模式：回放";
                mFormResp.ToolStripLabelRespModeSwitchText = "模式：回放";
                mFormSPO2.ToolStripLabelSPO2ModeSwitchText = "模式：回放";


                mThreadStartFlag = false;            //停止演示线程，加载完数据再打开
                mDisplayModeFlag = false;

                setUARTState(false);                 //关闭串口读取

                if (null != mProcLoadDataTask)
                {
                    mProcLoadDataTask.Wait();
                    mProcLoadDataTask = null;
                }

                mUARTFile = mFormModeSwitch.UARTFileName;

                loadUARTFile(mUARTFile);             //加载文件数据

                //打开演示线程
                mThreadStartFlag = true;
                mProcLoadDataTask = new Task(procLoadDataThread);
                mProcLoadDataTask.Start();
            }
            else                                     //演示模式                   
            {
                mFormNIBP.ToolStripLabelNIBPModeSwitchText = "模式：演示";
                mFormResp.ToolStripLabelRespModeSwitchText = "模式：演示";
                mFormSPO2.ToolStripLabelSPO2ModeSwitchText = "模式：演示";

                mThreadStartFlag = false;            //停止演示线程，加载完数据在打开
                mDisplayModeFlag = true;

                setUARTState(false);                 //关闭串口读取

                if (null != mProcLoadDataTask)
                {
                    mProcLoadDataTask.Wait();
                    mProcLoadDataTask = null;
                }

                mUARTFile = mFormModeSwitch.UARTFileName;
                loadUARTFile(mUARTFile);

                //打开演示线程
                mThreadStartFlag = true;
                mProcLoadDataTask = new Task(procLoadDataThread);
                mProcLoadDataTask.Start();
            }
        }
    }
}

