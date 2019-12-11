using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThiTracNghiem
{
    public partial class frmAdmin : Form
    {
        private NguoiDung admin;
        private frmLogin frmlogin;

        static BindingSource bsLoaiND = new BindingSource();
        static BindingSource bsHS = new BindingSource();
        static BindingSource bsGV = new BindingSource();
        static BindingSource bsAD = new BindingSource();

        private void setQLND()
        {
            lblHoTenAd.Text = admin.TenND;
            using (var qlttn = new QLTTNDataContext())
            {
                qlndCbKhoi.DataSource = qlttn.KhoiLops.Select(kl => kl.maKhoi).ToList();
                qlndCbKhoi.SelectedItem = qlndCbKhoi.Items[0];
                qlndCbLop.DataSource = qlttn.LopHocs.Where(lh => lh.maKhoi == qlndCbKhoi.SelectedValue.ToString()).Select(lh => lh.maLop).ToList();
                qlndCbChuyenMon.DataSource = qlttn.MonHocs.Select(mh => new { mh.maMH, mh.tenMH }).ToList();
                qlndCbChuyenMon.ValueMember = "maMH";
                qlndCbChuyenMon.DisplayMember = "tenMH";
            }
            qlndCbLoaiND.SelectedIndexChanged += (s, e) =>
            {
                loadDgvNguoiDung();
            };
        }
        private void loadCbLoaiND()
        {
            using (var qlttn = new QLTTNDataContext())
            {
                if (qlttn.LoaiNguoiDungs.Count() == 0)
                {
                    MessageBox.Show("Không có dữ liệu loại người dùng", "Thông báo tab Quản lý người dùng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                bsLoaiND.DataSource = qlttn.LoaiNguoiDungs.ToList();
                qlndCbLoaiND.DataSource = bsLoaiND;
                qlndCbLoaiND.ValueMember = "maLND";
                qlndCbLoaiND.DisplayMember = "TenLND";
            }
        }
        private void loadDgvNguoiDung()
        {
            if (bsLoaiND.Count == 0 || qlndCbLoaiND.SelectedValue == null)
            {
                MessageBox.Show("Chọn loại người dùng cần hiển thị", "Thông báo tab Quản lý người dùng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            qlndTxtHoTen.DataBindings.Clear();
            qlndTxtMaND.DataBindings.Clear();
            qlndDtpNgaySinh.DataBindings.Clear();
            qlndCbKhoi.DataBindings.Clear();
            qlndCbLop.DataBindings.Clear();
            qlndCbChuyenMon.DataBindings.Clear();

            using (var qlttn = new QLTTNDataContext())
            {
                var maLND = qlndCbLoaiND.SelectedValue.ToString();
                if (maLND == "HS")
                {
                    bsHS.DataSource = qlttn.HocSinhs.Where(hs => hs.NguoiDung.maLND == maLND).Select(hs => new
                    {
                        hs.maHS,
                        hs.HoTen,
                        hs.NgaySinh,
                        hs.maKhoi,
                        hs.maLop
                    }).ToList();
                    qlndDgvND.DataSource = bsHS;
                    qlndDgvND.Columns["maHS"].HeaderText = "Mã học sinh";
                    qlndDgvND.Columns["HoTen"].HeaderText = "Họ tên";
                    qlndDgvND.Columns["NgaySinh"].HeaderText = "Ngày sinh";
                    qlndDgvND.Columns["maKhoi"].HeaderText = "Khối";
                    qlndDgvND.Columns["maLop"].HeaderText = "Lớp";
                    if (bsHS.Count > 0)
                    {
                        if (qlndTxtHoTen.DataBindings.Count == 0)
                        {
                            qlndTxtHoTen.DataBindings.Add("Text", bsHS, "HoTen", true, DataSourceUpdateMode.Never);
                        }
                        if (qlndTxtMaND.DataBindings.Count == 0)
                        {
                            qlndTxtMaND.DataBindings.Add("Text", bsHS, "maHS", true, DataSourceUpdateMode.Never);
                        }
                        if (qlndDtpNgaySinh.DataBindings.Count == 0)
                        {
                            qlndDtpNgaySinh.DataBindings.Add("Text", bsHS, "NgaySinh", true, DataSourceUpdateMode.Never);
                        }
                        if (qlndCbKhoi.DataBindings.Count == 0)
                        {
                            qlndCbKhoi.DataBindings.Add("Text", bsHS, "maKhoi", true, DataSourceUpdateMode.Never);
                        }
                        if (qlndCbLop.DataBindings.Count == 0)
                        {
                            qlndCbLop.DataBindings.Add("Text", bsHS, "maLop", true, DataSourceUpdateMode.Never);
                        }
                    }
                    //else
                    //{
                    //    qlndTxtHoTen.DataBindings.Clear();
                    //    qlndTxtMaND.DataBindings.Clear();
                    //    qlndDtpNgaySinh.DataBindings.Clear();
                    //    qlndCbKhoi.DataBindings.Clear();
                    //    lbl.DataBindings.Clear();
                    //}
                }
                else if (maLND == "GV")
                {
                    bsGV.DataSource = qlttn.GiaoViens.Where(gv => gv.NguoiDung.maLND == maLND).Select(gv => new
                    {
                        gv.maGV,
                        gv.HoTen,
                        gv.NgaySinh,
                        gv.maMH,
                        gv.MonHoc.tenMH
                    }).ToList();
                    qlndDgvND.DataSource = bsGV;
                    qlndDgvND.Columns["maGV"].HeaderText = "Mã giáo viên";
                    qlndDgvND.Columns["HoTen"].HeaderText = "Họ tên";
                    qlndDgvND.Columns["NgaySinh"].HeaderText = "Ngày sinh";
                    qlndDgvND.Columns["tenMH"].HeaderText = "Chuyên môn";
                    qlndDgvND.Columns["maMH"].Visible = false;
                    if (bsGV.Count > 0)
                    {
                        if (qlndTxtHoTen.DataBindings.Count == 0)
                        {
                            qlndTxtHoTen.DataBindings.Add("Text", bsGV, "HoTen", true, DataSourceUpdateMode.Never);
                        }
                        if (qlndTxtMaND.DataBindings.Count == 0)
                        {
                            qlndTxtMaND.DataBindings.Add("Text", bsGV, "maGV", true, DataSourceUpdateMode.Never);
                        }
                        if (qlndDtpNgaySinh.DataBindings.Count == 0)
                        {
                            qlndDtpNgaySinh.DataBindings.Add("Text", bsGV, "NgaySinh", true, DataSourceUpdateMode.Never);
                        }
                        if (qlndCbChuyenMon.DataBindings.Count == 0)
                        {
                            qlndCbChuyenMon.DataBindings.Add("Text", bsGV, "tenMH", true, DataSourceUpdateMode.Never);
                        }
                    }
                    //else
                    //{
                    //    qlndTxtHoTen.DataBindings.Clear();
                    //    qlndTxtMaND.DataBindings.Clear();
                    //    qlndDtpNgaySinh.DataBindings.Clear();
                    //    qlndCbChuyenMon.DataBindings.Clear();
                    //}
                }
                else
                {
                    bsAD.DataSource = qlttn.NguoiDungs.Where(nd => nd.maLND == "AD").Select(nd => new { nd.maND, nd.TenND });
                    qlndDgvND.DataSource = bsAD;
                }
            }
        }

        public frmAdmin(frmLogin frmlogin, NguoiDung admin)
        {
            InitializeComponent();
            this.admin = admin;
            this.frmlogin = frmlogin;

            setQLND();
            loadCbLoaiND();
            qlndCbKhoi.KeyDown += QlndComboBox_KeyDown;
            qlndCbLop.KeyDown += QlndComboBox_KeyDown;
            qlndCbChuyenMon.KeyDown += QlndComboBox_KeyDown;
            this.FormClosing += (s, e) =>
            {
                this.frmlogin.Close();
            };
        }

        private void QlndComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                // chỉ cho bấm phím lên xuống mà thôi
            }
            else
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}
