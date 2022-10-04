
namespace FinalTest
{
    partial class FormModeSwitch
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
            this.rbDisplayData = new System.Windows.Forms.RadioButton();
            this.rbLoadData = new System.Windows.Forms.RadioButton();
            this.rbRealData = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.tbxUARTFileName = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbDisplayData
            // 
            this.rbDisplayData.AutoSize = true;
            this.rbDisplayData.Location = new System.Drawing.Point(544, 48);
            this.rbDisplayData.Margin = new System.Windows.Forms.Padding(6);
            this.rbDisplayData.Name = "rbDisplayData";
            this.rbDisplayData.Size = new System.Drawing.Size(137, 28);
            this.rbDisplayData.TabIndex = 36;
            this.rbDisplayData.TabStop = true;
            this.rbDisplayData.Text = "演示模式";
            this.rbDisplayData.UseVisualStyleBackColor = true;
            this.rbDisplayData.CheckedChanged += new System.EventHandler(this.rbDisplayData_CheckedChanged);
            // 
            // rbLoadData
            // 
            this.rbLoadData.AutoSize = true;
            this.rbLoadData.Location = new System.Drawing.Point(300, 48);
            this.rbLoadData.Margin = new System.Windows.Forms.Padding(6);
            this.rbLoadData.Name = "rbLoadData";
            this.rbLoadData.Size = new System.Drawing.Size(137, 28);
            this.rbLoadData.TabIndex = 35;
            this.rbLoadData.Text = "回放模式";
            this.rbLoadData.UseVisualStyleBackColor = true;
            // 
            // rbRealData
            // 
            this.rbRealData.AutoSize = true;
            this.rbRealData.Checked = true;
            this.rbRealData.Location = new System.Drawing.Point(56, 48);
            this.rbRealData.Margin = new System.Windows.Forms.Padding(6);
            this.rbRealData.Name = "rbRealData";
            this.rbRealData.Size = new System.Drawing.Size(137, 28);
            this.rbRealData.TabIndex = 34;
            this.rbRealData.TabStop = true;
            this.rbRealData.Text = "监护模式";
            this.rbRealData.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(458, 356);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 46);
            this.btnCancel.TabIndex = 33;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(152, 356);
            this.btnOk.Margin = new System.Windows.Forms.Padding(6);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(150, 46);
            this.btnOk.TabIndex = 32;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOpenFile);
            this.groupBox1.Controls.Add(this.tbxUARTFileName);
            this.groupBox1.Location = new System.Drawing.Point(28, 144);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(744, 178);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "加载数据";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(468, 66);
            this.btnOpenFile.Margin = new System.Windows.Forms.Padding(6);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(150, 46);
            this.btnOpenFile.TabIndex = 8;
            this.btnOpenFile.Text = "打开";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // tbxUARTFileName
            // 
            this.tbxUARTFileName.Location = new System.Drawing.Point(28, 70);
            this.tbxUARTFileName.Margin = new System.Windows.Forms.Padding(6);
            this.tbxUARTFileName.Name = "tbxUARTFileName";
            this.tbxUARTFileName.ReadOnly = true;
            this.tbxUARTFileName.Size = new System.Drawing.Size(424, 35);
            this.tbxUARTFileName.TabIndex = 7;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FormModeSwitch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rbDisplayData);
            this.Controls.Add(this.rbLoadData);
            this.Controls.Add(this.rbRealData);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormModeSwitch";
            this.Text = "模式切换";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbDisplayData;
        private System.Windows.Forms.RadioButton rbLoadData;
        private System.Windows.Forms.RadioButton rbRealData;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.TextBox tbxUARTFileName;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}