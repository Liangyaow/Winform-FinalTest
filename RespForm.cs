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
    public partial class RespForm : Form
    {
        private SendData mSendData;                  //声明串口,用于发送命令给从机（单片机）
        private string mRespGain;                  //呼吸增益

        public RespForm(SendData sendData, string gain)
        {
            InitializeComponent();
            //将主界面的的参数传到设置界面
            mSendData = sendData;
            mRespGain = gain;
        }
    }
}
