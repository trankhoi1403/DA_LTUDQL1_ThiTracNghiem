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

namespace ThiTracNghiem
{
    public partial class ThemCauHoi : Form
    {
        public ThemCauHoi()
        {
            InitializeComponent();
            cklbCapDo.SelectionMode = SelectionMode.One;

            btnThemCauHoi.Click += (s, e) =>
            {
                using (var qlttn = new QLTTNDataContext())
                {
                    qlttn.CauHois.InsertOnSubmit(new CauHoi()
                    {
                        NoiDung = txtCauHoi.Text,
                        CapDo = cklbCapDo.SelectedIndex
                    });
                    qlttn.SubmitChanges();
                }
                ThemDapAn t = new ThemDapAn(txtCauHoi.Text);
                t.Show();
            };
        }
    }
}
