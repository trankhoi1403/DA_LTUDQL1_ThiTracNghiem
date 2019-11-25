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

namespace ThiTracNghiem
{
    public partial class ThemCauHoi : Form
    {
        public ThemCauHoi()
        {
            InitializeComponent();

            var bsCauHoi = new BindingSource();
            var bsDapAn = new BindingSource();
            using (var qlttn = new QLTTNDataContext())
            {
                var opt = new DataLoadOptions();
                opt.LoadWith<CauHoi>(ch => ch.DapAns);
                qlttn.LoadOptions = opt;
                bsCauHoi.DataSource = (qlttn.CauHois.ToList());
                //bsDapAn.DataSource = (bsCauHoi.DataSource as EntitySet<CauHoi>).Select(ch => ch.DapAns);
            }
            cbDSCH.DataSource = bsCauHoi;
            cbDSCH.DisplayMember = "NoiDung";
            cbDSCH.ValueMember = "maCH";

            dgvDSDA.DataSource = bsCauHoi;
            dgvDSDA.DataMember = "DapAns";
            dgvDSDA.Columns["maCH"].DisplayIndex = 0;
            dgvDSDA.Columns["maCH"].ReadOnly = true;
            dgvDSDA.Columns["maDA"].DisplayIndex = 1;
            dgvDSDA.Columns["maDA"].ReadOnly = true;
            dgvDSDA.Columns["NoiDung"].DisplayIndex = 2;
            dgvDSDA.Columns["DungSai"].DisplayIndex = 3;
            dgvDSDA.Columns["CauHoi"].Visible = false;

            txtCauHoi.DataBindings.Add("Text", bsCauHoi, "NoiDung");
            txtDapAn.DataBindings.Add("Text", dgvDSDA.DataSource, "NoiDung");


            btnThemDapAn.Click += (s, e) =>
            {
                using (var qlttn = new QLTTNDataContext())
                {
                    string noidung = dgvDSDA.Rows[dgvDSDA.RowCount - 1].Cells["NoiDung"].Value.ToString();
                    bool dungsai = bool.Parse(dgvDSDA.Rows[dgvDSDA.RowCount - 1].Cells["DungSai"].Value.ToString());

                    qlttn.DapAns.InsertOnSubmit(new DapAn()
                    {
                        //maCH = int.Parse(cbDSCH.SelectedValue.ToString()),
                        //maDA = dgvDSDA.RowCount - 1,
                        NoiDung = noidung,
                        DungSai = dungsai,
                        CauHoi = qlttn.CauHois.Where(ch => ch.maCH == int.Parse(cbDSCH.SelectedValue.ToString())).SingleOrDefault()
                    });
                    qlttn.SubmitChanges();
                }
            };

            btnThemCauHoi.Click += (s, e) =>
            {
                int selectedIndex = 0;
                foreach (RadioButton rb in pnlCapDo.Controls)
                {
                    if (rb.Checked)
                    {
                        break;
                    }
                    selectedIndex++;
                }
                using (var qlttn = new QLTTNDataContext())
                {
                    qlttn.CauHois.InsertOnSubmit(new CauHoi()
                    {
                        NoiDung = txtCauHoi.Text,
                        CapDo = selectedIndex
                    });
                    qlttn.SubmitChanges();

                    //ThemDapAn t = new ThemDapAn(qlttn.CauHois.OrderByDescending(ch => ch.maCH).FirstOrDefault());
                }
            };
        }
    }
}
