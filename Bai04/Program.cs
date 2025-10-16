using System;
using System.Runtime.CompilerServices;

namespace Bai04
{
    class PhanSo
    {
        private int TuSo { get; set; }
        private int MauSo { get; set; }
        public PhanSo(int a=0,int b=1)
        {
            TuSo = a;
            MauSo = b;
        }
        private void RutGon()
        {
            if (TuSo == 0 || MauSo == 0) return;
            int a = Math.Abs(TuSo);
            int b = Math.Abs(MauSo);
            while(a != b)
            {
                if (a > b) a -= b;
                else if (a < b) b -= a;
            }
            TuSo /= a;
            MauSo /= a;
        }
        public void Input()
        {
            while (true)
            {
                try
                {
                    string tmp = Console.ReadLine() ?? "0";
                    string[] a = tmp.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                    TuSo = int.Parse(a[0]);
                    MauSo = int.Parse(a[1]);
                    if (MauSo == 0) throw new IndexOutOfRangeException();
                    break;
                }
                catch (IndexOutOfRangeException)
                {
                    Console.Write("Vui long nhap lai: ");
                }
            }
        }
        public void Output()
        {
            if (MauSo == 0) Console.Write("ERROR");
            else if (TuSo == 0) Console.Write(0);
            else if (MauSo == 1) Console.Write(TuSo);
            else
                Console.Write("{0}/{1}", TuSo, MauSo);
        }
        public static PhanSo operator +(PhanSo a, PhanSo b)
        {
            PhanSo x = new PhanSo();
            x.TuSo = a.TuSo * b.MauSo + b.TuSo * a.MauSo;
            x.MauSo = a.MauSo * b.MauSo;
            x.RutGon();
            return x;
        }
        public static PhanSo operator -(PhanSo a, PhanSo b)
        {
            PhanSo x = new PhanSo();
            x.TuSo = a.TuSo * b.MauSo - b.TuSo * a.MauSo;
            x.MauSo = a.MauSo * b.MauSo;
            x.RutGon();
            return x;
        }
        public static PhanSo operator *(PhanSo a, PhanSo b)
        {
            PhanSo x = new PhanSo();
            x.TuSo = a.TuSo * b.TuSo;
            x.MauSo = a.MauSo * b.MauSo;
            x.RutGon();
            return x;
        }
        public static PhanSo operator /(PhanSo a, PhanSo b)
        {
            PhanSo x = new PhanSo();
            x.TuSo = a.TuSo * b.MauSo;
            x.MauSo = a.MauSo * b.TuSo;
            x.RutGon();
            return x;
        }
        public static bool operator >(PhanSo a,PhanSo b)
        {
            if ((double)a.TuSo / (double)a.MauSo > (double)b.TuSo / (double)b.MauSo) return true;
            return false;
        }
        public static bool operator <(PhanSo a, PhanSo b)
        {
            return !(a>b);
        }
        public static bool operator ==(PhanSo a, PhanSo b)
        {
            if ((double)a.TuSo / (double)a.MauSo == (double)b.TuSo / (double)b.MauSo) return true;
            return false;
        }
        public static bool operator !=(PhanSo a, PhanSo b)
        {
            return !(a == b);
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            PhanSo other = (PhanSo)obj;
            PhanSo a = new PhanSo(TuSo, MauSo);
            PhanSo b = new PhanSo(other.TuSo, other.MauSo);
            return a.TuSo == b.TuSo && a.MauSo == b.MauSo;
        }

        public override int GetHashCode()
        {
            PhanSo temp = new PhanSo(TuSo, MauSo);
            return HashCode.Combine(temp.TuSo, temp.MauSo);
        }
    }
    class Program
    {
        static void Main()
        {
            PhanSo a = new PhanSo();
            PhanSo b = new PhanSo();
            Console.Write("Nhap phan so 1: ");
            a.Input();
            Console.Write("Nhap phan so 2: ");
            b.Input();
            PhanSo x = new PhanSo();
            
            x = a + b;
            Console.Write("\nTong: ");
            x.Output();

            x = a - b;
            Console.Write("\nHieu: ");
            x.Output();

            x = a * b;
            Console.Write("\nTich: ");
            x.Output();

            x = a / b;
            Console.Write("\nThuong: ");
            x.Output();
            Console.WriteLine();

            Console.Write("\nNhap so luong phan so: ");
            int sl = int.Parse(Console.ReadLine() ?? "0");
            PhanSo[] arr = new PhanSo[sl];
            for (int i=0; i < arr.Length; ++i)
            {
                Console.Write("Nhap phan so thu {0}: ", i + 1);
                arr[i] = new PhanSo();
                arr[i].Input();
            }
            for (int i = 0; i < arr.Length; ++i)
            {
                arr[i].Output();
                Console.Write(" ");
            }
            Console.WriteLine();
            ///////
            Console.Write("\nPhan so lon nhat: ");
            int indexmax = 0;
            for (int i = 1; i < arr.Length; ++i)
            {
                if (arr[indexmax] < arr[i])
                    indexmax = i;
            }
            for (int i = 0; i < arr.Length; ++i)
            {
                if (arr[indexmax] == arr[i])
                    arr[i].Output();
            }
            Console.WriteLine();
            ///////
            Console.WriteLine("\nSap xep phan so tang dan:");
            for (int i=0; i < arr.Length-1; ++i)
                for (int j=i+1; j<arr.Length; ++j)
                    if (arr[i] > arr[j])
                    {
                        PhanSo tmp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = tmp;
                    }
            foreach (PhanSo tmp in arr)
            {
                tmp.Output();
                Console.Write(" ");
            }
                
        }
    }
}