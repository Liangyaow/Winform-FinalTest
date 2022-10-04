/*******************************************************************************************************
* 模块名称: FormUARTSet.cs
* 摘    要: 串口设置界面类
* 当前版本: 1.0.0
* 作    者: Leyutek(COPYRIGHT 2018 - 2021 Leyutek. All rights reserved.)
* 完成日期: 2021年01月10日
* 内    容: 
* 注    意: 
*******************************************************************************************************
* 取代版本: 
* 作    者: 
* 完成日期: 
* 修改内容: 
* 修改文件: 
*******************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FinalTest
{
    /***************************************************************************************************
    * 名    称: StructUARTInfo（结构体）
    * 功能说明: 存储串口号信息结构体
    * 注    意: 
    ***************************************************************************************************/
    public struct StructUARTInfo
    {
        public List<string> portNumItem;            //串口号列表
        public string portNum;                      //串口号
        public string baudRate;                     //波特率
        public string dataBits;                     //数据位
        public string stopBits;                     //停止位
        public string parity;                       //校验和
        public bool isOpened;                     //串口是否打开标志位
    }

    /* 委托是方法的抽象，它存储的就是一系列具有相同签名和返回值类型的方法的地址。
     * 调用委托的时候，委托包含的所有方法将被执行
     * 委托类型必须在被用来创建变量以及类型对象之前声明。
     * 委托类型声明：1、以deleagate关键字开头；2、返回类型+委托类型名+参数列表
     * */
    public delegate void openUARTHandler(StructUARTInfo info);   //定义openUARTHandler委托

    /***************************************************************************************************
    * 类 名 称: FormUARTSet 
    * 功能说明: 串口设置界面类
    * 注    意: 
    ***************************************************************************************************/
    public partial class FormUARTSetting : Form
    {
        //实例化结构体
        private StructUARTInfo mUARTInfo = new StructUARTInfo();

        //声明委托openUARTHandler的变量
        public event openUARTHandler openUARTEvent;

        /***********************************************************************************************
        * 方法名称: FormUARTSet 
        * 功能说明: 构造方法
        * 参数说明：输入参数info-串口信息结构体
        * 注    意: 
        ***********************************************************************************************/
        public FormUARTSetting(StructUARTInfo info)
        {
            InitializeComponent();

            //将MainForm中的串口参数传递到FormUARTSet中的m_structUARTInfo
            mUARTInfo.portNumItem = info.portNumItem;   //串口号Item
            mUARTInfo.portNum = info.portNum;          //串口号
            mUARTInfo.baudRate = info.baudRate;         //波特率
            mUARTInfo.dataBits = info.dataBits;         //数据位
            mUARTInfo.stopBits = info.stopBits;         //停止位
            mUARTInfo.parity = info.parity;           //校验位
            mUARTInfo.isOpened = info.isOpened;         //串口状态

            //将mUARTInfo的串口号Item(即MainForm中的参数)显示在comboBox中，实现同步
            for (int i = 0; i < mUARTInfo.portNumItem.Count; i++)
            {
                comboBoxUARTPortNum.Items.Add(mUARTInfo.portNumItem[i]);
            }

            //将主窗口传过来的串口配置信息显示在combobox控件上
            comboBoxUARTPortNum.Text = mUARTInfo.portNum;
            comboBoxUARTBaudRate.Text = mUARTInfo.baudRate;
            comboBoxUARTDataBits.Text = mUARTInfo.dataBits;
            comboBoxUARTStopBits.Text = mUARTInfo.stopBits;
            comboBoxUARTParity.Text = mUARTInfo.parity;

            //使子Form的串口状态与MainForm的串口状态同步
            if (mUARTInfo.isOpened)
            {
                buttonUARTSetOpen.Text = "关闭串口";
            }
            else
            {
                buttonUARTSetOpen.Text = "打开串口";
            }
        }

        /**********************************************************************************************
        * 方法名称: buttonUARTSetOpen_Click 
        * 功能说明: “打开串口”按钮按下时执行
        * 注    意: 
        ***********************************************************************************************/
        private void buttonUARTSetOpen_Click(object sender, EventArgs e)
        {
            //将控件选中的信息存入结构体中
            mUARTInfo.portNum = comboBoxUARTPortNum.Text;      //串口号
            mUARTInfo.baudRate = comboBoxUARTBaudRate.Text;     //波特率
            mUARTInfo.dataBits = comboBoxUARTDataBits.Text;     //数据位
            mUARTInfo.stopBits = comboBoxUARTStopBits.Text;     //停止位
            mUARTInfo.parity = comboBoxUARTParity.Text;       //校验位

            openUARTEvent(mUARTInfo);                           //委托调用

            this.Close();                                       //关闭串口设置界面
        }
    }
}
