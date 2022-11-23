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
        private static void Main(string[] args)
        {
            Console.WriteLine();
             Task1();
            Task2();
            Console.ReadKey();
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
        private static void Task2() {
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

    }
}