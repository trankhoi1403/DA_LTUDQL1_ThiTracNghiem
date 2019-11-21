namespace ThiTracNghiem
{
    partial class ThemCauHoi
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCauHoi = new System.Windows.Forms.TextBox();
            this.btnThemCauHoi = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDSDA = new System.Windows.Forms.DataGridView();
            this.cbDSCH = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cklbCapDo = new System.Windows.Forms.CheckedListBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSDA)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nội dung câu hỏi:";
            // 
            // txtCauHoi
            // 
            this.txtCauHoi.Location = new System.Drawing.Point(132, 37);
            this.txtCauHoi.Multiline = true;
            this.txtCauHoi.Name = "txtCauHoi";
            this.txtCauHoi.Size = new System.Drawing.Size(219, 71);
            this.txtCauHoi.TabIndex = 0;
            // 
            // btnThemCauHoi
            // 
            this.btnThemCauHoi.Location = new System.Drawing.Point(151, 149);
            this.btnThemCauHoi.Name = "btnThemCauHoi";
            this.btnThemCauHoi.Size = new System.Drawing.Size(121, 42);
            this.btnThemCauHoi.TabIndex = 8;
            this.btnThemCauHoi.Text = "Thêm câu hỏi";
            this.btnThemCauHoi.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cklbCapDo);
            this.groupBox1.Controls.Add(this.txtCauHoi);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnThemCauHoi);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(767, 221);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // dgvDSDA
            // 
            this.dgvDSDA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSDA.Location = new System.Drawing.Point(382, 317);
            this.dgvDSDA.Name = "dgvDSDA";
            this.dgvDSDA.RowHeadersWidth = 51;
            this.dgvDSDA.RowTemplate.Height = 24;
            this.dgvDSDA.Size = new System.Drawing.Size(345, 121);
            this.dgvDSDA.TabIndex = 10;
            // 
            // cbDSCH
            // 
            this.cbDSCH.FormattingEnabled = true;
            this.cbDSCH.Location = new System.Drawing.Point(151, 317);
            this.cbDSCH.Name = "cbDSCH";
            this.cbDSCH.Size = new System.Drawing.Size(121, 24);
            this.cbDSCH.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 317);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Danh sách câu hỏi:";
            // 
            // cklbCapDo
            // 
            this.cklbCapDo.FormattingEnabled = true;
            this.cklbCapDo.Items.AddRange(new object[] {
            "Dễ",
            "Trung bình",
            "Khó"});
            this.cklbCapDo.Location = new System.Drawing.Point(396, 37);
            this.cklbCapDo.Name = "cklbCapDo";
            this.cklbCapDo.Size = new System.Drawing.Size(217, 72);
            this.cklbCapDo.TabIndex = 9;
            // 
            // ThemCauHoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 450);
            this.Controls.Add(this.cbDSCH);
            this.Controls.Add(this.dgvDSDA);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Name = "ThemCauHoi";
            this.Text = "Thêm câu hỏi";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSDA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCauHoi;
        private System.Windows.Forms.Button btnThemCauHoi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvDSDA;
        private System.Windows.Forms.ComboBox cbDSCH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox cklbCapDo;
    }
}

