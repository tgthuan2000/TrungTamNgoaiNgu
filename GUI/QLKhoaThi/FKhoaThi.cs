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
        int khoaThiIndex;

        public FKhoaThi()
        {
            InitializeComponent();
            khoaThiDAL = new KhoaThiDAL();
            khoaThis = new List<KhoaThi>();
            khoaThiIndex = -1;

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
                return true;
            }
            catch
            {
                MessageBox.Show("Lấy dữ liệu khoá thi không thành công, vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool loadDataKhoaThi()
        {
            SetVisibleBtns(false);
            return getKhoaThis();
        }


        private void btnLoadData_Click(object sender, EventArgs e)
        {
            if (loadDataKhoaThi())
            {
                MessageBox.Show("Tải dữ liệu khoá thi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnThemKhoaThi_Click(object sender, EventArgs e)
        {
            //FThemSuaKhoaThi fThemSuaKhoaThi = new FThemSuaKhoaThi();
            //fThemSuaKhoaThi.ShowDialog();
            //if (fThemSuaKhoaThi.Saved) loadDataKhoaThi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //FThemSuaKhoaThi fThemSuaKhoaThi = new FThemSuaKhoaThi(khoaThi[khoaThiIndex]);
            //fThemSuaKhoaThi.ShowDialog();
            //if (fThemSuaKhoaThi.Saved) loadDataKhoaThi();
        }

        private void btnThemGiaoVien_Click(object sender, EventArgs e)
        {
            //FThemGiaoVien fThemGiaoVien = new FThemGiaoVien();
            //fThemGiaoVien.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                khoaThiIndex = e.RowIndex;
                SetVisibleBtns(true);
            }
        }

        //
        // SetVisibleBtns
        //
        private void SetVisibleBtns(bool b)
        {
            FMain.SetVisible(
                new List<Button>() {
                    btnXem,
                    btnSua,
                }, b
            );
        }

        //
        //  btnXem
        //
        private void btnXem_Click(object sender, EventArgs e)
        {
            //FMain.GetPage(new FChiTietKhoaThi(khoaThis[khoaThiIndex]));
        }
    }
}
