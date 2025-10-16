using System;

namespace Bai03
{
    class Program
    {
        static bool KtraSNT(int x)
        {
            if (x < 2) return false;
            if (x == 2 || x == 3) return true;
            for (int i = 2; i <= Math.Sqrt(x); ++i)
                if (x % i == 0) return false;
            return true;
        }
        static void Main()
        {
            //a
            Console.Write("Nhap m: ");
            int m = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Nhap n: ");
            int n = int.Parse(Console.ReadLine() ?? "0");
            int[,] arr = new int[m,n];
            for (int i = 0; i < m; ++i)
            {
                Console.WriteLine("Nhap dong {0}: ", i + 1);
                for (int j = 0; j < n; ++j)
                {
                    Console.Write("Cot {0}: ", j + 1);
                    arr[i,j] = int.Parse(Console.ReadLine() ?? "0");
                }
            }

            Console.WriteLine("\nXuat ma tran:");
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }

            //b
            Console.Write("\nNhap phan tu can tim: ");
            int num = int.Parse(Console.ReadLine() ?? "0");
            bool check = false;
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (arr[i,j] == num)
                    {
                        Console.WriteLine("Phan tu can tim o vi tri [{0},{1}]",i,j);
                        check = true;
                        break;
                    }
                }
                if (check == true) break;
            }
            if (check == false)
                Console.WriteLine("Khong tim thay phan tu!");


            //c
            Console.WriteLine("\nXuat cac phan tu la so nguyen to:");
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (KtraSNT(arr[i,j]))
                        Console.Write(arr[i, j] + " ");
                }
            }
            Console.WriteLine();

            //d
            Console.Write("\nDong co nhieu so nguyen to nhat: ");
            int[] dem = new int[m];
            for (int i = 0; i < m; ++i)
            {
                int tmp = 0;
                for (int j = 0; j < n; ++j)
                {
                    if (KtraSNT(arr[i, j]))
                        tmp++;
                }
                dem[i] = tmp;
            }
            int max = 0;
            foreach (int x in dem){
                if (x > max)
                    max = x;
            }
            for (int i = 0; i < m; ++i)
            {
                if (dem[i] == max)
                    Console.Write("{0} ",i+1);
            }
            Console.WriteLine();
        }
    }
}
