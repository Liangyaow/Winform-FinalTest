
namespace FinalTest
{
    partial class FormRegister
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
            this.buttonLogin = new System.Windows.Forms.Button();
            this.labelRegister = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxAccount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelAcountWarn = new System.Windows.Forms.Label();
            this.labelPswWarn = new System.Windows.Forms.Label();
            this.checkBoxShowPsw = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(266, 341);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(221, 76);
            this.buttonLogin.TabIndex = 11;
            this.buttonLogin.Text = "立即注册";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // labelRegister
            // 
            this.labelRegister.AutoSize = true;
            this.labelRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelRegister.Location = new System.Drawing.Point(640, 367);
            this.labelRegister.Name = "labelRegister";
            this.labelRegister.Size = new System.Drawing.Size(106, 24);
            this.labelRegister.TabIndex = 10;
            this.labelRegister.Text = "返回登陆";
            this.labelRegister.Click += new System.EventHandler(this.labelRegister_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(224, 207);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(298, 35);
            this.textBoxPassword.TabIndex = 9;
            this.textBoxPassword.Leave += new System.EventHandler(this.textBoxPassword_Leave);
            // 
            // textBoxAccount
            // 
            this.textBoxAccount.Location = new System.Drawing.Point(224, 86);
            this.textBoxAccount.Name = "textBoxAccount";
            this.textBoxAccount.Size = new System.Drawing.Size(298, 35);
            this.textBoxAccount.TabIndex = 8;
            this.textBoxAccount.Leave += new System.EventHandler(this.textBoxAccount_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "密码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "账号";
            // 
            // labelAcountWarn
            // 
            this.labelAcountWarn.AutoEllipsis = true;
            this.labelAcountWarn.AutoSize = true;
            this.labelAcountWarn.ForeColor = System.Drawing.Color.Red;
            this.labelAcountWarn.Location = new System.Drawing.Point(220, 141);
            this.labelAcountWarn.Name = "labelAcountWarn";
            this.labelAcountWarn.Size = new System.Drawing.Size(202, 24);
            this.labelAcountWarn.TabIndex = 12;
            this.labelAcountWarn.Text = "请输入6-10位数字";
            this.labelAcountWarn.Visible = false;
            // 
            // labelPswWarn
            // 
            this.labelPswWarn.AutoSize = true;
            this.labelPswWarn.ForeColor = System.Drawing.Color.Red;
            this.labelPswWarn.Location = new System.Drawing.Point(220, 262);
            this.labelPswWarn.Name = "labelPswWarn";
            this.labelPswWarn.Size = new System.Drawing.Size(298, 24);
            this.labelPswWarn.TabIndex = 13;
            this.labelPswWarn.Text = "请输入6-20位字母数字组合";
            this.labelPswWarn.Visible = false;
            // 
            // checkBoxShowPsw
            // 
            this.checkBoxShowPsw.AutoSize = true;
            this.checkBoxShowPsw.Location = new System.Drawing.Point(608, 214);
            this.checkBoxShowPsw.Name = "checkBoxShowPsw";
            this.checkBoxShowPsw.Size = new System.Drawing.Size(138, 28);
            this.checkBoxShowPsw.TabIndex = 14;
            this.checkBoxShowPsw.Text = "显示密码";
            this.checkBoxShowPsw.UseVisualStyleBackColor = true;
            this.checkBoxShowPsw.CheckedChanged += new System.EventHandler(this.checkBoxShowPsw_CheckedChanged);
            // 
            // FormRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 460);
            this.Controls.Add(this.checkBoxShowPsw);
            this.Controls.Add(this.labelPswWarn);
            this.Controls.Add(this.labelAcountWarn);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.labelRegister);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxAccount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormRegister";
            this.Text = "注册";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label labelRegister;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxAccount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelAcountWarn;
        private System.Windows.Forms.Label labelPswWarn;
        private System.Windows.Forms.CheckBox checkBoxShowPsw;
    }
}