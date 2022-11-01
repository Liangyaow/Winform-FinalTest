
namespace FinalTest
{
    partial class FormChangePsw
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChangePsw));
            this.checkBoxShowPswForPsw = new System.Windows.Forms.CheckBox();
            this.labelPswWarn = new System.Windows.Forms.Label();
            this.labelAcountWarn = new System.Windows.Forms.Label();
            this.buttonChangePsw = new System.Windows.Forms.Button();
            this.labelBacktoLogin = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxAccount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelNewPswWarn = new System.Windows.Forms.Label();
            this.textBoxNewPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelConfirmPswWarn = new System.Windows.Forms.Label();
            this.textBoxConfirmPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBoxForShowNewPassword = new System.Windows.Forms.CheckBox();
            this.checkBoxForShowConfirmPassword = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkBoxShowPswForPsw
            // 
            this.checkBoxShowPswForPsw.AutoSize = true;
            this.checkBoxShowPswForPsw.Location = new System.Drawing.Point(645, 190);
            this.checkBoxShowPswForPsw.Name = "checkBoxShowPswForPsw";
            this.checkBoxShowPswForPsw.Size = new System.Drawing.Size(138, 28);
            this.checkBoxShowPswForPsw.TabIndex = 23;
            this.checkBoxShowPswForPsw.Text = "显示密码";
            this.checkBoxShowPswForPsw.UseVisualStyleBackColor = true;
            this.checkBoxShowPswForPsw.CheckedChanged += new System.EventHandler(this.checkBoxShowPswForPsw_CheckedChanged);
            // 
            // labelPswWarn
            // 
            this.labelPswWarn.AutoSize = true;
            this.labelPswWarn.ForeColor = System.Drawing.Color.Red;
            this.labelPswWarn.Location = new System.Drawing.Point(252, 240);
            this.labelPswWarn.Name = "labelPswWarn";
            this.labelPswWarn.Size = new System.Drawing.Size(298, 24);
            this.labelPswWarn.TabIndex = 22;
            this.labelPswWarn.Text = "请输入6-20位字母数字组合";
            this.labelPswWarn.Visible = false;
            // 
            // labelAcountWarn
            // 
            this.labelAcountWarn.AutoEllipsis = true;
            this.labelAcountWarn.AutoSize = true;
            this.labelAcountWarn.ForeColor = System.Drawing.Color.Red;
            this.labelAcountWarn.Location = new System.Drawing.Point(252, 119);
            this.labelAcountWarn.Name = "labelAcountWarn";
            this.labelAcountWarn.Size = new System.Drawing.Size(202, 24);
            this.labelAcountWarn.TabIndex = 21;
            this.labelAcountWarn.Text = "请输入6-10位数字";
            this.labelAcountWarn.Visible = false;
            // 
            // buttonChangePsw
            // 
            this.buttonChangePsw.Location = new System.Drawing.Point(265, 528);
            this.buttonChangePsw.Name = "buttonChangePsw";
            this.buttonChangePsw.Size = new System.Drawing.Size(221, 76);
            this.buttonChangePsw.TabIndex = 20;
            this.buttonChangePsw.Text = "立即修改";
            this.buttonChangePsw.UseVisualStyleBackColor = true;
            this.buttonChangePsw.Click += new System.EventHandler(this.buttonChangePsw_Click);
            // 
            // labelBacktoLogin
            // 
            this.labelBacktoLogin.AutoSize = true;
            this.labelBacktoLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelBacktoLogin.Location = new System.Drawing.Point(641, 554);
            this.labelBacktoLogin.Name = "labelBacktoLogin";
            this.labelBacktoLogin.Size = new System.Drawing.Size(106, 24);
            this.labelBacktoLogin.TabIndex = 19;
            this.labelBacktoLogin.Text = "返回登陆";
            this.labelBacktoLogin.Click += new System.EventHandler(this.labelBacktoLogin_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(244, 187);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(298, 35);
            this.textBoxPassword.TabIndex = 18;
            this.textBoxPassword.Leave += new System.EventHandler(this.textBoxPassword_Leave);
            // 
            // textBoxAccount
            // 
            this.textBoxAccount.Location = new System.Drawing.Point(244, 66);
            this.textBoxAccount.Name = "textBoxAccount";
            this.textBoxAccount.Size = new System.Drawing.Size(298, 35);
            this.textBoxAccount.TabIndex = 17;
            this.textBoxAccount.Leave += new System.EventHandler(this.textBoxAccount_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 24);
            this.label2.TabIndex = 16;
            this.label2.Text = "原始密码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 24);
            this.label1.TabIndex = 15;
            this.label1.Text = "账号";
            // 
            // labelNewPswWarn
            // 
            this.labelNewPswWarn.AutoSize = true;
            this.labelNewPswWarn.ForeColor = System.Drawing.Color.Red;
            this.labelNewPswWarn.Location = new System.Drawing.Point(252, 345);
            this.labelNewPswWarn.Name = "labelNewPswWarn";
            this.labelNewPswWarn.Size = new System.Drawing.Size(298, 24);
            this.labelNewPswWarn.TabIndex = 26;
            this.labelNewPswWarn.Text = "请输入6-20位字母数字组合";
            this.labelNewPswWarn.Visible = false;
            // 
            // textBoxNewPassword
            // 
            this.textBoxNewPassword.Location = new System.Drawing.Point(244, 291);
            this.textBoxNewPassword.Name = "textBoxNewPassword";
            this.textBoxNewPassword.PasswordChar = '*';
            this.textBoxNewPassword.Size = new System.Drawing.Size(298, 35);
            this.textBoxNewPassword.TabIndex = 25;
            this.textBoxNewPassword.Leave += new System.EventHandler(this.textBoxNewPassword_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(112, 295);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 24);
            this.label4.TabIndex = 24;
            this.label4.Text = "新密码";
            // 
            // labelConfirmPswWarn
            // 
            this.labelConfirmPswWarn.AutoSize = true;
            this.labelConfirmPswWarn.ForeColor = System.Drawing.Color.Red;
            this.labelConfirmPswWarn.Location = new System.Drawing.Point(252, 475);
            this.labelConfirmPswWarn.Name = "labelConfirmPswWarn";
            this.labelConfirmPswWarn.Size = new System.Drawing.Size(154, 24);
            this.labelConfirmPswWarn.TabIndex = 29;
            this.labelConfirmPswWarn.Text = "两次密码不同";
            this.labelConfirmPswWarn.Visible = false;
            // 
            // textBoxConfirmPassword
            // 
            this.textBoxConfirmPassword.Location = new System.Drawing.Point(244, 420);
            this.textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            this.textBoxConfirmPassword.PasswordChar = '*';
            this.textBoxConfirmPassword.Size = new System.Drawing.Size(298, 35);
            this.textBoxConfirmPassword.TabIndex = 28;
            this.textBoxConfirmPassword.Leave += new System.EventHandler(this.textBoxConfirmPassword_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(112, 425);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 24);
            this.label6.TabIndex = 27;
            this.label6.Text = "重复密码";
            // 
            // checkBoxForShowNewPassword
            // 
            this.checkBoxForShowNewPassword.AutoSize = true;
            this.checkBoxForShowNewPassword.Location = new System.Drawing.Point(645, 294);
            this.checkBoxForShowNewPassword.Name = "checkBoxForShowNewPassword";
            this.checkBoxForShowNewPassword.Size = new System.Drawing.Size(138, 28);
            this.checkBoxForShowNewPassword.TabIndex = 30;
            this.checkBoxForShowNewPassword.Text = "显示密码";
            this.checkBoxForShowNewPassword.UseVisualStyleBackColor = true;
            this.checkBoxForShowNewPassword.CheckedChanged += new System.EventHandler(this.checkBoxForShowNewPassword_CheckedChanged);
            // 
            // checkBoxForShowConfirmPassword
            // 
            this.checkBoxForShowConfirmPassword.AutoSize = true;
            this.checkBoxForShowConfirmPassword.Location = new System.Drawing.Point(645, 423);
            this.checkBoxForShowConfirmPassword.Name = "checkBoxForShowConfirmPassword";
            this.checkBoxForShowConfirmPassword.Size = new System.Drawing.Size(138, 28);
            this.checkBoxForShowConfirmPassword.TabIndex = 31;
            this.checkBoxForShowConfirmPassword.Text = "显示密码";
            this.checkBoxForShowConfirmPassword.UseVisualStyleBackColor = true;
            this.checkBoxForShowConfirmPassword.CheckedChanged += new System.EventHandler(this.checkBoxForShowConfirmPassword_CheckedChanged);
            // 
            // FormChangePsw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 634);
            this.Controls.Add(this.checkBoxForShowConfirmPassword);
            this.Controls.Add(this.checkBoxForShowNewPassword);
            this.Controls.Add(this.labelConfirmPswWarn);
            this.Controls.Add(this.textBoxConfirmPassword);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelNewPswWarn);
            this.Controls.Add(this.textBoxNewPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBoxShowPswForPsw);
            this.Controls.Add(this.labelPswWarn);
            this.Controls.Add(this.labelAcountWarn);
            this.Controls.Add(this.buttonChangePsw);
            this.Controls.Add(this.labelBacktoLogin);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxAccount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormChangePsw";
            this.Text = "修改密码";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxShowPswForPsw;
        private System.Windows.Forms.Label labelPswWarn;
        private System.Windows.Forms.Label labelAcountWarn;
        private System.Windows.Forms.Button buttonChangePsw;
        private System.Windows.Forms.Label labelBacktoLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxAccount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelNewPswWarn;
        private System.Windows.Forms.TextBox textBoxNewPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelConfirmPswWarn;
        private System.Windows.Forms.TextBox textBoxConfirmPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBoxForShowNewPassword;
        private System.Windows.Forms.CheckBox checkBoxForShowConfirmPassword;
    }
}