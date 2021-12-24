using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TrungTamNgoaiNgu.BIZ;
using TrungTamNgoaiNgu.DAL;

namespace TrungTamNgoaiNgu.GUI.QLNguoiDung
{
    public partial class FKetQuaThi : Form
    {
        NguoiDung nguoiDung;
        public FKetQuaThi(NguoiDung nguoiDung)
        {
            InitializeComponent();
            this.nguoiDung = nguoiDung;
            lblCCCD.Text = nguoiDung.CCCD;
            lblEmail.Text = nguoiDung.Email;
            lblHoTen.Text = String.Format("{0} {1}", nguoiDung.HoNguoiDung, nguoiDung.TenNguoiDung);
            lblNgaySinh.Text = nguoiDung.NgaySinh.ToShortDateString();
            lblNoiSinh.Text = nguoiDung.NoiSinh;
            ShowDialog();
        }
        private void FKetQuaThi_Load(object sender, EventArgs e)
        {
            List<ThiSinh> thiSinhs = new NguoiDungDAL().DanhSachKetQuaThi(nguoiDung);
            dataGridView1.DataSource = thiSinhs;
            lblSoLanThi.Text = thiSinhs.Count.ToString();
        }
    }
}
