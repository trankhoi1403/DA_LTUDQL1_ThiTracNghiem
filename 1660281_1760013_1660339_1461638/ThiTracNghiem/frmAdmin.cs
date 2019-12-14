using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
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

        private BindingSource bsLoaiND = new BindingSource();
        private BindingSource bsHS = new BindingSource();
        private BindingSource bsGV = new BindingSource();
        private BindingSource bsAD = new BindingSource();

        private int soLopDangChon = 0;

        private void setQLND()
        {
            qlndCbKhoi.KeyDown += QlndComboBox_KeyDown;
            qlndCbLop.KeyDown += QlndComboBox_KeyDown;
            qlndCbChuyenMon.KeyDown += QlndComboBox_KeyDown;
            qlndTxtHoTen.Validating += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(qlndTxtHoTen.Text))
                {
                    errorProvider.SetError(qlndTxtHoTen, "Không được để trống");
                    qlndTxtMaND.Focus();
                }
                else
                {
                    errorProvider.SetError(qlndTxtHoTen, "");
                }
            };
            qlndTxtMaND.Validating += (s, e) =>
              {
                  using (var qlttn = new QLTTNDataContext())
                  {
                      if (qlttn.NguoiDungs.Where(nd => nd.maND == qlndTxtMaND.Text).Count() > 0)
                      {
                          errorProvider.SetError(qlndTxtMaND, "Mã người dùng này đã tồn tại");
                          qlndTxtMaND.Focus();
                      }
                      else
                      {
                          errorProvider.SetError(qlndTxtMaND, "");
                      }
                  }
              };
            qlndDgvND.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Xoa",
                HeaderText = "Xóa người dùng",
                Width = 110
            });
            qlndDgvND.CellPainting += (s, e) =>
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
            tsLblHoTenAd.Text = "Xin chào " + admin.maND;
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
            qlndDgvCTGiangDay.CellValueChanged += (s, e) =>
              {
                  if (e.ColumnIndex == 0)
                  {
                      var cell = qlndDgvCTGiangDay.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;
                      if (cell.Value == cell.TrueValue)
                      {
                          cell.OwningRow.Selected = true;
                      }
                      else
                      {
                          cell.OwningRow.Selected = false;
                      }
                  }

                  soLopDangChon = 0;
                  foreach (DataGridViewRow row in qlndDgvCTGiangDay.Rows)
                  {
                      var cell = row.Cells["Chon"] as DataGridViewCheckBoxCell;
                      if (cell.Value == cell.TrueValue)
                      {
                          soLopDangChon++;
                      }
                  }
                  lblCTGiangDay.Text = $"Đang dạy: {soLopDangChon} lớp";
              };
            qlndDgvND.SelectionChanged += QlndDgvND_SelectionChanged;
            qlndDgvND.RowsAdded += (s, e) =>
            {
                gbND.Text = $"Tổng số người dùng: {qlndDgvND.RowCount}";
            };
            qlndDgvND.RowsRemoved += (s, e) =>
            {
                gbND.Text = $"Tổng số người dùng: {qlndDgvND.RowCount}";
            };
            qlndBtnThem.Click += (s, e) =>
              {
                  using (var qlttn = new QLTTNDataContext())
                  {
                      if (qlttn.NguoiDungs.Where(nd => nd.maND == qlndTxtMaND.Text).Count() > 0)
                      {
                          MessageBox.Show($"Đã tồn tại quản trị viên có có mã là {qlndTxtMaND.Text}", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                          return;
                      }
                      if (string.IsNullOrWhiteSpace(qlndTxtMaND.Text))
                      {
                          MessageBox.Show("Không được để trống mã", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                          return;
                      }

                      var malnd = qlndCbLoaiND.SelectedValue.ToString();
                      if (malnd == "HS")
                      {
                          if (string.IsNullOrWhiteSpace(qlndTxtHoTen.Text))
                          {
                              MessageBox.Show("Không được để trống họ tên", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                              return;
                          }
                          var hocsinh = new HocSinh
                          {
                              maHS = qlndTxtMaND.Text,
                              HoTen = qlndTxtHoTen.Text,
                              maKhoi = qlndCbKhoi.SelectedValue.ToString(),
                              maLop = qlndCbLop.SelectedValue.ToString(),
                              NgaySinh = qlndDtpNgaySinh.Value
                          };

                          qlttn.NguoiDungs.InsertOnSubmit(new NguoiDung
                          {
                              maND = hocsinh.maHS,
                              maLND = "HS"
                              // cần phải chỉnh trong cột [global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MatKhau"
                              // hay public string MatKhau
                              // trong file QLTTN.designer.cs
                              // thêm 2 thuộc tính này vào: AutoSync = AutoSync.OnInsert, IsDbGenerated = true
                              // thì prop VALUE sẽ được tự động tạo dựa vào default trong sql
                          });
                          qlttn.HocSinhs.InsertOnSubmit(hocsinh);
                          qlttn.SubmitChanges();
                      }
                      else if (malnd == "GV")
                      {
                          if (string.IsNullOrWhiteSpace(qlndTxtHoTen.Text))
                          {
                              MessageBox.Show("Không được để trống họ tên", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                              return;
                          }
                          var giaovien = new GiaoVien
                          {
                              maGV = qlndTxtMaND.Text,
                              HoTen = qlndTxtHoTen.Text,
                              NgaySinh = qlndDtpNgaySinh.Value,
                              maMH = qlndCbChuyenMon.SelectedValue.ToString()
                          };
                          // kiểm tra xem CTGiangDay có lớp nào hay chưa, đồng thời nếu có thì lưu vào trong llh
                          List<CT_GiangDay> lctgd = new List<CT_GiangDay>();
                          foreach (DataGridViewRow row in qlndDgvCTGiangDay.Rows)
                          {
                              var cell = row.Cells["Chon"] as DataGridViewCheckBoxCell;
                              if (cell.Value == cell.TrueValue)
                              {
                                  lctgd.Add(new CT_GiangDay
                                  {
                                      maGV = giaovien.maGV,
                                      maKhoi = row.Cells["maKhoi"].Value.ToString(),
                                      maLop = row.Cells["maLop"].Value.ToString()
                                  });
                              }
                          }
                          if (lctgd.Count == 0)
                          {
                              MessageBox.Show("Hãy chọn ít nhất 1 lớp giảng dạy cho giáo viên này", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                              return;
                          }
                          qlttn.NguoiDungs.InsertOnSubmit(new NguoiDung
                          {
                              maND = giaovien.maGV,
                              maLND = "GV"
                              // cần phải chỉnh trong cột [global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MatKhau"
                              // hay public string MatKhau
                              // trong file QLTTN.designer.cs
                              // thêm 2 thuộc tính này vào: AutoSync = AutoSync.OnInsert, IsDbGenerated = true
                              // thì prop VALUE sẽ được tự động tạo dựa vào default trong sql
                          });
                          qlttn.GiaoViens.InsertOnSubmit(giaovien);
                          qlttn.CT_GiangDays.InsertAllOnSubmit(lctgd);
                          qlttn.SubmitChanges();
                      }
                      else if (malnd == "AD")
                      {
                          qlttn.NguoiDungs.InsertOnSubmit(new NguoiDung
                          {
                              maND = qlndTxtMaND.Text,
                              maLND = "AD"
                              // cần phải chỉnh trong cột [global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MatKhau"
                              // hay public string MatKhau
                              // trong file QLTTN.designer.cs
                              // thêm 2 thuộc tính này vào: AutoSync = AutoSync.OnInsert, IsDbGenerated = true
                              // thì prop VALUE sẽ được tự động tạo dựa vào default trong sql
                          });
                          qlttn.SubmitChanges();
                      }
                  }

                  loadDgvNguoiDung();
              };
            qlndBtnSua.Click += (s, e) =>
             {
                 try
                 {
                     using (var qlttn = new QLTTNDataContext())
                     {
                         if (string.IsNullOrWhiteSpace(qlndTxtHoTen.Text))
                         {
                             MessageBox.Show("Không được để trống họ tên", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                             return;
                         }
                         var nguoiDung = qlttn.NguoiDungs.Where(nd => nd.maND == qlndTxtMaND.Text).FirstOrDefault();
                         if (nguoiDung == null)
                         {
                             MessageBox.Show($"Không tìm thấy người dùng {qlndTxtMaND.Text} để cập nhật", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                             qlndTxtMaND.Focus();
                             return;
                         }
                         if (nguoiDung.maLND == "HS")
                         {
                             nguoiDung.HocSinh.HoTen = qlndTxtHoTen.Text;
                             nguoiDung.HocSinh.maKhoi = qlndCbKhoi.SelectedValue.ToString();
                             nguoiDung.HocSinh.maLop = qlndCbLop.SelectedValue.ToString();
                             nguoiDung.HocSinh.NgaySinh = qlndDtpNgaySinh.Value;
                         }
                         else if (nguoiDung.maLND == "GV")
                         {
                             if (soLopDangChon == 0)
                             {
                                 MessageBox.Show("Xin hãy chọn một lớp để giảng dạy", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                 return;
                             }

                             nguoiDung.GiaoVien.HoTen = qlndTxtHoTen.Text;
                             nguoiDung.GiaoVien.NgaySinh = qlndDtpNgaySinh.Value;
                             nguoiDung.GiaoVien.maMH = qlndCbChuyenMon.SelectedValue.ToString();

                             qlttn.CT_GiangDays.DeleteAllOnSubmit(nguoiDung.GiaoVien.CT_GiangDays);
                             foreach (DataGridViewRow row in qlndDgvCTGiangDay.Rows)
                             {
                                 var cell = row.Cells["Chon"] as DataGridViewCheckBoxCell;
                                 if (cell.Value == cell.TrueValue)
                                 {
                                     qlttn.CT_GiangDays.InsertOnSubmit(new CT_GiangDay
                                     {
                                         maGV = nguoiDung.maND,
                                         maKhoi = row.Cells["maKhoi"].Value.ToString(),
                                         maLop = row.Cells["maLop"].Value.ToString()
                                     });
                                 }
                             }
                         }
                         else if (nguoiDung.maLND == "AD")
                         {
                             nguoiDung.maND = qlndTxtMaND.Text;
                         }
                         qlttn.SubmitChanges();
                     }
                 }
                 catch (Exception exc)
                 {
                     MessageBox.Show($"Đã xảy ra lỗi {Environment.NewLine}{exc.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     return;
                 }
                 loadDgvNguoiDung();
             };
            /// xóa người dùng
            qlndDgvND.CellClick += (s, e) =>
              {
                  if (e.ColumnIndex == 0)
                  {
                      var row = qlndDgvND.Rows[e.RowIndex];
                      var malnd = qlndCbLoaiND.SelectedValue.ToString();
                      using (var qlttn = new QLTTNDataContext())
                      {
                          if (malnd == "HS")
                          {
                              var mahs = row.Cells["maHS"].Value.ToString();
                              qlttn.HocSinhs.DeleteOnSubmit(qlttn.HocSinhs.Where(hs => hs.maHS == mahs).FirstOrDefault());
                              qlttn.NguoiDungs.DeleteOnSubmit(qlttn.NguoiDungs.Where(nd => nd.maND == mahs).FirstOrDefault());
                          }
                          else if (malnd == "GV")
                          {
                              var magv = row.Cells["maGV"].Value.ToString();
                              qlttn.CT_GiangDays.DeleteAllOnSubmit(qlttn.CT_GiangDays.Where(ctgd => ctgd.maGV == magv));
                              qlttn.GiaoViens.DeleteOnSubmit(qlttn.GiaoViens.Where(gv => gv.maGV == magv).FirstOrDefault());
                              qlttn.NguoiDungs.DeleteOnSubmit(qlttn.NguoiDungs.Where(nd => nd.maND == magv).FirstOrDefault());
                          }
                          else if (malnd == "AD")
                          {
                              var mand = row.Cells["maND"].Value.ToString();
                              if (admin.maND == mand)
                              {
                                  MessageBox.Show("Không thể xóa chính bạn", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                  return;
                              }
                              qlttn.NguoiDungs.DeleteOnSubmit(qlttn.NguoiDungs.Where(nd => nd.maND == mand).FirstOrDefault());
                          }
                          qlttn.SubmitChanges();
                      }
                      loadDgvNguoiDung();
                  }
              };
            qlndBtnImport.Click += (s, e) =>
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

                                  var dtND = ds.Tables["NguoiDung"];
                                  var dtGV = ds.Tables["GiaoVien"];
                                  var dtHS = ds.Tables["HocSinh"];
                                  var dtCTGiangDay = ds.Tables["CT_GiangDay"];
                                  MessageBox.Show(DateTime.Parse(dtHS.Rows[0]["NgaySinh"].ToString()).ToShortDateString());
                                  MessageBox.Show(DateTime.Parse(dtGV.Rows[0]["NgaySinh"].ToString()).ToShortDateString());
                                  int soDongThanhCong = 0;
                                  int soDongThatBai = 0;
                                  try
                                  {
                                      using (var qlttn = new QLTTNDataContext())
                                      {
                                          foreach (DataRow row in dtND.Rows)
                                          {
                                              if (qlttn.NguoiDungs.Where(nd => nd.maND == row["maND"].ToString()).Count() > 0)
                                              {
                                                  soDongThatBai++;
                                                  continue;
                                              }
                                              else
                                              {
                                                  qlttn.NguoiDungs.InsertOnSubmit(new NguoiDung
                                                  {
                                                      maND = row["maND"].ToString(),
                                                      MatKhau = row["MatKhau"].ToString(),
                                                      maLND = row["maLND"].ToString()
                                                  });
                                                  qlttn.SubmitChanges();
                                                  soDongThanhCong++;
                                              }
                                          }
                                          foreach (DataRow row in dtHS.Rows)
                                          {
                                              if (qlttn.HocSinhs.Where(nd => nd.maHS == row["maHS"].ToString()).Count() > 0)
                                              {
                                                  soDongThatBai++;
                                                  continue;
                                              }
                                              else
                                              {
                                                  qlttn.HocSinhs.InsertOnSubmit(new HocSinh
                                                  {
                                                      maHS = row["maHS"].ToString(),
                                                      HoTen = row["HoTen"].ToString(),
                                                      NgaySinh = DateTime.Parse(row["NgaySinh"].ToString()),
                                                      maLop = row["maLop"].ToString(),
                                                      maKhoi = row["maKhoi"].ToString()
                                                  });
                                                  qlttn.SubmitChanges();
                                                  soDongThanhCong++;
                                              }
                                          }
                                          //qlttn.SubmitChanges();

                                          foreach (DataRow row in dtGV.Rows)
                                          {
                                              if (qlttn.GiaoViens.Where(nd => nd.maGV == row["maGV"].ToString()).Count() > 0)
                                              {
                                                  soDongThatBai++;
                                                  continue;
                                              }
                                              else
                                              {
                                                  qlttn.GiaoViens.InsertOnSubmit(new GiaoVien
                                                  {
                                                      maGV = row["maGV"].ToString(),
                                                      HoTen = row["HoTen"].ToString(),
                                                      NgaySinh = DateTime.Parse(row["NgaySinh"].ToString()),
                                                      maMH = row["maMH"].ToString()
                                                  });
                                                  qlttn.SubmitChanges();
                                                  soDongThanhCong++;
                                              }
                                          }
                                          foreach (DataRow row in dtCTGiangDay.Rows)
                                          {
                                              if (qlttn.CT_GiangDays.Where(nd => nd.maGV == row["maGV"].ToString() &&
                                                                                 nd.maKhoi == row["maKhoi"].ToString() &&
                                                                                 nd.maLop == row["maLop"].ToString()).Count() > 0)
                                              {
                                                  soDongThatBai++;
                                                  continue;
                                              }
                                              else
                                              {
                                                  soDongThanhCong++;
                                                  qlttn.CT_GiangDays.InsertOnSubmit(new CT_GiangDay
                                                  {
                                                      maGV = row["maGV"].ToString(),
                                                      maKhoi = row["maKhoi"].ToString(),
                                                      maLop = row["maLop"].ToString()
                                                  });
                                                  qlttn.SubmitChanges();
                                              }
                                          }
                                      }
                                  }
                                  catch (Exception excep)
                                  {
                                      MessageBox.Show(excep.Message, "Form Admin: Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                      MessageBox.Show($"Số dòng thành công: {soDongThanhCong}");
                                      return;
                                  }
                                  MessageBox.Show($"Số dòng thành công: {soDongThanhCong}");
                              }
                          }
                      }
                  };

        }

        private void QlndDgvND_SelectionChanged(object sender, EventArgs e)
        {
            // hiển thị danh sách dữ liệu bên dgvCTGiangDay nếu cbLoaiND đang là GV
            if (qlndCbLoaiND.SelectedValue.ToString() == "GV" &&
                  qlndDgvND.DataSource == bsGV)
            {
                if (bsGV.Count == 0 || qlndDgvND.SelectedRows.Count == 0)
                {
                    return;
                }
                using (var qlttn = new QLTTNDataContext())
                {
                    var magv = qlndDgvND.SelectedRows[0].Cells["maGV"].Value.ToString();
                    var ctdg = qlttn.CT_GiangDays.Where(ct => ct.maGV == magv).Select(ct => new { ct.maKhoi, ct.maLop }).ToList();

                    foreach (DataGridViewRow row in qlndDgvCTGiangDay.Rows)
                    {
                        var cellChon = row.Cells["Chon"] as DataGridViewCheckBoxCell;
                        var cellKhoi = row.Cells["maKhoi"].Value.ToString();
                        var cellLop = row.Cells["maLop"].Value.ToString();
                        var ressult = ctdg.Where(ct => ct.maKhoi == cellKhoi && ct.maLop == cellLop).Count();
                        if (ressult > 0)
                        {
                            cellChon.Value = cellChon.TrueValue;
                        }
                        else
                        {
                            cellChon.Value = cellChon.FalseValue;
                        }
                    }
                }
            }
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
        private void loadDgvCTGiangDay()
        {
            qlndDgvCTGiangDay.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "Chon",
                HeaderText = "",
                TrueValue = true,
                FalseValue = false,
                IndeterminateValue = false,
                Width = 30
            });
            using (var qlttn = new QLTTNDataContext())
            {
                qlndDgvCTGiangDay.DataSource = qlttn.LopHocs.Select(lh => new { lh.maKhoi, lh.maLop }).ToList();
                qlndDgvCTGiangDay.Columns["maKhoi"].HeaderText = "Khối";
                qlndDgvCTGiangDay.Columns["maKhoi"].Width = 60;
                qlndDgvCTGiangDay.Columns["maLop"].HeaderText = "Lớp";
                qlndDgvCTGiangDay.Columns["maLop"].Width = 65;
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

            qlndTxtHoTen.Text = "";
            qlndTxtMaND.Text = "";
            qlndDtpNgaySinh.Text = "";
            qlndCbKhoi.Text = "";
            qlndCbLop.Text = "";
            qlndCbChuyenMon.Text = "";

            lblKhoi.Hide();
            lblLop.Hide();
            lblChuyenMon.Hide();
            lblHoTen.Hide();
            lblNgaySinh.Hide();
            lblCTGiangDay.Visible = false;
            qlndCbKhoi.Hide();
            qlndCbLop.Hide();
            qlndCbChuyenMon.Hide();
            qlndTxtHoTen.Hide();
            qlndDtpNgaySinh.Hide();
            qlndDgvCTGiangDay.Visible = false;

            qlndDgvND.DataSource = null;

            using (var qlttn = new QLTTNDataContext())
            {
                var maLND = qlndCbLoaiND.SelectedValue.ToString();
                if (maLND == "HS")
                {
                    lblKhoi.Show();
                    lblLop.Show();
                    //lblChuyenMon.Show();
                    lblHoTen.Show();
                    lblNgaySinh.Show();
                    qlndCbKhoi.Show();
                    qlndCbLop.Show();
                    //qlndCbChuyenMon.Show();
                    qlndTxtHoTen.Show();
                    qlndDtpNgaySinh.Show();
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
                    qlndDgvND.Columns["HoTen"].Width = 160;
                    qlndDgvND.Columns["NgaySinh"].HeaderText = "Ngày sinh";
                    qlndDgvND.Columns["maKhoi"].HeaderText = "Khối";
                    qlndDgvND.Columns["maKhoi"].Width = 60;
                    qlndDgvND.Columns["maLop"].HeaderText = "Lớp";
                    qlndDgvND.Columns["maLop"].Width = 60;
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
                }
                else if (maLND == "GV")
                {
                    lblChuyenMon.Show();
                    lblHoTen.Show();
                    lblNgaySinh.Show();
                    lblCTGiangDay.Visible = true;
                    qlndCbChuyenMon.Show();
                    qlndTxtHoTen.Show();
                    qlndDtpNgaySinh.Show();
                    qlndDgvCTGiangDay.Visible = true;

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
                    qlndDgvND.Columns["HoTen"].Width = 180;
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
                }
                else
                {
                    bsAD.DataSource = qlttn.NguoiDungs.Where(nd => nd.maLND == "AD").Select(nd => new { nd.maND }).ToList();
                    qlndDgvND.DataSource = bsAD;
                    qlndDgvND.Columns["maND"].HeaderText = "Mã người dùng";
                    qlndDgvND.Columns["maND"].Width = 150;

                    if (bsGV.Count > 0)
                    {
                        if (qlndTxtMaND.DataBindings.Count == 0)
                        {
                            qlndTxtMaND.DataBindings.Add("Text", bsAD, "maND", true, DataSourceUpdateMode.Never);
                        }
                    }
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
            loadDgvNguoiDung();
            loadDgvCTGiangDay();

            qlndCbLoaiND.SelectedIndex = 2; // kích hoạt sự kiện load tất cả các bindingSource, mở mục học sinh lên đầu tiên

            tsBtnDangXuat.Click += (s, e) =>
            {
                this.Close();
            };
            this.FormClosing += (s, e) =>
            {
                this.frmlogin.Show();
                this.Dispose();
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