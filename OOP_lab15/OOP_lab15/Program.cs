using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Laba16
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            Console.WriteLine();
            Task1();
           /* Task3();
            Task5();*/
            /* Task6();*/
            /*Task8();*/
            /*  await Task9();*/

        }

        private static void Task1()
        {
            var task = new Task(() =>
            {
                multiplicationMatrix(20);
            });
            Console.WriteLine("ID задачи: " + task.Id);
            Console.WriteLine("Статус задачи до выполнения: " + task.Status);
            var sw = new Stopwatch();
            task.Start();
            sw.Start();
            Console.WriteLine("Статус задачи во время выполнения: " + task.Status);
            task.Wait();
            sw.Stop();
            Console.WriteLine("Время выполнения: " + sw.Elapsed);//затраченное время
            sw.Restart();
            Console.WriteLine("Статус задачи после выполнения: " + task.Status);
            Console.WriteLine("Время выполнения: " + sw.Elapsed + "\n");//затраченное время

        }
        private static void Task3() {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            var task = new Task(() =>
            {
                multiplicationMatrix(20);
            }, token);
            task.Start();
            try {
                tokenSource.Cancel();
                task.Wait();
            }
            catch (AggregateException ex)
            {
                if (task.IsCanceled)
                {
                    Console.WriteLine($"Задача {task.Id} была отменена\n");
                }
            }
            finally
            {
                tokenSource.Dispose();
            }
        }
        private static void Task5() {
            Task<int> sumTask = new Task<int>(() => Sum(4, 5));
            // задача продолжения
            Task<int> subTask = sumTask.ContinueWith(t => Sub(4, 5));
            Task<int> mulTask = subTask.ContinueWith(t => Mul(4, 5));
            Task printTask1 = sumTask.ContinueWith(t => PrintResult(t.Result));
            Task printTask2 = subTask.ContinueWith(t => PrintResult(t.Result));
            Task printTask3 = mulTask.ContinueWith(t => PrintResult(t.Result));

            sumTask.Start();
            
            // ждем окончания второй задачи
            printTask3.Wait();

            int Sum(int a, int b) => a + b;
            int Sub(int a, int b) => a - b;
            int Mul(int a, int b) => a * b;
            void PrintResult(int sum) => Console.WriteLine($"Результат задачи: {sum}");
            //объект ожидания
            var awaiter = sumTask.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                int res = awaiter.GetResult();
                Console.WriteLine($"Результат задачи GetAwaiter(): {res}");
            });

        }
        public static void Task6() {
            var array1 = new int[10000000];
            var array2 = new int[10000000];
            var array3 = new int[10000000];
            var array4 = new int[10000000];

            var stopwatch = new Stopwatch();

            stopwatch.Start();
            //FOR
            Parallel.For(0, 10000000, CreatingArrayElements);
            stopwatch.Stop();
            Console.WriteLine($"Parallel FOR {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Restart();
            for (var i = 0; i < 10000000; i++)
            {
                array1[i] = 1;
                array2[i] = 1;
                array3[i] = 1;
            }

            stopwatch.Stop();
            Console.WriteLine($"Обычный FOR {stopwatch.ElapsedMilliseconds} ms");
            
            void CreatingArrayElements(int x)
            {
                array1[x] = 1;
                array2[x] = 1;
                array3[x] = 1;
            }
            //распараллельте вычисления цикла ForEach()
            stopwatch.Restart();

            int sum = 0;
            Parallel.ForEach(array1, SumOfElements);
            stopwatch.Stop();
            Console.WriteLine($"Parallel FOREACH {stopwatch.ElapsedMilliseconds} ms");
            sum = 0;
            stopwatch.Restart();
            foreach (int item in array1) sum += item;
            stopwatch.Stop();
            Console.WriteLine($"FOREACH {stopwatch.ElapsedMilliseconds} ms");
            
            void SumOfElements(int item)
            {
                sum += item;
            }



        }
        public static void Task7() {
            //Используя Parallel.Invoke() распараллельте выполнение блока операторов.
            
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                Parallel.Invoke(() => multiplicationMatrix(3), () => multiplicationMatrix(4));
                stopwatch.Stop();
            Console.WriteLine($"Parallel Invoke {stopwatch.ElapsedMilliseconds} ms");
            
        }
        public static void Task8() {
            BlockingCollection<string> collection = new BlockingCollection<string>(5);
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;

            Task[] sell = new Task[5] {
                new Task(() => {
                Thread.Sleep(1000);
                    collection.Add("Помидор");
                }),
                new Task(() => {
                Thread.Sleep(100);
                    collection.Add("Огурец");
                }),
                new Task(() => {
                Thread.Sleep(2000);
                    collection.Add("Шоколадка");
                }),
                new Task(() => {
                Thread.Sleep(4000);
                    collection.Add("Вантуз");
                }),
                new Task(() => {
                Thread.Sleep(6000);
                    collection.Add("Туалетная бумага");
                }),
                };

            Task[] consumers = new Task[10] {
                new Task(() => {
                    Thread.Sleep(5000);
                    if (collection.Count != 0)
                    {
                        Console.WriteLine($"Покупатель {Task.CurrentId} купил {collection.Take()}");
                    }
                    else
                        {
                        tokenSource.Cancel();
                        Console.WriteLine($"Корзина пуста, покупатель{Task.CurrentId}ушел") ;
                    }
                }, token),
                new Task(() => {
                    Thread.Sleep(6000);
                     if (collection.Count != 0)
                    {
                        Console.WriteLine($"Покупатель {Task.CurrentId} купил {collection.Take()}");
                    }
                    else
                        {
                        tokenSource.Cancel();
                        Console.WriteLine($"Корзина пуста, покупатель{Task.CurrentId}ушел") ;
                    }
                }, token),
                new Task(() => {
                    Thread.Sleep(7000);
                      if (collection.Count != 0)
                    {
                        Console.WriteLine($"Покупатель {Task.CurrentId} купил {collection.Take()}");
                    }
                    else
                        {
                        tokenSource.Cancel();
                        Console.WriteLine($"Корзина пуста, покупатель{Task.CurrentId}ушел") ;
                    }
                }, token),
                new Task(() => {
                    Thread.Sleep(4000);
                     if (collection.Count != 0)
                    {
                        Console.WriteLine($"Покупатель {Task.CurrentId} купил {collection.Take()}");
                    }
                    else
                        {
                        tokenSource.Cancel();
                        Console.WriteLine($"Корзина пуста, покупатель{Task.CurrentId}ушел") ;
                    }
                }, token),
                new Task(() => {
                    Thread.Sleep(8000);
                       if (collection.Count != 0)
                    {
                        Console.WriteLine($"Покупатель {Task.CurrentId} купил {collection.Take()}");
                    }
                    else
                        {
                        tokenSource.Cancel();
                        Console.WriteLine($"Корзина пуста, покупатель{Task.CurrentId}ушел") ;
                    }
                }, token),
                new Task(() => {
                    Thread.Sleep(9000);
                       if (collection.Count != 0)
                    {
                        Console.WriteLine($"Покупатель {Task.CurrentId} купил {collection.Take()}");
                    }
                    else
                        {
                        tokenSource.Cancel();
                        Console.WriteLine($"Корзина пуста, покупатель{Task.CurrentId}ушел") ;
                    }
                }, token),
                new Task(() => {
                    Thread.Sleep(10000);
                       if (collection.Count != 0)
                    {
                        Console.WriteLine($"Покупатель {Task.CurrentId} купил {collection.Take()}");
                    }
                    else
                        {
                        tokenSource.Cancel();
                        Console.WriteLine($"Корзина пуста, покупатель{Task.CurrentId}ушел") ;
                    }
                }, token),
                new Task(() => {
                    Thread.Sleep(11000);
                       if (collection.Count != 0)
                    {
                        Console.WriteLine($"Покупатель {Task.CurrentId} купил {collection.Take()}");
                    }
                    else
                        {
                        tokenSource.Cancel();
                        Console.WriteLine($"Корзина пуста, покупатель{Task.CurrentId}ушел") ;
                    }
                }, token),
                new Task(() => {
                    Thread.Sleep(12000);
                       if (collection.Count != 0)
                    {
                        Console.WriteLine($"Покупатель {Task.CurrentId} купил {collection.Take()}");
                    }
                    else
                        {
                        tokenSource.Cancel();
                        Console.WriteLine($"Корзина пуста, покупатель{Task.CurrentId}ушел") ;
                    }
                }, token),
                new Task(() => {
                    Thread.Sleep(13000);
                       if (collection.Count != 0)
                    {
                        Console.WriteLine($"Покупатель {Task.CurrentId} купил {collection.Take()}");
                    }
                    else
                        {
                        tokenSource.Cancel();
                        Console.WriteLine($"Корзина пуста, покупатель{Task.CurrentId}ушел") ;
                    }
                }, token),
            };
            foreach (var item in sell)
            {
                if (item.Status != TaskStatus.Running)
                {
                    item.Start();
                }
            }
            foreach (var item in consumers)
            {
                if (item.Status != TaskStatus.Running)
                {
                    item.Start();
                }
            }
            int count = 0;
            while (true)
            {
                if (collection.Count != count && collection.Count != 0)
                {
                    count = collection.Count;
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.WriteLine("--------------- Склад ---------------");

                    foreach (var i in collection)
                        Console.WriteLine(i);
                }
            }
        }

        public static async Task Task9() {
            await PrintNameAsync("Tom");
            await PrintNameAsync("Bob");
            await PrintNameAsync("Sam");

            // определение асинхронного метода
            async Task PrintNameAsync(string name)
            {
                await Task.Delay(3000);     // имитация продолжительной работы
                Console.WriteLine(name);
            }
        }
        private static void multiplicationMatrix(int size)
        {
            //перемножение матриц
                var matrix1 = new int[size, size];
                var matrix2 = new int[size, size];
                var matrix3 = new int[size, size];
                var rand = new Random();
                for (var i = 0; i < size; i++)
                {
                    for (var j = 0; j < size; j++)
                    {
                        matrix1[i, j] = rand.Next(1, 10);
                        matrix2[i, j] = rand.Next(1, 10);
                    }
                }

                for (var i = 0; i < size; i++)
                {
                    for (var j = 0; j < size; j++)
                    {
                        matrix3[i, j] = matrix1[i, j] * matrix2[i, j];
                    }
                }

                for (var i = 0; i < size; i++)
                {
                    for (var j = 0; j < size; j++)
                    {
                        Console.Write(matrix3[i, j] + " ");
                    }

                    Console.WriteLine();
                }
            
        }
        private static int Task5_3(int x, int y, int z) {
            return x + y + z;
        }
        public static int Task5_2(int x, int y, int z) {
            return x * y * z;
        }
        private static int Task5_1(int x, int y, int z)
        {
            return y * y + z * z;
        }

    }
}