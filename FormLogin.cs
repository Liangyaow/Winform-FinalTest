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
    public partial class FormLogin : Form
    {
        private bool mAccountFlag;
        private bool mPswFlag;

        private const string STORE_DATA_FILE = @".\Data\UserInfo.ini";  //设置保存数据文件路径及名字
        private IniHelper mIniFile;


        public FormLogin()
        {
            InitializeComponent();
            mIniFile = new IniHelper(STORE_DATA_FILE, "#用户信息表");          //传递INI文件名至配置文件
        }

        private void labelRegister_Click(object sender, EventArgs e)
        {
            FormRegister register = new FormRegister();
            register.StartPosition = FormStartPosition.CenterParent;
            register.ShowDialog();
        }

        private void checkBoxShowPsw_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = !checkBoxShowPsw.Checked;
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

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (mAccountFlag && mPswFlag)
            {
                string keyAccount = "";
                string keyPassword = "";

                List<string> listAcount = new List<string>();

                string userAccount = textBoxAccount.Text;
                string userPassword = textBoxPassword.Text;


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
                        MessageBox.Show("恭喜你 登录成功", "成功");
                        this.Hide();
                        FormMain mainform = new FormMain(userAccount);
                        mainform.StartPosition = FormStartPosition.CenterParent;
                        mainform.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("密码错误 请重试", "警告");
                    }
                }
                else
                {
                    MessageBox.Show("该账号不存在", "警告");
                }
            }
            else
            {
                MessageBox.Show("账号或密码错误", "警告");
            }
        }
    }
}
