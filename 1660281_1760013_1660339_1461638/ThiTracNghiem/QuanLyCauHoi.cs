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

namespace ThiTracNghiem
{
    public partial class QuanLyCauHoi : Form
    {
        static BindingSource bsCauHoi = new BindingSource();
        static BindingSource bsDapAn = new BindingSource();
        DataSet ds;
        static bool isset = false;
        void set()
        {
            isset = true;
            txtCauHoi.DataBindings.Add("Text", bsCauHoi, "NoiDung", true, DataSourceUpdateMode.Never);
            txtCauHoi.Validating += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtCauHoi.Text))
                {
                    e.Cancel = true;
                    txtCauHoi.Focus();
                    errorProvider.SetError(txtCauHoi, "Không được để trống câu hỏi");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(txtCauHoi, "");
                }
            };
            txtDapAn.DataBindings.Add("Text", bsDapAn, "NoiDung", true, DataSourceUpdateMode.Never);
            txtDapAn.Validating += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtDapAn.Text))
                {
                    e.Cancel = true;
                    txtCauHoi.Focus();
                    errorProvider.SetError(txtDapAn, "Không được để trống câu hỏi");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(txtDapAn, "");
                }
            };
            cbCapDo.DataBindings.Add("Text", bsCauHoi, "maCD", true, DataSourceUpdateMode.Never);
            cbCapDo.DataBindings[0].Format += (s, e) =>
            {
                if (e.DesiredType == typeof(string))
                {
                    int maCapDo = int.Parse(e.Value.ToString());
                    e.Value = (cbCapDo.DataSource as List<CapDo>).Where(cd => cd.maCD == maCapDo).FirstOrDefault().NoiDung;
                }
            };
            cbCapDo.DataBindings[0].Parse += (s, e) =>
            {
                if (e.DesiredType == typeof(int))
                {
                    string noiDungCapDo = e.Value.ToString();
                    e.Value = (cbCapDo.DataSource as List<CapDo>).Where(cd => cd.NoiDung == noiDungCapDo).FirstOrDefault().maCD;
                }
            };
            ckbDungSai.DataBindings.Add("Checked", bsDapAn, "DungSai", true, DataSourceUpdateMode.Never);
            cbDSCH.SelectedIndexChanged += (s, e) =>
            {
                using (var qlttn = new QLTTNDataContext())
                {
                    bsDapAn.DataSource = qlttn.CauHois.Where(ch => ch.maCH == int.Parse(cbDSCH.SelectedValue.ToString())).SingleOrDefault().DapAns.ToList();
                }
            };
        }
        public QuanLyCauHoi()
        {
            InitializeComponent();

            loadCBCauHoi();
            loadDGVDapAn();

            if (bsCauHoi.DataSource != null && bsDapAn.DataSource != null)
            {
                set();
            }

            btnThemCauHoi.Click += (s, e) =>
            {
                using (var qlttn = new QLTTNDataContext())
                {
                    if (qlttn.CauHois.Where(ch => ch.NoiDung == txtCauHoi.Text).Count() != 0)
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
                        NoiDung = txtCauHoi.Text,
                        CapDo = qlttn.CapDos.Where(cd => cd.maCD == int.Parse(cbCapDo.SelectedValue.ToString())).SingleOrDefault()
                    });
                    qlttn.SubmitChanges();
                }
                loadCBCauHoi();
                cbDSCH.SelectedItem = cbDSCH.Items[cbDSCH.Items.Count - 1];
                txtDapAn.Focus();
            };
            btnXoaCauHoi.Click += (s, e) =>
             {
                 using (var qlttn = new QLTTNDataContext())
                 {
                     var cauHoiHienTai = qlttn.CauHois
                                         .Where(ch => ch.maCH == int.Parse(cbDSCH.SelectedValue.ToString()))
                                         .FirstOrDefault();
                     qlttn.DapAns.DeleteAllOnSubmit(cauHoiHienTai.DapAns);
                     qlttn.CauHois.DeleteOnSubmit(cauHoiHienTai);
                     qlttn.SubmitChanges();
                 }
                 loadCBCauHoi();
             };
            btnSuaCauHoi.Click += (s, e) =>
            {
                using (var qlttn = new QLTTNDataContext())
                {
                    var cauHoiHienTai = qlttn.CauHois
                                        .Where(ch => ch.maCH == int.Parse(cbDSCH.SelectedValue.ToString()))
                                        .FirstOrDefault();

                    cauHoiHienTai.NoiDung = txtCauHoi.Text;
                    cauHoiHienTai.CapDo = qlttn.CapDos.Where(cd => cd.maCD == int.Parse(cbCapDo.SelectedValue.ToString())).FirstOrDefault();
                    qlttn.SubmitChanges();
                }
                loadCBCauHoi();
                cbDSCH.SelectedItem = cbDSCH.Items[cbDSCH.Items.Count - 1];
            };
            btnThemDapAn.Click += (s, e) =>
            {
                using (var qlttn = new QLTTNDataContext())
                {
                    var cauHoiHienTai = qlttn.CauHois
                                        .Where(ch => ch.maCH == int.Parse(cbDSCH.SelectedValue.ToString()))
                                        .FirstOrDefault();
                    if (cauHoiHienTai.DapAns.Where(da => da.NoiDung == txtDapAn.Text).Count() != 0)
                    {
                        MessageBox.Show("Câu hỏi này đã có trong danh sách. Xin mời tạo câu hỏi mới", "Lỗi trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                    if (cauHoiHienTai.DapAns.Count >= 6)
                    {
                        MessageBox.Show("Mỗi câu hỏi có tối đa 6 đáp án. Xin mời xóa bớt đáp án để thêm mới", "Hướng dẫn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string noidung = txtDapAn.Text;

                    qlttn.DapAns.InsertOnSubmit(new DapAn()
                    {
                        NoiDung = noidung,
                        DungSai = ckbDungSai.Checked,
                        CauHoi = qlttn.CauHois.Where(ch => ch.maCH == int.Parse(cbDSCH.SelectedValue.ToString())).SingleOrDefault()
                    });
                    qlttn.SubmitChanges();
                }
                loadDGVDapAn();
                dgvDSDA.Rows[dgvDSDA.Rows.GetLastRow(DataGridViewElementStates.Displayed)].Selected = true;
                txtDapAn.Focus();
            };
            btnXoaDapAn.Click += (s, e) =>
            {
                using (var qlttn = new QLTTNDataContext())
                {
                    var cauHoiHienTai = qlttn.CauHois
                                        .Where(ch => ch.maCH == int.Parse(cbDSCH.SelectedValue.ToString()))
                                        .FirstOrDefault();
                    if (cauHoiHienTai.DapAns.Count <= 2)
                    {
                        MessageBox.Show("Mỗi câu hỏi cần phải có tối thiểu 2 đáp án", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (dgvDSDA.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Hãy chọn đáp án cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    qlttn.DapAns.DeleteOnSubmit(cauHoiHienTai.DapAns.Where(da => da.maDA == int.Parse(dgvDSDA.SelectedRows[0].Cells["maDA"].Value.ToString())).FirstOrDefault());
                    qlttn.SubmitChanges();
                }
                loadDGVDapAn();
            };
            btnSuaDapAn.Click += (s, e) =>
            {
                using (var qlttn = new QLTTNDataContext())
                {
                    var cauHoiHienTai = qlttn.CauHois
                                        .Where(ch => ch.maCH == int.Parse(cbDSCH.SelectedValue.ToString()))
                                        .FirstOrDefault();
                    var dapAnHienTai = cauHoiHienTai.DapAns.Where(da => da.maDA == int.Parse(dgvDSDA.SelectedRows[0].Cells["maDA"].Value.ToString())).FirstOrDefault();
                    dapAnHienTai.NoiDung = txtDapAn.Text;
                    dapAnHienTai.DungSai = ckbDungSai.Checked;
                    qlttn.SubmitChanges();
                }
                loadDGVDapAn();
                txtDapAn.Focus();
            };

            btnImport.Click += (s, e) =>
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel Workbook 97-2003|*.xls", ValidateNames = true })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
                        {
                            IExcelDataReader reader;
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

                            //cb_sheet.Items.Clear();
                            using (var qlttn = new QLTTNDataContext())
                            {
                                qlttn.DapAns.DeleteAllOnSubmit(qlttn.DapAns.Select(da => da));
                                qlttn.CauHois.DeleteAllOnSubmit(qlttn.CauHois.Select(ch => ch));
                                qlttn.CapDos.DeleteAllOnSubmit(qlttn.CapDos.Select(cd => cd));
                                qlttn.SubmitChanges();

                                DataTable dtCapDo = ds.Tables["CapDo"];
                                foreach (DataRow row in dtCapDo.Rows)
                                {
                                    qlttn.CapDos.InsertOnSubmit(new CapDo()
                                    {
                                        maCD = int.Parse(row["maCD"].ToString()),
                                        NoiDung = row["NoiDung"].ToString()
                                    });
                                }
                                qlttn.SubmitChanges();
                                DataTable dtCauHoi = ds.Tables["CauHoi"];
                                foreach (DataRow row in dtCauHoi.Rows)
                                {
                                    qlttn.CauHois.InsertOnSubmit(new CauHoi()
                                    {
                                        maCH = int.Parse(row["maCH"].ToString()),
                                        NoiDung = row["NoiDung"].ToString(),
                                        maCD = int.Parse(row["maCD"].ToString())
                                    });
                                }
                                qlttn.SubmitChanges();
                                DataTable dtDapAn = ds.Tables["DapAn"];
                                foreach (DataRow row in dtDapAn.Rows)
                                {
                                    qlttn.DapAns.InsertOnSubmit(new DapAn()
                                    {
                                        NoiDung = row["NoiDung"].ToString(),
                                        maCH = int.Parse(row["maCH"].ToString()),
                                        maDA = int.Parse(row["maDA"].ToString()),
                                        DungSai = bool.Parse(row["DungSai"].ToString())
                                    });
                                }
                                qlttn.SubmitChanges();
                            }
                            loadCBCauHoi();
                            loadDGVDapAn();
                            if (!isset)
                            {
                                set();
                            }
                            reader.Close();

                        }
                    }
                }

            };
        }
        void loadCBCauHoi()
        {
            using (var qlttn = new QLTTNDataContext())
            {
                if (qlttn.CapDos.Count() > 0 && qlttn.CauHois.Count() > 0)
                {
                    bsCauHoi.DataSource = (qlttn.CauHois.ToList());
                    cbDSCH.DataSource = bsCauHoi;
                    cbDSCH.DisplayMember = "NoiDung";
                    cbDSCH.ValueMember = "maCH";

                    cbCapDo.DataSource = qlttn.CapDos.ToList();
                    cbCapDo.DisplayMember = "NoiDung";
                    cbCapDo.ValueMember = "maCD";
                    cbCapDo.SelectedValue = qlttn.CapDos.FirstOrDefault().maCD;
                }
            }
        }
        void loadDGVDapAn()
        {
            using (var qlttn = new QLTTNDataContext())
            {
                if (qlttn.CauHois.Count() > 0)
                {
                    bsDapAn.DataSource = qlttn.CauHois.Where(ch => ch.maCH == int.Parse(cbDSCH.SelectedValue.ToString())).SingleOrDefault().DapAns.ToList();
                    dgvDSDA.DataSource = bsDapAn;
                    dgvDSDA.Columns["maCH"].Visible = false;
                    dgvDSDA.Columns["CauHoi"].Visible = false;
                    dgvDSDA.Columns["maDA"].Visible = false;
                    dgvDSDA.Columns["NoiDung"].DisplayIndex = 1;
                    dgvDSDA.Columns["NoiDung"].Width = 450;
                    dgvDSDA.Columns["NoiDung"].HeaderText = "Nội dung đáp án";
                    dgvDSDA.Columns["DungSai"].DisplayIndex = 2;
                    dgvDSDA.Columns["DungSai"].Width = 115;
                    dgvDSDA.Columns["DungSai"].HeaderText = "Tính chất đáp án";
                }
            }
        }
    }
}

