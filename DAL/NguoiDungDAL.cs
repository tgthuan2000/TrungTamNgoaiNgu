using System.Collections.Generic;
using System.Linq;
using TrungTamNgoaiNgu.BIZ;

namespace TrungTamNgoaiNgu.DAL
{
    class NguoiDungDAL
    {
        TrungTamNgoaiNguEntities db;
        private NguoiDung nguoiDung;

        public NguoiDungDAL()
        {
        }

        //
        // Chi tiết
        //
        public NguoiDungDAL(NguoiDung nguoiDung)
        {
            this.nguoiDung = nguoiDung;
        }

        public List<NguoiDung> DanhSachNguoiDung()
        {
            db = new TrungTamNgoaiNguEntities();
            var qr = from nd in db.NguoiDungs
                     orderby nd.CCCD descending
                     select nd;

            return qr.ToList();
        }

        public List<NguoiDung> NguoiDungComboBox()
        {
            db = new TrungTamNgoaiNguEntities();
            var qr = from nd in db.NguoiDungs
                     orderby nd.CCCD
                     select nd;

            return qr.ToList();
        }

    }
}
