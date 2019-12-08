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

namespace ThiTracNghiem
{
    public partial class QuanLyCauHoi : Form
    {
        static BindingSource bsCauHoi = new BindingSource();
        static BindingSource bsDapAn = new BindingSource();
        void set()
        {

            txtCauHoi.DataBindings.Add("Text", bsCauHoi, "NoiDung", true, DataSourceUpdateMode.Never, "Null value");
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
            txtDapAn.DataBindings.Add("Text", bsDapAn, "NoiDung", true, DataSourceUpdateMode.Never, "Null value");
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
            cbCapDo.DataBindings.Add("Text", bsCauHoi, "maCD", true, DataSourceUpdateMode.Never, "Null value");
            cbCapDo.DataBindings[0].Format += (s, e) =>
            {
                if (e.DesiredType == typeof(string))
                {
                    int maCapDo = int.Parse(e.Value.ToString());
                    e.Value = (cbCapDo.DataSource as List<CapDo>).Where(cd => cd.maCD == maCapDo).FirstOrDefault().TenCD;
                }
            };
            cbCapDo.DataBindings[0].Parse += (s, e) =>
            {
                if (e.DesiredType == typeof(int))
                {
                    string noiDungCapDo = e.Value.ToString();
                    e.Value = (cbCapDo.DataSource as List<CapDo>).Where(cd => cd.TenCD == noiDungCapDo).FirstOrDefault().maCD;
                }
            };
            ckbDungSai.DataBindings.Add("Checked", bsDapAn, "DungSai", true, DataSourceUpdateMode.Never, false);
            cbDSCH.SelectedIndexChanged += (s, e) =>
            {
                using (var qlttn = new QLTTNDataContext())
                {
                    if (cbDSCH.SelectedItem != null)
                    {
                        bsDapAn.DataSource = qlttn.CauHois.Where(ch => ch.maCH == int.Parse(cbDSCH.SelectedValue.ToString())).SingleOrDefault().DapAns.ToList();
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
                else
                {
                    //bsCauHoi.DataSource = DBNull.Value;
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
                else
                {
                    //bsDapAn.DataSource = DBNull.Value;
                }
            }
        }
        public QuanLyCauHoi()
        {
            InitializeComponent();

            loadCBCauHoi();
            loadDGVDapAn();

            set();

            btnThemCauHoi.Click += (s, e) =>
            {
                using (var qlttn = new QLTTNDataContext())
                {
                    if (qlttn.CauHois.Where(ch => ch.NoiDung.ToLower() == txtCauHoi.Text.ToLower()).Count() != 0)
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
                     if (qlttn.CauHois.Count() <= 1)
                     {
                         MessageBox.Show("Không thể xóa vì cần phải có ít nhất một câu hỏi trong Database", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                         return;
                     }
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
                    if (qlttn.CauHois.Where(ch => ch.NoiDung.ToLower() == txtCauHoi.Text.ToLower()).Count() != 0)
                    {
                        MessageBox.Show("Câu hỏi này đã có trong danh sách. Xin mời tạo câu hỏi mới", "Trùng record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

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
                    if (cauHoiHienTai.DapAns.Where(da => da.NoiDung.ToLower() == txtDapAn.Text.ToLower()).Count() != 0)
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
                        NoiDung = txtDapAn.Text,
                        DungSai = ckbDungSai.Checked,
                        //DungSai = bool.Parse(txtDungSai.Text),
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
                    if (cauHoiHienTai.DapAns.Where(da => da.NoiDung.ToLower() == txtDapAn.Text.ToLower()).Count() != 0)
                    {
                        MessageBox.Show("Đáp án này đã có trong danh sách. Xin mời tạo đáp án mới", "Lỗi trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }

                    var dapAnHienTai = cauHoiHienTai.DapAns.Where(da => da.maDA == int.Parse(dgvDSDA.SelectedRows[0].Cells["maDA"].Value.ToString())).FirstOrDefault();
                    dapAnHienTai.NoiDung = txtDapAn.Text;
                    dapAnHienTai.DungSai = ckbDungSai.Checked;
                    //dapAnHienTai.DungSai = bool.Parse(txtDungSai.Text);

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
                        using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            IExcelDataReader reader;
                            DataSet ds;
                            List<CauHoi> cauHoiBiTrung = new List<CauHoi>();

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

                            //cb_sheet.Items.Clear();
                            using (var qlttn = new QLTTNDataContext())
                            {
                                DataTable dtCauHoi = ds.Tables["CauHoi"];
                                DataTable dtDapAn = ds.Tables["DapAn"];
                                DataRow firstRow = dtCauHoi.Rows[0];

                                int lastIdent = (int)qlttn.ExecuteQuery<decimal>("select IDENT_CURRENT('dbo.CauHoi')").FirstOrDefault();

                                foreach (DataRow row in dtCauHoi.Rows)
                                {
                                    CauHoi cauHoiTmp = new CauHoi()
                                    {
                                        NoiDung = row["NoiDung"].ToString(),
                                        maCD = int.Parse(row["maCD"].ToString()),
                                    };
                                    if (qlttn.CauHois.Where(ch => ch.NoiDung.ToLower() == cauHoiTmp.NoiDung.ToLower()).Count() == 0)
                                    {
                                        qlttn.CauHois.InsertOnSubmit(cauHoiTmp);
                                        qlttn.SubmitChanges();
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
                                            }
                                        }

                                    }
                                    else
                                    {
                                        cauHoiBiTrung.Add(cauHoiTmp);
                                    }

                                }
                                qlttn.SubmitChanges();
                            }
                            loadCBCauHoi();
                            loadDGVDapAn();
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
                            else
                            {
                                MessageBox.Show("Import danh sách câu hỏi thành công", "Thông báo");
                            }
                        }
                    }
                }

            };
            btnExport.Click += (s, e) =>
             {
                 using (var sfd = new SaveFileDialog()
                 {
                     CreatePrompt = false,
                     OverwritePrompt = true,
                     AddExtension = true,
                     Filter = "Excel Workbook|*.xlsx|Excel Workbook 97-2003|*.xls",
                     ValidateNames = true
                 })
                 {
                     if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                     {

                         DataTable dtCauHoi = new DataTable();
                         dtCauHoi.TableName = "CauHoi";
                         dtCauHoi.Columns.Add("maCH", typeof(int));
                         dtCauHoi.Columns.Add("NoiDung", typeof(string));
                         dtCauHoi.Columns.Add("maCD", typeof(int));

                         DataTable dtDapAn = new DataTable();
                         dtDapAn.TableName = "DapAn";
                         dtDapAn.Columns.Add("maCH", typeof(int));
                         dtDapAn.Columns.Add("maDA", typeof(int));
                         dtDapAn.Columns.Add("NoiDung", typeof(string));
                         dtDapAn.Columns.Add("DungSai", typeof(bool));

                         using (var qlttn = new QLTTNDataContext())
                         {
                             List<CauHoi> chs = qlttn.CauHois.ToList();
                             List<DapAn> das = qlttn.DapAns.ToList();
                             for (int i = 0; i < qlttn.CauHois.Count(); i++)
                             {
                                 List<DapAn> dasTmp = das.Where(da => da.maCH == chs[i].maCH).ToList();
                                 chs[i].maCH = i + 1;
                                 dtCauHoi.Rows.Add(chs[i].maCH, chs[i].NoiDung, chs[i].maCD);

                                 foreach (var da in dasTmp)
                                 {
                                     da.maCH = i + 1;
                                     dtDapAn.Rows.Add(da.maCH, da.maDA, da.NoiDung, da.DungSai);
                                 }
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