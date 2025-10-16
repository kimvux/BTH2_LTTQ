using System;
using System.Globalization;

namespace Bai01
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.Write("Month: ");
                string x = Console.ReadLine() ?? "1/2000";
                string[] date = x.Split(new Char[] { '/', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    DateTime ThisMonth = new DateTime(int.Parse(date[1]), int.Parse(date[0]), 1);
                    Console.WriteLine("Sun\tMon\tTue\tWed\tThu\tFri\tSat");
                    List<int[]> Calendar = new List<int[]>();
                    int day = 1;
                    int row = 0;
                    int index = (int)ThisMonth.DayOfWeek;
                    while (day <= DateTime.DaysInMonth(ThisMonth.Year, ThisMonth.Month))
                    {
                        Calendar.Add(new int[7]);
                        if (day == 1)
                        {
                            for (int i=index; i<7; ++i)
                            {
                                Calendar[row][i] = day;
                                day++;
                            }
                        }
                        else
                        {
                            for (int i = 0; i < 7; ++i)
                            {
                                if (day > DateTime.DaysInMonth(ThisMonth.Year, ThisMonth.Month))
                                    break;
                                Calendar[row][i] = day;
                                day++;
                            }
                        }
                        row++;
                    }
                    for (int i = 0; i < row; ++i)
                    {
                        for (int j = 0; j < 7; ++j)
                        {
                            if (Calendar[i][j] == 0)
                                Console.Write("\t");
                            else
                                Console.Write(Calendar[i][j] + "\t");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("ERROR.....");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("ERROR.....");
                }
            }
        }
    }
}