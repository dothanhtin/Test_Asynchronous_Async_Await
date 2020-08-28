using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Understand_Await_Async_Csharp
{
    public class TestTask
    {
        //task1
        public async static Task printTask1(int soLanLap1)
        {
            Action action1 = () =>
            {
                for (int i = 0; i <= soLanLap1; i++)
                {
                    WriteLine($"Task1 - {i}", ConsoleColor.Green);
                    Thread.Sleep(100);
                }
            };
            var task1 = new Task(action1);
            task1.Start();
            await task1;
            WriteLine($"Ket thuc task1", ConsoleColor.Green);
        }

        //task2
        public async static Task printTask2(int soLanLap2)
        {
            Action action2 = () =>
            {
                for (int i = 0; i <= soLanLap2; i++)
                {
                    WriteLine($"Task2 - {i}", ConsoleColor.Yellow);
                    Thread.Sleep(200);
                }
            };
            var task2 = new Task(action2);
            task2.Start();
            await task2;
            WriteLine($"Ket thuc task2", ConsoleColor.Yellow);
        }

        //task3
        public async static Task<string> printTask3(int soLanLap3)
        {
            Func<int, string> func3 = (int time) =>
             {
                 for (int i = 0; i <= time; i++)
                 {
                     WriteLine($"Task3 - {i}", ConsoleColor.Cyan);
                     Thread.Sleep(300);
                 }
                 return $"Ket thuc func3";
             };
            var task3 = new Task<string>(() => func3(soLanLap3));
            task3.Start();
            await task3;
            string res = task3.Result;
            WriteLine(res, ConsoleColor.Cyan);
            return task3.Result;
        }
        //task4
        public async static Task<string> printTask4(int soLanLap4)
        {
            Func<int, string> func4 = (int time) =>
               {
                   for (int i = 0; i <= time; i++)
                   {
                       WriteLine($"Task4 - {i}", ConsoleColor.White);
                       Thread.Sleep(400);
                   }
                   return $"Ket thuc func4";
               };
            var task4 = new Task<string>(() => func4(soLanLap4));
            task4.Start();
            await task4;
            var res = task4.Result;
            WriteLine(res, ConsoleColor.White);
            return res;
        }

        //-- phần này không phải là bất đồng bộ, vẫn thực hiện như đồng bộ
        //task5
        public static Task printTask5(int soLanLap5)
        {
            for (int i = 0; i <= soLanLap5; i++)
            {
                WriteLine($"Task5 - {i}", ConsoleColor.Red);
                Thread.Sleep(500);
            }
            WriteLine($"Ket thuc task5", ConsoleColor.Red);
            return Task.FromResult(1);
        }
        //task6
        public static Task printTask6(int soLanLap6)
        {
            for (int i = 0; i <= soLanLap6; i++)
            {
                WriteLine($"Task6 - {i}", ConsoleColor.DarkMagenta);
                Thread.Sleep(600);
            }
            WriteLine($"Ket thuc task6", ConsoleColor.DarkMagenta);
            return Task.FromResult(1);
        }
        public static void WriteLine(string s, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(s);
        }
    }
}
