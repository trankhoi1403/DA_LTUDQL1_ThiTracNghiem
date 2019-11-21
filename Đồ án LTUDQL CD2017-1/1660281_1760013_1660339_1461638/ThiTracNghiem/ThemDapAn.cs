using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            Label lblCauHoi = new Label();

            lblCauHoi.Show();
            lblCauHoi.Left = 100;
            lblCauHoi.Height = 50;
            lblCauHoi.Text = cauHoi;

            this.Controls.Add(lblCauHoi);
        }
    }
}
