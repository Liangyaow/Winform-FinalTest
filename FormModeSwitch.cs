/******************************************************************************************************
* 模块名称: FormModeSet.cs
* 摘    要: 监护、演示、回放模式选择
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
******************************************************************************************************/
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
    /***************************************************************************************************
    * 类 名 称: FormModeSet 
    * 功能说明: 模式选择类
    * 注    意: 
    ***************************************************************************************************/
    public partial class FormModeSwitch : Form
    {
        private string mType;

        //类属性：获取演示文件的路径
        public string UARTFileName
        {
            get { return tbxUARTFileName.Text; }
            set { tbxUARTFileName.Text = value; }
        }

        //类属性：选择监护模式
        public bool isRealMode
        {
            get { return rbRealData.Checked; }
            set { rbRealData.Checked = value; }
        }

        //类属性：选择回放模式
        public bool isLoadMode
        {
            get { return rbLoadData.Checked; }
            set { rbLoadData.Checked = value; }
        }

        //类属性：选择演示模式
        public bool isDisplayMode
        {
            get { return rbDisplayData.Checked; }
            set { rbDisplayData.Checked = value; }
        }

        /***********************************************************************************************
        * 方法名称: FormModeSet 
        * 功能说明: 构造方法
        * 注    意: 
        ***********************************************************************************************/
        public FormModeSwitch(string type)
        {
            InitializeComponent();
            mType = type;
        }

        /***********************************************************************************************
        * 方法名称: rbDisplayData_CheckedChanged 
        * 功能说明: 选择演示模式时自动加载演示数据，并在编辑框上显示文件路径及文件名
        * 注    意: 
        ***********************************************************************************************/
        private void rbDisplayData_CheckedChanged(object sender, EventArgs e)
        {
            tbxUARTFileName.Text = "RcvData\\演示数据.csv";                //显示演示数据文件路径
        }

        /***********************************************************************************************
        * 方法名称: btnOpenFile_Click 
        * 功能说明: 按下打开按钮，获得文件路径
        * 注    意: 
        ***********************************************************************************************/
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "打开"+mType+"数据文件";                    //打开的界面的标题
            openFileDialog1.InitialDirectory = Application.StartupPath;    //对话框的初始目录  

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbxUARTFileName.Text = openFileDialog1.FileName;           //显示选中的文件路径
            }
        }
    }
}
