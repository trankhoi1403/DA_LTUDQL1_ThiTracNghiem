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
            this.txtCauHoi = new System.Windows.Forms.TextBox();
            this.btnThemCauHoi = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlCapDo = new System.Windows.Forms.Panel();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.dgvDSDA = new System.Windows.Forms.DataGridView();
            this.cbDSCH = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnlDungSai = new System.Windows.Forms.Panel();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.txtDapAn = new System.Windows.Forms.TextBox();
            this.btnThemDapAn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.pnlCapDo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSDA)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.pnlDungSai.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCauHoi
            // 
            this.txtCauHoi.Location = new System.Drawing.Point(13, 23);
            this.txtCauHoi.Margin = new System.Windows.Forms.Padding(2);
            this.txtCauHoi.Multiline = true;
            this.txtCauHoi.Name = "txtCauHoi";
            this.txtCauHoi.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCauHoi.Size = new System.Drawing.Size(270, 79);
            this.txtCauHoi.TabIndex = 0;
            // 
            // btnThemCauHoi
            // 
            this.btnThemCauHoi.Location = new System.Drawing.Point(147, 127);
            this.btnThemCauHoi.Margin = new System.Windows.Forms.Padding(2);
            this.btnThemCauHoi.Name = "btnThemCauHoi";
            this.btnThemCauHoi.Size = new System.Drawing.Size(91, 34);
            this.btnThemCauHoi.TabIndex = 8;
            this.btnThemCauHoi.Text = "Thêm câu hỏi";
            this.btnThemCauHoi.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlCapDo);
            this.groupBox1.Controls.Add(this.txtCauHoi);
            this.groupBox1.Controls.Add(this.btnThemCauHoi);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(304, 184);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thêm câu hỏi";
            // 
            // pnlCapDo
            // 
            this.pnlCapDo.Controls.Add(this.radioButton2);
            this.pnlCapDo.Controls.Add(this.radioButton3);
            this.pnlCapDo.Controls.Add(this.radioButton1);
            this.pnlCapDo.Location = new System.Drawing.Point(21, 106);
            this.pnlCapDo.Name = "pnlCapDo";
            this.pnlCapDo.Size = new System.Drawing.Size(106, 78);
            this.pnlCapDo.TabIndex = 12;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(13, 30);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(76, 17);
            this.radioButton2.TabIndex = 10;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Trung bình";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(13, 53);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(44, 17);
            this.radioButton3.TabIndex = 11;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Khó";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(13, 6);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(39, 17);
            this.radioButton1.TabIndex = 9;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Dễ";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // dgvDSDA
            // 
            this.dgvDSDA.AllowUserToAddRows = false;
            this.dgvDSDA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSDA.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvDSDA.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDSDA.Location = new System.Drawing.Point(0, 225);
            this.dgvDSDA.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDSDA.Name = "dgvDSDA";
            this.dgvDSDA.RowHeadersWidth = 51;
            this.dgvDSDA.RowTemplate.Height = 24;
            this.dgvDSDA.Size = new System.Drawing.Size(558, 141);
            this.dgvDSDA.TabIndex = 10;
            // 
            // cbDSCH
            // 
            this.cbDSCH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDSCH.FormattingEnabled = true;
            this.cbDSCH.Location = new System.Drawing.Point(126, 193);
            this.cbDSCH.Margin = new System.Windows.Forms.Padding(2);
            this.cbDSCH.Name = "cbDSCH";
            this.cbDSCH.Size = new System.Drawing.Size(294, 21);
            this.cbDSCH.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 196);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Danh sách câu hỏi:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pnlDungSai);
            this.groupBox2.Controls.Add(this.txtDapAn);
            this.groupBox2.Controls.Add(this.btnThemDapAn);
            this.groupBox2.Location = new System.Drawing.Point(308, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(250, 184);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thêm đáp án";
            // 
            // pnlDungSai
            // 
            this.pnlDungSai.Controls.Add(this.radioButton4);
            this.pnlDungSai.Controls.Add(this.radioButton6);
            this.pnlDungSai.Location = new System.Drawing.Point(21, 106);
            this.pnlDungSai.Name = "pnlDungSai";
            this.pnlDungSai.Size = new System.Drawing.Size(121, 78);
            this.pnlDungSai.TabIndex = 12;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(13, 30);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(90, 17);
            this.radioButton4.TabIndex = 10;
            this.radioButton4.Text = "Là đáp án sai";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Checked = true;
            this.radioButton6.Location = new System.Drawing.Point(13, 6);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(102, 17);
            this.radioButton6.TabIndex = 9;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "Là đáp án đúng";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // txtDapAn
            // 
            this.txtDapAn.Location = new System.Drawing.Point(21, 22);
            this.txtDapAn.Margin = new System.Windows.Forms.Padding(2);
            this.txtDapAn.Multiline = true;
            this.txtDapAn.Name = "txtDapAn";
            this.txtDapAn.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDapAn.Size = new System.Drawing.Size(218, 79);
            this.txtDapAn.TabIndex = 0;
            // 
            // btnThemDapAn
            // 
            this.btnThemDapAn.Location = new System.Drawing.Point(147, 127);
            this.btnThemDapAn.Margin = new System.Windows.Forms.Padding(2);
            this.btnThemDapAn.Name = "btnThemDapAn";
            this.btnThemDapAn.Size = new System.Drawing.Size(91, 34);
            this.btnThemDapAn.TabIndex = 8;
            this.btnThemDapAn.Text = "Thêm đáp án";
            this.btnThemDapAn.UseVisualStyleBackColor = true;
            // 
            // ThemCauHoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 366);
            this.Controls.Add(this.cbDSCH);
            this.Controls.Add(this.dgvDSDA);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ThemCauHoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm câu hỏi";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlCapDo.ResumeLayout(false);
            this.pnlCapDo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSDA)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pnlDungSai.ResumeLayout(false);
            this.pnlDungSai.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtCauHoi;
        private System.Windows.Forms.Button btnThemCauHoi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvDSDA;
        private System.Windows.Forms.ComboBox cbDSCH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Panel pnlCapDo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel pnlDungSai;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.TextBox txtDapAn;
        private System.Windows.Forms.Button btnThemDapAn;
    }
}

