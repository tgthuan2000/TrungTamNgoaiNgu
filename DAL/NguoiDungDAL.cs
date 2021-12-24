﻿using System.Collections.Generic;
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
        public List<ThiSinh> DanhSachKetQuaThi(NguoiDung nguoiDung)
        {
            db = new TrungTamNgoaiNguEntities();
            var qr = from ts in db.ThiSinhs
                     where ts.CCCD == nguoiDung.CCCD
                     select ts;

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
        public bool Them(NguoiDung nguoiDung)
        {
            db = new TrungTamNgoaiNguEntities();
            db.NguoiDungs.Add(nguoiDung);
            return db.SaveChanges() > 0;
        }
        public bool Sua(NguoiDung nguoiDung)
        {
            db = new TrungTamNgoaiNguEntities();
            var qr = from nd in db.NguoiDungs
                     where nd.CCCD == nguoiDung.CCCD
                     select nd;

            foreach (NguoiDung nd in qr)
            {
                nd.NoiCap = nguoiDung.NoiCap;
                nd.NgayCap = nguoiDung.NgayCap;
                nd.HoNguoiDung = nguoiDung.HoNguoiDung;
                nd.TenNguoiDung = nguoiDung.TenNguoiDung;
                nd.SoDienThoai = nguoiDung.SoDienThoai;
                nd.GioiTinh = nguoiDung.GioiTinh;
                nd.Email = nguoiDung.Email;
                nd.NgaySinh = nguoiDung.NgaySinh;
                nd.NoiSinh = nguoiDung.NoiSinh;
            }
            return db.SaveChanges() > 0;
        }

        public bool DangKyDuThi(DuThi duThi)
        {
            db = new TrungTamNgoaiNguEntities();
            db.DuThis.Add(duThi);
            return db.SaveChanges() > 0;
        }
    }
}
