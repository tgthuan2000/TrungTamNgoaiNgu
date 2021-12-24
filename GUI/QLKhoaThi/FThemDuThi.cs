using System;
using System.Windows.Forms;
using TrungTamNgoaiNgu.BIZ;
using TrungTamNgoaiNgu.DAL;

namespace TrungTamNgoaiNgu.GUI.QLKhoaThi
{
    public partial class FThemDuThi : Form
    {
        private bool isSuccess = false;
        private int maKhoaThi;
        public bool Saved
        {
            get { return isSuccess; }
        }
        public FThemDuThi(int maKhoaThi)
        {
            InitializeComponent();
            this.maKhoaThi = maKhoaThi;
        }
        private void FThemDuThi_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
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
