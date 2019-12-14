using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Linq;
using System.IO;
using ClosedXML.Excel;
using System.Text.RegularExpressions;

namespace ThiTracNghiem
{
    public partial class frmGiaoVien : Form
    {
        private frmLogin frmlogin = null;
        private GiaoVien gv = null;
        private List<string> lkl = null;
        private BindingSource bsCauHoi = new BindingSource();
        private BindingSource bsDapAn = new BindingSource();
        private BindingSource bsDethi = new BindingSource();
        private BindingSource bsHocSinh = new BindingSource();

        private void loadCbKhoiLop()
        {
            using (var qlttn = new QLTTNDataContext())
            {
                lkl = gv.CT_GiangDays.Select(ctgd => ctgd.maKhoi).Distinct().ToList();
                cbKhoiLop.DataSource = lkl;
                //cbKhoiLop.DisplayMember = "maKhoi";
                //cbKhoiLop.ValueMember = "maKhoi";
                if (cbKhoiLop.Items.Count != 0)
                {
                    cbKhoiLop.SelectedItem = cbKhoiLop.Items[0];
                    string txt = cbKhoiLop.SelectedValue.ToString();
                }
                lblHoTenGV.Text = gv.HoTen;
                lblNgaySinhGV.Text = $"Ngày sinh: {gv.NgaySinh.Value.ToShortDateString()}";
                lblChuyenMon.Text = $"Chuyên môn: {qlttn.MonHocs.Where(mh => mh.maMH == gv.maMH).Single().tenMH}";

            }
        }
        private void loadQlchCbCauHoi()
        {
            using (var qlttn = new QLTTNDataContext())
            {
                try
                {
                    var cauHoi = (qlttn.CauHois.Where(ch => ch.maKhoi == cbKhoiLop.SelectedValue.ToString() && ch.maMH == gv.maMH)
                                                    .Select(ch => new { ch.maCH, ch.NoiDung, ch.CapDo.TenCD, ch.maCD }).ToList());
                    bsCauHoi.DataSource = cauHoi;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return;
                }

                if (bsCauHoi.Count > 0)
                {
                    qlchCbDsch.DataSource = bsCauHoi;
                    qlchCbDsch.DisplayMember = "NoiDung";
                    qlchCbDsch.ValueMember = "maCH";

                    qlchCbCapDo.DataSource = qlttn.CapDos.ToList();
                    qlchCbCapDo.DisplayMember = "TenCD";
                    qlchCbCapDo.ValueMember = "maCD";

                    var macd = qlttn.CauHois.Where(ch => ch.maCH.ToString() == qlchCbDsch.SelectedValue.ToString()).Single().maCD;
                    qlchCbCapDo.SelectedValue = macd;

                    if (qlchTxtCauHoi.DataBindings.Count == 0)
                    {
                        qlchTxtCauHoi.DataBindings.Add("Text", bsCauHoi, "NoiDung", true, DataSourceUpdateMode.Never, "Null value");
                    }
                    if (qlchCbCapDo.DataBindings.Count == 0)
                    {
                        qlchCbCapDo.DataBindings.Add("SelectedValue", bsCauHoi, "maCD", true, DataSourceUpdateMode.Never, "Null value");
                        qlchCbCapDo.DataBindings[0].Format += (s, e) =>
                        {
                            if (e.DesiredType == typeof(string))
                            {
                                int maCapDo = int.Parse(e.Value.ToString());
                                e.Value = (qlchCbCapDo.DataSource as List<CapDo>).Where(cd => cd.maCD == maCapDo).FirstOrDefault().TenCD;
                            }
                        };
                        qlchCbCapDo.DataBindings[0].Parse += (s, e) =>
                        {
                            if (e.DesiredType == typeof(int))
                            {
                                string noiDungCapDo = e.Value.ToString();
                                e.Value = (qlchCbCapDo.DataSource as List<CapDo>).Where(cd => cd.TenCD == noiDungCapDo).FirstOrDefault().maCD;
                            }
                        };
                    }
                }
                else
                {
                    qlchCbCapDo.DataBindings.Clear();
                    qlchTxtCauHoi.DataBindings.Clear();
                    MessageBox.Show("Không có dữ liệu câu hỏi", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void loadQlchDgvDapAn()
        {
            using (var qlttn = new QLTTNDataContext())
            {
                if (qlttn.CauHois.Count() > 0)
                {
                    try
                    {
                        bsDapAn.DataSource = qlttn.CauHois.Where(ch => ch.maCH == int.Parse(qlchCbDsch.SelectedValue.ToString())).SingleOrDefault().DapAns.ToList();
                        qlchDgvDsda.DataSource = bsDapAn;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                        return;
                    }

                    qlchDgvDsda.Columns["maCH"].Visible = false;
                    qlchDgvDsda.Columns["CauHoi"].Visible = false;
                    qlchDgvDsda.Columns["maDA"].Visible = false;
                    qlchDgvDsda.Columns["NoiDung"].DisplayIndex = 1;
                    qlchDgvDsda.Columns["NoiDung"].Width = 310;
                    qlchDgvDsda.Columns["NoiDung"].HeaderText = "Nội dung đáp án";
                    qlchDgvDsda.Columns["DungSai"].DisplayIndex = 2;
                    qlchDgvDsda.Columns["DungSai"].Width = 115;
                    qlchDgvDsda.Columns["DungSai"].HeaderText = "Tính chất đáp án";

                    if (qlchTxtDapAn.DataBindings.Count == 0)
                    {
                        qlchTxtDapAn.DataBindings.Add("Text", bsDapAn, "NoiDung", true, DataSourceUpdateMode.Never, "Null value");
                    }
                    if (qlchCkbDungSai.DataBindings.Count == 0)
                    {
                        qlchCkbDungSai.DataBindings.Add("Checked", bsDapAn, "DungSai", true, DataSourceUpdateMode.Never, false);
                    }
                }
                else
                {
                    qlchTxtDapAn.DataBindings.Clear();
                    qlchCkbDungSai.DataBindings.Clear();
                    MessageBox.Show("Không có dữ liệu đáp án", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void setQlch()
        {
            qlchTxtCauHoi.Validating += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(qlchTxtCauHoi.Text))
                {
                    e.Cancel = true;
                    qlchTxtCauHoi.Focus();
                    errorProvider.SetError(qlchTxtCauHoi, "Không được để trống câu hỏi");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(qlchTxtCauHoi, "");
                }
            };
            qlchTxtDapAn.Validating += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(qlchTxtDapAn.Text))
                {
                    e.Cancel = true;
                    qlchTxtCauHoi.Focus();
                    errorProvider.SetError(qlchTxtDapAn, "Không được để trống câu hỏi");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(qlchTxtDapAn, "");
                }
            };
            qlchCbDsch.SelectedIndexChanged += (s, e) =>
             {
                 loadQlchDgvDapAn();

                 if (qlchCbDsch.SelectedValue == null)
                 {
                     return;
                 }
                 using (var qlttn = new QLTTNDataContext())
                 {
                     qlchLbDeThiSuDungCauHoi.DataSource = qlttn.DeThis.Where(dt => dt.CT_DeThis.
                                                                                 Where(ctdt => ctdt.maCH == int.Parse(qlchCbDsch.SelectedValue.ToString())).Count() > 0)
                                                                      .Select(dt => new { dt.maDT, dt.TenDT }).ToList();
                 }
             };
            qlchLbDeThiSuDungCauHoi.Format += (s, e) =>
            {
                if (e.DesiredType == typeof(string))
                {
                    string str = e.Value.ToString();
                    str = str.Replace("{ maDT = ", "");
                    str = str.Replace(", TenDT = ", "-");
                    str = str.Remove(str.Length - 1, 1);
                    e.Value = str;
                }
            };
        }

        private void loadQldtDgvDeThi()
        {
            using (var qlttn = new QLTTNDataContext())
            {
                try
                {
                    var sourceDt = qlttn.DeThis.Where(dt => dt.maMH == gv.maMH && dt.maKhoi == cbKhoiLop.SelectedValue.ToString())
                                                .Select(dt => new { dt.maDT, dt.TenDT, dt.GiaoVien.HoTen, dt.ThoiGianLamBai, dt.NgayTao })
                                                .ToList();
                    bsDethi.DataSource = sourceDt;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return;
                }
                if (bsDethi.Count > 0)
                {
                    qldtDgvDeThi.DataSource = bsDethi;

                    qldtDgvDeThi.Columns["maDT"].HeaderText = "Mã";
                    qldtDgvDeThi.Columns["maDT"].Width = 40;
                    qldtDgvDeThi.Columns["TenDT"].HeaderText = "Tên đề thi";
                    qldtDgvDeThi.Columns["HoTen"].HeaderText = "Giáo viên ra đề";
                    qldtDgvDeThi.Columns["ThoiGianLamBai"].HeaderText = "Thời gian làm bài";
                    qldtDgvDeThi.Columns["ThoiGianLamBai"].Width = 90;
                    qldtDgvDeThi.Columns["NgayTao"].HeaderText = "Ngày tạo";

                    if (qldtTxtTenDT.DataBindings.Count == 0)
                    {
                        qldtTxtTenDT.DataBindings.Add("Text", bsDethi, "TenDT", true, DataSourceUpdateMode.Never, "null");
                    }
                    if (qldtLblNgayTao.DataBindings.Count == 0)
                    {
                        qldtLblNgayTao.DataBindings.Add("Text", bsDethi, "NgayTao", true, DataSourceUpdateMode.Never, 0);
                    }
                    if (qldtLblNguoiTao.DataBindings.Count == 0)
                    {
                        qldtLblNguoiTao.DataBindings.Add("Text", bsDethi, "HoTen", true, DataSourceUpdateMode.Never, 0);
                    }
                    if (qldtTxtThoiGianLamBai.DataBindings.Count == 0)
                    {
                        qldtTxtThoiGianLamBai.DataBindings.Add("Text", bsDethi, "ThoiGianLamBai", true, DataSourceUpdateMode.Never, 0);
                        qldtTxtThoiGianLamBai.DataBindings[0].Format += (s, e) =>
                         {
                             if (e.DesiredType == typeof(string))
                             {
                                 TimeSpan soPhut = TimeSpan.Parse(e.Value.ToString());
                                 e.Value = soPhut.TotalMinutes.ToString();
                             }
                         };
                    }
                }
                else
                {
                    qldtTxtTenDT.DataBindings.Clear();
                    qldtLblNguoiTao.DataBindings.Clear();
                    qldtLblNgayTao.DataBindings.Clear();
                    qldtTxtThoiGianLamBai.DataBindings.Clear();
                    MessageBox.Show("Không có dữ liệu trong dgv đề thi");
                }
            }
        }
        private void loadQldtDgvCauHoi()
        {
            if (bsCauHoi.Count > 0)
            {
                qldtDgvCauHoi.DataSource = bsCauHoi;
                qldtDgvCauHoi.Columns["maCH"].Width = 40;
                qldtDgvCauHoi.Columns["maCH"].HeaderText = "Mã";
                qldtDgvCauHoi.Columns["NoiDung"].Width = 140;
                qldtDgvCauHoi.Columns["NoiDung"].HeaderText = "Nội dung";
                qldtDgvCauHoi.Columns["TenCD"].Width = 80;
                qldtDgvCauHoi.Columns["TenCD"].HeaderText = "Cấp độ";
                qldtDgvCauHoi.Columns["maCD"].Visible = false;
                qldtDgvCauHoi.AllowUserToOrderColumns = true;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu câu hỏi", "Thông báo tab Quản lý đề thi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void setQldt()
        {
            qldtDgvCauHoi.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                Name = "Chon",
                HeaderText = "Chọn câu hỏi",
                Width = 80,
                TrueValue = true,    // khi được check thì value sẽ là true, được ktra trong event CellValueChanged
                FalseValue = false,
                IndeterminateValue = false
            });
            qldtDgvDeThi.Columns.Add(new DataGridViewButtonColumn()
            {
                Name = "Xoa",
                HeaderText = "Xóa đề thi",
                Width = 70
            });

            qldtTxtThoiGianLamBai.Text = "10";
            qldtTxtThoiGianLamBai.KeyDown += (s, e) =>
             {
                 if (e.KeyValue >= 48 && e.KeyValue <= 57 ||
                    e.KeyValue >= 96 && e.KeyValue <= 105 ||
                    e.KeyCode == Keys.Back ||
                    e.KeyCode == Keys.Delete ||
                    e.KeyCode == Keys.Left ||
                    e.KeyCode == Keys.Right)
                 {
                     // nếu là số hoặc xóa hoặc dịch trái phải thì cho gõ
                 }
                 else if (e.KeyCode == Keys.Up)
                 {
                     int soPhut = int.Parse(qldtTxtThoiGianLamBai.Text);
                     soPhut += 5;
                     qldtTxtThoiGianLamBai.Text = soPhut.ToString();
                 }
                 else if (e.KeyCode == Keys.Down)
                 {
                     int soPhut = int.Parse(qldtTxtThoiGianLamBai.Text);
                     soPhut -= 5;
                     qldtTxtThoiGianLamBai.Text = soPhut.ToString();
                 }
                 else
                 {
                     // không thì thôi
                     e.SuppressKeyPress = true;
                 }
             };
            qldtTxtThoiGianLamBai.KeyUp += (s, e) =>
             {
                 if (string.IsNullOrWhiteSpace(qldtTxtThoiGianLamBai.Text))
                 {
                     qldtTxtThoiGianLamBai.Text = "5";
                 }
                 int soPhut = int.Parse(qldtTxtThoiGianLamBai.Text);
                 if (soPhut < 0)
                 {
                     qldtTxtThoiGianLamBai.Text = "5";
                 }
             };
            qldtTxtTenDT.Validating += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(qldtTxtTenDT.Text))
                {
                    e.Cancel = true;
                    qldtTxtTenDT.Focus();
                    errorProvider.SetError(qldtTxtTenDT, "Không được để trống tên đề thi");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(qldtTxtTenDT, "");
                }
            };
            qldtBtnRdCauHoi.Click += (s, e) =>
              {
                  Random rd = new Random();
                  int maxCau = 10;

                  if (maxCau > qldtDgvCauHoi.RowCount)
                  {
                      maxCau = qldtDgvCauHoi.RowCount;
                  }
                  foreach (DataGridViewRow row in qldtDgvCauHoi.Rows)
                  {
                      var cell = row.Cells["Chon"] as DataGridViewCheckBoxCell;
                      cell.Value = cell.FalseValue;
                  }
                  List<int> li = new List<int>();
                  while (li.Count < maxCau)
                  {
                      int cauhoingaunhien = rd.Next(0, qldtDgvCauHoi.RowCount);

                      if (!li.Contains(cauhoingaunhien))
                      {
                          li.Add(cauhoingaunhien);
                          var cell = qldtDgvCauHoi.Rows[cauhoingaunhien].Cells["Chon"] as DataGridViewCheckBoxCell;
                          cell.Value = cell.TrueValue;
                      }
                  }
              };
            qldtDgvDeThi.CellPainting += (s, e) =>
            {
                if (e.RowIndex < 0)
                {
                    return;
                }
                if (e.ColumnIndex == 0)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    var w = e.CellBounds.Height - 4;
                    var h = e.CellBounds.Height - 4;
                    var x = e.CellBounds.X + (e.CellBounds.Width - w) / 2;
                    var y = e.CellBounds.Y + 2;
                    e.Graphics.DrawImage(Properties.Resources.delete__1_, x, y, w, h);
                    e.Handled = true;
                }
            };
        }

        private void setQlkt()
        {
            qlktDgvKT.Columns.Add(new DataGridViewButtonColumn()
            {
                Name = "Xoa",
                Width = 80,
                HeaderText = "Xóa kỳ thi"
            });
            qlktDgvKT.Rows.Add(3);
            qlktDgvKT.CellClick += (s, e) =>
             {
                 if (e.ColumnIndex == 0)
                 {
                     qlktDgvKT.Rows.RemoveAt(e.RowIndex);
                 }
             };


            qlktDgvHS.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                Name = "Chon",
                HeaderText = "Chọn học sinh",
                Width = 80,
                TrueValue = true,
                FalseValue = false,
                IndeterminateValue = false
            });

