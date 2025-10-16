using System;
using System.IO;

namespace Bai02
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.Write("Nhap duong dan: ");
                string x = Console.ReadLine() ?? "";
                DirectoryInfo thumuc = new DirectoryInfo(x);
                try
                {
                    FileInfo[] danhsach1 = thumuc.GetFiles();
                    foreach (FileInfo file in danhsach1)
                    {
                        Console.WriteLine(file.CreationTime + "\t" + file.Length / 1024 + "KB\t\t" + file.Name);
                    }
                    DirectoryInfo[] danhsach2 = thumuc.GetDirectories();
                    foreach (DirectoryInfo folder in danhsach2)
                    {
                        Console.WriteLine(folder.CreationTime + "\t<DIR>\t\t" + folder.Name);
                    }
                    Console.WriteLine();
                }
                catch (DirectoryNotFoundException)
                {
                    Console.WriteLine("Not found.....");
                }
            }
        }
    }
}