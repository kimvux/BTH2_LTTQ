using System;

namespace Bai05
{
    class Program
    {
        class ThongTin
        {
            protected string DiaDiem { get; set; } = string.Empty;
            protected double GiaBan { get; set; }
            protected double DienTich { get; set; }
            public virtual void Input()
            {
                Console.Write("Nhap dia diem: ");
                DiaDiem = Console.ReadLine() ?? "";
                Console.Write("Nhap gia ban: ");
                GiaBan = double.Parse(Console.ReadLine() ?? "0");
                Console.Write("Nhap dien tich: ");
                DienTich = double.Parse(Console.ReadLine() ?? "0");
            }
            public virtual void Output()
            {
                Console.Write("{0}\t{1}VND\t{2}m2", DiaDiem, GiaBan, DienTich);
            }
            public double GetGia()
            {
                return GiaBan;
            }
            public double GetDienTich()
            {
                return DienTich;
            }
            public virtual int GetNamXD()
            {
                return 0;
            }
            public string GetDiaDiem()
            {
                return DiaDiem;
            }
        }
        class KhuDat : ThongTin { }
        class NhaPho : ThongTin
        {
            private int NamXD { get; set; }
            private int SoTang { get; set; }
            public override void Input()
            {
                base.Input();
                Console.Write("Nhap nam xay dung: ");
                NamXD = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("Nhap so tang: ");
                SoTang = int.Parse(Console.ReadLine() ?? "1");
            }
            public override void Output()
            {
                base.Output();
                Console.Write("\t{0}\t{1}",NamXD,SoTang);
            }
            public override int GetNamXD()
            {
                return NamXD;
            }
        }
        class ChungCu : ThongTin
        {
            private int SoTang { get; set; }
            public override void Input()
            {
                base.Input();
                Console.Write("Nhap so tang: ");
                SoTang = int.Parse(Console.ReadLine() ?? "1");
            }
            public override void Output()
            {
                base.Output();
                Console.Write("\t{0}", SoTang);
            }
        }
        class QuanLy
        {
            private ThongTin[] DanhSach;
            public void Nhap()
            {
                Console.Write("Nhap so luong: ");
                int sl = int.Parse(Console.ReadLine() ?? "0");
                DanhSach = new ThongTin[sl];
                for (int i=0; i<sl; i++)
                {
                    Console.Write("1. Khu dat\n" +
                                  "2. Nha pho\n" +
                                  "3. Chung cu\n"+
                                  "Chon: ");
                    int pick = int.Parse(Console.ReadLine() ?? "1");
                    if (pick == 1)
                    {
                        DanhSach[i] = new KhuDat();
                        DanhSach[i].Input();
                    }
                    else if (pick == 2)
                    {
                        DanhSach[i] = new NhaPho();
                        DanhSach[i].Input();
                    }
                    else
                    {
                        DanhSach[i] = new ChungCu();
                        DanhSach[i].Input();
                    }
                }
            }
            public void Xuat()
            {
                Console.WriteLine("Danh sach khu dat:");
                int dem = 0;
                for (int i=0;i<DanhSach.Length; ++i)
                {
                    if (DanhSach[i].GetType() ==typeof(KhuDat))
                    {
                        DanhSach[i].Output();
                        Console.WriteLine();
                        dem++;
                    }
                }
                if (dem == 0)
                    Console.WriteLine("Trong!!");

                dem = 0;
                Console.WriteLine("Danh sach nha pho:");
                dem = 0;
                for (int i = 0; i < DanhSach.Length; ++i)
                {
                    if (DanhSach[i].GetType() == typeof(NhaPho))
                    {
                        DanhSach[i].Output();
                        Console.WriteLine();
                        dem++;
                    }
                }
                if (dem == 0)
                    Console.WriteLine("Trong!!");

                dem = 0;
                Console.WriteLine("Danh sach chung cu:");
                dem = 0;
                for (int i = 0; i < DanhSach.Length; ++i)
                {
                    if (DanhSach[i].GetType() == typeof(ChungCu))
                    {
                        DanhSach[i].Output();
                        Console.WriteLine();
                        dem++;
                    }
                }
                if (dem == 0)
                    Console.WriteLine("Trong!!");

            }
            public void TongGiaTri3Loai()
            {
                Console.WriteLine("Tong gia ban cua cong ty:");
                double sumKD = 0;
                double sumNP = 0;
                double sumCC = 0;
                for (int i = 0; i < DanhSach.Length; ++i)
                {
                    if (DanhSach[i].GetType() == typeof(KhuDat)) sumKD += DanhSach[i].GetGia();
                    else if (DanhSach[i].GetType() == typeof(NhaPho)) sumNP += DanhSach[i].GetGia();
                    else sumCC += DanhSach[i].GetGia();
                }
                Console.WriteLine("Khu dat: {0} VND", sumKD);
                Console.WriteLine("Nha pho: {0} VND", sumNP);
                Console.WriteLine("Chung cu: {0} VND", sumCC);
            }
            public void XuatDSKhuDatHoacNhaPho()
            {
                int dem = 0;
                Console.WriteLine("Danh sach khu dat co dien tich > 100m2:");
                for (int i = 0; i < DanhSach.Length; ++i)
                {
                    if (DanhSach[i].GetType() == typeof(KhuDat) && DanhSach[i].GetDienTich() > 100)
                    {
                        DanhSach[i].Output();
                        Console.WriteLine();
                        dem++;
                    }
                }
                if (dem == 0)
                    Console.WriteLine("Trong!");

                dem = 0;
                Console.WriteLine("Danh sach nha pho co dien tich > 60m2 va nam xay dung >= 2019:");
                for (int i = 0; i < DanhSach.Length; ++i)
                {
                    if (DanhSach[i].GetType() == typeof(NhaPho) && DanhSach[i].GetDienTich() > 60 && DanhSach[i].GetNamXD() >= 2019)
                    {
                        DanhSach[i].Output();
                        Console.WriteLine();
                        dem++;
                    }
                }
                if (dem == 0)
                    Console.WriteLine("Trong!");
            }
            public void TimKiem()
            {
                Console.Write("Nhap dia diem: ");
                string diadiem = Console.ReadLine() ?? "";
                Console.Write("Nhap gia: ");
                double gia = double.Parse(Console.ReadLine() ?? "0");
                Console.Write("Nhap dien tich: ");
                double dientich = double.Parse(Console.ReadLine() ?? "0");
                var kq = DanhSach.Where(x => x.GetDiaDiem().IndexOf(diadiem, StringComparison.OrdinalIgnoreCase) != -1 &&
                                             x.GetGia() <= gia &&
                                             x.GetDienTich() >= dientich &&
                                             (x.GetType() == typeof(NhaPho) || x.GetType() == typeof(ChungCu))
                                       ).ToList();
                if (kq.Count == 0)
                    Console.WriteLine("empty");
                foreach (var x in kq)
                {
                    x.Output();
                    Console.WriteLine();
                }
            }
        }
        static void Main()
        {
            QuanLy a = new QuanLy();
            a.Nhap();
            Console.WriteLine("========================================\n");
            a.Xuat();
            Console.WriteLine("========================================\n");
            a.TongGiaTri3Loai();
            Console.WriteLine("========================================\n");
            a.XuatDSKhuDatHoacNhaPho();
            Console.WriteLine("========================================\n");
            a.TimKiem();
        }
    }
}
