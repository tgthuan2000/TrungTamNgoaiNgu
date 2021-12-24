﻿using System;
using System.Windows.Forms;
using TrungTamNgoaiNgu.BIZ;
using TrungTamNgoaiNgu.DAL;

namespace TrungTamNgoaiNgu.GUI.QLNguoiDung
{
    public partial class FDangKyDuThi : Form
    {
        NguoiDungDAL nguoiDungDAL;
        private NguoiDung nguoiDung;
        public FDangKyDuThi(NguoiDung nguoiDung)
        {
            InitializeComponent();
            nguoiDungDAL = new NguoiDungDAL();
            this.nguoiDung = nguoiDung;
            ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FDangKyDuThi_Load(object sender, EventArgs e)
        {
            ActiveControl = comboBox1;
            radioButton1.Checked = true;
            comboBox1.DataSource = new KhoaThiDAL().KhoaThiComboBox(nguoiDung);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // get data
            int maKhoaThi;
            try
            {
                maKhoaThi = ((KhoaThi)comboBox1.SelectedItem).MaKhoaThi;
            }
            catch { maKhoaThi = -1; }
            int trinhDo = radioButton1.Checked ? 1 : 2; // 1 - B1 | 2 - A2


            // validate
            if (maKhoaThi == -1)
            {
                MessageBox.Show("Khoá thi không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // query
                DuThi duThi = new DuThi();
                duThi.CCCD = nguoiDung.CCCD;
                duThi.MaKhoaThi = maKhoaThi;
                duThi.MaTrinhDo = trinhDo;

                if (nguoiDungDAL.DangKyDuThi(duThi))
                    MessageBox.Show("Đăng ký dự thi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Đăng ký dự thi thất bại, vui lòng kiểm tra lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Close();
            }
        }
    }
}