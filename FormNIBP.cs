using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalTest
{
    //定义nibpSetDelegate委托
    public delegate void nibpSetDelegate(Byte[] arr, int len);
    //定义nibpSetDelegate委托
    public delegate void nibpSetHandler(bool isRealMode, bool isLoadMode, bool isDisplayMode);

    public partial class FormNIBP : Form
    {
        private SendData mSendData;                    //声明串口,用于发送命令给从机（单片机）
        private string mMeasMode;                    //NIBP测量模式

        PackUnpack mPackUnpack = new PackUnpack();     //实例化打包解包类

        //声明委托nibpSetDelegate的事件sendNIBPSetCmdToMCU，用于发送命令至单片机
        public event nibpSetDelegate sendNIBPSetCmdToMCU;
        //声明委托nibpSetHandler的事件sendNIBPModeEvent
        public event nibpSetHandler sendNIBPModeEvent;

        public FormNIBP(SendData sendData, string measMode)
        {
            InitializeComponent();

            //将主界面的的参数传到设置界面
            mSendData = sendData;
            mMeasMode = measMode;
        }

        private void NIBPForm_Load(object sender, EventArgs e)
        {
            comboBoxNIBPMeasMode.Text = mMeasMode;
        }

        //实现MainForm对NIBPForm的修改
        public string LabelNIBPCufPreText
        {
            get { return labelNIBPCufPre.Text; }
            set { labelNIBPCufPre.Text = value; }
        }

        public string LabelNIBPSysText
        {
            get { return labelNIBPSys.Text; }
            set { labelNIBPSys.Text = value; }
        }

        public string LabelNIBPDiaText
        {
            get { return labelNIBPDia.Text; }
            set { labelNIBPDia.Text = value; }
        }

        public string LabelNIBPMeanText
        {
            get { return labelNIBPMean.Text; }
            set { labelNIBPMean.Text = value; }
        }
        public string LabelNIBPPRText
        {
            get { return labelNIBPPR.Text; }
            set { labelNIBPPR.Text = value; }
        }
        public string LabelNIBPMeasModeText
        {
            get { return labelNIBPMeasMode.Text; }
            set { labelNIBPMeasMode.Text = value; }
        }


        /***********************************************************************************************
        * 方法名称: comboBoxNIBPMeasMode_SelectedIndexChanged 
        * 功能说明: 测量模式与自动测量周期更改后执行
        * 注    意: 
        ***********************************************************************************************/
        private void comboBoxNIBPMeasMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            int measMode = (byte)comboBoxNIBPMeasMode.SelectedIndex;      //获取combobox的选项
            if (measMode < 0)
            {
                return;
            }

            labelNIBPMeasMode.Text = comboBoxNIBPMeasMode.Text;

            List<byte> dataLst = new List<byte>();
            byte data = (byte)(measMode);
            dataLst.Add(0x82);                                //二级ID
            dataLst.Add(data);                                //NIBP测量模式

            if (!mSendData.mComPort.IsOpen)                   //串口没有打开
            {
                comboBoxNIBPMeasMode.Text = "手动";
            }
            else
            {
                //将更改后的NIBP测量模式打包发送给MCU，0x14-血压命令的模块ID
                mSendData.sendCmdToMcu(dataLst, 0x14);
            }
        }

        /***********************************************************************************************
       * 方法名称: buttonNIBPStartMeas_Click 
       * 功能说明: 开始测量按钮按下
       * 注    意: 
       ***********************************************************************************************/
        private void buttonNIBPStartMeas_Click(object sender, EventArgs e)
        {
            Byte[] arrCmd = new Byte[] { 0x14, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }; //去掉数据头和校验和
            List<byte> mPackData = new List<byte>(arrCmd);                                 //数组转list
            mPackUnpack.packData(ref mPackData);                                           //打包
            arrCmd = mPackData.ToArray();                                                  //list转数组

            if (!mSendData.mComPort.IsOpen)                                                //串口没有打开
            {
                MessageBox.Show("串口没有打开", "提示");
            }
            else
            {
                sendNIBPSetCmdToMCU(arrCmd, 10);
            }
        }

        /***********************************************************************************************
       * 类 名 称: buttonNIBPStopMeas_Click 
       * 功能说明: 停止测量按钮按下
       * 注    意: 
       ***********************************************************************************************/
        private void buttonNIBPStopMeas_Click(object sender, EventArgs e)
        {
            Byte[] arrCmd = new Byte[] { 0x14, 0x81, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };    //去掉数据头和校验和
            List<byte> mPackData = new List<byte>(arrCmd);                                    //数组转list
            mPackUnpack.packData(ref mPackData);                                              //打包
            arrCmd = mPackData.ToArray();                                                     //list转数组
            sendNIBPSetCmdToMCU(arrCmd, 10);     //通过委托发送数据给单片机，同方法sendCmdToMCU()
        }

        /***********************************************************************************************
        * 方法名称: buttonNIBPRst_Click 
        * 功能说明: 模块复位按钮按下
        * 注    意: 
        ***********************************************************************************************/
        private void buttonNIBPRst_Click(object sender, EventArgs e)
        {
            Byte[] arrCmd = new Byte[] { 0x14, 0x84, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };    //去掉数据头和校验和
            List<byte> mPackData = new List<byte>(arrCmd);                                    //数组转list
            mPackUnpack.packData(ref mPackData);                                              //打包
            arrCmd = mPackData.ToArray();                                                     //list转数组
            sendNIBPSetCmdToMCU(arrCmd, 10);     //通过委托发送数据给单片机，同方法sendCmdToMCU()
        }

        /***********************************************************************************************
        * 方法名称: buttonNIBPCheckLeak_Click 
        * 功能说明: 漏气检测按钮按下
        * 注    意: 
        ***********************************************************************************************/
        private void buttonNIBPCheckLeak_Click(object sender, EventArgs e)
        {
            Byte[] arrCmd = new Byte[] { 0x14, 0x85, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };    //去掉数据头和校验和
            List<byte> mPackData = new List<byte>(arrCmd);                                    //数组转list
            mPackUnpack.packData(ref mPackData);                                              //打包
            arrCmd = mPackData.ToArray();                                                     //list转数组
            sendNIBPSetCmdToMCU(arrCmd, 10);     //通过委托发送数据给单片机，同方法sendCmdToMCU()
        }

        /***********************************************************************************************
        * 方法名称: buttonNIBPCalibPressure_Click 
        * 功能说明: 压力校准按钮按下
        * 注    意: 
        ***********************************************************************************************/
        private void buttonNIBPCalibPressure_Click(object sender, EventArgs e)
        {
            Byte[] arrCmd = new Byte[] { 0x14, 0x83, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };    //去掉数据头和校验和
            List<byte> mPackData = new List<byte>(arrCmd);                                    //数组转list
            mPackUnpack.packData(ref mPackData);                                              //打包
            arrCmd = mPackData.ToArray();                                                     //list转数组
            sendNIBPSetCmdToMCU(arrCmd, 10);     //通过委托发送数据给单片机，同方法sendCmdToMCU()
        }

        /***********************************************************************************************
        * 方法名称: buttonNIBPSetOK_Click 
        * 功能说明: 确定按钮按下
        * 注    意: 
        ***********************************************************************************************/
        private void buttonNIBPSetOK_Click(object sender, EventArgs e)
        {
            this.Close();   //关闭界面
        }

        /***********************************************************************************************
        * 方法名称: buttonNIBPSetCancel_Click 
        * 功能说明: 取消按钮按下
        * 注    意: 
        ***********************************************************************************************/
        private void buttonNIBPSetCancel_Click(object sender, EventArgs e)
        {
            this.Close();   //关闭界面
        }

        private void toolStripLabelNIBPModeSwitch_Click(object sender, EventArgs e)
        {
            FormModeSwitch formModeSwitch = new FormModeSwitch("NIBP");
            formModeSwitch.StartPosition = FormStartPosition.CenterParent;
            if (formModeSwitch.ShowDialog() == DialogResult.OK)
            {
                
            }
        }
    }
}
