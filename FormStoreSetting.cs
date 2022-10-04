
/******************************************************************************************************
* 模块名称: FormStoreData.cs
* 摘    要: 数据存储模块
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
    * 类 名 称: FormStoreData 
    * 功能说明: 数据存储类
    * 注    意: 
    ***************************************************************************************************/
    public partial class FormStoreSetting : Form
    {
        public bool saveUARTdata
        {
            get { return checkBoxUARTData.Checked; }
            set { checkBoxUARTData.Checked = value; }
        }

        public bool saveNIBPdata
        {
            get { return checkBoxNIBPData.Checked; }
            set { checkBoxNIBPData.Checked = value; }
        }

        public bool saveRespdata
        {
            get { return checkBoxRespWave.Checked; }
            set { checkBoxRespWave.Checked = value; }
        }

        public bool saveSPO2data
        {
            get { return checkBoxSPO2Wave.Checked; }
            set { checkBoxSPO2Wave.Checked = value; }
        }

        public string saveFolder
        {
            get { return tbxSaveFolder.Text; }
            set { tbxSaveFolder.Text = value; }
        }

        /*********************************************************************************************
        * 方法名称: FormStoreData
        * 功能说明: 构造方法
        * 注    意:
        *********************************************************************************************/
        public FormStoreSetting()
        {
            InitializeComponent();
        }

        /***********************************************************************************************
        * 方法名称: tbxSaveFolder_Click 
        * 功能说明: 点击存储路径编辑框时执行方法
        * 注    意: 
        ***********************************************************************************************/
        private void tbxSaveFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tbxSaveFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        /***********************************************************************************************
        * 方法名称: buttonStoreDataCancel_Click 
        * 功能说明: 取消按钮按下时
        * 注    意: 
        ***********************************************************************************************/
        private void buttonStoreDataCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
