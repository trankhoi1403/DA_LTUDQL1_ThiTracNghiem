using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThiTracNghiem
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            txtTenDangNhap.Validating += txtTenDangNhap_Validating;
            txtMatKhau.Validating += txtTenDangNhap_Validating;
         
        }

    

        private void txtTenDangNhap_Validating(object sender, CancelEventArgs e)
        {
            var ctrl = sender as Control;
            var strInput = ctrl.Text;
            if(strInput.Length==0)
            {
                errorProviderMain.SetError(ctrl, "not input");
            }
            else
            {
                errorProviderMain.SetError(ctrl, "");
            }
            var reStr = @"^[a-z][a-z0-9_\.]{2,9}$";
            var re = new Regex(reStr);
            if(!re.IsMatch(strInput))
            {
                errorProviderMain.SetError(ctrl, "not match");
            }
            else
            {
                errorProviderMain.SetError(ctrl, "");
            }
        }
    }

}
