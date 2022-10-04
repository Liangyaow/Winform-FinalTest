﻿using System;
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
    public partial class FormResp : Form
    {
        private SendData mSendData;                  //声明串口,用于发送命令给从机（单片机）
        private string mRespGain;                  //呼吸增益
        private FormModeSwitch mFormModeSwitch;

        public FormResp(SendData sendData, string gain, FormModeSwitch formModeSwitch)
        {
            InitializeComponent();
            //将主界面的的参数传到设置界面
            mSendData = sendData;
            mRespGain = gain;
            mFormModeSwitch = formModeSwitch;
        }

        private void RespForm_Load(object sender, EventArgs e)
        {
            comboBoxRespGainSet.Text = mRespGain;         //窗口加载时显示主界面传来的呼吸增益值
        }

        //实现MainForm对RespForm的修改
        public string LabelRespRRText
        {
            get { return labelRespRR.Text; }
            set { labelRespRR.Text = value; }
        }

        public DataGridView DataGridViewResp
        {
            get { return dataGridViewResp; }
            set { dataGridViewResp = value; }
        }

        /***********************************************************************************************
        * 方法名称: buttonRespSetOK_Click 
        * 功能说明: 确定按钮按下时
        * 注    意: 
        ***********************************************************************************************/
        private void buttonRespSetOK_Click(object sender, EventArgs e)
        {
            int respGain = (byte)comboBoxRespGainSet.SelectedIndex;    //获取下拉列表呼吸增益选项
            if (respGain < 0)
            {
                return;
            }

            if (mRespGain != comboBoxRespGainSet.Text)    //增益值改变，需要向从机发送命令
            {
                List<byte> dataLst = new List<byte>();
                byte data = (byte)(respGain);             //增益设置：0-*0.25；1-*0.5；2-*1；3-*2；4-*4
                dataLst.Add(0x80);                        //二级ID
                dataLst.Add(data);                        //呼吸增益

                if (!mSendData.mComPort.IsOpen)           //串口没有打开，不能发送命令包
                {
                    MessageBox.Show("串口未打开，请先打开串口");
                }
                else
                {
                    mSendData.sendCmdToMcu(dataLst, 0x11); //将更改后的呼吸增益打包发送给MCU，0x11-呼吸命令的模块ID
                }
            }
            this.Close();
        }

        private void toolStripLabelRespModeSwitch_Click(object sender, EventArgs e)
        {
            mFormModeSwitch.StartPosition = FormStartPosition.CenterParent;
            mFormModeSwitch.ShowDialog();
        }

        /***********************************************************************************************
        * 方法名称: buttonRespSetCancel_Click 
        * 功能说明: 取消按钮按下时
        * 注    意: 
        ***********************************************************************************************/
        private void buttonRespSetCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
