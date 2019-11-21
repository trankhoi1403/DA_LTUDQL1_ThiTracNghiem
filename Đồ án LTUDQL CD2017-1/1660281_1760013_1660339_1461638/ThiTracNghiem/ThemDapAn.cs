using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThiTracNghiem
{
    public partial class ThemDapAn : Form
    {
        public string CauHoi;
        public ThemDapAn(string cauHoi)
        {
            CauHoi = cauHoi;

            InitializeComponent();
            TextBox txtCauHoi = new TextBox();

            txtCauHoi.Show();
            txtCauHoi.Left = 100;
            txtCauHoi.Top = 50;
            txtCauHoi.Text = cauHoi;
            txtCauHoi.ReadOnly = true;

            this.Controls.Add(txtCauHoi);

            btnThemDapAn.Click += (s, e) =>
            {
                using (var qlttn = new QLTTNDataContext())
                {
                    EntitySet<DapAn> chtamp = qlttn.CauHois.OrderByDescending(ch => ch.maCH).FirstOrDefault().DapAns;
                    chtamp.Add(new DapAn()
                    {
                        NoiDung = txtDapAn.Text,
                        DungSai = ckbDung.Checked
                    });
                    qlttn.SubmitChanges();
                }
            };
        }
    }
}
