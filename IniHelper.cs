/******************************************************************************************************
* 模块名称: IniHelper.cs
* 摘    要: 读写INI配置文件，StoreSetting类中引用此类
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
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace FinalTest
{
    /***************************************************************************************************
    * 类 名 称: IniHelper 
    * 功能说明: IniHelper类，用于读写INI配置文件
    * 注    意: 
    ***************************************************************************************************/
    class IniHelper
    {
        public string mFileName; //声明INI文件名  

        //声明读写INI文件的API函数  
        [DllImport("kernel32")]
        private static extern bool WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def,
            byte[] retVal, int size, string filePath);

        /***********************************************************************************************
        * 方法名称: IniHelper 
        * 功能说明: 类的构造方法，传递INI文件名
        * 参数说明：输入参数fileName-文件名，输出参数fileName-文件名（若不存在，为新建文件名）
        * 注    意: 
        ***********************************************************************************************/
        public IniHelper(string fileName,string title)
        {
            FileInfo fileInfo = new FileInfo(fileName);

            //判断文件是否存在  
            if ((!fileInfo.Exists))
            {
                //文件不存在，建立文件  
                StreamWriter sw = new StreamWriter(fileName, false, Encoding.Default);
                try
                {
                    sw.Write(title);
                    sw.Close();
                }
                catch
                {
                    throw (new ApplicationException("INI文件不存在"));
                }
            }

            //传递创建好的文件名，必须是完全路径，不能是相对路径  
            mFileName = fileInfo.FullName;
        }

        /***********************************************************************************************
        * 方法名称: writeString 
        * 功能说明: 写string变量到文件
        * 参数说明：输入参数（1）section-字段名，输入参数（2）ident-键名，输入参数（3）value-string类型键值
        * 注    意: 
        ***********************************************************************************************/
        public void writeString(string section, string ident, string value)
        {
            if (!WritePrivateProfileString(section, ident, value, mFileName))
            {
                throw (new ApplicationException("写INI文件出错"));
            }
        }

        /***********************************************************************************************
        * 方法名称: readString 
        * 功能说明: 从文件读string变量
        * 参数说明：输入参数（1）section-字段名，输入参数（2）ident-键名，输入参数（3）defaultStr-string类型默认
        *           值，如果INI文件中没有前两个参数指定的字段名或键名,则将此值赋给变量，返回值s.Trim()-从
        *           文件读取的string变量        
        * 注    意: 
        ***********************************************************************************************/
        public string readString(string section, string ident, string defaultStr)
        {
            Byte[] buffer = new Byte[65535];  //缓存器
            int bufLen = GetPrivateProfileString(section, ident, defaultStr, buffer, buffer.GetUpperBound(0), mFileName);
            //必须设定0（系统默认的代码页）的编码方式，否则无法支持中文  
            string s = Encoding.GetEncoding(0).GetString(buffer);
            s = s.Substring(0, bufLen);
            return s.Trim();
        }

        /***********************************************************************************************
        * 方法名称: readBool 
        * 功能说明: 从文件读Bool类型变量
        * 参数说明：输入参数（1）section-字段名，输入参数（2）ident-键名，输入参数（3）defaultBool-bool类型默认
        *           值，如果INI文件中没有前两个参数指定的字段名或键名,则将此值赋给变量，返回值s.Trim()-从
        *           文件读取的布尔型变量
        * 注    意: 
        ***********************************************************************************************/
        public bool readBool(string section, string ident, bool defaultBool)
        {
            try
            {
                return Convert.ToBoolean(readString(section, ident, Convert.ToString(defaultBool)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return defaultBool;
            }
        }

        /***********************************************************************************************
        * 方法名称: writeBool 
        * 功能说明: 写Bool类型的变量到文件
        * 参数说明：输入参数（1）section-字段名，输入参数（2）ident-键名，输入参数（3）value-bool类型键值
        * 注    意: 
        ***********************************************************************************************/
        public void writeBool(string section, string ident, bool value)
        {
            writeString(section, ident, Convert.ToString(value));
        }

        /***********************************************************************************************
        * 方法名称: updateFile 
        * 功能说明: 更新缓冲区 
        * 注    意: 对于Win9X，来说需要实现updateFile方法将缓冲中的数据写入文件
        *           在Win NT, 2000和XP上，都是直接写文件，没有缓冲，所以，无须实现updateFile  
        *           执行完对Ini文件的修改之后，应该调用本方法更新缓冲区。  
        ***********************************************************************************************/
        public void updateFile()
        {
            WritePrivateProfileString(null, null, null, mFileName);
        }

        /***********************************************************************************************
        * 方法名称: ~IniHelper 
        * 功能说明: 类的析构方法， 确保资源的释放
        * 注    意: 
        ***********************************************************************************************/
        ~IniHelper()
        {
            updateFile();
        }
    }
}
