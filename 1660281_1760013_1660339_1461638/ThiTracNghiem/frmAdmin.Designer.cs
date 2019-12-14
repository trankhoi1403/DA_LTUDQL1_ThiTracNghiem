namespace ThiTracNghiem
{
    partial class frmAdmin
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsLblHoTenAd = new System.Windows.Forms.ToolStripLabel();
            this.tsBtnDangXuat = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpQLCH = new System.Windows.Forms.TabPage();
            this.gbND = new System.Windows.Forms.GroupBox();
            this.qlndDgvND = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.qlndBtnExport = new System.Windows.Forms.Button();
            this.qlndBtnImport = new System.Windows.Forms.Button();
            this.qlndCbLoaiND = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.qlndDgvCTGiangDay = new System.Windows.Forms.DataGridView();
            this.lblCTGiangDay = new System.Windows.Forms.Label();
            this.qlndCbChuyenMon = new System.Windows.Forms.ComboBox();
            this.lblChuyenMon = new System.Windows.Forms.Label();
            this.qlndTxtMaND = new System.Windows.Forms.TextBox();
            this.qlndDtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.qlndCbLop = new System.Windows.Forms.ComboBox();
            this.qlndCbKhoi = new System.Windows.Forms.ComboBox();
            this.lblLop = new System.Windows.Forms.Label();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.lblMaSo = new System.Windows.Forms.Label();
            this.lblKhoi = new System.Windows.Forms.Label();
            this.qlndTxtHoTen = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.qlndBtnSua = new System.Windows.Forms.Button();
            this.qlndBtnThem = new System.Windows.Forms.Button();
            this.tpQLDT = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.qldtBtnRdCauHoi = new System.Windows.Forms.Button();
            this.qldtLblSoCHDuocChon = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.qldtDgvCauHoi = new System.Windows.Forms.DataGridView();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.qldtDtpThoiGianLamBai = new System.Windows.Forms.DateTimePicker();
            this.qldtLblNgayTao = new System.Windows.Forms.Label();
            this.qldtLblNguoiTao = new System.Windows.Forms.Label();
            this.qldtBtnThemDT = new System.Windows.Forms.Button();
            this.qldtBtnSuaDT = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.qldtTxtTenDT = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.qldtBtnXoaDT = new System.Windows.Forms.Button();
            this.qldtDgvDeThi = new System.Windows.Forms.DataGridView();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpQLCH.SuspendLayout();
            this.gbND.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qlndDgvND)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qlndDgvCTGiangDay)).BeginInit();
            this.tpQLDT.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qldtDgvCauHoi)).BeginInit();
            this.groupBox10.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qldtDgvDeThi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLblHoTenAd,
            this.tsBtnDangXuat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1008, 25);
            this.toolStrip1.TabIndex = 34;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsLblHoTenAd
            // 
            this.tsLblHoTenAd.Name = "tsLblHoTenAd";
            this.tsLblHoTenAd.Size = new System.Drawing.Size(56, 22);
            this.tsLblHoTenAd.Text = "Xin chào:";
            // 
            // tsBtnDangXuat
            // 
            this.tsBtnDangXuat.Image = global::ThiTracNghiem.Properties.Resources.logout;
            this.tsBtnDangXuat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDangXuat.Name = "tsBtnDangXuat";
            this.tsBtnDangXuat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tsBtnDangXuat.Size = new System.Drawing.Size(81, 22);
            this.tsBtnDangXuat.Text = "Đăng xuất";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpQLCH);
            this.tabControl1.Controls.Add(this.tpQLDT);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(86, 18);
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1008, 500);
            this.tabControl1.TabIndex = 35;
            // 
            // tpQLCH
            // 
            this.tpQLCH.BackColor = System.Drawing.Color.Transparent;
            this.tpQLCH.Controls.Add(this.gbND);
            this.tpQLCH.Controls.Add(this.groupBox2);
            this.tpQLCH.Controls.Add(this.groupBox4);
            this.tpQLCH.Location = new System.Drawing.Point(4, 22);
            this.tpQLCH.Name = "tpQLCH";
            this.tpQLCH.Padding = new System.Windows.Forms.Padding(3);
            this.tpQLCH.Size = new System.Drawing.Size(1000, 474);
            this.tpQLCH.TabIndex = 0;
            this.tpQLCH.Text = "Quản lý người dùng";
            // 
            // gbND
            // 
            this.gbND.BackColor = System.Drawing.Color.PowderBlue;
            this.gbND.Controls.Add(this.qlndDgvND);
            this.gbND.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbND.Location = new System.Drawing.Point(367, 14);
            this.gbND.Margin = new System.Windows.Forms.Padding(2);
            this.gbND.Name = "gbND";
            this.gbND.Padding = new System.Windows.Forms.Padding(2);
            this.gbND.Size = new System.Drawing.Size(618, 447);
            this.gbND.TabIndex = 32;
            this.gbND.TabStop = false;
            this.gbND.Text = "Tổng số người dùng:";
            // 
            // qlndDgvND
            // 
            this.qlndDgvND.AllowUserToAddRows = false;
            this.qlndDgvND.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.qlndDgvND.Location = new System.Drawing.Point(13, 23);
            this.qlndDgvND.Margin = new System.Windows.Forms.Padding(2);
            this.qlndDgvND.MultiSelect = false;
            this.qlndDgvND.Name = "qlndDgvND";
            this.qlndDgvND.ReadOnly = true;
            this.qlndDgvND.RowHeadersVisible = false;
            this.qlndDgvND.RowHeadersWidth = 51;
            this.qlndDgvND.RowTemplate.Height = 24;
            this.qlndDgvND.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.qlndDgvND.Size = new System.Drawing.Size(589, 410);
            this.qlndDgvND.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Salmon;
            this.groupBox2.Controls.Add(this.qlndBtnExport);
            this.groupBox2.Controls.Add(this.qlndBtnImport);
            this.groupBox2.Controls.Add(this.qlndCbLoaiND);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(14, 14);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(349, 136);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            // 
            // qlndBtnExport
            // 
            this.qlndBtnExport.BackColor = System.Drawing.Color.Cornsilk;
            this.qlndBtnExport.Location = new System.Drawing.Point(177, 66);
            this.qlndBtnExport.Name = "qlndBtnExport";
            this.qlndBtnExport.Size = new System.Drawing.Size(111, 45);
            this.qlndBtnExport.TabIndex = 2;
            this.qlndBtnExport.Text = "Xuất ra excel";
            this.qlndBtnExport.UseVisualStyleBackColor = false;
            // 
            // qlndBtnImport
            // 
            this.qlndBtnImport.BackColor = System.Drawing.Color.Cornsilk;
            this.qlndBtnImport.Location = new System.Drawing.Point(46, 66);
            this.qlndBtnImport.Name = "qlndBtnImport";
            this.qlndBtnImport.Size = new System.Drawing.Size(111, 45);
            this.qlndBtnImport.TabIndex = 1;
            this.qlndBtnImport.Text = "Nhập từ excel";
            this.qlndBtnImport.UseVisualStyleBackColor = false;
            // 
            // qlndCbLoaiND
            // 
            this.qlndCbLoaiND.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.qlndCbLoaiND.FormattingEnabled = true;
            this.qlndCbLoaiND.Location = new System.Drawing.Point(149, 21);
            this.qlndCbLoaiND.Margin = new System.Windows.Forms.Padding(2);
            this.qlndCbLoaiND.MaxDropDownItems = 5;
            this.qlndCbLoaiND.Name = "qlndCbLoaiND";
            this.qlndCbLoaiND.Size = new System.Drawing.Size(169, 23);
            this.qlndCbLoaiND.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 15);
            this.label3.TabIndex = 32;
            this.label3.Text = "Loại người dùng:";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.PowderBlue;
            this.groupBox4.Controls.Add(this.qlndDgvCTGiangDay);
            this.groupBox4.Controls.Add(this.lblCTGiangDay);
            this.groupBox4.Controls.Add(this.qlndCbChuyenMon);
            this.groupBox4.Controls.Add(this.lblChuyenMon);
            this.groupBox4.Controls.Add(this.qlndTxtMaND);
            this.groupBox4.Controls.Add(this.qlndDtpNgaySinh);
            this.groupBox4.Controls.Add(this.qlndCbLop);
            this.groupBox4.Controls.Add(this.qlndCbKhoi);
            this.groupBox4.Controls.Add(this.lblLop);
            this.groupBox4.Controls.Add(this.lblNgaySinh);
            this.groupBox4.Controls.Add(this.lblMaSo);
            this.groupBox4.Controls.Add(this.lblKhoi);
            this.groupBox4.Controls.Add(this.qlndTxtHoTen);
            this.groupBox4.Controls.Add(this.lblHoTen);
            this.groupBox4.Controls.Add(this.qlndBtnSua);
            this.groupBox4.Controls.Add(this.qlndBtnThem);
            this.groupBox4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(14, 154);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(349, 307);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Thông tin chi tiết";
            // 
            // qlndDgvCTGiangDay
            // 
            this.qlndDgvCTGiangDay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.qlndDgvCTGiangDay.ColumnHeadersVisible = false;
            this.qlndDgvCTGiangDay.Location = new System.Drawing.Point(139, 139);
            this.qlndDgvCTGiangDay.Name = "qlndDgvCTGiangDay";
            this.qlndDgvCTGiangDay.RowHeadersVisible = false;
            this.qlndDgvCTGiangDay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.qlndDgvCTGiangDay.Size = new System.Drawing.Size(175, 90);
            this.qlndDgvCTGiangDay.TabIndex = 7;
            // 
            // lblCTGiangDay
            // 
            this.lblCTGiangDay.AutoSize = true;
            this.lblCTGiangDay.Location = new System.Drawing.Point(29, 143);
            this.lblCTGiangDay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCTGiangDay.Name = "lblCTGiangDay";
            this.lblCTGiangDay.Size = new System.Drawing.Size(91, 15);
            this.lblCTGiangDay.TabIndex = 43;
            this.lblCTGiangDay.Text = "Đang dạy: 3 lớp";
            // 
            // qlndCbChuyenMon
            // 
            this.qlndCbChuyenMon.FormattingEnabled = true;
            this.qlndCbChuyenMon.Location = new System.Drawing.Point(139, 110);
            this.qlndCbChuyenMon.Margin = new System.Windows.Forms.Padding(2);
            this.qlndCbChuyenMon.MaxDropDownItems = 5;
            this.qlndCbChuyenMon.Name = "qlndCbChuyenMon";
            this.qlndCbChuyenMon.Size = new System.Drawing.Size(175, 23);
            this.qlndCbChuyenMon.TabIndex = 6;
            // 
            // lblChuyenMon
            // 
            this.lblChuyenMon.AutoSize = true;
            this.lblChuyenMon.Location = new System.Drawing.Point(28, 113);
            this.lblChuyenMon.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblChuyenMon.Name = "lblChuyenMon";
            this.lblChuyenMon.Size = new System.Drawing.Size(78, 15);
            this.lblChuyenMon.TabIndex = 40;
            this.lblChuyenMon.Text = "Chuyên môn:";
            // 
            // qlndTxtMaND
            // 
            this.qlndTxtMaND.Location = new System.Drawing.Point(139, 27);
            this.qlndTxtMaND.MaxLength = 10;
            this.qlndTxtMaND.Name = "qlndTxtMaND";
            this.qlndTxtMaND.Size = new System.Drawing.Size(95, 22);
            this.qlndTxtMaND.TabIndex = 3;
            // 
            // qlndDtpNgaySinh
            // 
            this.qlndDtpNgaySinh.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            this.qlndDtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.qlndDtpNgaySinh.Location = new System.Drawing.Point(139, 83);
            this.qlndDtpNgaySinh.Name = "qlndDtpNgaySinh";
            this.qlndDtpNgaySinh.Size = new System.Drawing.Size(95, 22);
            this.qlndDtpNgaySinh.TabIndex = 5;
            // 
            // qlndCbLop
            // 
            this.qlndCbLop.FormattingEnabled = true;
            this.qlndCbLop.Location = new System.Drawing.Point(139, 139);
            this.qlndCbLop.Margin = new System.Windows.Forms.Padding(2);
            this.qlndCbLop.MaxDropDownItems = 5;
            this.qlndCbLop.Name = "qlndCbLop";
            this.qlndCbLop.Size = new System.Drawing.Size(63, 23);
            this.qlndCbLop.TabIndex = 7;
            // 
            // qlndCbKhoi
            // 
            this.qlndCbKhoi.FormattingEnabled = true;
            this.qlndCbKhoi.Location = new System.Drawing.Point(139, 110);
            this.qlndCbKhoi.Margin = new System.Windows.Forms.Padding(2);
            this.qlndCbKhoi.MaxDropDownItems = 5;
            this.qlndCbKhoi.Name = "qlndCbKhoi";
            this.qlndCbKhoi.Size = new System.Drawing.Size(63, 23);
            this.qlndCbKhoi.TabIndex = 6;
            // 
            // lblLop
            // 
            this.lblLop.AutoSize = true;
            this.lblLop.Location = new System.Drawing.Point(30, 140);
            this.lblLop.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(31, 15);
            this.lblLop.TabIndex = 20;
            this.lblLop.Text = "Lớp:";
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Location = new System.Drawing.Point(29, 86);
            this.lblNgaySinh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(65, 15);
            this.lblNgaySinh.TabIndex = 19;
            this.lblNgaySinh.Text = "Ngày sinh:";
            // 
            // lblMaSo
            // 
            this.lblMaSo.AutoSize = true;
            this.lblMaSo.Location = new System.Drawing.Point(29, 30);
            this.lblMaSo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaSo.Name = "lblMaSo";
            this.lblMaSo.Size = new System.Drawing.Size(44, 15);
            this.lblMaSo.TabIndex = 18;
            this.lblMaSo.Text = "Mã số:";
            // 
            // lblKhoi
            // 
            this.lblKhoi.AutoSize = true;
            this.lblKhoi.Location = new System.Drawing.Point(29, 113);
            this.lblKhoi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblKhoi.Name = "lblKhoi";
            this.lblKhoi.Size = new System.Drawing.Size(36, 15);
            this.lblKhoi.TabIndex = 17;
            this.lblKhoi.Text = "Khối:";
            // 
            // qlndTxtHoTen
            // 
            this.qlndTxtHoTen.Location = new System.Drawing.Point(139, 55);
            this.qlndTxtHoTen.MaxLength = 100;
            this.qlndTxtHoTen.Name = "qlndTxtHoTen";
            this.qlndTxtHoTen.Size = new System.Drawing.Size(175, 22);
            this.qlndTxtHoTen.TabIndex = 4;
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(29, 58);
            this.lblHoTen.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(46, 15);
            this.lblHoTen.TabIndex = 15;
            this.lblHoTen.Text = "Họ tên:";
            // 
            // qlndBtnSua
            // 
            this.qlndBtnSua.BackColor = System.Drawing.Color.Cornsilk;
            this.qlndBtnSua.Location = new System.Drawing.Point(206, 247);
            this.qlndBtnSua.Margin = new System.Windows.Forms.Padding(2);
            this.qlndBtnSua.Name = "qlndBtnSua";
            this.qlndBtnSua.Size = new System.Drawing.Size(71, 46);
            this.qlndBtnSua.TabIndex = 9;
            this.qlndBtnSua.Text = "Cập nhật";
            this.qlndBtnSua.UseVisualStyleBackColor = false;
            // 
            // qlndBtnThem
            // 
            this.qlndBtnThem.BackColor = System.Drawing.Color.Cornsilk;
            this.qlndBtnThem.Location = new System.Drawing.Point(53, 245);
            this.qlndBtnThem.Margin = new System.Windows.Forms.Padding(2);
            this.qlndBtnThem.Name = "qlndBtnThem";
            this.qlndBtnThem.Size = new System.Drawing.Size(71, 46);
            this.qlndBtnThem.TabIndex = 8;
            this.qlndBtnThem.Text = "Thêm";
            this.qlndBtnThem.UseVisualStyleBackColor = false;
            // 
            // tpQLDT
            // 
            this.tpQLDT.BackColor = System.Drawing.Color.LavenderBlush;
            this.tpQLDT.Controls.Add(this.groupBox8);
            this.tpQLDT.Controls.Add(this.groupBox10);
            this.tpQLDT.Controls.Add(this.groupBox7);
            this.tpQLDT.Location = new System.Drawing.Point(4, 22);
            this.tpQLDT.Name = "tpQLDT";
            this.tpQLDT.Padding = new System.Windows.Forms.Padding(3);
            this.tpQLDT.Size = new System.Drawing.Size(1000, 474);
            this.tpQLDT.TabIndex = 1;
            this.tpQLDT.Text = "Quản lý hệ thống";
            // 
            // groupBox8
            // 
            this.groupBox8.BackColor = System.Drawing.Color.PowderBlue;
            this.groupBox8.Controls.Add(this.qldtBtnRdCauHoi);
            this.groupBox8.Controls.Add(this.qldtLblSoCHDuocChon);
            this.groupBox8.Controls.Add(this.label11);
            this.groupBox8.Controls.Add(this.qldtDgvCauHoi);
            this.groupBox8.Location = new System.Drawing.Point(530, 15);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(432, 451);
            this.groupBox8.TabIndex = 12;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Danh sách câu hỏi trong đề thi";
            // 
            // qldtBtnRdCauHoi
            // 
            this.qldtBtnRdCauHoi.BackColor = System.Drawing.Color.Cornsilk;
            this.qldtBtnRdCauHoi.Location = new System.Drawing.Point(272, 21);
            this.qldtBtnRdCauHoi.Name = "qldtBtnRdCauHoi";
            this.qldtBtnRdCauHoi.Size = new System.Drawing.Size(116, 41);
            this.qldtBtnRdCauHoi.TabIndex = 37;
            this.qldtBtnRdCauHoi.Text = "Random câu hỏi";
            this.qldtBtnRdCauHoi.UseVisualStyleBackColor = false;
            // 
            // qldtLblSoCHDuocChon
            // 
            this.qldtLblSoCHDuocChon.AutoSize = true;
            this.qldtLblSoCHDuocChon.Location = new System.Drawing.Point(138, 35);
            this.qldtLblSoCHDuocChon.Name = "qldtLblSoCHDuocChon";
            this.qldtLblSoCHDuocChon.Size = new System.Drawing.Size(35, 15);
            this.qldtLblSoCHDuocChon.TabIndex = 36;
            this.qldtLblSoCHDuocChon.Text = "0 câu";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(47, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 15);
            this.label11.TabIndex = 32;
            this.label11.Text = "Tổng số câu:";
            // 
            // qldtDgvCauHoi
            // 
            this.qldtDgvCauHoi.AllowUserToAddRows = false;
            this.qldtDgvCauHoi.AllowUserToDeleteRows = false;
            this.qldtDgvCauHoi.AllowUserToOrderColumns = true;
            this.qldtDgvCauHoi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.qldtDgvCauHoi.Location = new System.Drawing.Point(24, 72);
            this.qldtDgvCauHoi.Name = "qldtDgvCauHoi";
            this.qldtDgvCauHoi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.qldtDgvCauHoi.Size = new System.Drawing.Size(389, 350);
            this.qldtDgvCauHoi.TabIndex = 35;
            // 
            // groupBox10
            // 
            this.groupBox10.BackColor = System.Drawing.Color.PowderBlue;
            this.groupBox10.Controls.Add(this.qldtDtpThoiGianLamBai);
            this.groupBox10.Controls.Add(this.qldtLblNgayTao);
            this.groupBox10.Controls.Add(this.qldtLblNguoiTao);
            this.groupBox10.Controls.Add(this.qldtBtnThemDT);
            this.groupBox10.Controls.Add(this.qldtBtnSuaDT);
            this.groupBox10.Controls.Add(this.label8);
            this.groupBox10.Controls.Add(this.qldtTxtTenDT);
            this.groupBox10.Controls.Add(this.label15);
            this.groupBox10.Controls.Add(this.label10);
            this.groupBox10.Controls.Add(this.label9);
            this.groupBox10.Controls.Add(this.label16);
            this.groupBox10.Location = new System.Drawing.Point(13, 224);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(519, 242);
            this.groupBox10.TabIndex = 11;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Chi tiết đề thi";
            // 
            // qldtDtpThoiGianLamBai
            // 
            this.qldtDtpThoiGianLamBai.CustomFormat = "hh:mm:ss";
            this.qldtDtpThoiGianLamBai.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.qldtDtpThoiGianLamBai.Location = new System.Drawing.Point(181, 55);
            this.qldtDtpThoiGianLamBai.Name = "qldtDtpThoiGianLamBai";
            this.qldtDtpThoiGianLamBai.Size = new System.Drawing.Size(70, 22);
            this.qldtDtpThoiGianLamBai.TabIndex = 35;
            // 
            // qldtLblNgayTao
            // 
            this.qldtLblNgayTao.AutoSize = true;
            this.qldtLblNgayTao.Location = new System.Drawing.Point(178, 115);
            this.qldtLblNgayTao.Name = "qldtLblNgayTao";
            this.qldtLblNgayTao.Size = new System.Drawing.Size(27, 15);
            this.qldtLblNgayTao.TabIndex = 34;
            this.qldtLblNgayTao.Text = "null";
            // 
            // qldtLblNguoiTao
            // 
            this.qldtLblNguoiTao.AutoSize = true;
            this.qldtLblNguoiTao.Location = new System.Drawing.Point(178, 88);
            this.qldtLblNguoiTao.Name = "qldtLblNguoiTao";
            this.qldtLblNguoiTao.Size = new System.Drawing.Size(27, 15);
            this.qldtLblNguoiTao.TabIndex = 33;
            this.qldtLblNguoiTao.Text = "null";
            // 
            // qldtBtnThemDT
            // 
            this.qldtBtnThemDT.BackColor = System.Drawing.Color.Cornsilk;
            this.qldtBtnThemDT.Location = new System.Drawing.Point(424, 55);
            this.qldtBtnThemDT.Name = "qldtBtnThemDT";
            this.qldtBtnThemDT.Size = new System.Drawing.Size(72, 46);
            this.qldtBtnThemDT.TabIndex = 32;
            this.qldtBtnThemDT.Text = "Thêm đề thi";
            this.qldtBtnThemDT.UseVisualStyleBackColor = false;
            // 
            // qldtBtnSuaDT
            // 
            this.qldtBtnSuaDT.BackColor = System.Drawing.Color.Cornsilk;
            this.qldtBtnSuaDT.Location = new System.Drawing.Point(424, 145);
            this.qldtBtnSuaDT.Name = "qldtBtnSuaDT";
            this.qldtBtnSuaDT.Size = new System.Drawing.Size(72, 46);
            this.qldtBtnSuaDT.TabIndex = 31;
            this.qldtBtnSuaDT.Text = "Cập nhật đề thi";
            this.qldtBtnSuaDT.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(53, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 15);
            this.label8.TabIndex = 30;
            this.label8.Text = "Thời gian làm bài:";
            // 
            // qldtTxtTenDT
            // 
            this.qldtTxtTenDT.Location = new System.Drawing.Point(181, 25);
            this.qldtTxtTenDT.MaxLength = 1000;
            this.qldtTxtTenDT.Name = "qldtTxtTenDT";
            this.qldtTxtTenDT.Size = new System.Drawing.Size(176, 22);
            this.qldtTxtTenDT.TabIndex = 28;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(53, 28);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 15);
            this.label15.TabIndex = 27;
            this.label15.Text = "Tên đề thi:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(53, 115);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 15);
            this.label10.TabIndex = 24;
            this.label10.Text = "Ngày tạo:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(53, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 15);
            this.label9.TabIndex = 23;
            this.label9.Text = "Người tạo:";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(53, 144);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(114, 44);
            this.label16.TabIndex = 22;
            this.label16.Text = "Danh sách các kỳ thi đã sử dụng:";
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.Color.Salmon;
            this.groupBox7.Controls.Add(this.qldtBtnXoaDT);
            this.groupBox7.Controls.Add(this.qldtDgvDeThi);
            this.groupBox7.Location = new System.Drawing.Point(13, 15);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(511, 203);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Danh sách đề thi";
            // 
            // qldtBtnXoaDT
            // 
            this.qldtBtnXoaDT.BackColor = System.Drawing.Color.Cornsilk;
            this.qldtBtnXoaDT.Location = new System.Drawing.Point(424, 72);
            this.qldtBtnXoaDT.Name = "qldtBtnXoaDT";
            this.qldtBtnXoaDT.Size = new System.Drawing.Size(72, 50);
            this.qldtBtnXoaDT.TabIndex = 33;
            this.qldtBtnXoaDT.Text = "Xóa đề thi";
            this.qldtBtnXoaDT.UseVisualStyleBackColor = false;
            // 
            // qldtDgvDeThi
            // 
            this.qldtDgvDeThi.AllowUserToAddRows = false;
            this.qldtDgvDeThi.AllowUserToDeleteRows = false;
            this.qldtDgvDeThi.AllowUserToOrderColumns = true;
            this.qldtDgvDeThi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.qldtDgvDeThi.Location = new System.Drawing.Point(14, 19);
            this.qldtDgvDeThi.Name = "qldtDgvDeThi";
            this.qldtDgvDeThi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.qldtDgvDeThi.Size = new System.Drawing.Size(400, 168);
            this.qldtDgvDeThi.TabIndex = 0;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 521);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản trị viên";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tpQLCH.ResumeLayout(false);
            this.gbND.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qlndDgvND)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qlndDgvCTGiangDay)).EndInit();
            this.tpQLDT.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qldtDgvCauHoi)).EndInit();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qldtDgvDeThi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel tsLblHoTenAd;
        private System.Windows.Forms.ToolStripButton tsBtnDangXuat;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpQLCH;
        private System.Windows.Forms.GroupBox gbND;
        private System.Windows.Forms.DataGridView qlndDgvND;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button qlndBtnExport;
        private System.Windows.Forms.Button qlndBtnImport;
        private System.Windows.Forms.ComboBox qlndCbLoaiND;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox qlndCbChuyenMon;
        private System.Windows.Forms.Label lblChuyenMon;
        private System.Windows.Forms.TextBox qlndTxtMaND;
        private System.Windows.Forms.DateTimePicker qlndDtpNgaySinh;
        private System.Windows.Forms.ComboBox qlndCbLop;
        private System.Windows.Forms.ComboBox qlndCbKhoi;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.Label lblMaSo;
        private System.Windows.Forms.Label lblKhoi;
        private System.Windows.Forms.TextBox qlndTxtHoTen;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Button qlndBtnSua;
        private System.Windows.Forms.Button qlndBtnThem;
        private System.Windows.Forms.TabPage tpQLDT;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button qldtBtnRdCauHoi;
        private System.Windows.Forms.Label qldtLblSoCHDuocChon;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView qldtDgvCauHoi;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.DateTimePicker qldtDtpThoiGianLamBai;
        private System.Windows.Forms.Label qldtLblNgayTao;
        private System.Windows.Forms.Label qldtLblNguoiTao;
        private System.Windows.Forms.Button qldtBtnThemDT;
        private System.Windows.Forms.Button qldtBtnSuaDT;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox qldtTxtTenDT;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button qldtBtnXoaDT;
        private System.Windows.Forms.DataGridView qldtDgvDeThi;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label lblCTGiangDay;
        private System.Windows.Forms.DataGridView qlndDgvCTGiangDay;
    }
}