
namespace FinalTest
{
    partial class FormResp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormResp));
            this.labelRespRR = new System.Windows.Forms.Label();
            this.labelRespBPM = new System.Windows.Forms.Label();
            this.buttonRespSetOK = new System.Windows.Forms.Button();
            this.comboBoxRespGainSet = new System.Windows.Forms.ComboBox();
            this.labelRespGainSet = new System.Windows.Forms.Label();
            this.toolStripModeSwitch = new System.Windows.Forms.ToolStrip();
            this.toolStripLabelRespModeSwitch = new System.Windows.Forms.ToolStripLabel();
            this.labelRespCN = new System.Windows.Forms.Label();
            this.dataGridViewResp = new System.Windows.Forms.DataGridView();
            this.toolStripModeSwitch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResp)).BeginInit();
            this.SuspendLayout();
            // 
            // labelRespRR
            // 
            this.labelRespRR.AutoSize = true;
            this.labelRespRR.BackColor = System.Drawing.Color.Transparent;
            this.labelRespRR.Font = new System.Drawing.Font("宋体", 30F);
            this.labelRespRR.ForeColor = System.Drawing.Color.Black;
            this.labelRespRR.Location = new System.Drawing.Point(199, 102);
            this.labelRespRR.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelRespRR.Name = "labelRespRR";
            this.labelRespRR.Size = new System.Drawing.Size(114, 80);
            this.labelRespRR.TabIndex = 248;
            this.labelRespRR.Text = "--";
            // 
            // labelRespBPM
            // 
            this.labelRespBPM.AutoSize = true;
            this.labelRespBPM.BackColor = System.Drawing.Color.Transparent;
            this.labelRespBPM.Font = new System.Drawing.Font("宋体", 12F);
            this.labelRespBPM.ForeColor = System.Drawing.Color.Black;
            this.labelRespBPM.Location = new System.Drawing.Point(417, 84);
            this.labelRespBPM.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelRespBPM.Name = "labelRespBPM";
            this.labelRespBPM.Size = new System.Drawing.Size(63, 33);
            this.labelRespBPM.TabIndex = 247;
            this.labelRespBPM.Text = "bpm";
            // 
            // buttonRespSetOK
            // 
            this.buttonRespSetOK.Location = new System.Drawing.Point(398, 195);
            this.buttonRespSetOK.Margin = new System.Windows.Forms.Padding(6);
            this.buttonRespSetOK.Name = "buttonRespSetOK";
            this.buttonRespSetOK.Size = new System.Drawing.Size(106, 40);
            this.buttonRespSetOK.TabIndex = 251;
            this.buttonRespSetOK.Text = "确定";
            this.buttonRespSetOK.UseVisualStyleBackColor = true;
            this.buttonRespSetOK.Click += new System.EventHandler(this.buttonRespSetOK_Click);
            // 
            // comboBoxRespGainSet
            // 
            this.comboBoxRespGainSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRespGainSet.FormattingEnabled = true;
            this.comboBoxRespGainSet.Items.AddRange(new object[] {
            "X0.25",
            "X0.5",
            "X1",
            "X2",
            "X4"});
            this.comboBoxRespGainSet.Location = new System.Drawing.Point(171, 226);
            this.comboBoxRespGainSet.Margin = new System.Windows.Forms.Padding(6);
            this.comboBoxRespGainSet.Name = "comboBoxRespGainSet";
            this.comboBoxRespGainSet.Size = new System.Drawing.Size(142, 32);
            this.comboBoxRespGainSet.TabIndex = 250;
            // 
            // labelRespGainSet
            // 
            this.labelRespGainSet.AutoSize = true;
            this.labelRespGainSet.Location = new System.Drawing.Point(13, 230);
            this.labelRespGainSet.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelRespGainSet.Name = "labelRespGainSet";
            this.labelRespGainSet.Size = new System.Drawing.Size(106, 24);
            this.labelRespGainSet.TabIndex = 249;
            this.labelRespGainSet.Text = "增益设置";
            // 
            // toolStripModeSwitch
            // 
            this.toolStripModeSwitch.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripModeSwitch.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelRespModeSwitch});
            this.toolStripModeSwitch.Location = new System.Drawing.Point(0, 0);
            this.toolStripModeSwitch.Name = "toolStripModeSwitch";
            this.toolStripModeSwitch.Size = new System.Drawing.Size(2564, 37);
            this.toolStripModeSwitch.TabIndex = 255;
            this.toolStripModeSwitch.Text = "模式切换";
            // 
            // toolStripLabelRespModeSwitch
            // 
            this.toolStripLabelRespModeSwitch.Name = "toolStripLabelRespModeSwitch";
            this.toolStripLabelRespModeSwitch.Size = new System.Drawing.Size(110, 31);
            this.toolStripLabelRespModeSwitch.Text = "模式切换";
            this.toolStripLabelRespModeSwitch.Click += new System.EventHandler(this.toolStripLabelRespModeSwitch_Click);
            // 
            // labelRespCN
            // 
            this.labelRespCN.AutoSize = true;
            this.labelRespCN.BackColor = System.Drawing.Color.Transparent;
            this.labelRespCN.Font = new System.Drawing.Font("宋体", 14F);
            this.labelRespCN.ForeColor = System.Drawing.Color.Black;
            this.labelRespCN.Location = new System.Drawing.Point(13, 117);
            this.labelRespCN.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelRespCN.Name = "labelRespCN";
            this.labelRespCN.Size = new System.Drawing.Size(169, 38);
            this.labelRespCN.TabIndex = 246;
            this.labelRespCN.Text = "呼吸频率";
            // 
            // dataGridViewResp
            // 
            this.dataGridViewResp.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewResp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewResp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewResp.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewResp.Location = new System.Drawing.Point(353, 60);
            this.dataGridViewResp.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridViewResp.Name = "dataGridViewResp";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewResp.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewResp.RowHeadersWidth = 51;
            this.dataGridViewResp.RowTemplate.Height = 23;
            this.dataGridViewResp.Size = new System.Drawing.Size(2160, 270);
            this.dataGridViewResp.TabIndex = 254;
            // 
            // FormResp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2564, 385);
            this.Controls.Add(this.toolStripModeSwitch);
            this.Controls.Add(this.dataGridViewResp);
            this.Controls.Add(this.buttonRespSetOK);
            this.Controls.Add(this.comboBoxRespGainSet);
            this.Controls.Add(this.labelRespGainSet);
            this.Controls.Add(this.labelRespRR);
            this.Controls.Add(this.labelRespBPM);
            this.Controls.Add(this.labelRespCN);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormResp";
            this.Text = "呼吸";
            this.Load += new System.EventHandler(this.RespForm_Load);
            this.toolStripModeSwitch.ResumeLayout(false);
            this.toolStripModeSwitch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRespRR;
        private System.Windows.Forms.Label labelRespBPM;
        private System.Windows.Forms.Button buttonRespSetOK;
        private System.Windows.Forms.ComboBox comboBoxRespGainSet;
        private System.Windows.Forms.Label labelRespGainSet;
        private System.Windows.Forms.ToolStrip toolStripModeSwitch;
        private System.Windows.Forms.ToolStripLabel toolStripLabelRespModeSwitch;
        private System.Windows.Forms.Label labelRespCN;
        private System.Windows.Forms.DataGridView dataGridViewResp;
    }
}