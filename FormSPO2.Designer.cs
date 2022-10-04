
namespace FinalTest
{
    partial class FormSPO2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelSPO2PrbOff = new System.Windows.Forms.Label();
            this.labelSPO2FingerOff = new System.Windows.Forms.Label();
            this.label1SPO2PRCN = new System.Windows.Forms.Label();
            this.labelSPO2PR = new System.Windows.Forms.Label();
            this.labelSPO2Percent = new System.Windows.Forms.Label();
            this.labelSPO2Data = new System.Windows.Forms.Label();
            this.labelSPO2CN = new System.Windows.Forms.Label();
            this.buttonSPO2Set = new System.Windows.Forms.Button();
            this.labelSPO2BPM = new System.Windows.Forms.Label();
            this.buttonSPO2SetCancel = new System.Windows.Forms.Button();
            this.buttonSPO2SetOK = new System.Windows.Forms.Button();
            this.comboBoxSPO2Sens = new System.Windows.Forms.ComboBox();
            this.labelSPO2Sens = new System.Windows.Forms.Label();
            this.dataGridViewSPO2 = new System.Windows.Forms.DataGridView();
            this.buttonSPO2Setup = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabelSPO2ModeSwitch = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSPO2)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelSPO2PrbOff
            // 
            this.labelSPO2PrbOff.AutoSize = true;
            this.labelSPO2PrbOff.BackColor = System.Drawing.Color.Black;
            this.labelSPO2PrbOff.Font = new System.Drawing.Font("宋体", 12F);
            this.labelSPO2PrbOff.ForeColor = System.Drawing.Color.Red;
            this.labelSPO2PrbOff.Location = new System.Drawing.Point(342, 315);
            this.labelSPO2PrbOff.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelSPO2PrbOff.Name = "labelSPO2PrbOff";
            this.labelSPO2PrbOff.Size = new System.Drawing.Size(143, 33);
            this.labelSPO2PrbOff.TabIndex = 249;
            this.labelSPO2PrbOff.Text = "探头脱落";
            // 
            // labelSPO2FingerOff
            // 
            this.labelSPO2FingerOff.AutoSize = true;
            this.labelSPO2FingerOff.BackColor = System.Drawing.Color.Black;
            this.labelSPO2FingerOff.Font = new System.Drawing.Font("宋体", 12F);
            this.labelSPO2FingerOff.ForeColor = System.Drawing.Color.Red;
            this.labelSPO2FingerOff.Location = new System.Drawing.Point(112, 315);
            this.labelSPO2FingerOff.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelSPO2FingerOff.Name = "labelSPO2FingerOff";
            this.labelSPO2FingerOff.Size = new System.Drawing.Size(143, 33);
            this.labelSPO2FingerOff.TabIndex = 248;
            this.labelSPO2FingerOff.Text = "手指脱落";
            // 
            // label1SPO2PRCN
            // 
            this.label1SPO2PRCN.AutoSize = true;
            this.label1SPO2PRCN.BackColor = System.Drawing.Color.Black;
            this.label1SPO2PRCN.Font = new System.Drawing.Font("宋体", 14F);
            this.label1SPO2PRCN.ForeColor = System.Drawing.Color.Cyan;
            this.label1SPO2PRCN.Location = new System.Drawing.Point(326, 99);
            this.label1SPO2PRCN.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1SPO2PRCN.Name = "label1SPO2PRCN";
            this.label1SPO2PRCN.Size = new System.Drawing.Size(93, 38);
            this.label1SPO2PRCN.TabIndex = 247;
            this.label1SPO2PRCN.Text = "脉率";
            // 
            // labelSPO2PR
            // 
            this.labelSPO2PR.AutoSize = true;
            this.labelSPO2PR.BackColor = System.Drawing.Color.Black;
            this.labelSPO2PR.Font = new System.Drawing.Font("宋体", 30F);
            this.labelSPO2PR.ForeColor = System.Drawing.Color.Cyan;
            this.labelSPO2PR.Location = new System.Drawing.Point(318, 180);
            this.labelSPO2PR.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelSPO2PR.Name = "labelSPO2PR";
            this.labelSPO2PR.Size = new System.Drawing.Size(114, 80);
            this.labelSPO2PR.TabIndex = 246;
            this.labelSPO2PR.Text = "--";
            this.labelSPO2PR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelSPO2Percent
            // 
            this.labelSPO2Percent.AutoSize = true;
            this.labelSPO2Percent.BackColor = System.Drawing.Color.Black;
            this.labelSPO2Percent.Font = new System.Drawing.Font("宋体", 25F);
            this.labelSPO2Percent.ForeColor = System.Drawing.Color.Cyan;
            this.labelSPO2Percent.Location = new System.Drawing.Point(228, 188);
            this.labelSPO2Percent.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelSPO2Percent.Name = "labelSPO2Percent";
            this.labelSPO2Percent.Size = new System.Drawing.Size(63, 67);
            this.labelSPO2Percent.TabIndex = 245;
            this.labelSPO2Percent.Text = "%";
            // 
            // labelSPO2Data
            // 
            this.labelSPO2Data.AutoSize = true;
            this.labelSPO2Data.BackColor = System.Drawing.Color.Black;
            this.labelSPO2Data.Font = new System.Drawing.Font("宋体", 30F);
            this.labelSPO2Data.ForeColor = System.Drawing.Color.Cyan;
            this.labelSPO2Data.Location = new System.Drawing.Point(126, 180);
            this.labelSPO2Data.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelSPO2Data.Name = "labelSPO2Data";
            this.labelSPO2Data.Size = new System.Drawing.Size(114, 80);
            this.labelSPO2Data.TabIndex = 244;
            this.labelSPO2Data.Text = "--";
            // 
            // labelSPO2CN
            // 
            this.labelSPO2CN.AutoSize = true;
            this.labelSPO2CN.BackColor = System.Drawing.Color.Black;
            this.labelSPO2CN.Font = new System.Drawing.Font("宋体", 14F);
            this.labelSPO2CN.ForeColor = System.Drawing.Color.Cyan;
            this.labelSPO2CN.Location = new System.Drawing.Point(136, 99);
            this.labelSPO2CN.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelSPO2CN.Name = "labelSPO2CN";
            this.labelSPO2CN.Size = new System.Drawing.Size(93, 38);
            this.labelSPO2CN.TabIndex = 243;
            this.labelSPO2CN.Text = "血氧";
            // 
            // buttonSPO2Set
            // 
            this.buttonSPO2Set.BackColor = System.Drawing.Color.Black;
            this.buttonSPO2Set.Location = new System.Drawing.Point(80, 70);
            this.buttonSPO2Set.Margin = new System.Windows.Forms.Padding(6);
            this.buttonSPO2Set.Name = "buttonSPO2Set";
            this.buttonSPO2Set.Size = new System.Drawing.Size(462, 307);
            this.buttonSPO2Set.TabIndex = 242;
            this.buttonSPO2Set.Text = "button3";
            this.buttonSPO2Set.UseVisualStyleBackColor = false;
            // 
            // labelSPO2BPM
            // 
            this.labelSPO2BPM.AutoSize = true;
            this.labelSPO2BPM.BackColor = System.Drawing.Color.Black;
            this.labelSPO2BPM.Font = new System.Drawing.Font("宋体", 20F);
            this.labelSPO2BPM.ForeColor = System.Drawing.Color.Cyan;
            this.labelSPO2BPM.Location = new System.Drawing.Point(421, 188);
            this.labelSPO2BPM.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelSPO2BPM.Name = "labelSPO2BPM";
            this.labelSPO2BPM.Size = new System.Drawing.Size(104, 54);
            this.labelSPO2BPM.TabIndex = 250;
            this.labelSPO2BPM.Text = "bpm";
            // 
            // buttonSPO2SetCancel
            // 
            this.buttonSPO2SetCancel.Location = new System.Drawing.Point(836, 277);
            this.buttonSPO2SetCancel.Margin = new System.Windows.Forms.Padding(6);
            this.buttonSPO2SetCancel.Name = "buttonSPO2SetCancel";
            this.buttonSPO2SetCancel.Size = new System.Drawing.Size(116, 48);
            this.buttonSPO2SetCancel.TabIndex = 254;
            this.buttonSPO2SetCancel.Text = "取消";
            this.buttonSPO2SetCancel.UseVisualStyleBackColor = true;
            this.buttonSPO2SetCancel.Click += new System.EventHandler(this.buttonSPO2SetCancel_Click);
            // 
            // buttonSPO2SetOK
            // 
            this.buttonSPO2SetOK.Location = new System.Drawing.Point(660, 277);
            this.buttonSPO2SetOK.Margin = new System.Windows.Forms.Padding(6);
            this.buttonSPO2SetOK.Name = "buttonSPO2SetOK";
            this.buttonSPO2SetOK.Size = new System.Drawing.Size(116, 48);
            this.buttonSPO2SetOK.TabIndex = 253;
            this.buttonSPO2SetOK.Text = "确定";
            this.buttonSPO2SetOK.UseVisualStyleBackColor = true;
            this.buttonSPO2SetOK.Click += new System.EventHandler(this.buttonSPO2SetOK_Click);
            // 
            // comboBoxSPO2Sens
            // 
            this.comboBoxSPO2Sens.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSPO2Sens.FormattingEnabled = true;
            this.comboBoxSPO2Sens.Items.AddRange(new object[] {
            "高",
            "中",
            "低"});
            this.comboBoxSPO2Sens.Location = new System.Drawing.Point(836, 191);
            this.comboBoxSPO2Sens.Margin = new System.Windows.Forms.Padding(6);
            this.comboBoxSPO2Sens.Name = "comboBoxSPO2Sens";
            this.comboBoxSPO2Sens.Size = new System.Drawing.Size(126, 32);
            this.comboBoxSPO2Sens.TabIndex = 252;
            // 
            // labelSPO2Sens
            // 
            this.labelSPO2Sens.AutoSize = true;
            this.labelSPO2Sens.Location = new System.Drawing.Point(644, 197);
            this.labelSPO2Sens.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelSPO2Sens.Name = "labelSPO2Sens";
            this.labelSPO2Sens.Size = new System.Drawing.Size(154, 24);
            this.labelSPO2Sens.TabIndex = 251;
            this.labelSPO2Sens.Text = "计算灵敏度：";
            // 
            // dataGridViewSPO2
            // 
            this.dataGridViewSPO2.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSPO2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewSPO2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewSPO2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewSPO2.Location = new System.Drawing.Point(24, 477);
            this.dataGridViewSPO2.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridViewSPO2.Name = "dataGridViewSPO2";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSPO2.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewSPO2.RowHeadersWidth = 51;
            this.dataGridViewSPO2.RowTemplate.Height = 23;
            this.dataGridViewSPO2.Size = new System.Drawing.Size(2160, 270);
            this.dataGridViewSPO2.TabIndex = 256;
            // 
            // buttonSPO2Setup
            // 
            this.buttonSPO2Setup.BackColor = System.Drawing.Color.Black;
            this.buttonSPO2Setup.FlatAppearance.BorderSize = 0;
            this.buttonSPO2Setup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSPO2Setup.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSPO2Setup.ForeColor = System.Drawing.Color.Aqua;
            this.buttonSPO2Setup.Location = new System.Drawing.Point(24, 440);
            this.buttonSPO2Setup.Margin = new System.Windows.Forms.Padding(6);
            this.buttonSPO2Setup.Name = "buttonSPO2Setup";
            this.buttonSPO2Setup.Size = new System.Drawing.Size(2160, 40);
            this.buttonSPO2Setup.TabIndex = 255;
            this.buttonSPO2Setup.Text = "SPO2";
            this.buttonSPO2Setup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSPO2Setup.UseVisualStyleBackColor = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelSPO2ModeSwitch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(2246, 50);
            this.toolStrip1.TabIndex = 257;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabelSPO2ModeSwitch
            // 
            this.toolStripLabelSPO2ModeSwitch.Name = "toolStripLabelSPO2ModeSwitch";
            this.toolStripLabelSPO2ModeSwitch.Size = new System.Drawing.Size(110, 44);
            this.toolStripLabelSPO2ModeSwitch.Text = "模式切换";
            // 
            // SPO2Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2246, 799);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dataGridViewSPO2);
            this.Controls.Add(this.buttonSPO2Setup);
            this.Controls.Add(this.buttonSPO2SetCancel);
            this.Controls.Add(this.buttonSPO2SetOK);
            this.Controls.Add(this.comboBoxSPO2Sens);
            this.Controls.Add(this.labelSPO2Sens);
            this.Controls.Add(this.labelSPO2BPM);
            this.Controls.Add(this.labelSPO2PrbOff);
            this.Controls.Add(this.labelSPO2FingerOff);
            this.Controls.Add(this.label1SPO2PRCN);
            this.Controls.Add(this.labelSPO2PR);
            this.Controls.Add(this.labelSPO2Percent);
            this.Controls.Add(this.labelSPO2Data);
            this.Controls.Add(this.labelSPO2CN);
            this.Controls.Add(this.buttonSPO2Set);
            this.Name = "SPO2Form";
            this.Text = "血氧";
            this.Load += new System.EventHandler(this.SPO2Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSPO2)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSPO2PrbOff;
        private System.Windows.Forms.Label labelSPO2FingerOff;
        private System.Windows.Forms.Label label1SPO2PRCN;
        private System.Windows.Forms.Label labelSPO2PR;
        private System.Windows.Forms.Label labelSPO2Percent;
        private System.Windows.Forms.Label labelSPO2Data;
        private System.Windows.Forms.Label labelSPO2CN;
        private System.Windows.Forms.Button buttonSPO2Set;
        private System.Windows.Forms.Label labelSPO2BPM;
        private System.Windows.Forms.Button buttonSPO2SetCancel;
        private System.Windows.Forms.Button buttonSPO2SetOK;
        private System.Windows.Forms.ComboBox comboBoxSPO2Sens;
        private System.Windows.Forms.Label labelSPO2Sens;
        private System.Windows.Forms.DataGridView dataGridViewSPO2;
        private System.Windows.Forms.Button buttonSPO2Setup;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabelSPO2ModeSwitch;
    }
}