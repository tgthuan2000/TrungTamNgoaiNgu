﻿using System.Collections.Generic;
using System.Linq;
using TrungTamNgoaiNgu.BIZ;

namespace TrungTamNgoaiNgu.DAL
{
    class KhoaThiDAL
    {
        TrungTamNgoaiNguEntities db;
        private readonly KhoaThi khoaThi;

        public KhoaThiDAL() { }

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
        public List<PhongThi> DanhSachPhongThi(KhoaThi khoaThi)
        {
            db = new TrungTamNgoaiNguEntities();
            var qr = from pt in db.PhongThis
                     orderby pt.MaKhoaThi descending
                     where pt.MaKhoaThi == khoaThi.MaKhoaThi
                     select pt;

            return qr.ToList();
        }
        public List<DuThi> DanhSachDuThi(KhoaThi khoaThi)
        {
            db = new TrungTamNgoaiNguEntities();
            var qr = from dt in db.DuThis
                     orderby dt.NguoiDung.TenNguoiDung descending
                     where dt.MaKhoaThi == khoaThi.MaKhoaThi
                     select dt;

            return qr.ToList();
        }
        public List<KhoaThi> KhoaThiComboBox(NguoiDung nguoiDung)
        {
            db = new TrungTamNgoaiNguEntities();
            var qr = from kt in db.KhoaThis
                     orderby kt.MaKhoaThi descending
                     where kt.ChotSo == false
                     select kt;

            var qr2 = from dt in db.DuThis
                      where dt.CCCD == nguoiDung.CCCD
                      select dt.KhoaThi;

            return qr.Except(qr2).ToList();
        }


        public bool Them(KhoaThi khoaThi)
        {
            db = new TrungTamNgoaiNguEntities();
            db.KhoaThis.Add(khoaThi);
            return db.SaveChanges() > 0;
        }
        public bool Sua(KhoaThi khoaThi)
        {
            db = new TrungTamNgoaiNguEntities();
            var qr = from kt in db.KhoaThis
                     where kt.MaKhoaThi == khoaThi.MaKhoaThi
                     select kt;

            foreach (KhoaThi kt in qr)
            {
                kt.TenKhoa = khoaThi.TenKhoa;
                kt.NgayThi = khoaThi.NgayThi;
                kt.ChotSo = false;
            }
            return db.SaveChanges() > 0;
        }
        public bool Xoa(KhoaThi khoaThi)
        {
            db = new TrungTamNgoaiNguEntities();
            var qr = from kt in db.KhoaThis
                     where kt.MaKhoaThi == khoaThi.MaKhoaThi
                     select kt;

            foreach (KhoaThi kt in qr)
            {
                db.KhoaThis.Remove(kt);
            }

            var qr2 = from dt in db.DuThis
                      where dt.MaKhoaThi == khoaThi.MaKhoaThi
                      select dt;

            foreach (DuThi dt in qr2)
            {
                db.DuThis.Remove(dt);
            }

            return db.SaveChanges() > 0;
        }
        public bool XoaThiSinhDuThi(DuThi duThi)
        {
            db = new TrungTamNgoaiNguEntities();
            var qr = from dt in db.DuThis
                     where dt.MaKhoaThi == duThi.MaKhoaThi && dt.CCCD == duThi.CCCD
                     select dt;

            foreach (DuThi dt in qr)
            {
                db.DuThis.Remove(dt);
            }
            return db.SaveChanges() > 0;
        }

        public bool ChotSo(KhoaThi khoaThi)
        {
            db = new TrungTamNgoaiNguEntities();
            var qr = from kt in db.KhoaThis
                     where kt.MaKhoaThi == khoaThi.MaKhoaThi
                     select kt;

            foreach (KhoaThi kt in qr)
            {
                kt.ChotSo = true;
            }
            return db.SaveChanges() > 0;
        }

        public bool ThemGiaoVien(GiaoVien giaovien)
        {
            db = new TrungTamNgoaiNguEntities();
            db.GiaoViens.Add(giaovien);
            return db.SaveChanges() > 0;
        }
    }
}