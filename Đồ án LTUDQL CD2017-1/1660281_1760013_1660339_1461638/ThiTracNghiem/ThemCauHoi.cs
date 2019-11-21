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

            btnThemCauHoi.Click += (s, e) =>
            {
                SqlConnection con = new SqlConnection(Program.conStr);
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into CauHoi(NoiDung, CapDo) values(@noidung, @capdo)", con);
                cmd.Parameters.AddWithValue("@noidung", txtCauHoi.Text);
                cmd.Parameters.AddWithValue("@capdo", cklbCapDo.SelectedIndex);
                cmd.ExecuteNonQuery();

                ThemDapAn t = new ThemDapAn(txtCauHoi.Text);
                t.Show();

                con.Close();
            };
        }
    }
}
