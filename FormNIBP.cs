using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FinalTest
{
    public partial class FormNIBP : Form
    {
        private SendData mSendData;                   //声明串口,用于发送命令给从机（单片机）
        private string mMeasMode;                    //NIBP测量模式
        private FormModeSwitch mFormModeSwitch;     //模式设置界面
        PackUnpack mPackUnpack = new PackUnpack();     //实例化打包解包类

        /***********************************************************************************************
        * 方法名称: FormNIBP
        * 功能说明: 构造放方法
        * 注    意: 
        ***********************************************************************************************/
        public FormNIBP(SendData sendData, string measMode, FormModeSwitch formModeSwitch)
        {
            InitializeComponent();

            //将主界面的的参数传到设置界面
            mSendData = sendData;
            mMeasMode = measMode;
            mFormModeSwitch = formModeSwitch;

            toolStripLabelNIBPModeSwitch.Text = "模式：监护";
        }

        /***********************************************************************************************
        * 方法名称: NIBPForm_Load 
        * 功能说明:血压设置界面加载时执行方法
        * 注    意: 
        ***********************************************************************************************/
        private void NIBPForm_Load(object sender, EventArgs e)
        {
            comboBoxNIBPMeasMode.Text = mMeasMode;      //窗口加载时显示主界面传来的测量模式
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

        public string ToolStripLabelNIBPModeSwitchText
        {
            get { return toolStripLabelNIBPModeSwitch.Text; }
            set { toolStripLabelNIBPModeSwitch.Text = value; }
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
                //将 更改后的NIBP测量模式 打包发送给MCU，0x14-血压命令的模块ID
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
            List<byte> dataLst = new List<byte>();
            dataLst.Add(0x80);                                                                //二级ID

            if (!mSendData.mComPort.IsOpen)                                                //串口没有打开
            {
                MessageBox.Show("串口没有打开", "提示");
            }
            else
            {
                //将 开始测量 相关的命令包打包发送给MCU，0x14-血压命令的模块ID
                mSendData.sendCmdToMcu(dataLst, 0x14);
            }
        }

        /***********************************************************************************************
        * 类 名 称: buttonNIBPStopMeas_Click 
        * 功能说明: 停止测量按钮按下
        * 注    意: 
        ***********************************************************************************************/
        private void buttonNIBPStopMeas_Click(object sender, EventArgs e)
        {
            List<byte> dataLst = new List<byte>();
            dataLst.Add(0x81);                                                                //二级ID
            if (!mSendData.mComPort.IsOpen)                                                //串口没有打开
            {
                MessageBox.Show("串口没有打开", "提示");
            }
            else
            {
                //将 停止测量 相关的命令包 打包发送给MCU，0x14-血压命令的模块ID
                mSendData.sendCmdToMcu(dataLst, 0x14);
            }
        }

        /***********************************************************************************************
        * 方法名称: buttonNIBPRst_Click 
        * 功能说明: 模块复位按钮按下
        * 注    意: 
        ***********************************************************************************************/
        private void buttonNIBPRst_Click(object sender, EventArgs e)
        {
            List<byte> dataLst = new List<byte>();
            dataLst.Add(0x84);                                                                //二级ID
            if (!mSendData.mComPort.IsOpen)                                                //串口没有打开
            {
                MessageBox.Show("串口没有打开", "提示");
            }
            else
            {
                //将 模复位功能 相关的命令包 打包发送给MCU，0x14-血压命令的模块ID
                mSendData.sendCmdToMcu(dataLst, 0x14);
            }
        }

        /***********************************************************************************************
        * 方法名称: buttonNIBPCheckLeak_Click 
        * 功能说明: 漏气检测按钮按下
        * 注    意: 
        ***********************************************************************************************/
        private void buttonNIBPCheckLeak_Click(object sender, EventArgs e)
        {
            List<byte> dataLst = new List<byte>();
            dataLst.Add(0x85);                                                                //二级ID
            if (!mSendData.mComPort.IsOpen)                                                //串口没有打开
            {
                MessageBox.Show("串口没有打开", "提示");
            }
            else
            {
                //将漏气检测 相关的命令包 打包发送给MCU，0x14-血压命令的模块ID
                mSendData.sendCmdToMcu(dataLst, 0x14);
            }
        }

        /***********************************************************************************************
        * 方法名称: buttonNIBPCalibPressure_Click 
        * 功能说明: 压力校准按钮按下
        * 注    意: 
        ***********************************************************************************************/
        private void buttonNIBPCalibPressure_Click(object sender, EventArgs e)
        {
            List<byte> dataLst = new List<byte>();
            dataLst.Add(0x83);                                                                //二级ID
            if (!mSendData.mComPort.IsOpen)                                                //串口没有打开
            {
                MessageBox.Show("串口没有打开", "提示");
            }
            else
            {
                //将 压力校准的命令包 打包发送给MCU，0x14-血压命令的模块ID
                mSendData.sendCmdToMcu(dataLst, 0x14);
            }
        }

        /***********************************************************************************************
        * 方法名称: toolStripLabelNIBPModeSwitch_Click 
        * 功能说明: 模式设置菜单被点击时触发 此时显示模式设置界面
        * 注    意: 
        ***********************************************************************************************/
        private void toolStripLabelNIBPModeSwitch_Click(object sender, EventArgs e)
        {
            mFormModeSwitch.StartPosition = FormStartPosition.CenterParent;
            mFormModeSwitch.ShowDialog();
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
    }
}
