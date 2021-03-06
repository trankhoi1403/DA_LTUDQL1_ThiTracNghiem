﻿using System;
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
        static Form frm = null;
        static NguoiDung nguoiDung = null;
        
        public frmLogin()
        {
            InitializeComponent();
            txtTenDangNhap.Validating += txtTenDangNhap_Validating;
            txtMatKhau.Validating += txtTenDangNhap_Validating;
            txtTenDangNhap.GotFocus += TxtTenDangNhap_GotFocus;
            txtMatKhau.GotFocus += TxtTenDangNhap_GotFocus;

            //this.Paint += (s, e) =>
            // {
            //     Image img = ThiTracNghiem.Properties.Resources.hinh_nen_form_login;
            //     e.Graphics.DrawImage(img, groupBox1.Bounds);
            // };
            txtMatKhau.GotFocus += (s, e) =>
             {

             };
            txtMatKhau.TextChanged += (s, e) =>
             {
                 using (var qlttn = new QLTTNDataContext())
                 {
                     nguoiDung = qlttn.NguoiDungs.Where(nd => nd.maND == txtTenDangNhap.Text && nd.MatKhau == txtMatKhau.Text).FirstOrDefault();
                     if (nguoiDung != null)
                     {
                         frm = null;
                         if (nguoiDung.maLND == "HS")
                         {
                             frm = new frmHocSinh(this, nguoiDung.HocSinh);
                         }
                         else if (nguoiDung.maLND == "GV")
                         {
                             frm = new frmGiaoVien(this, nguoiDung.GiaoVien);
                         }
                         else if (nguoiDung.maLND == "AD")
                         {
                             frm = new frmAdmin(this, nguoiDung);
                         }
                         if (frm != null)
                         {
                             frm.Show();
                             this.Hide();
                         }
                     }
                 }
             };

        }

        private void TxtTenDangNhap_GotFocus(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            t.SelectAll();
        }

        private void txtTenDangNhap_Validating(object sender, CancelEventArgs e)
        {
            var ctrl = sender as Control;
            var strInput = ctrl.Text;
            if (strInput.Length == 0)
            {
                errorProviderMain.SetError(ctrl, "not input");
            }
            else
            {
                errorProviderMain.SetError(ctrl, "");
            }
        }
    }
}
