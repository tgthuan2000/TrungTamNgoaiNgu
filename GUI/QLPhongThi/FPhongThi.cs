using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TrungTamNgoaiNgu.BIZ;
using TrungTamNgoaiNgu.DAL;

namespace TrungTamNgoaiNgu.GUI.QLKhoaThi
{
    public partial class FPhongThi : Form
    {
        PhongThiDAL phongThiDAL;
        PhongThi phongThi;
        List<ThiSinh> thiSinhs;
        List<ThiSinh> thiSinhsTemp;
        List<GiamThi> giamThis;

        public FPhongThi(PhongThi phongThi)
        {
            InitializeComponent();
            this.phongThi = phongThi;
            phongThiDAL = new PhongThiDAL(phongThi);
            thiSinhs = new List<ThiSinh>();
            thiSinhsTemp = new List<ThiSinh>();
            giamThis = new List<GiamThi>();
        }

        private void FPhongThi_Load(object sender, EventArgs e)
        {
            FMain.SetVisible(new List<Button>() { btnVaoDiem, btnChotPhongThi }, !phongThi.ChotSo);
            lbTitle.Text = String.Format("{0} | Phòng thi: {1}", phongThi.KhoaThi.TenKhoa, phongThi.TenPhong);
            getDataGiamThi();
            getDataThiSinh();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FMain.GetPage(new FKhoaThi());
        }

        //
        // getDataThiSinh
        //
        private bool getDataThiSinh()
        {
            try
            {
                thiSinhs = phongThiDAL.DanhSachThiSinh();
                thiSinhsTemp = thiSinhs;
                dataGridView2.DataSource = thiSinhs;

                FMain.setVisibleColDataGridView(dataGridView2, new int[] { });
                FMain.setSizeColDataGridView(dataGridView2, "");
                FMain.setHeaderColDataGridView(dataGridView2,
                    new string[] { },
                    new string[] { }
                );
                return true;
            }
            catch
            {
                MessageBox.Show("Lấy dữ liệu thí sinh không thành công, vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //
        // getDataGiamThi
        //
        private bool getDataGiamThi()
        {
            try
            {
                giamThis = phongThiDAL.DanhSachGiamThi();
                dataGridView3.DataSource = giamThis;

                FMain.setVisibleColDataGridView(dataGridView3, new int[] { });
                FMain.setSizeColDataGridView(dataGridView3, "");
                FMain.setHeaderColDataGridView(dataGridView3, "", "");
                return true;
            }
            catch
            {
                MessageBox.Show("Lấy dữ liệu giám thị không thành công, vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnVaoDiem_Click(object sender, EventArgs e)
        {

        }

        private void btnChotPhongThi_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn chốt điểm phòng thi không?", "Cảnh báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                if (phongThiDAL.ChotSo())
                {
                    FMain.SetVisible(new List<Button>() { btnVaoDiem, btnChotPhongThi }, false);
                    MessageBox.Show("Điểm phòng thi đã được chốt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Thao tác thất bại, vui lòng kiểm tra lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
