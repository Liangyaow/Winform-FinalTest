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


        public FormChangePsw()
        {
            InitializeComponent();
            mIniFile = new IniHelper(STORE_DATA_FILE, "#用户信息表");          //传递INI文件名至配置文件

        }

        private void labelBacktoLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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

        private void textBoxConfirmPassword_Leave(object sender, EventArgs e)
        {
            if (textBoxNewPassword.Text == textBoxConfirmPassword.Text)
            {
                labelConfirmPswWarn.Visible = false;
                mConfirmPswFlag = true;
            }
            else
            {
                labelConfirmPswWarn.Visible = true;
                mConfirmPswFlag = false;
            }
        }

        private void buttonChangePsw_Click(object sender, EventArgs e)
        {
            if (mAccountFlag && mPswFlag && mNewPswFlag && mConfirmPswFlag)
            {
                string keyAccount = "";
                string keyPassword = "";

                List<string> listAcount = new List<string>();

                string userAccount = textBoxAccount.Text;
                string userPassword = textBoxPassword.Text;
                string userNewPassword = textBoxNewPassword.Text;

                for (int i = 0; i < 100; i++)
                {
                    keyAccount = "User" + Convert.ToString(i) + "Account";
                    keyPassword = "User" + Convert.ToString(i) + "Password";

                    listAcount.Add(mIniFile.readString("UserInfo", keyAccount, "nothing"));

                    if ((listAcount[i] == "nothing")
                        && (mIniFile.readString("UserInfo", keyPassword, "nothing") == "nothing"))
                    {
                        keyAccount = "User" + Convert.ToString(i - 1) + "Account";
                        keyPassword = "User" + Convert.ToString(i - 1) + "Password";

                        break;
                    }
                }

                int keyIndex = listAcount.FindIndex(item => item.Equals(userAccount));
                if (keyIndex != -1)
                {
                    keyPassword = keyPassword = "User" + Convert.ToString(keyIndex) + "Password";

                    if (mIniFile.readString("UserInfo", keyPassword, "nothing") == Encode.getEncodedPsw(userPassword))
                    {
                        mIniFile.writeString("UserInfo", keyPassword, Encode.getEncodedPsw(userNewPassword));
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
