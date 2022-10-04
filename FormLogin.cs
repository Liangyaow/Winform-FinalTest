using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace FinalTest
{
    public partial class FormLogin : Form
    {
        private bool mAccountFlag = false;
        private bool mPswFlag = false;

        private const string STORE_DATA_FILE = @".\Data\UserInfo.ini";  //设置保存用户信息文件路径及名字
        private IniHelper mIniFile;

        /***********************************************************************************************
        * 方法名称: FormRegister
        * 功能说明:登陆界面的构造函数
        * 参数说明：
        * 注    意:
        ***********************************************************************************************/
        public FormLogin()
        {
            InitializeComponent();

            mIniFile = new IniHelper(STORE_DATA_FILE, "#用户信息表");          //传递INI文件名至配置文件
        }

        /***********************************************************************************************
        * 方法名称: labelRegister_Click
        * 功能说明:注册界面label被按下时触发 跳转到注册页面
        * 参数说明：
        * 注    意:
        ***********************************************************************************************/
        private void labelRegister_Click(object sender, EventArgs e)
        {
            FormRegister register = new FormRegister();
            register.StartPosition = FormStartPosition.CenterParent;
            register.ShowDialog();
        }

        /***********************************************************************************************
        * 方法名称: labelChangePsw_Click
        * 功能说明:修改密码label被按下时触发 跳转到修改密码页面
        * 参数说明：
        * 注    意:
        ***********************************************************************************************/
        private void labelChangePsw_Click(object sender, EventArgs e)
        {
            FormChangePsw formChangePsw = new FormChangePsw();
            formChangePsw.StartPosition = FormStartPosition.CenterParent;
            formChangePsw.ShowDialog();
        }

        /***********************************************************************************************
        * 方法名称: checkBoxShowPsw_CheckedChanged
        * 功能说明:按下显示密码checkbox时触发
        * 参数说明：
        * 注    意:
        ***********************************************************************************************/
        private void checkBoxShowPsw_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPsw.Checked)                //勾选不显示密码
            {
                textBoxPassword.PasswordChar = '\0';
            }
            else                                        //不勾选不显示密码
            {
                textBoxPassword.PasswordChar = Convert.ToChar('*');
            }
        }

        /***********************************************************************************************
        * 方法名称: textBoxAccount_Leave
        * 功能说明:输入账号的textbox失去焦点时触发
        * 参数说明：
        * 注    意:
        ***********************************************************************************************/
        private void textBoxAccount_Leave(object sender, EventArgs e)
        {
            Match match = Regex.Match(textBoxAccount.Text, @"^[0-9]{6,10}$");   //要账号求是6-9位数字组成
            if (match.Success)                                                  //用户输入的账号符合要求
            {
                labelAcountWarn.Visible = false;                                //隐藏警告语
                mAccountFlag = true;                                            //输入账号完成标志位 设为true
            }
            else                                                                //用户输入的账号不符合要求
            {
                labelAcountWarn.Visible = true;                                 //显示警告语
                mAccountFlag = false;                                           //输入账号完成标志位 设为false
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
            Match match = Regex.Match(textBoxPassword.Text, @"^[0-9A-Za-z]{6,20}$");        //要求密码是6-20位数字字母组成
            if (match.Success)                              //用户输入的密码符合要求
            {
                labelPswWarn.Visible = false;               //隐藏警告语
                mPswFlag = true;                            //输入密码完成标志位 设为true
            }
            else                                            //用户输入的密码不符合要求
            {
                labelPswWarn.Visible = true;                //显示警告语
                mPswFlag = false;                           //输入密码完成标志位 设为false
            }
        }

        /***********************************************************************************************
        * 方法名称: labelChangePsw_Click
        * 功能说明:修改密码label被按下时触发 跳转到修改密码页面
        * 参数说明：
        * 注    意:
        ***********************************************************************************************/
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (mAccountFlag && mPswFlag)                               //用户输入的账号和密码满足设定的规则
            {
                string userAccount = textBoxAccount.Text;               //用户当前输入的账号
                string userPassword = textBoxPassword.Text;             //用户当前输入的密码(经过MD5密文加密)

                string keyAccount = "";                                  //用来查UserInfo段中的 账号的Key值
                string keyPassword = "";                                 //用来查UserInfo段中的 密码的Key值

                List<string> listAcount = new List<string>();           //存储UserInfo段中的所有的账号值

                //循环直到listlistAcount存储了UserInfo文件所有的账号
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

                int keyIndex = listAcount.FindIndex(item => item.Equals(userAccount));  //查找当前输入账号在所有所存储的账号的索引
                if (keyIndex != -1)                                                    //查找成功
                {
                    keyPassword = keyPassword = "User" + Convert.ToString(keyIndex) + "Password";

                    //将输入的密码经MD5密文加密后跟数据库中存储的密码相比较
                    if (mIniFile.readString("UserInfo", keyPassword, "nothing") == Encode.getEncodedPsw(userPassword))  //结果两者相同
                    {
                        MessageBox.Show("恭喜你 登录成功", "成功");
                        this.Hide();
                        FormMain mainform = new FormMain(userAccount);
                        mainform.StartPosition = FormStartPosition.CenterParent;
                        mainform.ShowDialog();                                                                            //显示MainForm主界面
                        this.Close();
                    }
                    else                                                                                                //结果两者不相同                 
                    {
                        MessageBox.Show("密码错误 请重试", "警告");
                    }
                }
                else                                                                //查找失败
                {
                    MessageBox.Show("该账号不存在", "警告");
                }
            }
            else                                                                    //用户输入的账号或(和)密码不满足设定的规则
            {
                MessageBox.Show("账号或密码错误", "警告");
            }
        }
    }
}
