using System.Collections.Generic;
using System.Linq;
using TrungTamNgoaiNgu.BIZ;

namespace TrungTamNgoaiNgu.DAL
{
    class KhoaThiDAL
    {
        TrungTamNgoaiNguEntities db;
        private KhoaThi khoaThi;

        public KhoaThiDAL()
        {
        }

        //
        // Chi tiết khoá thi
        //
        public KhoaThiDAL(KhoaThi khoaThi)
        {
            this.khoaThi = khoaThi;
        }

        public List<KhoaThi> DanhSachKhoaThi()
        {
            db = new TrungTamNgoaiNguEntities();
            var qr = from kt in db.KhoaThis
                     orderby kt.MaKhoaThi descending
                     select kt;

            return qr.ToList();
        }

        public List<KhoaThi> KhoaThiComboBox()
        {
            db = new TrungTamNgoaiNguEntities();
            var qr = from kt in db.KhoaThis
                     orderby kt.TenKhoa
                     select kt;

            return qr.ToList();
        }


    }
}
