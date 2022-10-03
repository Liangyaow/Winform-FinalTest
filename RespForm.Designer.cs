
namespace FinalTest
{
    partial class RespForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelRespRR = new System.Windows.Forms.Label();
            this.labelRespBPM = new System.Windows.Forms.Label();
            this.labelRespCN = new System.Windows.Forms.Label();
            this.buttonRespSet = new System.Windows.Forms.Button();
            this.buttonRespSetOK = new System.Windows.Forms.Button();
            this.comboBoxRespGainSet = new System.Windows.Forms.ComboBox();
            this.labelRespGainSet = new System.Windows.Forms.Label();
            this.buttonRespSetCancel = new System.Windows.Forms.Button();
            this.dataGridViewResp = new System.Windows.Forms.DataGridView();
            this.buttonRespSetup = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResp)).BeginInit();
            this.SuspendLayout();
            // 
            // labelRespRR
            // 
            this.labelRespRR.AutoSize = true;
            this.labelRespRR.BackColor = System.Drawing.Color.Black;
            this.labelRespRR.Font = new System.Drawing.Font("宋体", 30F);
            this.labelRespRR.ForeColor = System.Drawing.Color.Yellow;
            this.labelRespRR.Location = new System.Drawing.Point(257, 220);
            this.labelRespRR.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelRespRR.Name = "labelRespRR";
            this.labelRespRR.Size = new System.Drawing.Size(114, 80);
            this.labelRespRR.TabIndex = 248;
            this.labelRespRR.Text = "--";
            // 
            // labelRespBPM
            // 
            this.labelRespBPM.AutoSize = true;
            this.labelRespBPM.BackColor = System.Drawing.Color.Black;
            this.labelRespBPM.Font = new System.Drawing.Font("宋体", 12F);
            this.labelRespBPM.ForeColor = System.Drawing.Color.Yellow;
            this.labelRespBPM.Location = new System.Drawing.Point(349, 115);
            this.labelRespBPM.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelRespBPM.Name = "labelRespBPM";
            this.labelRespBPM.Size = new System.Drawing.Size(63, 33);
            this.labelRespBPM.TabIndex = 247;
            this.labelRespBPM.Text = "bpm";
            // 
            // labelRespCN
            // 
            this.labelRespCN.AutoSize = true;
            this.labelRespCN.BackColor = System.Drawing.Color.Black;
            this.labelRespCN.Font = new System.Drawing.Font("宋体", 14F);
            this.labelRespCN.ForeColor = System.Drawing.Color.Yellow;
            this.labelRespCN.Location = new System.Drawing.Point(229, 115);
            this.labelRespCN.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelRespCN.Name = "labelRespCN";
            this.labelRespCN.Size = new System.Drawing.Size(93, 38);
            this.labelRespCN.TabIndex = 246;
            this.labelRespCN.Text = "呼吸";
            // 
            // buttonRespSet
            // 
            this.buttonRespSet.BackColor = System.Drawing.Color.Black;
            this.buttonRespSet.Font = new System.Drawing.Font("宋体", 20F);
            this.buttonRespSet.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonRespSet.Location = new System.Drawing.Point(203, 86);
            this.buttonRespSet.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.buttonRespSet.Name = "buttonRespSet";
            this.buttonRespSet.Size = new System.Drawing.Size(230, 302);
            this.buttonRespSet.TabIndex = 245;
            this.buttonRespSet.UseVisualStyleBackColor = false;
            // 
            // buttonRespSetOK
            // 
            this.buttonRespSetOK.Location = new System.Drawing.Point(588, 243);
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
            this.comboBoxRespGainSet.Location = new System.Drawing.Point(746, 169);
            this.comboBoxRespGainSet.Margin = new System.Windows.Forms.Padding(6);
            this.comboBoxRespGainSet.Name = "comboBoxRespGainSet";
            this.comboBoxRespGainSet.Size = new System.Drawing.Size(142, 32);
            this.comboBoxRespGainSet.TabIndex = 250;
            // 
            // labelRespGainSet
            // 
            this.labelRespGainSet.AutoSize = true;
            this.labelRespGainSet.Location = new System.Drawing.Point(588, 176);
            this.labelRespGainSet.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelRespGainSet.Name = "labelRespGainSet";
            this.labelRespGainSet.Size = new System.Drawing.Size(106, 24);
            this.labelRespGainSet.TabIndex = 249;
            this.labelRespGainSet.Text = "增益设置";
            // 
            // buttonRespSetCancel
            // 
            this.buttonRespSetCancel.Location = new System.Drawing.Point(746, 243);
            this.buttonRespSetCancel.Margin = new System.Windows.Forms.Padding(6);
            this.buttonRespSetCancel.Name = "buttonRespSetCancel";
            this.buttonRespSetCancel.Size = new System.Drawing.Size(100, 40);
            this.buttonRespSetCancel.TabIndex = 252;
            this.buttonRespSetCancel.Text = "取消";
            this.buttonRespSetCancel.UseVisualStyleBackColor = true;
            this.buttonRespSetCancel.Click += new System.EventHandler(this.buttonRespSetCancel_Click);
            // 
            // dataGridViewResp
            // 
            this.dataGridViewResp.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewResp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridViewResp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewResp.DefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridViewResp.Location = new System.Drawing.Point(15, 712);
            this.dataGridViewResp.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridViewResp.Name = "dataGridViewResp";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewResp.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridViewResp.RowHeadersWidth = 51;
            this.dataGridViewResp.RowTemplate.Height = 23;
            this.dataGridViewResp.Size = new System.Drawing.Size(2160, 270);
            this.dataGridViewResp.TabIndex = 254;
            // 
            // buttonRespSetup
            // 
            this.buttonRespSetup.BackColor = System.Drawing.Color.Black;
            this.buttonRespSetup.FlatAppearance.BorderSize = 0;
            this.buttonRespSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRespSetup.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonRespSetup.ForeColor = System.Drawing.Color.Yellow;
            this.buttonRespSetup.Location = new System.Drawing.Point(15, 675);
            this.buttonRespSetup.Margin = new System.Windows.Forms.Padding(6);
            this.buttonRespSetup.Name = "buttonRespSetup";
            this.buttonRespSetup.Size = new System.Drawing.Size(2160, 40);
            this.buttonRespSetup.TabIndex = 253;
            this.buttonRespSetup.Text = "Resp";
            this.buttonRespSetup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRespSetup.UseVisualStyleBackColor = false;
            // 
            // RespForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2254, 1139);
            this.Controls.Add(this.dataGridViewResp);
            this.Controls.Add(this.buttonRespSetup);
            this.Controls.Add(this.buttonRespSetOK);
            this.Controls.Add(this.comboBoxRespGainSet);
            this.Controls.Add(this.labelRespGainSet);
            this.Controls.Add(this.buttonRespSetCancel);
            this.Controls.Add(this.labelRespRR);
            this.Controls.Add(this.labelRespBPM);
            this.Controls.Add(this.labelRespCN);
            this.Controls.Add(this.buttonRespSet);
            this.Name = "RespForm";
            this.Load += new System.EventHandler(this.RespForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRespRR;
        private System.Windows.Forms.Label labelRespBPM;
        private System.Windows.Forms.Label labelRespCN;
        private System.Windows.Forms.Button buttonRespSet;
        private System.Windows.Forms.Button buttonRespSetOK;
        private System.Windows.Forms.ComboBox comboBoxRespGainSet;
        private System.Windows.Forms.Label labelRespGainSet;
        private System.Windows.Forms.Button buttonRespSetCancel;
        private System.Windows.Forms.DataGridView dataGridViewResp;
        private System.Windows.Forms.Button buttonRespSetup;
    }
}