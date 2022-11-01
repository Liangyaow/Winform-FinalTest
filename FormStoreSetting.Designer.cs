
namespace FinalTest
{
    partial class FormStoreSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStoreSetting));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbxSaveFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxUARTData = new System.Windows.Forms.CheckBox();
            this.checkBoxSPO2Wave = new System.Windows.Forms.CheckBox();
            this.checkBoxRespWave = new System.Windows.Forms.CheckBox();
            this.checkBoxNIBPData = new System.Windows.Forms.CheckBox();
            this.buttonStoreDataCancel = new System.Windows.Forms.Button();
            this.buttonStartStore = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbxSaveFolder);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.checkBoxUARTData);
            this.groupBox1.Controls.Add(this.checkBoxSPO2Wave);
            this.groupBox1.Controls.Add(this.checkBoxRespWave);
            this.groupBox1.Controls.Add(this.checkBoxNIBPData);
            this.groupBox1.Location = new System.Drawing.Point(99, 32);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(592, 334);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            // 
            // tbxSaveFolder
            // 
            this.tbxSaveFolder.Location = new System.Drawing.Point(46, 253);
            this.tbxSaveFolder.Margin = new System.Windows.Forms.Padding(6);
            this.tbxSaveFolder.Name = "tbxSaveFolder";
            this.tbxSaveFolder.ReadOnly = true;
            this.tbxSaveFolder.Size = new System.Drawing.Size(470, 35);
            this.tbxSaveFolder.TabIndex = 34;
            this.tbxSaveFolder.Click += new System.EventHandler(this.tbxSaveFolder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 222);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 24);
            this.label1.TabIndex = 33;
            this.label1.Text = "存储路径：";
            // 
            // checkBoxUARTData
            // 
            this.checkBoxUARTData.AutoSize = true;
            this.checkBoxUARTData.Location = new System.Drawing.Point(46, 70);
            this.checkBoxUARTData.Margin = new System.Windows.Forms.Padding(6);
            this.checkBoxUARTData.Name = "checkBoxUARTData";
            this.checkBoxUARTData.Size = new System.Drawing.Size(138, 28);
            this.checkBoxUARTData.TabIndex = 32;
            this.checkBoxUARTData.Text = "UART数据";
            this.checkBoxUARTData.UseVisualStyleBackColor = true;
            // 
            // checkBoxSPO2Wave
            // 
            this.checkBoxSPO2Wave.AutoSize = true;
            this.checkBoxSPO2Wave.Location = new System.Drawing.Point(376, 136);
            this.checkBoxSPO2Wave.Margin = new System.Windows.Forms.Padding(6);
            this.checkBoxSPO2Wave.Name = "checkBoxSPO2Wave";
            this.checkBoxSPO2Wave.Size = new System.Drawing.Size(138, 28);
            this.checkBoxSPO2Wave.TabIndex = 31;
            this.checkBoxSPO2Wave.Text = "SPO2波形";
            this.checkBoxSPO2Wave.UseVisualStyleBackColor = true;
            // 
            // checkBoxRespWave
            // 
            this.checkBoxRespWave.AutoSize = true;
            this.checkBoxRespWave.Location = new System.Drawing.Point(376, 72);
            this.checkBoxRespWave.Margin = new System.Windows.Forms.Padding(6);
            this.checkBoxRespWave.Name = "checkBoxRespWave";
            this.checkBoxRespWave.Size = new System.Drawing.Size(138, 28);
            this.checkBoxRespWave.TabIndex = 30;
            this.checkBoxRespWave.Text = "RESP波形";
            this.checkBoxRespWave.UseVisualStyleBackColor = true;
            // 
            // checkBoxNIBPData
            // 
            this.checkBoxNIBPData.AutoSize = true;
            this.checkBoxNIBPData.Location = new System.Drawing.Point(46, 136);
            this.checkBoxNIBPData.Margin = new System.Windows.Forms.Padding(6);
            this.checkBoxNIBPData.Name = "checkBoxNIBPData";
            this.checkBoxNIBPData.Size = new System.Drawing.Size(126, 28);
            this.checkBoxNIBPData.TabIndex = 29;
            this.checkBoxNIBPData.Text = "ECG波形";
            this.checkBoxNIBPData.UseVisualStyleBackColor = true;
            // 
            // buttonStoreDataCancel
            // 
            this.buttonStoreDataCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonStoreDataCancel.Location = new System.Drawing.Point(415, 408);
            this.buttonStoreDataCancel.Margin = new System.Windows.Forms.Padding(8);
            this.buttonStoreDataCancel.Name = "buttonStoreDataCancel";
            this.buttonStoreDataCancel.Size = new System.Drawing.Size(150, 61);
            this.buttonStoreDataCancel.TabIndex = 40;
            this.buttonStoreDataCancel.Text = "取消";
            this.buttonStoreDataCancel.UseVisualStyleBackColor = true;
            this.buttonStoreDataCancel.Click += new System.EventHandler(this.buttonStoreDataCancel_Click);
            // 
            // buttonStartStore
            // 
            this.buttonStartStore.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonStartStore.Location = new System.Drawing.Point(193, 408);
            this.buttonStartStore.Margin = new System.Windows.Forms.Padding(8);
            this.buttonStartStore.Name = "buttonStartStore";
            this.buttonStartStore.Size = new System.Drawing.Size(150, 61);
            this.buttonStartStore.TabIndex = 39;
            this.buttonStartStore.Text = "确定";
            this.buttonStartStore.UseVisualStyleBackColor = true;
            // 
            // FormStoreSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 534);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonStoreDataCancel);
            this.Controls.Add(this.buttonStartStore);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormStoreSetting";
            this.Text = "存储设置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxSaveFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxUARTData;
        private System.Windows.Forms.CheckBox checkBoxSPO2Wave;
        private System.Windows.Forms.CheckBox checkBoxRespWave;
        private System.Windows.Forms.CheckBox checkBoxNIBPData;
        private System.Windows.Forms.Button buttonStoreDataCancel;
        private System.Windows.Forms.Button buttonStartStore;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}