            qlktDgvDT.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                Name = "Chon",
                HeaderText = "Chọn đề thi",
                Width = 80,
                TrueValue = true,
                FalseValue = false,
                IndeterminateValue = false
            });

            qlktBtnRdHs.Click += (s, e) =>
             {
                 Random rd = new Random();
                 int maxHocSinh = 10;

                 if (maxHocSinh > qlktDgvHS.RowCount)
                 {
                     maxHocSinh = qlktDgvHS.RowCount;
                 }
                 foreach (DataGridViewRow row in qlktDgvHS.Rows)
                 {
                     var cell = row.Cells["Chon"] as DataGridViewCheckBoxCell;
                     cell.Value = cell.FalseValue;
                 }
                 List<int> li = new List<int>();
                 while (li.Count < maxHocSinh)
                 {
                     int hocSinhNgauNhien = rd.Next(0, qlktDgvHS.RowCount);

                     if (!li.Contains(hocSinhNgauNhien))
                     {
                         li.Add(hocSinhNgauNhien);
                         var cell = qlktDgvHS.Rows[hocSinhNgauNhien].Cells["Chon"] as DataGridViewCheckBoxCell;
                         cell.Value = cell.TrueValue;
                     }
                 }
             };

            qlktDgvKT.CellPainting += (s, e) =>
             {
                 if (e.RowIndex < 0)
                 {
                     return;
                 }
                 if (e.ColumnIndex == 0)
                 {
                     e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                     var w = e.CellBounds.Height - 4;
                     var h = e.CellBounds.Height - 4;
                     var x = e.CellBounds.X + (e.CellBounds.Width - w) / 2;
                     var y = e.CellBounds.Y + 2;
                     e.Graphics.DrawImage(Properties.Resources.delete__1_, x, y, w, h);
                     e.Handled = true;
                 }
             };
        }
        private void loadQlktDgvHocSinh()
        {
            using (var qlttn = new QLTTNDataContext())
            {
                if (qlttn.HocSinhs.Count() == 0)
                {
                    MessageBox.Show("Không có dữ liệu học sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                try
                {
                    bsHocSinh.DataSource = qlttn.HocSinhs.Where(hs => hs.maKhoi == cbKhoiLop.SelectedValue.ToString())
                                                         .Select(hs => new { hs.maHS, hs.HoTen, hs.maKhoi, hs.maLop, hs.NgaySinh }).ToList();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return;
                }
                if (bsHocSinh.Count > 0)
                {
                    qlktDgvHS.DataSource = bsHocSinh;
                    qlktDgvHS.Columns["maHS"].Width = 80;
                    qlktDgvHS.Columns["HoTen"].Width = 150;
                    qlktDgvHS.Columns["maLop"].Width = 80;
                    qlktDgvHS.Columns["NgaySinh"].Width = 80;
                    qlktDgvHS.Columns["maKhoi"].Visible = false;

                    qlktDgvHS.Columns["maHS"].HeaderText = "Mã học sinh";
                    qlktDgvHS.Columns["HoTen"].HeaderText = "Họ tên";
                    qlktDgvHS.Columns["maLop"].HeaderText = "Lớp học";
                    qlktDgvHS.Columns["NgaySinh"].HeaderText = "Ngày sinh";
                }
            }
        }
        private void loadQlktDgvDeThi()
        {
            if (bsDethi.Count > 0)
            {
                qlktDgvDT.DataSource = bsDethi;
                qlktDgvDT.Columns["maDT"].HeaderText = "Mã";
                qlktDgvDT.Columns["maDT"].Width = 40;
                qlktDgvDT.Columns["TenDT"].HeaderText = "Tên đề thi";
                qlktDgvDT.Columns["HoTen"].HeaderText = "Giáo viên ra đề";
                qlktDgvDT.Columns["ThoiGianLamBai"].HeaderText = "Thời gian làm bài";
                qlktDgvDT.Columns["NgayTao"].HeaderText = "Ngày tạo";
            }
            else
            {
                MessageBox.Show("Không có dữ liệu đề thi", "Thông báo tab Quản lý kỳ thi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void loadQlktDgvKyThi()
        {

        }

        private bool DaTonTai(DeThi dethiHientai)
        {
            using (var qlttn = new QLTTNDataContext())
            {

                // kiểm tra tên đề thi xem có trùng hay không
                if (qlttn.DeThis.Where(dt => dt.TenDT == dethiHientai.TenDT).Count() > 0)
                {
                    MessageBox.Show("Tên đề thi đã có rồi, xin mời đổi lại tên khác", "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }

                // kiểm tra xem các câu hỏi trong đề thi đã có trùng với đề thi khác hay không
                List<int> lmach = new List<int>();
                foreach (DataGridViewRow row in qldtDgvCauHoi.Rows)
                {
                    var cell = row.Cells["Chon"] as DataGridViewCheckBoxCell;
                    if (cell.Value == cell.TrueValue)
                    {
                        lmach.Add(int.Parse(row.Cells["maCH"].Value.ToString()));
                    }
                }
                var dsdethi = qlttn.CT_DeThis.GroupBy(ctdt => ctdt.maDT).ToList();
                foreach (var dethi in dsdethi)
                {
                    int soCauTimThay = 0;
                    foreach (var ch in lmach)
                    {
                        // nếu như tìm thấy câu hỏi trong dethi
                        if (dethi.Where(ctdt => ctdt.maCH == ch).Count() > 0)
                        {
                            soCauTimThay++;
                        }
                    }
                    if (soCauTimThay == dethi.Count())
                    {
                        string line = "";
                        for (int i = 0; i < dethi.Count(); i++)
                        {
                            line += $"{ Environment.NewLine } {dethi.ElementAt(i).maCH}. {dethi.ElementAt(i).CauHoi.NoiDung}";
                        }
                        MessageBox.Show($"Tên đề thi bị trùng: <{dethi.ElementAt(0).DeThi.TenDT}> {line}", "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return true;
                    }
                }
            }
            return false;
        }

        private Dictionary<TabPage, Color> TabColors = new Dictionary<TabPage, Color>();

        private void SetTabHeader(TabPage page, Color color)
        {
            TabColors[page] = color;
            tabControl1.Invalidate();
        }
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            //e.DrawBackground();
            if (e.State == DrawItemState.Selected)
            {
                using (Brush br = new SolidBrush(Color.LemonChiffon))
                {
                    e.Graphics.FillRectangle(br, e.Bounds);
                    SizeF sz = e.Graphics.MeasureString(tabControl1.TabPages[e.Index].Text, e.Font);
                    e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + (e.Bounds.Width - sz.Width) / 2, e.Bounds.Top + (e.Bounds.Height - sz.Height) / 2 + 1);

                    Rectangle rect = e.Bounds;
                    rect.Offset(0, 1);
                    rect.Inflate(0, -1);
                    e.Graphics.DrawRectangle(Pens.DarkGray, rect);
                    e.DrawFocusRectangle();
                }
            }
            else
            {
                using (Brush br = new SolidBrush(TabColors[tabControl1.TabPages[e.Index]]))
                {
                    e.Graphics.FillRectangle(br, e.Bounds);
                    SizeF sz = e.Graphics.MeasureString(tabControl1.TabPages[e.Index].Text, e.Font);
                    e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + (e.Bounds.Width - sz.Width) / 2, e.Bounds.Top + (e.Bounds.Height - sz.Height) / 2 + 1);

                    Rectangle rect = e.Bounds;
                    //rect.Offset(0, 1);
                    //rect.Inflate(0, -1);
                    e.Graphics.DrawRectangle(Pens.DarkGray, rect);
                    e.DrawFocusRectangle();
                }
            }
        }

        public frmGiaoVien(frmLogin frmlogin, GiaoVien gv)
        {
            this.gv = gv;
            this.frmlogin = frmlogin;
            InitializeComponent();

            button1.Click += (s, e) =>
             {
                 using (var qlttn = new QLTTNDataContext())
                 {
                     qlttn.Connection.ChangeDatabase(qlchTxtCauHoi.Text);

                     MessageBox.Show(qlttn.ToString());
                 }
             };
            button2.Click += (s, e) =>
            {
                using (var qlttn = new QLTTNDataContext())
                {
                    qlttn.DeleteDatabase();
                    qlttn.SubmitChanges();
                }
            };

            tabControl1.SelectedIndex = 2;
            loadCbKhoiLop();
            loadQlchCbCauHoi();
            loadQlchDgvDapAn();
            setQlch();

            setQldt();
            loadQldtDgvDeThi();
            loadQldtDgvCauHoi();

            setQlkt();
            loadQlktDgvHocSinh();
            loadQlktDgvDeThi();
            loadQlktDgvKyThi();

            this.tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            foreach (TabPage tp in tabControl1.TabPages)
            {
                SetTabHeader(tp, Color.FromKnownColor(KnownColor.Control));
                tp.BackColor = Color.LemonChiffon;
            }
            this.btnDangXuat.Click += (s, e) =>
            {
                frmlogin.Show();
                this.Close();
            };
            this.cbKhoiLop.SelectedIndexChanged += (s, e) =>
             {
                 loadQlchCbCauHoi();
                 loadQlchDgvDapAn();
                 loadQldtDgvCauHoi();
                 loadQldtDgvDeThi();
                 loadQlktDgvDeThi();
                 loadQlktDgvHocSinh();
                 loadQlktDgvKyThi();
             };

            // ======================================= QUẢN LÝ KỲ THI =============================================


            // ======================================= QUẢN LÝ ĐỀ THI =============================================
            qldtDgvDeThi.CellClick += (s, e) =>
                {
                    using (var qlttn = new QLTTNDataContext())
                    {
                        if (qlttn.DeThis.Count() == 0)
                        {
                            qldtDgvDeThi.Rows.Clear();
                            return;
                        }
                        if (qldtDgvDeThi.SelectedRows.Count > 0)
                        {
                            int madt = int.Parse(qldtDgvDeThi.SelectedRows[0].Cells["maDT"].Value.ToString());
                            var dschtrongDeThi = qlttn.CT_DeThis.Where(ctdt => ctdt.maDT == madt).GroupBy(ctdt => ctdt.maDT).Single().ToList();
                            foreach (DataGridViewRow row in qldtDgvCauHoi.Rows)
                            {
                                var cell = row.Cells["Chon"] as DataGridViewCheckBoxCell;
                                string str = row.Cells["maCH"].Value.ToString();
                                var mach = int.Parse(str);
                                var timthay = dschtrongDeThi.Where(ch => ch.maCH == mach && ch.maDT == madt).Count();
                                if (timthay == 1)
                                {
                                    cell.Value = cell.TrueValue;
                                }
                                else
                                {
                                    cell.Value = cell.FalseValue;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không thể load câu hỏi từ đề thi");
                        }
                    }
                };
            qldtDgvCauHoi.CellValueChanged += (s, e) =>
              {
                  if (e.ColumnIndex == 0)
                  {
                      int soch = 0;

                      foreach (DataGridViewRow row in qldtDgvCauHoi.Rows)
                      {
                          var chon = row.Cells["Chon"] as DataGridViewCheckBoxCell;
                          if (chon.Value == chon.TrueValue)
                          {
                              soch++;
                              chon.Selected = true;
                          }
                          else
                          {
                              chon.Selected = false;
                          }
                      }
                      qldtLblSoCHDuocChon.Text = soch + " câu";
                  }
              };
            qldtBtnSuaDT.Click += (s, e) =>
              {
                  int soch = int.Parse(qldtLblSoCHDuocChon.Text.Replace(" câu", ""));
                  if (soch != 10)
                  {
                      MessageBox.Show("Mỗi đề thi cần có 10 câu hỏi", "Yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                      return;
                  }
                  using (var qlttn = new QLTTNDataContext())
                  {

                      // bước 1: kiểm tra
                      int madt;
                      if (qldtDgvDeThi.SelectedRows.Count > 0)
                      {
                          madt = int.Parse(qldtDgvDeThi.SelectedRows[0].Cells["maDT"].Value.ToString());
                          var dethiHienTai = qlttn.DeThis.Where(dt => dt.maDT == madt).Single();

                          // bước 1: cập nhật thông tin đề thi
                          dethiHienTai.maGV = gv.maGV;
                          dethiHienTai.maMH = gv.maMH;
                          dethiHienTai.maKhoi = cbKhoiLop.SelectedValue.ToString();
                          dethiHienTai.TenDT = qldtTxtTenDT.Text;
                          dethiHienTai.ThoiGianLamBai = TimeSpan.FromMinutes(double.Parse(qldtTxtThoiGianLamBai.Text));
                          dethiHienTai.NgayTao = DateTime.Now;
                          qlttn.SubmitChanges();

                          // bước 2: xóa chi tiết đề thi hiện tại
                          qlttn.CT_DeThis.DeleteAllOnSubmit(qlttn.CT_DeThis.Where(ctdt => ctdt.maDT == madt));
                          qlttn.SubmitChanges();

                          // bước 3: thêm mới chi tiết đề thi hiện tại
                          foreach (DataGridViewRow row in qldtDgvCauHoi.Rows)
                          {
                              var cell = row.Cells["Chon"] as DataGridViewCheckBoxCell;
                              if (cell.Value == cell.TrueValue)
                              {
                                  qlttn.CT_DeThis.InsertOnSubmit(new CT_DeThi()
                                  {
                                      maDT = madt,
                                      maCH = int.Parse(row.Cells["maCH"].Value.ToString())
                                  });
                              }
                          }
                          qlttn.SubmitChanges();

                          loadQldtDgvDeThi();
                      }
                      else
                      {
                          MessageBox.Show("Mời bạn lựa chọn đề thi cần cập nhật", "Yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                          return;
                      }

                  }
              };
            /// xóa đề thi
            qldtDgvDeThi.CellClick += (s, e) =>
              {
                  if (e.ColumnIndex == 0)
                  {
                      int madt = int.Parse(qldtDgvDeThi.Rows[e.RowIndex].Cells["maDT"].Value.ToString());
                      using (var qlttn = new QLTTNDataContext())
                      {
                          qlttn.CT_DeThis.DeleteAllOnSubmit(qlttn.CT_DeThis.Where(ctdt => ctdt.maDT == madt));
                          qlttn.SubmitChanges();
                          qlttn.DeThis.DeleteOnSubmit(qlttn.DeThis.Where(dt => dt.maDT == madt).Single());
                          qlttn.SubmitChanges();
                          if (qlttn.DeThis.Count() == 0)
                          {
                              qldtDgvDeThi.Rows.Clear();
                          }
                      }
                      loadQldtDgvDeThi();
                      qldtDgvCauHoi.Rows.RemoveAt(e.RowIndex);
                  }
              };
            qldtBtnThemDT.Click += (s, e) =>
            {
                int soch = int.Parse(qldtLblSoCHDuocChon.Text.Replace(" câu", ""));
                if (string.IsNullOrWhiteSpace(qldtTxtTenDT.Text))
                {
                    MessageBox.Show("Bạn cần phải nhập tên đề tài", "Hướng dẫn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (soch == 10)
                {
                    using (var qlttn = new QLTTNDataContext())
                    {
                        var dethiHientai = new DeThi()
                        {
                            maGV = gv.maGV,
                            maMH = gv.maMH,
                            maKhoi = cbKhoiLop.SelectedValue.ToString(),
                            TenDT = qldtTxtTenDT.Text,
                            ThoiGianLamBai = TimeSpan.FromMinutes(double.Parse(qldtTxtThoiGianLamBai.Text)),
                            NgayTao = DateTime.Now
                        };

                        if (DaTonTai(dethiHientai))
                        {
                            return;
                        }

                        qlttn.DeThis.InsertOnSubmit(dethiHientai);
                        qlttn.SubmitChanges();

                        foreach (DataGridViewRow row in qldtDgvCauHoi.Rows)
                        {
                            int maDTHienTai = (int)qlttn.ExecuteQuery<decimal>("select IDENT_CURRENT('dbo.DeThi')").FirstOrDefault();

                            var cell = row.Cells["Chon"] as DataGridViewCheckBoxCell;
                            if (cell.Value == cell.TrueValue)
                            {
                                qlttn.CT_DeThis.InsertOnSubmit(new CT_DeThi()
                                {
                                    maDT = maDTHienTai,
                                    maCH = int.Parse(row.Cells["maCH"].Value.ToString())
                                });
                            }
                        }
                        qlttn.SubmitChanges();
                    }

                    loadQldtDgvDeThi();
                }
                else
                {
                    MessageBox.Show("Mỗi đề thi cần có 10 câu hỏi", "Yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            // ======================================= QUẢN LÝ CÂU HỎI VÀ ĐÁP ÁN =============================================
            qlchBtnThemCH.Click += (s, e) =>
            {
                using (var qlttn = new QLTTNDataContext())
                {
                    if (string.IsNullOrWhiteSpace(qlchTxtCauHoi.Text))
                    {
                        MessageBox.Show("Bạn cần phải nhập nội dung cho câu hỏi", "Hướng dẫn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (qlttn.CauHois.Where(ch => ch.NoiDung.ToLower() == qlchTxtCauHoi.Text.ToLower()).Count() != 0)
                    {
                        MessageBox.Show("Câu hỏi này đã có trong danh sách. Xin mời tạo câu hỏi mới", "Trùng record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // tìm thử xem có câu hỏi nào chưa có đáp án hay không, nếu như có thì ngừng việc
                    // thêm câu hỏi mới mà yêu cầu người dùng thêm đáp án cho câu hỏi đó
                    var cauhoi = qlttn.CauHois.Where(ch => ch.DapAns == null || ch.DapAns.Count < 2).FirstOrDefault();
                    if (cauhoi != null)
                    {
                        MessageBox.Show($"Xin mời nhập tối thiểu 2 đáp án cho câu hỏi sau trước khi thêm câu hỏi mới:{Environment.NewLine} <{cauhoi.NoiDung}>", "Câu hỏi chưa có đáp án", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                    qlttn.CauHois.InsertOnSubmit(new CauHoi()
                    {
                        NoiDung = qlchTxtCauHoi.Text,
                        CapDo = qlttn.CapDos.Where(cd => cd.maCD == int.Parse(qlchCbCapDo.SelectedValue.ToString())).SingleOrDefault(),
                        maKhoi = cbKhoiLop.SelectedValue.ToString(),
                        maMH = gv.maMH
                    });
                    qlttn.SubmitChanges();
                }
                loadQlchCbCauHoi();
                qlchCbDsch.SelectedItem = qlchCbDsch.Items[qlchCbDsch.Items.Count - 1];
                qlchTxtDapAn.Focus();
            };
            qlchBtnXoaCH.Click += (s, e) =>
            {
                using (var qlttn = new QLTTNDataContext())
                {
                    if (qlchLbDeThiSuDungCauHoi.Items.Count > 0)
                    {
                        string str = $"Không thể xóa câu hỏi này vì nó đang được sử dụng trong các đề thi: ";
                        foreach (var item in qlchLbDeThiSuDungCauHoi.Items)
                        {
                            str += $"{ Environment.NewLine }{item.ToString()}";
                        }
                        str += $"{ Environment.NewLine }Để xóa cần phải loại câu hỏi này khỏi các đề thi trên.";
                        MessageBox.Show(str, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    if (qlchCbDsch.SelectedValue == null)
                    {
                        return;
                    }

                    var cauHoiHienTai = qlttn.CauHois
                                        .Where(ch => ch.maCH == int.Parse(qlchCbDsch.SelectedValue.ToString()))
                                        .FirstOrDefault();
                    qlttn.DapAns.DeleteAllOnSubmit(cauHoiHienTai.DapAns);
                    qlttn.CauHois.DeleteOnSubmit(cauHoiHienTai);
                    try
                    {
                        qlttn.SubmitChanges();
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show(ee.Message, "Chương trình vấp phải một lỗi nào đó", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                loadQlchCbCauHoi();
            };
            qlchBtnSuaCH.Click += (s, e) =>
            {
                if (qlchCbDsch.SelectedValue == null)
                {
                    return;
                }

                using (var qlttn = new QLTTNDataContext())
                {
                    var cauHoiHienTai = qlttn.CauHois
                                        .Where(ch => ch.maCH == int.Parse(qlchCbDsch.SelectedValue.ToString()))
                                        .FirstOrDefault();

                    cauHoiHienTai.NoiDung = qlchTxtCauHoi.Text;
                    cauHoiHienTai.CapDo = qlttn.CapDos.Where(cd => cd.maCD == int.Parse(qlchCbCapDo.SelectedValue.ToString())).FirstOrDefault();
                    cauHoiHienTai.maKhoi = cbKhoiLop.SelectedValue.ToString();
                    qlttn.SubmitChanges();
                }

                loadQlchCbCauHoi();
                //qlchCbDsch.SelectedItem = qlchCbDsch.Items[qlchCbDsch.Items.Count - 1];
            };
            qlchBtnThemDA.Click += (s, e) =>
            {
                if (qlchCbDsch.SelectedValue == null)
                {
                    return;
                }
                if (string.IsNullOrWhiteSpace(qlchTxtDapAn.Text))
                {
                    MessageBox.Show("Bạn cần phải nhập nội dung cho đáp án", "Hướng dẫn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (var qlttn = new QLTTNDataContext())
                {
                    var cauHoiHienTai = qlttn.CauHois
                                        .Where(ch => ch.maCH == int.Parse(qlchCbDsch.SelectedValue.ToString()))
                                        .FirstOrDefault();
                    if (cauHoiHienTai.DapAns.Where(da => da.NoiDung.ToLower() == qlchTxtDapAn.Text.ToLower()).Count() != 0)
                    {
                        MessageBox.Show("Đáp án này đã có trong danh sách. Xin mời tạo đáp án mới", "Lỗi trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                    if (cauHoiHienTai.DapAns.Count >= 6)
                    {
                        MessageBox.Show("Mỗi câu hỏi có tối đa 6 đáp án. Xin mời xóa bớt đáp án để thêm mới", "Hướng dẫn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    qlttn.DapAns.InsertOnSubmit(new DapAn()
                    {
                        NoiDung = qlchTxtDapAn.Text,
                        DungSai = qlchCkbDungSai.Checked,
                        //DungSai = bool.Parse(txtDungSai.Text),
                        CauHoi = qlttn.CauHois.Where(ch => ch.maCH == int.Parse(qlchCbDsch.SelectedValue.ToString())).SingleOrDefault()
                    });
                    qlttn.SubmitChanges();
                }
                loadQlchDgvDapAn();
                qlchDgvDsda.Rows[qlchDgvDsda.Rows.GetLastRow(DataGridViewElementStates.Displayed)].Selected = true;
                qlchTxtDapAn.Focus();
            };
            qlchBtnXoaDA.Click += (s, e) =>
            {
                if (qlchCbDsch.SelectedValue == null)
                {
                    return;
                }
                using (var qlttn = new QLTTNDataContext())
                {
                    var cauHoiHienTai = qlttn.CauHois
                                        .Where(ch => ch.maCH == int.Parse(qlchCbDsch.SelectedValue.ToString()))
                                        .FirstOrDefault();
                    if (cauHoiHienTai.DapAns.Count <= 2)
                    {
                        MessageBox.Show("Mỗi câu hỏi cần phải có tối thiểu 2 đáp án", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (qlchDgvDsda.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Hãy chọn đáp án cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    qlttn.DapAns.DeleteOnSubmit(cauHoiHienTai.DapAns.Where(da => da.maDA == int.Parse(qlchDgvDsda.SelectedRows[0].Cells["maDA"].Value.ToString())).FirstOrDefault());
                    qlttn.SubmitChanges();
                }
                loadQlchDgvDapAn();
            };
            qlchBtnSuaDA.Click += (s, e) =>
            {
                if (qlchCbDsch.SelectedValue == null)
                {
                    return;
                }
                using (var qlttn = new QLTTNDataContext())
                {
                    var cauHoiHienTai = qlttn.CauHois
                                        .Where(ch => ch.maCH == int.Parse(qlchCbDsch.SelectedValue.ToString()))
                                        .FirstOrDefault();

                    var dapAnHienTai = cauHoiHienTai.DapAns.Where(da => da.maDA == int.Parse(qlchDgvDsda.SelectedRows[0].Cells["maDA"].Value.ToString())).FirstOrDefault();
                    dapAnHienTai.NoiDung = qlchTxtDapAn.Text;
                    dapAnHienTai.DungSai = qlchCkbDungSai.Checked;
                    //dapAnHienTai.DungSai = bool.Parse(txtDungSai.Text);

                    qlttn.SubmitChanges();
                }
                loadQlchDgvDapAn();
                qlchTxtDapAn.Focus();
            };
            qlchBtnImport.Click += (s, e) =>
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel Workbook 97-2003|*.xls", ValidateNames = true })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            IExcelDataReader reader;
                            DataSet ds;
                            if (ofd.FilterIndex == 2)
                            {
                                reader = ExcelReaderFactory.CreateBinaryReader(stream);
                            }
                            else
                            {
                                reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                            }

                            ds = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                                {
                                    UseHeaderRow = true
                                }
                            });
                            reader.Close();


                            List<CauHoi> cauHoiBiTrung = new List<CauHoi>();
                            List<CauHoi> cauHoiKhongDungChuyenMon = new List<CauHoi>();
                            int soCauHoiDuocThem = 0, soDapAnDuocThem = 0;
                            using (var qlttn = new QLTTNDataContext())
                            {
                                DataTable dtCauHoi = ds.Tables["CauHoi"];
                                DataTable dtDapAn = ds.Tables["DapAn"];
                                DataRow firstRow = dtCauHoi.Rows[0];

                                //int lastIdent = (int)qlttn.ExecuteQuery<decimal>("select IDENT_CURRENT('dbo.CauHoi')").FirstOrDefault();
                                try
                                {
                                    foreach (DataRow row in dtCauHoi.Rows)
                                    {
                                        CauHoi cauHoiTmp = new CauHoi()
                                        {
                                            NoiDung = row["NoiDung"].ToString(),
                                            maCD = int.Parse(row["maCD"].ToString()),
                                            maKhoi = row["maKhoi"].ToString(),
                                            maMH = row["maMH"].ToString()
                                        };
                                        // kiểm tra dòng đó đúng là chuyên môn của giáo viên đó (không phân biệt khối lớp)  thì mới cho vào
                                        if (cauHoiTmp.maMH == gv.maMH)
                                        {
                                            if (qlttn.CauHois.Where(ch => ch.NoiDung.ToLower() == cauHoiTmp.NoiDung.ToLower()).Count() == 0)
                                            {
                                                qlttn.CauHois.InsertOnSubmit(cauHoiTmp);
                                                qlttn.SubmitChanges();
                                                soCauHoiDuocThem++;
                                                foreach (DataRow rowDapAn in dtDapAn.Rows)
                                                {
                                                    if (rowDapAn["maCH"].ToString() == row["maCH"].ToString())
                                                    {
                                                        DapAn datmp = new DapAn()
                                                        {
                                                            NoiDung = rowDapAn["NoiDung"].ToString(),
                                                            maCH = qlttn.CauHois.Max(ch => ch.maCH),
                                                            DungSai = rowDapAn["DungSai"].ToString().ToLower() == "true" ? true : false
                                                        };
                                                        qlttn.DapAns.InsertOnSubmit(datmp);
                                                        soDapAnDuocThem++;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                cauHoiBiTrung.Add(cauHoiTmp);
                                            }
                                        }
                                        else
                                        {
                                            cauHoiKhongDungChuyenMon.Add(cauHoiTmp);
                                        }
                                    }
                                    qlttn.SubmitChanges();
                                }
                                catch (Exception err)
                                {
                                    MessageBox.Show(err.Message, "Đã xảy ra một lỗi nào đó trong hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                            }
                            loadQlchCbCauHoi();
                            loadQlchDgvDapAn();
                            if (cauHoiBiTrung.Count > 0)
                            {
                                string strCauHois = "";
                                for (int i = 0; i < cauHoiBiTrung.Count; i++)
                                {
                                    string str = cauHoiBiTrung[i].NoiDung;
                                    int maxLeng = 50;
                                    if (str.Length > maxLeng)
                                    {
                                        str = str.Replace(str.Substring(maxLeng, str.Length - maxLeng), " ...");
                                    }
                                    strCauHois += $"{Environment.NewLine} {i + 1}. {str}";
                                }
                                MessageBox.Show($">>>> DANH SÁCH NHỮNG CÂU HỎI BỊ TRÙNG <<<< {strCauHois}", "Không thể import", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            }
                            if (cauHoiKhongDungChuyenMon.Count > 0)
                            {
                                string strCauHois = "";
                                for (int i = 0; i < cauHoiKhongDungChuyenMon.Count; i++)
                                {
                                    string str = cauHoiKhongDungChuyenMon[i].NoiDung;
                                    int maxLeng = 50;
                                    if (str.Length > maxLeng)
                                    {
                                        str = str.Replace(str.Substring(maxLeng, str.Length - maxLeng), " ...");
                                    }
                                    strCauHois += $"{Environment.NewLine} {i + 1}. {str}";
                                }
                                MessageBox.Show($">>>> DANH SÁCH NHỮNG CÂU HỎI KHÔNG ĐÚNG CHUYÊN MÔN <<<< {strCauHois}", "Không thể import", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }

                            MessageBox.Show($">>>> KẾT QUẢ IMPORT DANH SÁCH CÂU HỎI <<<< {Environment.NewLine} Tổng số câu hỏi được thêm: {soCauHoiDuocThem} {Environment.NewLine} Tổng số đáp án được thêm: {soDapAnDuocThem}", "Thông báo");
                        }
                    }
                }

            };
            qlchBtnExport.Click += (s, e) =>
            {
                using (var sfd = new SaveFileDialog()
                {
                    CreatePrompt = false,
                    OverwritePrompt = true,
                    AddExtension = true,
                    Filter = "Excel Workbook|*.xlsx|Excel Workbook 97-2003|*.xls",
                    ValidateNames = true,
                })
                {
                    if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {

                        DataTable dtCauHoi = new DataTable();
                        dtCauHoi.TableName = "CauHoi";
                        dtCauHoi.Columns.Add("maCH", typeof(int));
                        dtCauHoi.Columns.Add("NoiDung", typeof(string));
                        dtCauHoi.Columns.Add("maCD", typeof(int));
                        dtCauHoi.Columns.Add("maMH", typeof(string));
                        dtCauHoi.Columns.Add("maKhoi", typeof(string));

                        DataTable dtDapAn = new DataTable();
                        dtDapAn.TableName = "DapAn";
                        dtDapAn.Columns.Add("maCH", typeof(int));
                        dtDapAn.Columns.Add("maDA", typeof(int));
                        dtDapAn.Columns.Add("NoiDung", typeof(string));
                        dtDapAn.Columns.Add("DungSai", typeof(bool));

                        using (var qlttn = new QLTTNDataContext())
                        {
                            List<CauHoi> chs = qlttn.CauHois.Where(ch => ch.maMH == gv.maMH).ToList();
                            for (int i = 0; i < chs.Count; i++)
                            {
                                foreach (var da in chs[i].DapAns)
                                {
                                    da.maCH = i + 1;
                                    dtDapAn.Rows.Add(da.maCH, da.maDA, da.NoiDung, da.DungSai);
                                }

                                // thay đổi mã câu hỏi chỗ này để xuất ra theo thứ tự cho đẹp, khi import thì canh chỉnh lại, vì maCH
                                // có tính chất identity tự động tăng, khi insert trong db
                                chs[i].maCH = i + 1;

                                dtCauHoi.Rows.Add(chs[i].maCH, chs[i].NoiDung, chs[i].maCD, chs[i].maMH, chs[i].maKhoi);
                            }
                        };

                        XLWorkbook wb = new XLWorkbook();
                        wb.Worksheets.Add(dtCauHoi, dtCauHoi.TableName);
                        wb.Worksheets.Add(dtDapAn, dtDapAn.TableName);


                        wb.SaveAs(sfd.InitialDirectory + sfd.FileName);
                    }
                }
            };
        }
    }
}
