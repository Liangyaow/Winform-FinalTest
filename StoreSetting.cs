/******************************************************************************************************
* 模块名称: StoreSetting.cs
* 摘    要: 存储设置串口的配置类，MainForm中引用此类
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

namespace FinalTest
{
    /***************************************************************************************************
    * 类 名 称: StoreSetting 
    * 功能说明: StoreSetting类，用于存储配置信息
    * 注    意: INI文件中保存的是UART、呼吸、血氧、心电是否保存的状态（bool类型，保存-ture，未保存-false），
    *           和文件保存位置（string类型）
    ***************************************************************************************************/
    class StoreSetting
    {
        private const string PRE_STORE_DATA_FILE = @".\Data\";  //设置保存数据文件路径及名字 的前缀
        private const string POS_STORE_DATA_FILE = @"\storeData.ini";//设置保存数据文件路径及名字 的后缀 
        private string mUserAccount;

        private bool mNIBP;
        private bool mResp;
        private bool mSPO2;
        private bool mUART;
        private string mSaveFolder;

        private IniHelper mIniFile;

        //添加类的属性
        public bool bSaveNIBP
        {
            get { return mNIBP; }
            set { mNIBP = value; }
        }
        public bool bSaveResp
        {
            get { return mResp; }
            set { mResp = value; }
        }

        public bool bSaveSPO2
        {
            get { return mSPO2; }
            set { mSPO2 = value; }
        }

        public bool bSaveUART
        {
            get { return mUART; }
            set { mUART = value; }
        }

        public string saveFolder
        {
            get { return mSaveFolder; }
            set { mSaveFolder = value; }
        }

        /*********************************************************************************************
        * 方法名称: StoreSetting
        * 功能说明: 构造方法
        * 参数说明：输入参数(1)userAccount:用户的账号(2)创建文件时的第一行所写的标识
        * 注    意: 
        *********************************************************************************************/
        public StoreSetting(string userAccount, string title)
        {
            string fileName = PRE_STORE_DATA_FILE + userAccount + POS_STORE_DATA_FILE;
            mIniFile = new IniHelper(fileName, title); //传递INI文件名至配置文件

            mUserAccount = userAccount;

            loadFromFile();
        }

        /*********************************************************************************************
        * 方法名称: loadFromFile
        * 功能说明: 将init文件内的内容写入给成员变量
        * 参数说明：
        * 注    意: 
        *********************************************************************************************/
        public void loadFromFile()
        {
            mNIBP = mIniFile.readBool("StoreSetting", "NIBP", false);
            mResp = mIniFile.readBool("StoreSetting", "Resp", false);
            mSPO2 = mIniFile.readBool("StoreSetting", "SPO2", false);
            mUART = mIniFile.readBool("StoreSetting", "UART", false);
            mSaveFolder = mIniFile.readString("StoreSetting", "SaveFolder", @".\RcvData\" + mUserAccount + @"\");
        }

        /*********************************************************************************************
        * 方法名称: saveToFile
        * 功能说明: 将成员变量的值写入给init文件
        * 参数说明：
        * 注    意: 
        *********************************************************************************************/
        public void saveToFile()
        {
            mIniFile.writeBool("StoreSetting", "NIBP", mNIBP);
            mIniFile.writeBool("StoreSetting", "Resp", mResp);
            mIniFile.writeBool("StoreSetting", "SPO2", mSPO2);
            mIniFile.writeBool("StoreSetting", "UART", mUART);
            mIniFile.writeString("StoreSetting", "SaveFolder", mSaveFolder);
        }
    }
}
