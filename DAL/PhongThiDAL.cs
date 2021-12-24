using System.Collections.Generic;
using System.Linq;
using TrungTamNgoaiNgu.BIZ;

namespace TrungTamNgoaiNgu.DAL
{
    class PhongThiDAL
    {
        TrungTamNgoaiNguEntities db;
        private PhongThi phongThi;

        public PhongThiDAL()
        {
        }

        //
        // Chi tiết phòng thi
        //
        public PhongThiDAL(PhongThi phongThi)
        {
            this.phongThi = phongThi;
        }

        public List<PhongThi> DanhSachPhongThi()
        {
            db = new TrungTamNgoaiNguEntities();
            var qr = from pt in db.PhongThis
                     orderby pt.MaPhong descending
                     select pt;

            return qr.ToList();
        }

        public List<PhongThi> PhongThiComboBox()
        {
            db = new TrungTamNgoaiNguEntities();
            var qr = from pt in db.PhongThis
                     orderby pt.TenPhong
                     select pt;

            return qr.ToList();
        }
        public List<ThiSinh> DanhSachThiSinh()
        {
            db = new TrungTamNgoaiNguEntities();
            var qr = from ts in db.ThiSinhs
                     orderby ts.SBD
                     where ts.MaPhong == phongThi.MaPhong
                     select ts;

            return qr.ToList();
        }
        public List<GiamThi> DanhSachGiamThi()
        {
            db = new TrungTamNgoaiNguEntities();
            var qr = from gt in db.GiamThis
                     orderby gt.GiaoVien.TenGiaoVien
                     where gt.MaPhong == phongThi.MaPhong
                     select gt;

            return qr.ToList();
        }

        public bool ChotSo()
        {
            db = new TrungTamNgoaiNguEntities();
            var qr = from pt in db.PhongThis
                     where pt.MaPhong == phongThi.MaPhong
                     select pt;

            foreach (PhongThi pt in qr)
            {
                pt.ChotSo = true;
            }

            return db.SaveChanges() > 0;
        }
    }
}
