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

    }
}
