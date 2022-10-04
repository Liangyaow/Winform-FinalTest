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
    public partial class FormRegister : Form
    {
        private bool mAccountFlag;
        private bool mPswFlag;


        private const string STORE_DATA_FILE = @".\Data\UserInfo.ini";  //设置保存数据文件路径及名字
        private IniHelper mIniFile;

        public FormRegister()
        {
            InitializeComponent();
            mIniFile = new IniHelper(STORE_DATA_FILE, "#用户信息表");          //传递INI文件名至配置文件
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

        private void buttonRegister_Click(object sender, EventArgs e)
        {

            if (mAccountFlag && mPswFlag)
            {
                string userAccount;
                string userPsw;

                string keyAccount = "";
                string keyPassword = "";

                List<string> listAcount = new List<string>();

                userAccount = textBoxAccount.Text;
                userPsw = Encode.getEncodedPsw(textBoxPassword.Text);

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
                if (listAcount.Contains(userAccount))
                {
                    MessageBox.Show("账号重复", "警告");
                }
                else
                {
                    mIniFile.writeString("UserInfo", keyAccount, userAccount);
                    mIniFile.writeString("UserInfo", keyPassword, userPsw);

                    MessageBox.Show("恭喜你 注册成功", "成功");


                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("请输入正确格式的账号和密码", "警告");
            }
        }

        private void labelBackToLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void checkBoxShowPsw_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPsw.Checked)
            {
                textBoxPassword.PasswordChar = '\0';
            }
            else
            {
                textBoxPassword.PasswordChar = Convert.ToChar('*');
            }
        }


    }
}
