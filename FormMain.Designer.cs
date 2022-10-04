
namespace FinalTest
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            this.buttonToNIBP = new System.Windows.Forms.Button();
            this.buttonToResp = new System.Windows.Forms.Button();
            this.buttonToSPO2 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItemUART = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemStoreSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.timeToolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.timerFor1Sec = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.labelAccount = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelUART = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonToNIBP
            // 
            this.buttonToNIBP.Location = new System.Drawing.Point(143, 161);
            this.buttonToNIBP.Name = "buttonToNIBP";
            this.buttonToNIBP.Size = new System.Drawing.Size(364, 145);
            this.buttonToNIBP.TabIndex = 0;
            this.buttonToNIBP.Text = "血压";
            this.buttonToNIBP.UseVisualStyleBackColor = true;
            this.buttonToNIBP.Click += new System.EventHandler(this.buttonToNIBP_Click);
            // 
            // buttonToResp
            // 
            this.buttonToResp.Location = new System.Drawing.Point(143, 344);
            this.buttonToResp.Name = "buttonToResp";
            this.buttonToResp.Size = new System.Drawing.Size(364, 145);
            this.buttonToResp.TabIndex = 1;
            this.buttonToResp.Text = "呼吸";
            this.buttonToResp.UseVisualStyleBackColor = true;
            this.buttonToResp.Click += new System.EventHandler(this.buttonToResp_Click);
            // 
            // buttonToSPO2
            // 
            this.buttonToSPO2.Location = new System.Drawing.Point(143, 527);
            this.buttonToSPO2.Name = "buttonToSPO2";
            this.buttonToSPO2.Size = new System.Drawing.Size(364, 145);
            this.buttonToSPO2.TabIndex = 2;
            this.buttonToSPO2.Text = "血氧";
            this.buttonToSPO2.UseVisualStyleBackColor = true;
            this.buttonToSPO2.Click += new System.EventHandler(this.buttonToSPO2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemUART,
            this.ToolStripMenuItemStoreSetting,
            this.timeToolStripMenuItemAbout,
            this.ToolStripMenuItemExit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(657, 39);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItemUART
            // 
            this.ToolStripMenuItemUART.Name = "ToolStripMenuItemUART";
            this.ToolStripMenuItemUART.Size = new System.Drawing.Size(130, 35);
            this.ToolStripMenuItemUART.Text = "串口设置";
            this.ToolStripMenuItemUART.Click += new System.EventHandler(this.ToolStripMenuItemUART_Click);
            // 
            // ToolStripMenuItemStoreSetting
            // 
            this.ToolStripMenuItemStoreSetting.Name = "ToolStripMenuItemStoreSetting";
            this.ToolStripMenuItemStoreSetting.Size = new System.Drawing.Size(130, 35);
            this.ToolStripMenuItemStoreSetting.Text = "数据存储";
            this.ToolStripMenuItemStoreSetting.Click += new System.EventHandler(this.ToolStripMenuItemStoreSetting_Click);
            // 
            // timeToolStripMenuItemAbout
            // 
            this.timeToolStripMenuItemAbout.Name = "timeToolStripMenuItemAbout";
            this.timeToolStripMenuItemAbout.Size = new System.Drawing.Size(82, 35);
            this.timeToolStripMenuItemAbout.Text = "关于";
            this.timeToolStripMenuItemAbout.Click += new System.EventHandler(this.timeToolStripMenuItemAbout_Click);
            // 
            // ToolStripMenuItemExit
            // 
            this.ToolStripMenuItemExit.Name = "ToolStripMenuItemExit";
            this.ToolStripMenuItemExit.Size = new System.Drawing.Size(82, 35);
            this.ToolStripMenuItemExit.Text = "退出";
            this.ToolStripMenuItemExit.Click += new System.EventHandler(this.ToolStripMenuItemExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "您好，";
            // 
            // timerFor1Sec
            // 
            this.timerFor1Sec.Enabled = true;
            this.timerFor1Sec.Interval = 30;
            this.timerFor1Sec.Tick += new System.EventHandler(this.timerForSec_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "当前时间为：";
            // 
            // labelAccount
            // 
            this.labelAccount.AutoSize = true;
            this.labelAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelAccount.Location = new System.Drawing.Point(96, 48);
            this.labelAccount.Name = "labelAccount";
            this.labelAccount.Size = new System.Drawing.Size(46, 24);
            this.labelAccount.TabIndex = 6;
            this.labelAccount.Text = "111";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(186, 92);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(58, 24);
            this.labelTime.TabIndex = 7;
            this.labelTime.Text = "Time";
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelUART});
            this.statusStrip1.Location = new System.Drawing.Point(0, 742);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(657, 41);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelUART
            // 
            this.toolStripStatusLabelUART.Name = "toolStripStatusLabelUART";
            this.toolStripStatusLabelUART.Size = new System.Drawing.Size(110, 31);
            this.toolStripStatusLabelUART.Text = "串口关闭";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(657, 783);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelAccount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonToSPO2);
            this.Controls.Add(this.buttonToResp);
            this.Controls.Add(this.buttonToNIBP);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonToNIBP;
        private System.Windows.Forms.Button buttonToResp;
        private System.Windows.Forms.Button buttonToSPO2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemUART;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerFor1Sec;
        private System.Windows.Forms.ToolStripMenuItem timeToolStripMenuItemAbout;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemExit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelAccount;
        private System.Windows.Forms.Label labelTime;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelUART;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemStoreSetting;
    }
}