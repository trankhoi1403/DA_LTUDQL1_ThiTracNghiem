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
        private List<CT_GiangDay> lkl = null;
        static BindingSource bsCauHoi = new BindingSource();
        static BindingSource bsDapAn = new BindingSource();

        static BindingSource bsQldtDethi = new BindingSource();

        private void loadCbKhoiLop()
        {
            using (var qlttn = new QLTTNDataContext())
            {
                lkl = gv.CT_GiangDays.ToList();
                cbKhoiLop.DataSource = lkl;
                cbKhoiLop.DisplayMember = "maKhoi";
                cbKhoiLop.ValueMember = "maKhoi";
                cbKhoiLop.SelectedItem = cbKhoiLop.Items[0];
                string txt = cbKhoiLop.SelectedValue.ToString();
                lblHoTenGV.Text = gv.HoTen;
                lblNgaySinhGV.Text = $"Ngày sinh: {gv.NgaySinh.Value.ToShortDateString()}";
                lblChuyenMon.Text = $"Chuyên môn: {qlttn.MonHocs.Where(mh => mh.maMH == gv.maMH).Single().tenMH}";
            }
        }
        private void loadQlchCbCauHoi()
        {
            using (var qlttn = new QLTTNDataContext())
            {
                if (qlttn.CapDos.Count() > 0 && qlttn.CauHois.Count() > 0)
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

                    qlchCbDsch.DataSource = bsCauHoi;
                    qlchCbDsch.DisplayMember = "NoiDung";
                    qlchCbDsch.ValueMember = "maCH";


                    qlchCbCapDo.DataSource = qlttn.CapDos.ToList();
                    qlchCbCapDo.DisplayMember = "TenCD";
                    qlchCbCapDo.ValueMember = "maCD";

                    var macd = qlttn.CauHois.Where(ch => ch.maCH.ToString() == qlchCbDsch.SelectedValue.ToString()).Single().maCD;
                    qlchCbCapDo.SelectedValue = macd;
                    //qlchCbCapDo.SelectedValue = qlchCbDsch.SelectedValue.ToString();
                }
                else
                {
                    //bsCauHoi.DataSource = DBNull.Value;
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
                    qlchDgvDsda.Columns["NoiDung"].Width = 210;
                    qlchDgvDsda.Columns["NoiDung"].HeaderText = "Nội dung đáp án";
                    qlchDgvDsda.Columns["DungSai"].DisplayIndex = 2;
                    qlchDgvDsda.Columns["DungSai"].Width = 115;
                    qlchDgvDsda.Columns["DungSai"].HeaderText = "Tính chất đáp án";
                }
                else
                {
                    //bsDapAn.DataSource = DBNull.Value;
                }
            }
        }
        private void setQlch()
        {
            qlchTxtCauHoi.DataBindings.Add("Text", bsCauHoi, "NoiDung", true, DataSourceUpdateMode.Never, "Null value");
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
            qlchTxtDapAn.DataBindings.Add("Text", bsDapAn, "NoiDung", true, DataSourceUpdateMode.Never, "Null value");
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
            qlchCkbDungSai.DataBindings.Add("Checked", bsDapAn, "DungSai", true, DataSourceUpdateMode.Never, false);
            qlchCbDsch.SelectedIndexChanged += (s, e) =>
            {
                using (var qlttn = new QLTTNDataContext())
                {
                    if (qlchCbDsch.SelectedItem != null)
                    {
                        bsDapAn.DataSource = qlttn.CauHois.Where(ch => ch.maCH == int.Parse(qlchCbDsch.SelectedValue.ToString())).SingleOrDefault().DapAns.ToList();
                    }
                }
            };
        }

        private void loadQldtDgvDeThi()
        {
            using (var qlttn = new QLTTNDataContext())
            {
                var sourceDt = qlttn.DeThis.Where(dt => dt.maMH == gv.maMH && dt.maKhoi == cbKhoiLop.SelectedValue.ToString())
                                            .Select(dt => new { dt.maDT, dt.TenDT, dt.GiaoVien.HoTen, dt.ThoiGianLamBai, dt.NgayTao })
                                            .ToList();
                if (sourceDt.Count > 0)
                {
                    bsQldtDethi.DataSource = sourceDt;
                    qldtDgvDeThi.DataSource = bsQldtDethi;

                    qldtDgvDeThi.Columns["maDT"].HeaderText = "Mã";
                    qldtDgvDeThi.Columns["maDT"].Width = 40;
                    qldtDgvDeThi.Columns["TenDT"].HeaderText = "Tên đề thi";
                    qldtDgvDeThi.Columns["HoTen"].HeaderText = "Giáo viên ra đề";
                    qldtDgvDeThi.Columns["ThoiGianLamBai"].HeaderText = "Thời gian làm bài";
                    qldtDgvDeThi.Columns["NgayTao"].HeaderText = "Ngày tạo";

                    if (qldtTxtTenDT.DataBindings.Count == 0)
                    {
                        qldtTxtTenDT.DataBindings.Add("Text", bsQldtDethi, "TenDT", true, DataSourceUpdateMode.Never, "null");
                    }
                    if (qldtTxtThoiGianLamBai.DataBindings.Count == 0)
                    {
                        qldtTxtThoiGianLamBai.DataBindings.Add("Text", bsQldtDethi, "ThoiGianLamBai", true, DataSourceUpdateMode.Never, 0);
                    }
                    if (qldtLblNgayTao.DataBindings.Count == 0)
                    {
                        qldtLblNgayTao.DataBindings.Add("Text", bsQldtDethi, "NgayTao", true, DataSourceUpdateMode.Never, 0);
                    }
                    if (qldtLblNguoiTao.DataBindings.Count == 0)
                    {
                        qldtLblNguoiTao.DataBindings.Add("Text", bsQldtDethi, "HoTen", true, DataSourceUpdateMode.Never, 0);
                    }
                }
                else
                {
                    qldtTxtTenDT.DataBindings.Clear();
                    qldtTxtThoiGianLamBai.DataBindings.Clear();
                    qldtLblNguoiTao.DataBindings.Clear();
                    qldtLblNgayTao.DataBindings.Clear();
                    MessageBox.Show("Không có dữ liệu trong dgv đề thi");
                }
            }
        }
        private void loadQldtDgvCauHoi()
        {
            using (var qlttn = new QLTTNDataContext())
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
        }
        private void setQldt()
        {
            var col = new DataGridViewCheckBoxColumn();
            col.Name = "Chon";
            col.HeaderText = "Chọn câu hỏi";
            col.Width = 80;
            col.TrueValue = true;    // khi được check thì value sẽ là true, được ktra trong event CellValueChanged
            col.FalseValue = false;
            col.IndeterminateValue = col.FalseValue;
            foreach (DataGridViewRow row in qldtDgvCauHoi.Rows)
            {
                row.Cells[0].Value = col.TrueValue;
            }
            qldtDgvCauHoi.Columns.Add(col);

            qldtTxtThoiGianLamBai.Validated += (s, e) =>
             {
                 Regex rg = new Regex("[0-2][0-3]:[0-5][0-9]:[0-5][0-9]");
                 if (!rg.IsMatch(qldtTxtThoiGianLamBai.Text))
                 {
                     qldtTxtThoiGianLamBai.Text = "00:10:00";
                 }
             };
            qldtTxtThoiGianLamBai.MouseUp += (s, e) =>
            {
                if (qldtTxtThoiGianLamBai.SelectedText.Length > 2)
                {
                    qldtTxtThoiGianLamBai.Select(0, qldtTxtThoiGianLamBai.Text.IndexOf(':'));
                }
            };
            qldtTxtThoiGianLamBai.MouseDown += (s, e) =>
            {
                int i = qldtTxtThoiGianLamBai.GetCharIndexFromPosition(e.Location);
                if (i < 3)
                {
                    qldtTxtThoiGianLamBai.Select(0, 2);
                }
                else if (i < 6)
                {
                    qldtTxtThoiGianLamBai.Select(3, 2);
                }
                else
                {
                    qldtTxtThoiGianLamBai.Select(6, 2);
                }
            };
            qldtTxtThoiGianLamBai.KeyDown += (s, e) =>
             {
                 if (qldtTxtThoiGianLamBai.SelectedText == qldtTxtThoiGianLamBai.Text)
                 {
                     qldtTxtThoiGianLamBai.Select(0, 2);
                 }
                 if (e.KeyValue >= 48 && e.KeyValue <= 57 || e.KeyValue >= 96 && e.KeyValue <= 105 || e.KeyCode == Keys.Back)
                 {
                     if (qldtTxtThoiGianLamBai.Text.Contains("__"))
                     {
                         qldtTxtThoiGianLamBai.Select(qldtTxtThoiGianLamBai.Text.IndexOf("__"), 2);
                     }
                     else
                     {
                         if (e.KeyCode == Keys.Back)
                         {
                             if (qldtTxtThoiGianLamBai.SelectionStart == qldtTxtThoiGianLamBai.Text.IndexOf(':') + 1 ||
                                  qldtTxtThoiGianLamBai.SelectionStart == qldtTxtThoiGianLamBai.Text.IndexOf(':', 3) + 1)
                             {
                                 e.SuppressKeyPress = true;
                                 return;
                             }
                         }
                         if (qldtTxtThoiGianLamBai.TextLength == 8)
                         {
                             if (qldtTxtThoiGianLamBai.SelectionStart == qldtTxtThoiGianLamBai.Text.IndexOf(':') ||
                                qldtTxtThoiGianLamBai.SelectionStart == qldtTxtThoiGianLamBai.Text.IndexOf(':', 3))
                             {
                                 int h, m, second;
                                 if (!(int.TryParse(qldtTxtThoiGianLamBai.Text.Substring(0, 2), out h) && h < 24))
                                 {
                                     qldtTxtThoiGianLamBai.Select(0, 2);
                                 }
                                 else if (!(int.TryParse(qldtTxtThoiGianLamBai.Text.Substring(3, 2), out m) && m < 60))
                                 {
                                     qldtTxtThoiGianLamBai.Select(3, 2);
                                 }
                                 else if (!(int.TryParse(qldtTxtThoiGianLamBai.Text.Substring(0, 2), out second) && second < 60))
                                 {
                                     qldtTxtThoiGianLamBai.Select(6, 2);
                                 }
                                 else
                                 {
                                     qldtTxtThoiGianLamBai.SelectionStart++;
                                     qldtTxtThoiGianLamBai.SelectionLength = 2;
                                 }
                             }
                         }
                     }
                 }
                 else
                 {
                     e.SuppressKeyPress = true;
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

            tabControl1.SelectedIndex = 1;
            loadCbKhoiLop();
            loadQlchCbCauHoi();
            loadQlchDgvDapAn();
            setQlch();

            setQldt();
            loadQldtDgvDeThi();
            loadQldtDgvCauHoi();



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
                          dethiHienTai.ThoiGianLamBai = TimeSpan.Parse(qldtTxtThoiGianLamBai.Text);
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

            qldtBtnXoaDT.Click += (s, e) =>
              {
                  int madt;
                  if (qldtDgvDeThi.SelectedRows.Count > 0)
                  {
                      madt = int.Parse(qldtDgvDeThi.SelectedRows[0].Cells["maDT"].Value.ToString());
                  }
                  else
                  {
                      MessageBox.Show("Mời bạn lựa chọn đề thi cần xóa", "Yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                      return;
                  }
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
              };

            qldtBtnThemDT.Click += (s, e) =>
            {
                int soch = int.Parse(qldtLblSoCHDuocChon.Text.Replace(" câu", ""));
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
                            ThoiGianLamBai = TimeSpan.Parse(qldtTxtThoiGianLamBai.Text),
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
                    if (qlttn.CauHois.Count() <= 1)
                    {
                        MessageBox.Show("Không thể xóa vì cần phải có ít nhất một câu hỏi trong Database", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    var cauHoiHienTai = qlttn.CauHois
                                        .Where(ch => ch.maCH == int.Parse(qlchCbDsch.SelectedValue.ToString()))
                                        .FirstOrDefault();
                    qlttn.DapAns.DeleteAllOnSubmit(cauHoiHienTai.DapAns);
                    qlttn.CauHois.DeleteOnSubmit(cauHoiHienTai);
                    qlttn.SubmitChanges();
                }
                loadQlchCbCauHoi();
            };
            qlchBtnSuaCH.Click += (s, e) =>
            {
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
