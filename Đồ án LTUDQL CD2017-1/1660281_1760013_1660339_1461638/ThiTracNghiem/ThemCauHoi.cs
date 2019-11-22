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
                bsCauHoi.DataSource = (qlttn.CauHois.ToList());
                cbDSCH.DataSource = bsCauHoi;
                cbDSCH.DisplayMember = "NoiDung";
                cbDSCH.ValueMember = "maCH";
                bsDapAn.DataSource = qlttn.CauHois.Where(ch => ch.maCH == int.Parse(cbDSCH.SelectedValue.ToString())).SingleOrDefault().DapAns.ToList();
                dgvDSDA.DataSource = bsDapAn;
                dgvDSDA.Columns["maCH"].Visible = false;
                dgvDSDA.Columns["CauHoi"].Visible = false;
                dgvDSDA.Columns["maDA"].DisplayIndex = 0;
                dgvDSDA.Columns["NoiDung"].DisplayIndex = 1;
                dgvDSDA.Columns["DungSai"].DisplayIndex = 2;
            }

            cbDSCH.SelectedIndexChanged += (s, e) =>
            {
                using (var qlttn = new QLTTNDataContext())
                {
                    bsDapAn.DataSource = qlttn.CauHois.Where(ch => ch.maCH == int.Parse(cbDSCH.SelectedValue.ToString())).SingleOrDefault().DapAns.ToList();
                }
            };

            txtCauHoi.DataBindings.Add("Text", bsCauHoi, "NoiDung", true, DataSourceUpdateMode.Never);
            txtDapAn.DataBindings.Add("Text", bsDapAn, "NoiDung", true, DataSourceUpdateMode.Never);

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
                }
            };


            btnThemDapAn.Click += (s, e) =>
            {
                int selectedIndex = 0;
                foreach (RadioButton rb in pnlDungSai.Controls)
                {
                    if (rb.Checked)
                    {
                        break;
                    }
                    selectedIndex++;
                }
                using (var qlttn = new QLTTNDataContext())
                {
                    string noidung = txtDapAn.Text;
                    bool dungsai = selectedIndex == 0 ? false : true;

                    qlttn.DapAns.InsertOnSubmit(new DapAn()
                    {
                        NoiDung = noidung,
                        DungSai = dungsai,
                        CauHoi = qlttn.CauHois.Where(ch => ch.maCH == int.Parse(cbDSCH.SelectedValue.ToString())).SingleOrDefault()
                    });
                    qlttn.SubmitChanges();
                }
                dgvDSDA.DataSource = bsDapAn;
            };
        }
    }
}