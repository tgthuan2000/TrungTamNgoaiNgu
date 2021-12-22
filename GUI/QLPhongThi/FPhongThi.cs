using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TrungTamNgoaiNgu.BIZ;
using TrungTamNgoaiNgu.DAL;

namespace TrungTamNgoaiNgu.GUI.QLPhongThi
{
    public partial class FPhongThi : Form
    {
        PhongThiDAL phongThiDAL;
        List<PhongThi> phongThis;
        int phongThiIndex;

        public FPhongThi()
        {
            InitializeComponent();

            phongThiDAL = new PhongThiDAL();
            phongThis = new List<PhongThi>();
            phongThiIndex = -1;

            // load data init
            getPhongThis();

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
        private bool getPhongThis()
        {
            try
            {
                phongThis = phongThiDAL.DanhSachPhongThi();
                dataGridView1.DataSource = phongThis;
                return true;
            }
            catch
            {
                MessageBox.Show("Lấy dữ liệu phòng thi không thành công, vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool loadDataPhongThi()
        {
            SetVisibleBtns(false);
            return getPhongThis();
        }


        private void btnLoadData_Click(object sender, EventArgs e)
        {
            if (loadDataPhongThi())
            {
                MessageBox.Show("Tải dữ liệu phòng thi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnThemPhongThi_Click(object sender, EventArgs e)
        {
            //FThemSuaPhongThi fThemSuaPhongThi = new FThemSuaPhongThi();
            //fThemSuaPhongThi.ShowDialog();
            //if (fThemSuaPhongThi.Saved) loadDataPhongThi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //FThemSuaPhongThi fThemSuaPhongThi = new FThemSuaPhongThi(phongThi[phongThiIndex]);
            //fThemSuaPhongThi.ShowDialog();
            //if (fThemSuaPhongThi.Saved) loadDataPhongThi();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                phongThiIndex = e.RowIndex;
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
            //FMain.GetPage(new FChiTietPhongThi(phongThis[phongThiIndex]));
        }
    }
}
