using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TrungTamNgoaiNgu.BIZ;
using TrungTamNgoaiNgu.DAL;

namespace TrungTamNgoaiNgu.GUI.QLKhoaThi
{
    public partial class FKhoaThi : Form
    {
        KhoaThiDAL khoaThiDAL;
        List<KhoaThi> khoaThis;
        List<PhongThi> phongThis;
        List<DuThi> duThis;
        int khoaThiIndex;
        int phongThiIndex;
        int duThiIndex;

        public FKhoaThi()
        {
            InitializeComponent();
            khoaThiDAL = new KhoaThiDAL();
            khoaThis = new List<KhoaThi>();
            phongThis = new List<PhongThi>();
            duThis = new List<DuThi>();
            khoaThiIndex = -1;
            phongThiIndex = -1;
            duThiIndex = -1;
        }

        private void FKhoaThi_Load(object sender, EventArgs e)
        {
            // load data init
            getKhoaThis();

            // style
            styles();
        }

        //
        // styles
        //
        private void styles()
        {
            FMain.setVisibleColDataGridView(dataGridView1, new int[] { });
            FMain.setSizeColDataGridView(dataGridView1, "");
            FMain.setHeaderColDataGridView(dataGridView1,
                new string[] { },
                new string[] { }
            );
        }

        //
        // get data
        //
        private bool getKhoaThis()
        {
            try
            {
                khoaThis = khoaThiDAL.DanhSachKhoaThi();
                dataGridView1.DataSource = khoaThis;
                FMain.SetVisible(btnSuaKhoaThi, false);
                FMain.SetVisible(btnChotKhoaThi, false);
                FMain.SetVisible(btnXoaKhoaThi, false);
                return true;
            }
            catch
            {
                MessageBox.Show("Lấy dữ liệu khoá thi không thành công, vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnThemKhoaThi_Click(object sender, EventArgs e)
        {
            FThemSuaKhoaThi fThemSuaKhoaThi = new FThemSuaKhoaThi();
            fThemSuaKhoaThi.ShowDialog();
            if (fThemSuaKhoaThi.Saved) getKhoaThis();
        }

        private void btnSuaKhoaThi_Click(object sender, EventArgs e)
        {
            FThemSuaKhoaThi fThemSuaKhoaThi = new FThemSuaKhoaThi(khoaThis[khoaThiIndex]);
            fThemSuaKhoaThi.ShowDialog();
            if (fThemSuaKhoaThi.Saved)
            {
                getKhoaThis();
                dataGridView1.Rows[khoaThiIndex].Selected = true;
                khoaThiIndex = -1;
            }
        }
        private void btnChotKhoaThi_Click(object sender, EventArgs e)
        {
            int least = 5;
            int countB1 = duThis.FindAll(i => i.MaTrinhDo == 1).Count;
            int countA2 = duThis.FindAll(i => i.MaTrinhDo == 2).Count;

            if (countA2 == 0 && countB1 == 0)
            {
                MessageBox.Show("Không có thí sinh dự thi, không thể chốt khoá thi!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool flag = true;
            if (countB1 > 0 && countB1 < least)
            {
                flag = false;
                MessageBox.Show("Danh sách thí sinh B1 không đủ chỉ tiêu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (countA2 > 0 && countA2 < least)
            {
                flag = false;
                MessageBox.Show("Danh sách thí sinh A2 không đủ chỉ tiêu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (flag)
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn chốt khoá thi không?", "Cảnh báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    if (khoaThiDAL.ChotSo(khoaThis[khoaThiIndex]))
                    {
                        getKhoaThis();
                        MessageBox.Show("Khoá thi đã được chốt, tạo phòng thi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.Rows[khoaThiIndex].Selected = true;
                        khoaThiIndex = -1;
                    }
                    else
                        MessageBox.Show("Thao tác thất bại, vui lòng kiểm tra lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void btnXoaKhoaThi_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xoá khoá thi không?", "Cảnh báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                if (khoaThiDAL.Xoa(khoaThis[khoaThiIndex]))
                {
                    getKhoaThis();
                    khoaThiIndex = -1;
                    MessageBox.Show("Khoá thi đã được xoá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Thao tác thất bại, vui lòng kiểm tra lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnThemGiaoVien_Click(object sender, EventArgs e)
        {
            new FThemGiaoVien();
        }

        private void getDuThis()
        {
            duThis = khoaThiDAL.DanhSachDuThi(khoaThis[khoaThiIndex]);
            dataGridView3.DataSource = duThis;
            duThiIndex = -1;
            FMain.SetVisible(btnXoaThiSinhDuThi, false);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex != khoaThiIndex)
            {
                khoaThiIndex = e.RowIndex;
                getDuThis();
                phongThis = khoaThiDAL.DanhSachPhongThi(khoaThis[khoaThiIndex]);
                dataGridView2.DataSource = phongThis;

                FMain.SetVisible(btnChiTietPhong, false);
                bool isOpen = !khoaThis[khoaThiIndex].ChotSo;
                FMain.SetVisible(btnSuaKhoaThi, isOpen);
                FMain.SetVisible(btnThemDuThi, isOpen);
                FMain.SetVisible(btnChotKhoaThi, isOpen);
                FMain.SetVisible(btnXoaKhoaThi, isOpen);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex != phongThiIndex)
            {
                phongThiIndex = e.RowIndex;
                FMain.SetVisible(btnChiTietPhong, true);
            }
        }

        private void btnChiTietPhong_Click(object sender, EventArgs e)
        {
            FMain.GetPage(new FPhongThi(phongThis[phongThiIndex]));
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex != duThiIndex)
            {
                duThiIndex = e.RowIndex;
                FMain.SetVisible(btnXoaThiSinhDuThi, true);
            }
        }

        private void btnXoaThiSinhDuThi_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xoá thí sinh này khỏi danh sách dự thi không?", "Cảnh báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                if (khoaThiDAL.XoaThiSinhDuThi(duThis[duThiIndex]))
                {
                    getDuThis();
                    MessageBox.Show("Thí sinh đã được xoá khỏi danh sách dự thi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Thao tác thất bại, vui lòng kiểm tra lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThemDuThi_Click(object sender, EventArgs e)
        {
            FThemDuThi fThemDuThi = new FThemDuThi(khoaThis[khoaThiIndex].MaKhoaThi);
            fThemDuThi.ShowDialog();
            if (fThemDuThi.Saved) getDuThis();
        }
    }
}
