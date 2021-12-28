using System.Collections.Generic;
using System.Linq;
using TrungTamNgoaiNgu.BIZ;

namespace TrungTamNgoaiNgu.DAL
{
    class PhongThiDAL
    {
        TrungTamNgoaiNguEntities db;
        private readonly PhongThi phongThi;

        public PhongThiDAL()
        {

        }
        public PhongThiDAL(PhongThi phongThi)
        {
            this.phongThi = phongThi;
        }

        public bool createRoom(List<DuThi> duThis,int countA2, int countB2)
        {
            db = new TrungTamNgoaiNguEntities();

            if(countA2 > 5)
            {
                int roomNumber = 1;
                for (int i = 0; i < countA2; i += 5)
                {
                    PhongThi phongThi = new PhongThi();
                    phongThi.TenPhong = "A2P0" + roomNumber++;
                    phongThi.MaKhoaThi = duThis[0].MaKhoaThi;
                    phongThi.MaTrinhDo = 2;
                    db.PhongThis.Add(phongThi);
                }
            }
            else
            {
                int roomNumber = 1;
                PhongThi phongThi = new PhongThi();
                phongThi.TenPhong = "A2P0" + roomNumber++;
                phongThi.MaKhoaThi = duThis[0].MaKhoaThi;
                phongThi.MaTrinhDo = 2;
                db.PhongThis.Add(phongThi);

            }

            if (countB2 > 5)
            {
                int roomNumber = 1;
                for (int i = 0; i < countB2; i += 5)
                {
                    PhongThi phongThi = new PhongThi();
                    phongThi.TenPhong = "B1P0" + roomNumber++;
                    phongThi.MaKhoaThi = duThis[0].MaKhoaThi;
                    phongThi.MaTrinhDo = 1;
                    db.PhongThis.Add(phongThi);
                }
            }
            else
            {
                int roomNumber = 1;
                PhongThi phongThi = new PhongThi();
                phongThi.TenPhong = "B1P0" + roomNumber++;
                phongThi.MaKhoaThi = duThis[0].MaKhoaThi;
                phongThi.MaTrinhDo = 1;
                db.PhongThis.Add(phongThi);

            }
            return db.SaveChanges() > 1;
        }

        public bool AddCandidates(List<DuThi> duThis, List<PhongThi> phongThis)
        {
            int index = 0;

            foreach (var itemPhongThis in phongThis)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (itemPhongThis.MaTrinhDo == duThis[index].MaTrinhDo)
                    {
                        
                        System.Console.WriteLine("Test " + index);

                        ThiSinh thiSinh = new ThiSinh();
                        thiSinh.CCCD = duThis[index].CCCD;
                        thiSinh.MaPhong = itemPhongThis.MaPhong;
                        if (duThis[index].MaTrinhDo == 2)
                        {
                            thiSinh.SBD = "A20" + (i + 1);
                        }
                        else
                        {
                            thiSinh.SBD = "B10" + (i + 1);
                        }
                        thiSinh.DiemNghe = null;
                        thiSinh.DiemDoc = null;
                        thiSinh.DiemNoi = null;
                        thiSinh.DiemViet = null;

                        System.Console.WriteLine("Test " + thiSinh.CCCD + " " + thiSinh.SBD + " " + thiSinh.MaPhong);
                        db.ThiSinhs.Add(thiSinh);

                        index += 1;
                        if (index >= duThis.Count) break;
                    }
                }
            }
            return db.SaveChanges() > 0; 
        }

        public bool addTeachesIntoRoom(List<PhongThi> phongThis)
        {
            int index = 0;
            db = new TrungTamNgoaiNguEntities();
            var result = from gv in db.GiaoViens select gv;
            List<GiaoVien> GiaoVien = result.ToList();
            foreach(var item in phongThis)
            {
                for(int i = 0; i < 2; i++)
                {
                    System.Console.WriteLine("test " + item.TenPhong + " " + GiaoVien[index].TenGiaoVien + " "+ index);
                    GiamThi giamThi = new GiamThi();
                    giamThi.MaGiaoVien = GiaoVien[index].MaGiaoVien;
                    giamThi.MaPhong = item.MaPhong;
                    giamThi.NhiemVu = null;
                    db.GiamThis.Add(giamThi);

                    index += 1;
                    if (index >= phongThis.Count * 2) break;
                }
            }
            return db.SaveChanges() > 0;
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

        public bool LuuDiem(List<ThiSinh> thiSinhs)
        {
            db = new TrungTamNgoaiNguEntities();
            var qr = from ts in db.ThiSinhs
                     where ts.MaPhong == phongThi.MaPhong
                     select ts;

            foreach (ThiSinh ts in qr)
            {
                ThiSinh thiSinh = thiSinhs.Find(i => i.SBD == ts.SBD);
                ts.DiemDoc = thiSinh.DiemDoc;
                ts.DiemNghe = thiSinh.DiemNghe;
                ts.DiemNoi = thiSinh.DiemNoi;
                ts.DiemViet = thiSinh.DiemViet;
            }

            return db.SaveChanges() > 0;
        }
    }
}
