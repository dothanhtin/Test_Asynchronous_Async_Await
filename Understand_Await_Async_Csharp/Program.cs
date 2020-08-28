using System;
using System.Threading;
using System.Threading.Tasks;

namespace Understand_Await_Async_Csharp
{
    class Program
    {
        #region old code test
        //static async Task Main(string[] args)
        //{
        //    Console.WriteLine($"{' ',5} {Thread.CurrentThread.ManagedThreadId,3} MainThread");
        //    //Task<string> t1 = Program.Async1("A", "B");
        //    //Task t2 = Program.Async2();

        //    var t1 = Program.Async1("x", "y");
        //    var t2 = Program.Async2();
        //    Console.WriteLine("Làm gì đó ở thread chính sau khi 2 task chạy");


        //    // Làm gì đó khi t1, t2 đang chạy
        //    Console.WriteLine("Task1, Task2 đang chạy");


        //    await t1; // chờ t1 kết thúc
        //    Console.WriteLine("Làm gì đó khi t1 kết thúc");

        //    // Chờ t1 kết thúc và đọc kết quả trả về
        //    //t1.Wait();
        //    //String s = t1.Result;
        //    //Program.WriteLine(s, ConsoleColor.Red);

        //    // Ngăn không cho thread chính kết thúc
        //    // Nếu thread chính kết thúc mà t2 đang chạy nó sẽ bị ngắt
        //    Console.ReadKey();
        //}
        #endregion
        static async Task Main(string[] args)
        {
            Console.WriteLine("Run multi tasks:");
            //var task1 = TestTask.printTask1(10);
            //var task2 = TestTask.printTask2(9);

            //await Task.WhenAll(task1, task2); //run bất đồng bộ cho cả 2 task
            
            var task1 = TestTask.printTask1(9);
            //await task1;
            var task2 = TestTask.printTask2(10);
            //await task2;
            var task3 = TestTask.printTask3(11);
            var task4 = TestTask.printTask4(12);
            var task5 = TestTask.printTask5(13);
            var task6 = TestTask.printTask6(14);
            await Task.WhenAll(task1, task2, task3, task4, task5, task6);
            //await task2;
            //await TestTask.printTask1(10);
            //await TestTask.printTask2(9);
            Console.ReadKey();
        }
        // Viết ra màn hình thông báo có màu
        public static void WriteLine(string s, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(s);
        }

        // Tạo và chạy Task, sử dụng delegate Func (có kiểu trả về)
        public async static Task<string> Async1(string thamso1, string thamso2)
        {
            // tạo biến delegate trả về kiểu string, có một tham số object
            Func<object, string> myfunc = (object thamso) =>
            {
                // Đọc tham số (dùng kiểu động - xem kiểu động để biết chi tiết)
                dynamic ts = thamso;
                for (int i = 1; i <= 10; i++)
                {
                    //  Thread.CurrentThread.ManagedThreadId  trả về ID của thread đạng chạy
                    WriteLine($"{i,5} {Thread.CurrentThread.ManagedThreadId,3} Tham số {ts.x} {ts.y}",
                        ConsoleColor.Green);
                    Thread.Sleep(500);
                }
                return $"Kết thúc Async1! {ts.x}";
            };

            Task<string> task = new Task<string>(myfunc, new { x = thamso1, y = thamso2 });
            task.Start(); // chạy thread

            // Làm gì đó sau khi chạy Task ở đây
            Console.WriteLine("Async1: Làm gì đó sau khi task chạy");

            //string ketqua = task.Result;   // khóa (block) thread cha - chờ task hoàn thành
            await task;

            // Từ đây là code sau await (trong Async1) sẽ chỉ thi hành khi task kết thúc
            string ketqua = task.Result;
            Console.WriteLine("Làm gì đó khi task 1 đã kết thúc");
            //return task;
            return ketqua;
        }

        // Tạo và chạy Task, sử dụng delegate Action (không kiểu trả về)
        public static Task Async2()
        {
            Action myaction = () =>
            {
                for (int i = 1; i <= 10; i++)
                {
                    WriteLine($"{i,5} {Thread.CurrentThread.ManagedThreadId,3}",
                        ConsoleColor.Yellow);
                    Thread.Sleep(2000);
                }
            };
            Task task = new Task(myaction);
            task.Start();

            // Làm gì đó sau khi chạy Task ở đây
            Console.WriteLine("Async2: Làm gì đó sau khi task 2 chạy");

            return task;
        }

    }
}
