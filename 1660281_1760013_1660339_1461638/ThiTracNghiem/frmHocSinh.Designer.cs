namespace ThiTracNghiem
{
    partial class frmHocSinh
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpLBTN = new System.Windows.Forms.TabPage();
            this.lblThoiGian = new System.Windows.Forms.Label();
            this.bttnBtnNopBai = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.bttnGbTtHS = new System.Windows.Forms.GroupBox();
            this.bttnGbDiemThi = new System.Windows.Forms.GroupBox();
            this.bttnGbChonCH = new System.Windows.Forms.GroupBox();
            this.tpTTCN = new System.Windows.Forms.TabPage();
            this.tpOLTT = new System.Windows.Forms.TabPage();
            this.tpDGCH = new System.Windows.Forms.TabPage();
            this.dgchbtnExport = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgchCbCapDo = new System.Windows.Forms.ComboBox();
            this.dgchTxtCH = new System.Windows.Forms.TextBox();
            this.dgchBtnSuaCH = new System.Windows.Forms.Button();
            this.dgchBtnXoaCH = new System.Windows.Forms.Button();
            this.dgchBtnThemCH = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgchbtnImport = new System.Windows.Forms.Button();
            this.cbDSCH = new System.Windows.Forms.ComboBox();
            this.dgvDSDA = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgchCkbDungSai = new System.Windows.Forms.CheckBox();
            this.dgchTxtDA = new System.Windows.Forms.TextBox();
            this.dgchBtnSuaDA = new System.Windows.Forms.Button();
            this.dgchBtnXoaDA = new System.Windows.Forms.Button();
            this.dgchBtnThemDA = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ttcnGbttcn = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ttcnTxtTen = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tpLBTN.SuspendLayout();
            this.tpTTCN.SuspendLayout();
            this.tpDGCH.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSDA)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.ttcnGbttcn.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpLBTN);
            this.tabControl1.Controls.Add(this.tpTTCN);
            this.tabControl1.Controls.Add(this.tpOLTT);
            this.tabControl1.Controls.Add(this.tpDGCH);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1182, 653);
            this.tabControl1.TabIndex = 0;
            // 
            // tpLBTN
            // 
            this.tpLBTN.Controls.Add(this.lblThoiGian);
            this.tpLBTN.Controls.Add(this.bttnBtnNopBai);
            this.tpLBTN.Controls.Add(this.label2);
            this.tpLBTN.Controls.Add(this.groupBox4);
            this.tpLBTN.Controls.Add(this.bttnGbTtHS);
            this.tpLBTN.Controls.Add(this.bttnGbDiemThi);
            this.tpLBTN.Controls.Add(this.bttnGbChonCH);
            this.tpLBTN.Location = new System.Drawing.Point(4, 25);
            this.tpLBTN.Margin = new System.Windows.Forms.Padding(4);
            this.tpLBTN.Name = "tpLBTN";
            this.tpLBTN.Padding = new System.Windows.Forms.Padding(4);
            this.tpLBTN.Size = new System.Drawing.Size(1174, 624);
            this.tpLBTN.TabIndex = 0;
            this.tpLBTN.Text = "Làm bài trắc nghiệm";
            this.tpLBTN.UseVisualStyleBackColor = true;
            // 
            // lblThoiGian
            // 
            this.lblThoiGian.AutoSize = true;
            this.lblThoiGian.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblThoiGian.Location = new System.Drawing.Point(919, 546);
            this.lblThoiGian.Name = "lblThoiGian";
            this.lblThoiGian.Size = new System.Drawing.Size(247, 57);
            this.lblThoiGian.TabIndex = 4;
            this.lblThoiGian.Text = "Thời Gian";
            this.lblThoiGian.Click += new System.EventHandler(this.lblThoiGian_Click);
            // 
            // bttnBtnNopBai
            // 
            this.bttnBtnNopBai.Font = new System.Drawing.Font("Times New Roman", 25.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.bttnBtnNopBai.Location = new System.Drawing.Point(436, 546);
            this.bttnBtnNopBai.Name = "bttnBtnNopBai";
            this.bttnBtnNopBai.Size = new System.Drawing.Size(260, 70);
            this.bttnBtnNopBai.TabIndex = 3;
            this.bttnBtnNopBai.Text = "Nộp Bài";
            this.bttnBtnNopBai.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.Chocolate;
            this.label2.Location = new System.Drawing.Point(329, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(363, 76);
            this.label2.TabIndex = 2;
            this.label2.Text = "Phần Thi Trắc Nghiệm\r\nChúc Bạn May Mắn\r\n";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(164, 101);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(696, 431);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            // 
            // bttnGbTtHS
            // 
            this.bttnGbTtHS.Location = new System.Drawing.Point(866, 7);
            this.bttnGbTtHS.Name = "bttnGbTtHS";
            this.bttnGbTtHS.Size = new System.Drawing.Size(300, 250);
            this.bttnGbTtHS.TabIndex = 1;
            this.bttnGbTtHS.TabStop = false;
            this.bttnGbTtHS.Text = "Thông Tin Học Sinh";
            // 
            // bttnGbDiemThi
            // 
            this.bttnGbDiemThi.Location = new System.Drawing.Point(866, 275);
            this.bttnGbDiemThi.Name = "bttnGbDiemThi";
            this.bttnGbDiemThi.Size = new System.Drawing.Size(300, 257);
            this.bttnGbDiemThi.TabIndex = 1;
            this.bttnGbDiemThi.TabStop = false;
            this.bttnGbDiemThi.Text = "Điểm Thi";
            // 
            // bttnGbChonCH
            // 
            this.bttnGbChonCH.Location = new System.Drawing.Point(8, 7);
            this.bttnGbChonCH.Name = "bttnGbChonCH";
            this.bttnGbChonCH.Size = new System.Drawing.Size(150, 525);
            this.bttnGbChonCH.TabIndex = 0;
            this.bttnGbChonCH.TabStop = false;
            this.bttnGbChonCH.Text = "Chọn Câu Hỏi";
            // 
            // tpTTCN
            // 
            this.tpTTCN.Controls.Add(this.ttcnGbttcn);
            this.tpTTCN.Location = new System.Drawing.Point(4, 25);
            this.tpTTCN.Margin = new System.Windows.Forms.Padding(4);
            this.tpTTCN.Name = "tpTTCN";
            this.tpTTCN.Padding = new System.Windows.Forms.Padding(4);
            this.tpTTCN.Size = new System.Drawing.Size(1174, 624);
            this.tpTTCN.TabIndex = 1;
            this.tpTTCN.Text = "Thông tin cá nhân";
            this.tpTTCN.UseVisualStyleBackColor = true;
            // 
            // tpOLTT
            // 
            this.tpOLTT.Location = new System.Drawing.Point(4, 25);
            this.tpOLTT.Margin = new System.Windows.Forms.Padding(4);
            this.tpOLTT.Name = "tpOLTT";
            this.tpOLTT.Size = new System.Drawing.Size(1174, 624);
            this.tpOLTT.TabIndex = 2;
            this.tpOLTT.Text = "Ôn luyện thi thử";
            this.tpOLTT.UseVisualStyleBackColor = true;
            // 
            // tpDGCH
            // 
            this.tpDGCH.Controls.Add(this.dgchbtnExport);
            this.tpDGCH.Controls.Add(this.groupBox1);
            this.tpDGCH.Controls.Add(this.dgchbtnImport);
            this.tpDGCH.Controls.Add(this.cbDSCH);
            this.tpDGCH.Controls.Add(this.dgvDSDA);
            this.tpDGCH.Controls.Add(this.groupBox2);
            this.tpDGCH.Controls.Add(this.label3);
            this.tpDGCH.Location = new System.Drawing.Point(4, 25);
            this.tpDGCH.Margin = new System.Windows.Forms.Padding(4);
            this.tpDGCH.Name = "tpDGCH";
            this.tpDGCH.Size = new System.Drawing.Size(1174, 624);
            this.tpDGCH.TabIndex = 3;
            this.tpDGCH.Text = "Đóng góp câu hỏi";
            this.tpDGCH.UseVisualStyleBackColor = true;
            // 
            // dgchbtnExport
            // 
            this.dgchbtnExport.Location = new System.Drawing.Point(636, 238);
            this.dgchbtnExport.Margin = new System.Windows.Forms.Padding(4);
            this.dgchbtnExport.Name = "dgchbtnExport";
            this.dgchbtnExport.Size = new System.Drawing.Size(117, 28);
            this.dgchbtnExport.TabIndex = 20;
            this.dgchbtnExport.Text = "Xuất ra excel";
            this.dgchbtnExport.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgchCbCapDo);
            this.groupBox1.Controls.Add(this.dgchTxtCH);
            this.groupBox1.Controls.Add(this.dgchBtnSuaCH);
            this.groupBox1.Controls.Add(this.dgchBtnXoaCH);
            this.groupBox1.Controls.Add(this.dgchBtnThemCH);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(11, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(400, 222);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin câu hỏi";
            // 
            // dgchCbCapDo
            // 
            this.dgchCbCapDo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dgchCbCapDo.FormattingEnabled = true;
            this.dgchCbCapDo.Location = new System.Drawing.Point(207, 139);
            this.dgchCbCapDo.Margin = new System.Windows.Forms.Padding(4);
            this.dgchCbCapDo.Name = "dgchCbCapDo";
            this.dgchCbCapDo.Size = new System.Drawing.Size(160, 24);
            this.dgchCbCapDo.TabIndex = 13;
            // 
            // dgchTxtCH
            // 
            this.dgchTxtCH.Location = new System.Drawing.Point(17, 28);
            this.dgchTxtCH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgchTxtCH.Multiline = true;
            this.dgchTxtCH.Name = "dgchTxtCH";
            this.dgchTxtCH.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgchTxtCH.Size = new System.Drawing.Size(359, 98);
            this.dgchTxtCH.TabIndex = 0;
            // 
            // dgchBtnSuaCH
            // 
            this.dgchBtnSuaCH.Location = new System.Drawing.Point(271, 176);
            this.dgchBtnSuaCH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgchBtnSuaCH.Name = "dgchBtnSuaCH";
            this.dgchBtnSuaCH.Size = new System.Drawing.Size(107, 31);
            this.dgchBtnSuaCH.TabIndex = 8;
            this.dgchBtnSuaCH.Text = "Cập nhật";
            this.dgchBtnSuaCH.UseVisualStyleBackColor = true;
            // 
            // dgchBtnXoaCH
            // 
            this.dgchBtnXoaCH.Location = new System.Drawing.Point(147, 176);
            this.dgchBtnXoaCH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgchBtnXoaCH.Name = "dgchBtnXoaCH";
            this.dgchBtnXoaCH.Size = new System.Drawing.Size(107, 31);
            this.dgchBtnXoaCH.TabIndex = 8;
            this.dgchBtnXoaCH.Text = "Xóa";
            this.dgchBtnXoaCH.UseVisualStyleBackColor = true;
            // 
            // dgchBtnThemCH
            // 
            this.dgchBtnThemCH.Location = new System.Drawing.Point(19, 176);
            this.dgchBtnThemCH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgchBtnThemCH.Name = "dgchBtnThemCH";
            this.dgchBtnThemCH.Size = new System.Drawing.Size(107, 31);
            this.dgchBtnThemCH.TabIndex = 8;
            this.dgchBtnThemCH.Text = "Thêm";
            this.dgchBtnThemCH.UseVisualStyleBackColor = true;
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
            // dgchbtnImport
            // 
            this.dgchbtnImport.Location = new System.Drawing.Point(501, 238);
            this.dgchbtnImport.Margin = new System.Windows.Forms.Padding(4);
            this.dgchbtnImport.Name = "dgchbtnImport";
            this.dgchbtnImport.Size = new System.Drawing.Size(117, 28);
            this.dgchbtnImport.TabIndex = 19;
            this.dgchbtnImport.Text = "Nhập từ excel";
            this.dgchbtnImport.UseVisualStyleBackColor = true;
            // 
            // cbDSCH
            // 
            this.cbDSCH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDSCH.FormattingEnabled = true;
            this.cbDSCH.Location = new System.Drawing.Point(168, 238);
            this.cbDSCH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbDSCH.Name = "cbDSCH";
            this.cbDSCH.Size = new System.Drawing.Size(277, 24);
            this.cbDSCH.TabIndex = 18;
            // 
            // dgvDSDA
            // 
            this.dgvDSDA.AllowUserToAddRows = false;
            this.dgvDSDA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSDA.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvDSDA.Location = new System.Drawing.Point(0, 398);
            this.dgvDSDA.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvDSDA.MultiSelect = false;
            this.dgvDSDA.Name = "dgvDSDA";
            this.dgvDSDA.ReadOnly = true;
            this.dgvDSDA.RowHeadersWidth = 51;
            this.dgvDSDA.RowTemplate.Height = 24;
            this.dgvDSDA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDSDA.Size = new System.Drawing.Size(1174, 226);
            this.dgvDSDA.TabIndex = 17;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgchCkbDungSai);
            this.groupBox2.Controls.Add(this.dgchTxtDA);
            this.groupBox2.Controls.Add(this.dgchBtnSuaDA);
            this.groupBox2.Controls.Add(this.dgchBtnXoaDA);
            this.groupBox2.Controls.Add(this.dgchBtnThemDA);
            this.groupBox2.Location = new System.Drawing.Point(420, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(400, 222);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin đáp án";
            // 
            // dgchCkbDungSai
            // 
            this.dgchCkbDungSai.AutoSize = true;
            this.dgchCkbDungSai.Location = new System.Drawing.Point(25, 139);
            this.dgchCkbDungSai.Margin = new System.Windows.Forms.Padding(4);
            this.dgchCkbDungSai.Name = "dgchCkbDungSai";
            this.dgchCkbDungSai.Size = new System.Drawing.Size(130, 21);
            this.dgchCkbDungSai.TabIndex = 10;
            this.dgchCkbDungSai.Text = "Là đáp án đúng";
            this.dgchCkbDungSai.UseVisualStyleBackColor = true;
            // 
            // dgchTxtDA
            // 
            this.dgchTxtDA.Location = new System.Drawing.Point(23, 27);
            this.dgchTxtDA.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgchTxtDA.Multiline = true;
            this.dgchTxtDA.Name = "dgchTxtDA";
            this.dgchTxtDA.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgchTxtDA.Size = new System.Drawing.Size(359, 98);
            this.dgchTxtDA.TabIndex = 0;
            // 
            // dgchBtnSuaDA
            // 
            this.dgchBtnSuaDA.Location = new System.Drawing.Point(276, 175);
            this.dgchBtnSuaDA.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgchBtnSuaDA.Name = "dgchBtnSuaDA";
            this.dgchBtnSuaDA.Size = new System.Drawing.Size(107, 31);
            this.dgchBtnSuaDA.TabIndex = 8;
            this.dgchBtnSuaDA.Text = "Cập nhật";
            this.dgchBtnSuaDA.UseVisualStyleBackColor = true;
            // 
            // dgchBtnXoaDA
            // 
            this.dgchBtnXoaDA.Location = new System.Drawing.Point(152, 175);
            this.dgchBtnXoaDA.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgchBtnXoaDA.Name = "dgchBtnXoaDA";
            this.dgchBtnXoaDA.Size = new System.Drawing.Size(107, 31);
            this.dgchBtnXoaDA.TabIndex = 8;
            this.dgchBtnXoaDA.Text = "Xóa";
            this.dgchBtnXoaDA.UseVisualStyleBackColor = true;
            // 
            // dgchBtnThemDA
            // 
            this.dgchBtnThemDA.Location = new System.Drawing.Point(25, 175);
            this.dgchBtnThemDA.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgchBtnThemDA.Name = "dgchBtnThemDA";
            this.dgchBtnThemDA.Size = new System.Drawing.Size(107, 31);
            this.dgchBtnThemDA.TabIndex = 8;
            this.dgchBtnThemDA.Text = "Thêm";
            this.dgchBtnThemDA.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Danh sách câu hỏi:";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ttcnGbttcn
            // 
            this.ttcnGbttcn.Controls.Add(this.textBox1);
            this.ttcnGbttcn.Controls.Add(this.label5);
            this.ttcnGbttcn.Controls.Add(this.ttcnTxtTen);
            this.ttcnGbttcn.Controls.Add(this.label4);
            this.ttcnGbttcn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ttcnGbttcn.Location = new System.Drawing.Point(7, 7);
            this.ttcnGbttcn.Name = "ttcnGbttcn";
            this.ttcnGbttcn.Size = new System.Drawing.Size(618, 325);
            this.ttcnGbttcn.TabIndex = 0;
            this.ttcnGbttcn.TabStop = false;
            this.ttcnGbttcn.Text = "Thông Tin Cá Nhân";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(6, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Họ Tên: ";
            // 
            // ttcnTxtTen
            // 
            this.ttcnTxtTen.Location = new System.Drawing.Point(109, 31);
            this.ttcnTxtTen.Name = "ttcnTxtTen";
            this.ttcnTxtTen.Size = new System.Drawing.Size(400, 30);
            this.ttcnTxtTen.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(109, 74);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(400, 30);
            this.textBox1.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(6, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 25);
            this.label5.TabIndex = 2;
            this.label5.Text = "Họ Tên: ";
            // 
            // frmHocSinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 653);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmHocSinh";
            this.Text = "Học sinh";
            this.tabControl1.ResumeLayout(false);
            this.tpLBTN.ResumeLayout(false);
            this.tpLBTN.PerformLayout();
            this.tpTTCN.ResumeLayout(false);
            this.tpDGCH.ResumeLayout(false);
            this.tpDGCH.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSDA)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ttcnGbttcn.ResumeLayout(false);
            this.ttcnGbttcn.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpLBTN;
        private System.Windows.Forms.TabPage tpTTCN;
        private System.Windows.Forms.TabPage tpOLTT;
        private System.Windows.Forms.TabPage tpDGCH;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button dgchbtnExport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox dgchCbCapDo;
        private System.Windows.Forms.TextBox dgchTxtCH;
        private System.Windows.Forms.Button dgchBtnSuaCH;
        private System.Windows.Forms.Button dgchBtnXoaCH;
        private System.Windows.Forms.Button dgchBtnThemCH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button dgchbtnImport;
        private System.Windows.Forms.ComboBox cbDSCH;
        private System.Windows.Forms.DataGridView dgvDSDA;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox dgchCkbDungSai;
        private System.Windows.Forms.TextBox dgchTxtDA;
        private System.Windows.Forms.Button dgchBtnSuaDA;
        private System.Windows.Forms.Button dgchBtnXoaDA;
        private System.Windows.Forms.Button dgchBtnThemDA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox bttnGbTtHS;
        private System.Windows.Forms.GroupBox bttnGbDiemThi;
        private System.Windows.Forms.GroupBox bttnGbChonCH;
        private System.Windows.Forms.Label lblThoiGian;
        private System.Windows.Forms.Button bttnBtnNopBai;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox ttcnGbttcn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ttcnTxtTen;
        private System.Windows.Forms.Label label4;
    }
}