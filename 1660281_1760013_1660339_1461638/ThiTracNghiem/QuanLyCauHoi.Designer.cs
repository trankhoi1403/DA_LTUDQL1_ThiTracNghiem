namespace ThiTracNghiem
{
    partial class QuanLyCauHoi
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
            this.txtCauHoi = new System.Windows.Forms.TextBox();
            this.btnThemCauHoi = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbCapDo = new System.Windows.Forms.ComboBox();
            this.btnSuaCauHoi = new System.Windows.Forms.Button();
            this.btnXoaCauHoi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDSDA = new System.Windows.Forms.DataGridView();
            this.cbDSCH = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ckbDungSai = new System.Windows.Forms.CheckBox();
            this.txtDapAn = new System.Windows.Forms.TextBox();
            this.btnSuaDapAn = new System.Windows.Forms.Button();
            this.btnXoaDapAn = new System.Windows.Forms.Button();
            this.btnThemDapAn = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSDA)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCauHoi
            // 
            this.txtCauHoi.Location = new System.Drawing.Point(17, 28);
            this.txtCauHoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCauHoi.Multiline = true;
            this.txtCauHoi.Name = "txtCauHoi";
            this.txtCauHoi.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCauHoi.Size = new System.Drawing.Size(359, 98);
            this.txtCauHoi.TabIndex = 0;
            // 
            // btnThemCauHoi
            // 
            this.btnThemCauHoi.Location = new System.Drawing.Point(19, 176);
            this.btnThemCauHoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThemCauHoi.Name = "btnThemCauHoi";
            this.btnThemCauHoi.Size = new System.Drawing.Size(107, 31);
            this.btnThemCauHoi.TabIndex = 8;
            this.btnThemCauHoi.Text = "Thêm";
            this.btnThemCauHoi.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbCapDo);
            this.groupBox1.Controls.Add(this.txtCauHoi);
            this.groupBox1.Controls.Add(this.btnSuaCauHoi);
            this.groupBox1.Controls.Add(this.btnXoaCauHoi);
            this.groupBox1.Controls.Add(this.btnThemCauHoi);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(11, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(400, 222);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin câu hỏi";
            // 
            // cbCapDo
            // 
            this.cbCapDo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCapDo.FormattingEnabled = true;
            this.cbCapDo.Location = new System.Drawing.Point(207, 139);
            this.cbCapDo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbCapDo.Name = "cbCapDo";
            this.cbCapDo.Size = new System.Drawing.Size(160, 24);
            this.cbCapDo.TabIndex = 13;
            // 
            // btnSuaCauHoi
            // 
            this.btnSuaCauHoi.Location = new System.Drawing.Point(271, 176);
            this.btnSuaCauHoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSuaCauHoi.Name = "btnSuaCauHoi";
            this.btnSuaCauHoi.Size = new System.Drawing.Size(107, 31);
            this.btnSuaCauHoi.TabIndex = 8;
            this.btnSuaCauHoi.Text = "Cập nhật";
            this.btnSuaCauHoi.UseVisualStyleBackColor = true;
            // 
            // btnXoaCauHoi
            // 
            this.btnXoaCauHoi.Location = new System.Drawing.Point(147, 176);
            this.btnXoaCauHoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoaCauHoi.Name = "btnXoaCauHoi";
            this.btnXoaCauHoi.Size = new System.Drawing.Size(107, 31);
            this.btnXoaCauHoi.TabIndex = 8;
            this.btnXoaCauHoi.Text = "Xóa";
            this.btnXoaCauHoi.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lựa chọn cấp độ câu hỏi:";
            // 
            // dgvDSDA
            // 
            this.dgvDSDA.AllowUserToAddRows = false;
            this.dgvDSDA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSDA.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvDSDA.Location = new System.Drawing.Point(0, 280);
            this.dgvDSDA.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvDSDA.MultiSelect = false;
            this.dgvDSDA.Name = "dgvDSDA";
            this.dgvDSDA.ReadOnly = true;
            this.dgvDSDA.RowHeadersWidth = 51;
            this.dgvDSDA.RowTemplate.Height = 24;
            this.dgvDSDA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDSDA.Size = new System.Drawing.Size(829, 226);
            this.dgvDSDA.TabIndex = 10;
            // 
            // cbDSCH
            // 
            this.cbDSCH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDSCH.FormattingEnabled = true;
            this.cbDSCH.Location = new System.Drawing.Point(168, 238);
            this.cbDSCH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbDSCH.Name = "cbDSCH";
            this.cbDSCH.Size = new System.Drawing.Size(277, 24);
            this.cbDSCH.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Danh sách câu hỏi:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ckbDungSai);
            this.groupBox2.Controls.Add(this.txtDapAn);
            this.groupBox2.Controls.Add(this.btnSuaDapAn);
            this.groupBox2.Controls.Add(this.btnXoaDapAn);
            this.groupBox2.Controls.Add(this.btnThemDapAn);
            this.groupBox2.Location = new System.Drawing.Point(420, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(400, 222);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin đáp án";
            // 
            // ckbDungSai
            // 
            this.ckbDungSai.AutoSize = true;
            this.ckbDungSai.Location = new System.Drawing.Point(25, 139);
            this.ckbDungSai.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ckbDungSai.Name = "ckbDungSai";
            this.ckbDungSai.Size = new System.Drawing.Size(130, 21);
            this.ckbDungSai.TabIndex = 10;
            this.ckbDungSai.Text = "Là đáp án đúng";
            this.ckbDungSai.UseVisualStyleBackColor = true;
            //
            // txtDapAn
            // 
            this.txtDapAn.Location = new System.Drawing.Point(23, 27);
            this.txtDapAn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDapAn.Multiline = true;
            this.txtDapAn.Name = "txtDapAn";
            this.txtDapAn.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDapAn.Size = new System.Drawing.Size(359, 98);
            this.txtDapAn.TabIndex = 0;
            // 
            // btnSuaDapAn
            // 
            this.btnSuaDapAn.Location = new System.Drawing.Point(276, 175);
            this.btnSuaDapAn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSuaDapAn.Name = "btnSuaDapAn";
            this.btnSuaDapAn.Size = new System.Drawing.Size(107, 31);
            this.btnSuaDapAn.TabIndex = 8;
            this.btnSuaDapAn.Text = "Cập nhật";
            this.btnSuaDapAn.UseVisualStyleBackColor = true;
            // 
            // btnXoaDapAn
            // 
            this.btnXoaDapAn.Location = new System.Drawing.Point(152, 175);
            this.btnXoaDapAn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoaDapAn.Name = "btnXoaDapAn";
            this.btnXoaDapAn.Size = new System.Drawing.Size(107, 31);
            this.btnXoaDapAn.TabIndex = 8;
            this.btnXoaDapAn.Text = "Xóa";
            this.btnXoaDapAn.UseVisualStyleBackColor = true;
            // 
            // btnThemDapAn
            // 
            this.btnThemDapAn.Location = new System.Drawing.Point(25, 175);
            this.btnThemDapAn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThemDapAn.Name = "btnThemDapAn";
            this.btnThemDapAn.Size = new System.Drawing.Size(107, 31);
            this.btnThemDapAn.TabIndex = 8;
            this.btnThemDapAn.Text = "Thêm";
            this.btnThemDapAn.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(501, 238);
            this.btnImport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(117, 28);
            this.btnImport.TabIndex = 12;
            this.btnImport.Text = "Nhập từ excel";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(636, 238);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(117, 28);
            this.btnExport.TabIndex = 13;
            this.btnExport.Text = "Xuất ra excel";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // QuanLyCauHoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 506);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.cbDSCH);
            this.Controls.Add(this.dgvDSDA);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "QuanLyCauHoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý danh sách câu hỏi";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSDA)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDapAn;
        private System.Windows.Forms.Button btnThemDapAn;
        private System.Windows.Forms.ComboBox cbCapDo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button btnXoaCauHoi;
        private System.Windows.Forms.Button btnXoaDapAn;
        private System.Windows.Forms.Button btnSuaCauHoi;
        private System.Windows.Forms.Button btnSuaDapAn;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.CheckBox ckbDungSai;
        private System.Windows.Forms.Button btnExport;
    }
}

