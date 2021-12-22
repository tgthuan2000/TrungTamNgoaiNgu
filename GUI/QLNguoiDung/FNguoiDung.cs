using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TrungTamNgoaiNgu.BIZ;
using TrungTamNgoaiNgu.DAL;

namespace TrungTamNgoaiNgu.GUI.QLNguoiDung
{
    public partial class FNguoiDung : Form
    {
        NguoiDungDAL nguoiDungDAL;
        List<NguoiDung> nguoiDungs;
        int nguoiDungIndex;

        public FNguoiDung()
        {
            InitializeComponent();

            nguoiDungDAL = new NguoiDungDAL();
            nguoiDungs = new List<NguoiDung>();
            nguoiDungIndex = -1;

            // load data init
            getNguoiDungs();

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
        private bool getNguoiDungs()
        {
            try
            {
                nguoiDungs = nguoiDungDAL.DanhSachNguoiDung();
                dataGridView1.DataSource = nguoiDungs;
                return true;
            }
            catch
            {
                MessageBox.Show("Lấy dữ liệu người dùng không thành công, vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool loadDataNguoiDung()
        {
            SetVisibleBtns(false);
            return getNguoiDungs();
        }


        private void btnLoadData_Click(object sender, EventArgs e)
        {
            if (loadDataNguoiDung())
            {
                MessageBox.Show("Tải dữ liệu người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnThemNguoiDung_Click(object sender, EventArgs e)
        {
            //FThemSuaNguoiDung fThemSuaNguoiDung = new FThemSuaNguoiDung();
            //fThemSuaNguoiDung.ShowDialog();
            //if (fThemSuaNguoiDung.Saved) loadDataNguoiDung();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //FThemSuaNguoiDung fThemSuaNguoiDung = new FThemSuaNguoiDung(nguoiDungs[nguoiDungIndex]);
            //fThemSuaNguoiDung.ShowDialog();
            //if (fThemSuaNguoiDung.Saved) loadDataNguoiDung();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                nguoiDungIndex = e.RowIndex;
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
            //FMain.GetPage(new FChiTietNguoiDung(nguoiDungs[nguoiDungIndex]));
        }
    }
}
