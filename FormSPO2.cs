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
    public delegate void spo2SetHandler(bool isRealMode, bool isLoadMode, bool isDisplayMode);

    public partial class FormSPO2 : Form
    {
        private SendData mSendData;         //声明串口,用于发送命令给从机（单片机）
        private string mSPO2Sens;         //血氧灵敏度

        //声明委托spo2SetHandler的事件sendSPO2ModeEvent
        public event spo2SetHandler sendSPO2ModeEvent;

        public FormSPO2(SendData sendData, string sensor)
        {
            InitializeComponent();
            mSendData = sendData;
            mSPO2Sens = sensor;
        }

        /***********************************************************************************************
        * 方法名称: FormSPO2Set_Load 
        * 功能说明: 血氧设置界面加载时执行方法
        * 注    意: 
        ***********************************************************************************************/
        private void SPO2Form_Load(object sender, EventArgs e)
        {
            comboBoxSPO2Sens.Text = mSPO2Sens;       //窗口加载时显示主界面传来的血氧灵敏度值
        }

        //实现MainForm对SPO2Form的修改
        public Color LabelSPO2FingerOffForeColor
        {
            get { return labelSPO2FingerOff.ForeColor; }
            set { labelSPO2FingerOff.ForeColor = value; }
        }

        public string LabelSPO2FingerOffText
        {
            get { return labelSPO2FingerOff.Text; }
            set { labelSPO2FingerOff.Text = value; }
        }

        public Color LabelSPO2PrbOffForeColor
        {
            get { return labelSPO2PrbOff.ForeColor; }
            set { labelSPO2PrbOff.ForeColor = value; }
        }

        public string LabelSPO2PrbOffText
        {
            get { return labelSPO2PrbOff.Text; }
            set { labelSPO2PrbOff.Text = value; }
        }

        public string LabelSPO2PRText
        {
            get { return labelSPO2PR.Text; }
            set { labelSPO2PR.Text = value; }
        }

        public string LabelSPO2DataText
        {
            get { return labelSPO2Data.Text; }
            set { labelSPO2Data.Text = value; }
        }
        public DataGridView DataGridViewSPO2
        {
            get { return dataGridViewSPO2; }
            set { dataGridViewSPO2 = value; }
        }

        /***********************************************************************************************
        * 方法名称: buttonSPO2SetOK_Click 
        * 功能说明: 确定按钮按下
        * 注    意: 
        ***********************************************************************************************/
        private void buttonSPO2SetOK_Click(object sender, EventArgs e)
        {
            int spo2Sens = (byte)comboBoxSPO2Sens.SelectedIndex;   //获取下拉列表血氧灵敏度选项
            if (spo2Sens < 0)
            {
                return;
            }

            if (comboBoxSPO2Sens.Text != mSPO2Sens)                //血氧灵敏度值改变，需要向从机发送命令
            {
                List<byte> dataLst = new List<byte>();
                byte data = (byte)(spo2Sens + 1);                  //计算灵敏度：1-高；2-中；3-低
                dataLst.Add(0x80);                                 //二级ID
                dataLst.Add(data);                                 //血氧灵敏度

                if (!mSendData.mComPort.IsOpen)                    //串口没有打开，不能发送命令包
                {
                    MessageBox.Show("串口未打开，请先打开串口");
                }
                else
                {
                    mSendData.sendCmdToMcu(dataLst, 0x13);  //将更改后的血氧灵敏度值打包发送给MCU，0x13-血氧命令的模块ID 
                }
            }
            this.Close();

        }
        /***********************************************************************************************
        * 方法名称: buttonSPO2SetCancel_Click 
        * 功能说明: 取消按钮按下
        * 注    意: 
        ***********************************************************************************************/
        private void buttonSPO2SetCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
