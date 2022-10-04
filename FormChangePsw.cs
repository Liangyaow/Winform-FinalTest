using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace FinalTest
{
    public partial class FormChangePsw : Form
    {
        private bool mAccountFlag;
        private bool mPswFlag;
        private bool mNewPswFlag;
        private bool mConfirmPswFlag;

        private const string STORE_DATA_FILE = @".\Data\UserInfo.ini";  //设置保存数据文件路径及名字
        private IniHelper mIniFile;


        /***********************************************************************************************
        * 方法名称: FormChangePsw
        * 功能说明:修改密码界面的构造函数
        * 参数说明：
        * 注    意:
        ***********************************************************************************************/
        public FormChangePsw()
        {
            InitializeComponent();
            mIniFile = new IniHelper(STORE_DATA_FILE, "#用户信息表");          //传递INI文件名至配置文件
        }

        /***********************************************************************************************
        * 方法名称: labelBacktoLogin_Click
        * 功能说明:按下返回登陆label时触发
        * 参数说明：
        * 注    意:
        ***********************************************************************************************/
        private void labelBacktoLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /***********************************************************************************************
        * 方法名称:checkBoxShowPswForPsw_CheckedChanged
        * 功能说明:
        * 参数说明：
        * 注    意:
        ***********************************************************************************************/
        private void checkBoxShowPswForPsw_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPswForPsw.Checked)
            {
                textBoxPassword.PasswordChar = '\0';
            }
            else
            {
                textBoxPassword.PasswordChar = Convert.ToChar('*');
            }
        }

        /***********************************************************************************************
        * 方法名称: checkBoxForShowNewPassword_CheckedChanged
        * 功能说明:
        * 参数说明：
        * 注    意:
        ***********************************************************************************************/
        private void checkBoxForShowNewPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxForShowNewPassword.Checked)
            {
                textBoxNewPassword.PasswordChar = '\0';
            }
            else
            {
                textBoxNewPassword.PasswordChar = Convert.ToChar('*');
            }
        }

        /***********************************************************************************************
        * 方法名称: checkBoxForShowConfirmPassword_CheckedChanged
        * 功能说明:
        * 参数说明：
        * 注    意:
        ***********************************************************************************************/

        private void checkBoxForShowConfirmPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxForShowConfirmPassword.Checked)
            {
                textBoxConfirmPassword.PasswordChar = '\0';
            }
            else
            {
                textBoxConfirmPassword.PasswordChar = Convert.ToChar('*');
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
            Match match = Regex.Match(textBoxAccount.Text, @"^[0-9]{6,10}$");
            if (match.Success)
            {
                labelAcountWarn.Visible = false;
                mAccountFlag = true;
            }
            else
            {
                labelAcountWarn.Visible = true;
                mAccountFlag = false;

            }
        }

        /***********************************************************************************************
        * 方法名称: textBoxPassword_Leave
        * 功能说明:输入原密码的textbox失去焦点时触发
        * 参数说明：
        * 注    意:
        ***********************************************************************************************/
        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            Match match = Regex.Match(textBoxPassword.Text, @"^[0-9A-Za-z]{6,20}$");
            if (match.Success)
            {
                labelPswWarn.Visible = false;
                mPswFlag = true;
            }
            else
            {
                labelPswWarn.Visible = true;
                mPswFlag = false;
            }
        }

        /***********************************************************************************************
        * 方法名称:textBoxNewPassword_Leave
        * 功能说明:输入新密码的textbox失去焦点时触发
        * 参数说明：
        * 注    意:
        ***********************************************************************************************/
        private void textBoxNewPassword_Leave(object sender, EventArgs e)
        {
            Match match = Regex.Match(textBoxPassword.Text, @"^[0-9A-Za-z]{6,20}$");
            if (match.Success)
            {
                labelNewPswWarn.Visible = false;
                mNewPswFlag = true;
            }
            else
            {
                labelNewPswWarn.Visible = true;
                mNewPswFlag = false;
            }
        }

        /***********************************************************************************************
        * 方法名称: textBoxConfirmPassword_Leave
        * 功能说明:输入确认密码的textbox失去焦点时触发
        * 参数说明：
        * 注    意:
        ***********************************************************************************************/
        private void textBoxConfirmPassword_Leave(object sender, EventArgs e)
        {
            if (textBoxNewPassword.Text == textBoxConfirmPassword.Text) //确认密码和新密码要相同
            {
                labelConfirmPswWarn.Visible = false;                       //隐藏警告语
                mConfirmPswFlag = true;                                    //确定密码完成标志位 设为true
            }
            else                                                        //确认密码和新密码要相同
            {
                labelConfirmPswWarn.Visible = true;                     //显示警告语
                mConfirmPswFlag = false;                                //确定密码完成标志位 设为false
            }
        }

        /***********************************************************************************************
        * 方法名称: buttonChangePsw_Click
        * 功能说明:按下 修改密码按钮时触发
        * 参数说明：
        * 注    意:
        ***********************************************************************************************/
        private void buttonChangePsw_Click(object sender, EventArgs e)
        {
            if (mAccountFlag && mPswFlag && mNewPswFlag && mConfirmPswFlag)
            {
                string userAccount = textBoxAccount.Text;           //用户当前输入的账号
                string userPassword = textBoxPassword.Text;         //用户当前输入的原密码
                string userNewPassword = textBoxNewPassword.Text;   //用户当前输入的新密码

                string keyAccount = "";
                string keyPassword = "";

                List<string> listAcount = new List<string>();

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

                int keyIndex = listAcount.FindIndex(item => item.Equals(userAccount));
                if (keyIndex != -1)
                {
                    keyPassword = keyPassword = "User" + Convert.ToString(keyIndex) + "Password";

                    //将输入的密码经MD5密文加密后跟数据库中存储的密码相比较
                    if (mIniFile.readString("UserInfo", keyPassword, "nothing") == Encode.getEncodedPsw(userPassword))
                    {
                        mIniFile.writeString("UserInfo", keyPassword, Encode.getEncodedPsw(userNewPassword));   //对数据库进行修改
                        MessageBox.Show("恭喜你 修改成功", "成功");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("原密码错误 请重试", "警告");
                    }
                }
                else
                {
                    MessageBox.Show("该账号不存在", "警告");
                }
            }
            else
            {
                MessageBox.Show("输入有误请重新检查", "警告");
            }
        }
    }
}
