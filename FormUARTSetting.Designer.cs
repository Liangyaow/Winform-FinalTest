
namespace FinalTest
{
    partial class FormUARTSetting
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
            this.buttonUARTSetOpen = new System.Windows.Forms.Button();
            this.comboBoxUARTParity = new System.Windows.Forms.ComboBox();
            this.labelUARTParity = new System.Windows.Forms.Label();
            this.comboBoxUARTStopBits = new System.Windows.Forms.ComboBox();
            this.labelUARTStopBits = new System.Windows.Forms.Label();
            this.comboBoxUARTDataBits = new System.Windows.Forms.ComboBox();
            this.labelUARTDataBits = new System.Windows.Forms.Label();
            this.comboBoxUARTBaudRate = new System.Windows.Forms.ComboBox();
            this.labelUARTBaudRate = new System.Windows.Forms.Label();
            this.comboBoxUARTPortNum = new System.Windows.Forms.ComboBox();
            this.labelUARTPortNum = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonUARTSetOpen
            // 
            this.buttonUARTSetOpen.Location = new System.Drawing.Point(137, 430);
            this.buttonUARTSetOpen.Margin = new System.Windows.Forms.Padding(8);
            this.buttonUARTSetOpen.Name = "buttonUARTSetOpen";
            this.buttonUARTSetOpen.Size = new System.Drawing.Size(212, 82);
            this.buttonUARTSetOpen.TabIndex = 73;
            this.buttonUARTSetOpen.Text = "打开串口";
            this.buttonUARTSetOpen.UseVisualStyleBackColor = true;
            this.buttonUARTSetOpen.Click += new System.EventHandler(this.buttonUARTSetOpen_Click);
            // 
            // comboBoxUARTParity
            // 
            this.comboBoxUARTParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUARTParity.FormattingEnabled = true;
            this.comboBoxUARTParity.Items.AddRange(new object[] {
            "NONE",
            "ODD",
            "EVEN"});
            this.comboBoxUARTParity.Location = new System.Drawing.Point(235, 352);
            this.comboBoxUARTParity.Margin = new System.Windows.Forms.Padding(8);
            this.comboBoxUARTParity.Name = "comboBoxUARTParity";
            this.comboBoxUARTParity.Size = new System.Drawing.Size(198, 32);
            this.comboBoxUARTParity.TabIndex = 72;
            // 
            // labelUARTParity
            // 
            this.labelUARTParity.AutoSize = true;
            this.labelUARTParity.Location = new System.Drawing.Point(55, 357);
            this.labelUARTParity.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelUARTParity.Name = "labelUARTParity";
            this.labelUARTParity.Size = new System.Drawing.Size(106, 24);
            this.labelUARTParity.TabIndex = 71;
            this.labelUARTParity.Text = "校验位：";
            // 
            // comboBoxUARTStopBits
            // 
            this.comboBoxUARTStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUARTStopBits.FormattingEnabled = true;
            this.comboBoxUARTStopBits.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.comboBoxUARTStopBits.Location = new System.Drawing.Point(235, 272);
            this.comboBoxUARTStopBits.Margin = new System.Windows.Forms.Padding(8);
            this.comboBoxUARTStopBits.Name = "comboBoxUARTStopBits";
            this.comboBoxUARTStopBits.Size = new System.Drawing.Size(198, 32);
            this.comboBoxUARTStopBits.TabIndex = 70;
            // 
            // labelUARTStopBits
            // 
            this.labelUARTStopBits.AutoSize = true;
            this.labelUARTStopBits.Location = new System.Drawing.Point(55, 277);
            this.labelUARTStopBits.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelUARTStopBits.Name = "labelUARTStopBits";
            this.labelUARTStopBits.Size = new System.Drawing.Size(106, 24);
            this.labelUARTStopBits.TabIndex = 69;
            this.labelUARTStopBits.Text = "停止位：";
            // 
            // comboBoxUARTDataBits
            // 
            this.comboBoxUARTDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUARTDataBits.FormattingEnabled = true;
            this.comboBoxUARTDataBits.Items.AddRange(new object[] {
            "8",
            "9"});
            this.comboBoxUARTDataBits.Location = new System.Drawing.Point(235, 192);
            this.comboBoxUARTDataBits.Margin = new System.Windows.Forms.Padding(8);
            this.comboBoxUARTDataBits.Name = "comboBoxUARTDataBits";
            this.comboBoxUARTDataBits.Size = new System.Drawing.Size(198, 32);
            this.comboBoxUARTDataBits.TabIndex = 68;
            // 
            // labelUARTDataBits
            // 
            this.labelUARTDataBits.AutoSize = true;
            this.labelUARTDataBits.Location = new System.Drawing.Point(55, 197);
            this.labelUARTDataBits.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelUARTDataBits.Name = "labelUARTDataBits";
            this.labelUARTDataBits.Size = new System.Drawing.Size(106, 24);
            this.labelUARTDataBits.TabIndex = 67;
            this.labelUARTDataBits.Text = "数据位：";
            // 
            // comboBoxUARTBaudRate
            // 
            this.comboBoxUARTBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUARTBaudRate.FormattingEnabled = true;
            this.comboBoxUARTBaudRate.Items.AddRange(new object[] {
            "4800  ",
            "9600  ",
            "14400 ",
            "19200 ",
            "38400 ",
            "57600 ",
            "76800 ",
            "115200"});
            this.comboBoxUARTBaudRate.Location = new System.Drawing.Point(235, 112);
            this.comboBoxUARTBaudRate.Margin = new System.Windows.Forms.Padding(8);
            this.comboBoxUARTBaudRate.Name = "comboBoxUARTBaudRate";
            this.comboBoxUARTBaudRate.Size = new System.Drawing.Size(198, 32);
            this.comboBoxUARTBaudRate.TabIndex = 66;
            // 
            // labelUARTBaudRate
            // 
            this.labelUARTBaudRate.AutoSize = true;
            this.labelUARTBaudRate.Location = new System.Drawing.Point(55, 117);
            this.labelUARTBaudRate.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelUARTBaudRate.Name = "labelUARTBaudRate";
            this.labelUARTBaudRate.Size = new System.Drawing.Size(106, 24);
            this.labelUARTBaudRate.TabIndex = 65;
            this.labelUARTBaudRate.Text = "波特率：";
            // 
            // comboBoxUARTPortNum
            // 
            this.comboBoxUARTPortNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUARTPortNum.FormattingEnabled = true;
            this.comboBoxUARTPortNum.Location = new System.Drawing.Point(235, 32);
            this.comboBoxUARTPortNum.Margin = new System.Windows.Forms.Padding(8);
            this.comboBoxUARTPortNum.Name = "comboBoxUARTPortNum";
            this.comboBoxUARTPortNum.Size = new System.Drawing.Size(198, 32);
            this.comboBoxUARTPortNum.TabIndex = 64;
            // 
            // labelUARTPortNum
            // 
            this.labelUARTPortNum.AutoSize = true;
            this.labelUARTPortNum.Location = new System.Drawing.Point(55, 37);
            this.labelUARTPortNum.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelUARTPortNum.Name = "labelUARTPortNum";
            this.labelUARTPortNum.Size = new System.Drawing.Size(106, 24);
            this.labelUARTPortNum.TabIndex = 63;
            this.labelUARTPortNum.Text = "串口号：";
            // 
            // UARTSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 545);
            this.Controls.Add(this.buttonUARTSetOpen);
            this.Controls.Add(this.comboBoxUARTParity);
            this.Controls.Add(this.labelUARTParity);
            this.Controls.Add(this.comboBoxUARTStopBits);
            this.Controls.Add(this.labelUARTStopBits);
            this.Controls.Add(this.comboBoxUARTDataBits);
            this.Controls.Add(this.labelUARTDataBits);
            this.Controls.Add(this.comboBoxUARTBaudRate);
            this.Controls.Add(this.labelUARTBaudRate);
            this.Controls.Add(this.comboBoxUARTPortNum);
            this.Controls.Add(this.labelUARTPortNum);
            this.Name = "UARTSetting";
            this.Text = "串口设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonUARTSetOpen;
        private System.Windows.Forms.ComboBox comboBoxUARTParity;
        private System.Windows.Forms.Label labelUARTParity;
        private System.Windows.Forms.ComboBox comboBoxUARTStopBits;
        private System.Windows.Forms.Label labelUARTStopBits;
        private System.Windows.Forms.ComboBox comboBoxUARTDataBits;
        private System.Windows.Forms.Label labelUARTDataBits;
        private System.Windows.Forms.ComboBox comboBoxUARTBaudRate;
        private System.Windows.Forms.Label labelUARTBaudRate;
        private System.Windows.Forms.ComboBox comboBoxUARTPortNum;
        private System.Windows.Forms.Label labelUARTPortNum;
    }
}