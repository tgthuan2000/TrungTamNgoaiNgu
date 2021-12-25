using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TrungTamNgoaiNgu.BIZ;
using TrungTamNgoaiNgu.DAL;

namespace TrungTamNgoaiNgu.GUI.QLKhoaThi
{
    public partial class FThemDuThi : Form
    {
        private bool isSuccess = false;
        private int maKhoaThi;
        private List<NguoiDung> nguoiDungs;
        public bool Saved
        {
            get { return isSuccess; }
        }
        public FThemDuThi(int maKhoaThi)
        {
            InitializeComponent();
            nguoiDungs = new List<NguoiDung>();
            this.maKhoaThi = maKhoaThi;
        }
        private void FThemDuThi_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            nguoiDungs = new KhoaThiDAL().DanhSachNguoiDungNgoaiKhoaThi(maKhoaThi);
            dataGridView1.DataSource = nguoiDungs;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
