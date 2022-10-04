using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace FinalTest
{
    public partial class FormRegister : Form
    {
        private bool mAccountFlag = false;
        private bool mPswFlag = false;


        private const string STORE_DATA_FILE = @".\Data\UserInfo.ini";  //设置保存数据文件路径及名字
        private IniHelper mIniFile;

        /***********************************************************************************************
        * 方法名称: FormRegister
        * 功能说明:注册界面的构造函数
        * 参数说明：
        * 注    意:
        ***********************************************************************************************/
        public FormRegister()
        {
            InitializeComponent();
            mIniFile = new IniHelper(STORE_DATA_FILE, "#用户信息表");          //传递INI文件名至配置文件
        }

        /***********************************************************************************************
        * 方法名称: textBoxAccount_Leave
        * 功能说明:输入账号的textbox失去焦点时触发
        * 参数说明：
        * 注    意:
        ***********************************************************************************************/
        private void textBoxAccount_Leave(object sender, EventArgs e)
        {
            Match match = Regex.Match(textBoxAccount.Text, @"^[0-9]{6,10}$"); //要账号求是6-9位数字组成
            if (match.Success)                  //用户输入的账号符合要求
            {
                labelAcountWarn.Visible = false; //隐藏警告语
                mAccountFlag = true;            //输入账号完成标志位 设为true
            }
            else                                //用户输入的账号不符合要求
            {
                labelAcountWarn.Visible = true;   //显示警告语
                mAccountFlag = false;           //输入账号完成标志位 设为false
            }
        }

        /***********************************************************************************************
        * 方法名称: textBoxPassword_Leave
        * 功能说明:输入密码的textbox失去焦点时触发
        * 参数说明：
        * 注    意:
        ***********************************************************************************************/
        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            Match match = Regex.Match(textBoxPassword.Text, @"^[0-9A-Za-z]{6,20}$");    //要求密码是6-20位数字字母组成
            if (match.Success)                          //用户输入的密码符合要求
            {
                labelPswWarn.Visible = false;           //隐藏警告语
                mPswFlag = true;                        //输入密码完成标志位 设为true
            }
            else                                        //用户输入的密码不符合要求
            {
                labelPswWarn.Visible = true;            //显示警告语
                mPswFlag = false;                       //输入密码完成标志位 设为false
            }
        }

        /***********************************************************************************************
        * 方法名称: buttonRegister_Click
        * 功能说明:按下注册按钮时触发
        * 参数说明：
        * 注    意:
        ***********************************************************************************************/
        private void buttonRegister_Click(object sender, EventArgs e)
        {

            if (mAccountFlag && mPswFlag)                           //用户输入的账号和密码满足设定的规则
            {
                string userAccount = textBoxAccount.Text; ;                    //用户当前输入的账号
                string userPsw = Encode.getEncodedPsw(textBoxPassword.Text);    //用户当前输入的密码(经过MD5密文加密)

                string keyAccount = "";                             //用来查UserInfo段中的 账号的Key值
                string keyPassword = "";                            //用来查UserInfo段中的 密码的Key值

                List<string> listAcount = new List<string>();       //存储UserInfo段中的所有的账号值

                //循环直到账号的Key值或密码的key值都指向要插入数据的地方
                for (int i = 0; i < 100; i++)
                {
                    keyAccount = "User" + Convert.ToString(i) + "Account";
                    keyPassword = "User" + Convert.ToString(i) + "Password";
                    listAcount.Add(mIniFile.readString("UserInfo", keyAccount, "nothing"));
                    if ((listAcount[i] == "nothing")
                        && (mIniFile.readString("UserInfo", keyPassword, "nothing") == "nothing"))
                    {
                        break;
                    }
                }

                if (listAcount.Contains(userAccount))  //当前输入的账号已经在UserInfo段中存在
                {
                    MessageBox.Show("账号重复", "警告");
                }
                else                                    //当前输入的账号已经在UserInfo段中不存在
                {
                    mIniFile.writeString("UserInfo", keyAccount, userAccount);  //插入账号
                    mIniFile.writeString("UserInfo", keyPassword, userPsw);     //插入密码

                    MessageBox.Show("恭喜你 注册成功", "成功");
                    this.Close();
                }
            }
            else                                           //用户输入的账号或(和)密码不满足设定的规则
            {
                MessageBox.Show("请输入正确格式的账号和密码", "警告");
            }
        }

        /***********************************************************************************************
        * 方法名称: labelBackToLogin_Click
        * 功能说明:按下返回登陆label时触发
        * 参数说明：
        * 注    意:
        ***********************************************************************************************/
        private void labelBackToLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /***********************************************************************************************
        * 方法名称: checkBoxShowPsw_CheckedChanged
        * 功能说明:按下显示密码checkbox时触发
        * 参数说明：
        * 注    意:
        ***********************************************************************************************/
        private void checkBoxShowPsw_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPsw.Checked)   //勾选不显示密码
            {
                textBoxPassword.PasswordChar = '\0';
            }
            else                            //不勾选不显示密码
            {
                textBoxPassword.PasswordChar = Convert.ToChar('*');
            }
        }


    }
}
