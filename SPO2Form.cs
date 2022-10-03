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
    public partial class SPO2Form : Form
    {
        private SendData mSendData;         //声明串口,用于发送命令给从机（单片机）
        private string mSPO2Sens;         //血氧灵敏度

        public SPO2Form(SendData sendData, string sensor)
        {
            InitializeComponent();
            mSendData = sendData;
            mSPO2Sens = sensor;
        }
    }
}
