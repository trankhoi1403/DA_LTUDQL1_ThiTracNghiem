namespace ThiTracNghiem
{
    partial class frmGiaoVien
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
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.QLKTTOT = new System.Windows.Forms.TabPage();
            this.tpQLKT = new System.Windows.Forms.TabPage();
            this.tpQLDT = new System.Windows.Forms.TabPage();
            this.tpQLCH = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.qlchBtnThemDA = new System.Windows.Forms.Button();
            this.qlchBtnXoaDA = new System.Windows.Forms.Button();
            this.qlchBtnSuaDA = new System.Windows.Forms.Button();
            this.qlchTxtDapAn = new System.Windows.Forms.TextBox();
            this.qlchCkbDungSai = new System.Windows.Forms.CheckBox();
            this.qlchDgvDsda = new System.Windows.Forms.DataGridView();
            this.qlchCbDsch = new System.Windows.Forms.ComboBox();
            this.qlchBtnImport = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.qlchBtnThemCH = new System.Windows.Forms.Button();
            this.qlchBtnXoaCH = new System.Windows.Forms.Button();
            this.qlchBtnSuaCH = new System.Windows.Forms.Button();
            this.qlchTxtCauHoi = new System.Windows.Forms.TextBox();
            this.qlchCbCapDo = new System.Windows.Forms.ComboBox();
            this.qlchBtnExport = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpQLHS = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.tpQLCH.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qlchDgvDsda)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // QLKTTOT
            // 
            this.QLKTTOT.Location = new System.Drawing.Point(4, 22);
            this.QLKTTOT.Name = "QLKTTOT";
            this.QLKTTOT.Padding = new System.Windows.Forms.Padding(3);
            this.QLKTTOT.Size = new System.Drawing.Size(614, 415);
            this.QLKTTOT.TabIndex = 3;
            this.QLKTTOT.Text = "Quản lý kỳ thi thử/Ôn tập";
            this.QLKTTOT.UseVisualStyleBackColor = true;
            // 
            // tpQLKT
            // 
            this.tpQLKT.Location = new System.Drawing.Point(4, 22);
            this.tpQLKT.Name = "tpQLKT";
            this.tpQLKT.Padding = new System.Windows.Forms.Padding(3);
            this.tpQLKT.Size = new System.Drawing.Size(614, 415);
            this.tpQLKT.TabIndex = 2;
            this.tpQLKT.Text = "Quản lý kỳ thi";
            this.tpQLKT.UseVisualStyleBackColor = true;
            // 
            // tpQLDT
            // 
            this.tpQLDT.BackColor = System.Drawing.SystemColors.Control;
            this.tpQLDT.Location = new System.Drawing.Point(4, 22);
            this.tpQLDT.Name = "tpQLDT";
            this.tpQLDT.Padding = new System.Windows.Forms.Padding(3);
            this.tpQLDT.Size = new System.Drawing.Size(614, 415);
            this.tpQLDT.TabIndex = 1;
            this.tpQLDT.Text = "Quản lý đề thi";
            // 
            // tpQLCH
            // 
            this.tpQLCH.BackColor = System.Drawing.SystemColors.Control;
            this.tpQLCH.Controls.Add(this.qlchBtnExport);
            this.tpQLCH.Controls.Add(this.groupBox1);
            this.tpQLCH.Controls.Add(this.qlchBtnImport);
            this.tpQLCH.Controls.Add(this.qlchCbDsch);
            this.tpQLCH.Controls.Add(this.qlchDgvDsda);
            this.tpQLCH.Controls.Add(this.groupBox2);
            this.tpQLCH.Controls.Add(this.label3);
            this.tpQLCH.Location = new System.Drawing.Point(4, 22);
            this.tpQLCH.Name = "tpQLCH";
            this.tpQLCH.Padding = new System.Windows.Forms.Padding(3);
            this.tpQLCH.Size = new System.Drawing.Size(614, 415);
            this.tpQLCH.TabIndex = 0;
            this.tpQLCH.Text = "Quản lý câu hỏi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 197);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Danh sách câu hỏi:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.qlchCkbDungSai);
            this.groupBox2.Controls.Add(this.qlchTxtDapAn);
            this.groupBox2.Controls.Add(this.qlchBtnSuaDA);
            this.groupBox2.Controls.Add(this.qlchBtnXoaDA);
            this.groupBox2.Controls.Add(this.qlchBtnThemDA);
            this.groupBox2.Location = new System.Drawing.Point(313, 1);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(300, 180);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin đáp án";
            // 
            // qlchBtnThemDA
            // 
            this.qlchBtnThemDA.Location = new System.Drawing.Point(19, 142);
            this.qlchBtnThemDA.Margin = new System.Windows.Forms.Padding(2);
            this.qlchBtnThemDA.Name = "qlchBtnThemDA";
            this.qlchBtnThemDA.Size = new System.Drawing.Size(80, 25);
            this.qlchBtnThemDA.TabIndex = 8;
            this.qlchBtnThemDA.Text = "Thêm";
            this.qlchBtnThemDA.UseVisualStyleBackColor = true;
            // 
            // qlchBtnXoaDA
            // 
            this.qlchBtnXoaDA.Location = new System.Drawing.Point(114, 142);
            this.qlchBtnXoaDA.Margin = new System.Windows.Forms.Padding(2);
            this.qlchBtnXoaDA.Name = "qlchBtnXoaDA";
            this.qlchBtnXoaDA.Size = new System.Drawing.Size(80, 25);
            this.qlchBtnXoaDA.TabIndex = 8;
            this.qlchBtnXoaDA.Text = "Xóa";
            this.qlchBtnXoaDA.UseVisualStyleBackColor = true;
            // 
            // qlchBtnSuaDA
            // 
            this.qlchBtnSuaDA.Location = new System.Drawing.Point(207, 142);
            this.qlchBtnSuaDA.Margin = new System.Windows.Forms.Padding(2);
            this.qlchBtnSuaDA.Name = "qlchBtnSuaDA";
            this.qlchBtnSuaDA.Size = new System.Drawing.Size(80, 25);
            this.qlchBtnSuaDA.TabIndex = 8;
            this.qlchBtnSuaDA.Text = "Cập nhật";
            this.qlchBtnSuaDA.UseVisualStyleBackColor = true;
            // 
            // qlchTxtDapAn
            // 
            this.qlchTxtDapAn.Location = new System.Drawing.Point(17, 22);
            this.qlchTxtDapAn.Margin = new System.Windows.Forms.Padding(2);
            this.qlchTxtDapAn.Multiline = true;
            this.qlchTxtDapAn.Name = "qlchTxtDapAn";
            this.qlchTxtDapAn.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.qlchTxtDapAn.Size = new System.Drawing.Size(270, 80);
            this.qlchTxtDapAn.TabIndex = 0;
            // 
            // qlchCkbDungSai
            // 
            this.qlchCkbDungSai.AutoSize = true;
            this.qlchCkbDungSai.Location = new System.Drawing.Point(19, 113);
            this.qlchCkbDungSai.Name = "qlchCkbDungSai";
            this.qlchCkbDungSai.Size = new System.Drawing.Size(103, 17);
            this.qlchCkbDungSai.TabIndex = 10;
            this.qlchCkbDungSai.Text = "Là đáp án đúng";
            this.qlchCkbDungSai.UseVisualStyleBackColor = true;
            // 
            // qlchDgvDsda
            // 
            this.qlchDgvDsda.AllowUserToAddRows = false;
            this.qlchDgvDsda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.qlchDgvDsda.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.qlchDgvDsda.Location = new System.Drawing.Point(3, 228);
            this.qlchDgvDsda.Margin = new System.Windows.Forms.Padding(2);
            this.qlchDgvDsda.MultiSelect = false;
            this.qlchDgvDsda.Name = "qlchDgvDsda";
            this.qlchDgvDsda.ReadOnly = true;
            this.qlchDgvDsda.RowHeadersWidth = 51;
            this.qlchDgvDsda.RowTemplate.Height = 24;
            this.qlchDgvDsda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.qlchDgvDsda.Size = new System.Drawing.Size(608, 184);
            this.qlchDgvDsda.TabIndex = 17;
            // 
            // qlchCbDsch
            // 
            this.qlchCbDsch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.qlchCbDsch.FormattingEnabled = true;
            this.qlchCbDsch.Location = new System.Drawing.Point(124, 194);
            this.qlchCbDsch.Margin = new System.Windows.Forms.Padding(2);
            this.qlchCbDsch.Name = "qlchCbDsch";
            this.qlchCbDsch.Size = new System.Drawing.Size(209, 21);
            this.qlchCbDsch.TabIndex = 18;
            // 
            // qlchBtnImport
            // 
            this.qlchBtnImport.Location = new System.Drawing.Point(374, 194);
            this.qlchBtnImport.Name = "qlchBtnImport";
            this.qlchBtnImport.Size = new System.Drawing.Size(88, 23);
            this.qlchBtnImport.TabIndex = 19;
            this.qlchBtnImport.Text = "Nhập từ excel";
            this.qlchBtnImport.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.qlchCbCapDo);
            this.groupBox1.Controls.Add(this.qlchTxtCauHoi);
            this.groupBox1.Controls.Add(this.qlchBtnSuaCH);
            this.groupBox1.Controls.Add(this.qlchBtnXoaCH);
            this.groupBox1.Controls.Add(this.qlchBtnThemCH);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 1);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(300, 180);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin câu hỏi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 117);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lựa chọn cấp độ câu hỏi:";
            // 
            // qlchBtnThemCH
            // 
            this.qlchBtnThemCH.Location = new System.Drawing.Point(14, 143);
            this.qlchBtnThemCH.Margin = new System.Windows.Forms.Padding(2);
            this.qlchBtnThemCH.Name = "qlchBtnThemCH";
            this.qlchBtnThemCH.Size = new System.Drawing.Size(80, 25);
            this.qlchBtnThemCH.TabIndex = 8;
            this.qlchBtnThemCH.Text = "Thêm";
            this.qlchBtnThemCH.UseVisualStyleBackColor = true;
            // 
            // qlchBtnXoaCH
            // 
            this.qlchBtnXoaCH.Location = new System.Drawing.Point(110, 143);
            this.qlchBtnXoaCH.Margin = new System.Windows.Forms.Padding(2);
            this.qlchBtnXoaCH.Name = "qlchBtnXoaCH";
            this.qlchBtnXoaCH.Size = new System.Drawing.Size(80, 25);
            this.qlchBtnXoaCH.TabIndex = 8;
            this.qlchBtnXoaCH.Text = "Xóa";
            this.qlchBtnXoaCH.UseVisualStyleBackColor = true;
            // 
            // qlchBtnSuaCH
            // 
            this.qlchBtnSuaCH.Location = new System.Drawing.Point(203, 143);
            this.qlchBtnSuaCH.Margin = new System.Windows.Forms.Padding(2);
            this.qlchBtnSuaCH.Name = "qlchBtnSuaCH";
            this.qlchBtnSuaCH.Size = new System.Drawing.Size(80, 25);
            this.qlchBtnSuaCH.TabIndex = 8;
            this.qlchBtnSuaCH.Text = "Cập nhật";
            this.qlchBtnSuaCH.UseVisualStyleBackColor = true;
            // 
            // qlchTxtCauHoi
            // 
            this.qlchTxtCauHoi.Location = new System.Drawing.Point(13, 23);
            this.qlchTxtCauHoi.Margin = new System.Windows.Forms.Padding(2);
            this.qlchTxtCauHoi.Multiline = true;
            this.qlchTxtCauHoi.Name = "qlchTxtCauHoi";
            this.qlchTxtCauHoi.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.qlchTxtCauHoi.Size = new System.Drawing.Size(270, 80);
            this.qlchTxtCauHoi.TabIndex = 0;
            // 
            // qlchCbCapDo
            // 
            this.qlchCbCapDo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.qlchCbCapDo.FormattingEnabled = true;
            this.qlchCbCapDo.Location = new System.Drawing.Point(155, 113);
            this.qlchCbCapDo.Name = "qlchCbCapDo";
            this.qlchCbCapDo.Size = new System.Drawing.Size(121, 21);
            this.qlchCbCapDo.TabIndex = 13;
            // 
            // qlchBtnExport
            // 
            this.qlchBtnExport.Location = new System.Drawing.Point(475, 194);
            this.qlchBtnExport.Name = "qlchBtnExport";
            this.qlchBtnExport.Size = new System.Drawing.Size(88, 23);
            this.qlchBtnExport.TabIndex = 20;
            this.qlchBtnExport.Text = "Xuất ra excel";
            this.qlchBtnExport.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpQLCH);
            this.tabControl1.Controls.Add(this.tpQLDT);
            this.tabControl1.Controls.Add(this.tpQLKT);
            this.tabControl1.Controls.Add(this.QLKTTOT);
            this.tabControl1.Controls.Add(this.tpQLHS);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(622, 441);
            this.tabControl1.TabIndex = 0;
            // 
            // tpQLHS
            // 
            this.tpQLHS.Location = new System.Drawing.Point(4, 22);
            this.tpQLHS.Name = "tpQLHS";
            this.tpQLHS.Padding = new System.Windows.Forms.Padding(3);
            this.tpQLHS.Size = new System.Drawing.Size(614, 415);
            this.tpQLHS.TabIndex = 4;
            this.tpQLHS.Text = "Quản lý học sinh";
            this.tpQLHS.UseVisualStyleBackColor = true;
            // 
            // frmGiaoVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 441);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmGiaoVien";
            this.Text = "frmGiaoVien";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.tpQLCH.ResumeLayout(false);
            this.tpQLCH.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qlchDgvDsda)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpQLCH;
        private System.Windows.Forms.Button qlchBtnExport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox qlchCbCapDo;
        private System.Windows.Forms.TextBox qlchTxtCauHoi;
        private System.Windows.Forms.Button qlchBtnSuaCH;
        private System.Windows.Forms.Button qlchBtnXoaCH;
        private System.Windows.Forms.Button qlchBtnThemCH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button qlchBtnImport;
        private System.Windows.Forms.ComboBox qlchCbDsch;
        private System.Windows.Forms.DataGridView qlchDgvDsda;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox qlchCkbDungSai;
        private System.Windows.Forms.TextBox qlchTxtDapAn;
        private System.Windows.Forms.Button qlchBtnSuaDA;
        private System.Windows.Forms.Button qlchBtnXoaDA;
        private System.Windows.Forms.Button qlchBtnThemDA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tpQLDT;
        private System.Windows.Forms.TabPage tpQLKT;
        private System.Windows.Forms.TabPage QLKTTOT;
        private System.Windows.Forms.TabPage tpQLHS;
    }
}