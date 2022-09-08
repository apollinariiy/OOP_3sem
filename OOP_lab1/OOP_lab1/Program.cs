using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab1
{
    class Program
    {
        static void Main(string[] args)
        {//1TYPES
         //a
            Console.WriteLine("Введите bool, byte, sbyte, char, short, ushort, int, long, ulong, float, double, demical, uint, string");
            bool a1 = Convert.ToBoolean(Console.ReadLine());
            byte a2 = Convert.ToByte(Console.ReadLine());
            sbyte a3 = Convert.ToSByte(Console.ReadLine());
            char a11 = Convert.ToChar(Console.ReadLine());
            short a4 = Convert.ToInt16(Console.ReadLine());
            ushort a7 = Convert.ToUInt16(Console.ReadLine());
            int a5 = Convert.ToInt32(Console.ReadLine());
            long a6 = Convert.ToInt16(Console.ReadLine());
            ulong a8 = Convert.ToUInt64(Console.ReadLine());
            float a9 = Convert.ToSingle(Console.ReadLine());
            double a10 = Convert.ToDouble(Console.ReadLine());
            decimal a12 = Convert.ToDecimal(Console.ReadLine());
            uint a13 = Convert.ToUInt32(Console.ReadLine());
            string a16 = Console.ReadLine();
            //nint a14 = Convert.ToInt32(Console.ReadLine());
            //nuint a15 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(a1 + " " + a2 + " " + a3 + " " + a4 + " " + a5 + " " + a6 + " " + a7 + " " + a8 + " " + a9 + " " + a10 + " " + a11 + " " + a12 + " " + a13 + " ");
            //b преобразование 
            //неявные
            long transToLongImp = a4;
            short transToShortImp = a2;
            double transToDoubleImp = a4;
            float transToFloatImp = a4;
            int transToIntImp = a4;
            //явные
            byte transToByteExp = (byte)(a5 + a9);
            sbyte transToSByteExp = (sbyte)(a5 + a9);
            short transToShortExp = (short)(a5 + a9);
            int transToIntExp = (int)(a5 + a9);
            long transToLongExp = (long)(a5 + a9);
            //c
            Object boxing = a5;
            boxing = 133;
            a5 = (int)boxing;
            //d
            //e
            float? a = null;
            //f
            var impType = true;
            Console.WriteLine(impType.GetType());
            //impType = 12;
            //2STRING
            //a
            string lit1 = "aaa";
            string lit2 = "aaa";
            string lit3 = "mmm";
            Console.WriteLine($"Сравнение 1 и 2 строки: {lit1 == lit2}");
            Console.WriteLine($"Сравнение 2 и 3 строки: {lit2 == lit3}");
            //b
            string qq = "Первая строка";
            string rr = "Вторая строка ";
            string ss = "Третья строка";
            string[] tt;
            Console.WriteLine($"Сцепление строк: {String.Concat(qq, rr)}");
            Console.WriteLine($"Копирование строки: {String.Copy(rr)}");
            Console.WriteLine($"Выделение подстроки: {ss.Substring(9)}");
            Console.WriteLine($"Разделение строки на слова: ");
            tt = qq.Split();
            for (int iii = 0; iii < tt.Length; iii++)
            {
                Console.WriteLine(tt[iii]);
            }
            Console.WriteLine($"Вставка подстроки в заданную позицию: {rr.Insert(4, qq)}");
            Console.WriteLine($"Удаление заданной подстроки: {ss.Remove(4)}");
            //c
            string lit4 = "";
            string lit5 = null;
            Console.WriteLine($"Сравнение пуст и null строк: {lit4 == lit5}");
            Console.WriteLine($"IsNullOrEmpty: {string.IsNullOrEmpty(lit4)}");
            Console.WriteLine($"IsNullOrEmpty: {string.IsNullOrEmpty(lit5)}");
            //d
            StringBuilder lit6 = new StringBuilder("Строка", 5);
            lit6.Append("а");
            lit6.Insert(0, "а");
            lit6.Remove(2, 1);
            Console.WriteLine($"StringBuilder: {lit6}");
            //3ARRAY
            //a
            int[,] arr = { { 1, 1, 1 }, { 0, 0, 0 }, { 1, 0, 1 } };
            int rows = arr.GetUpperBound(0) + 1;
            int columns = arr.Length / rows;
            for (int rrr = 0; rrr < rows; rrr++)
            {
                for (int ccc = 0; ccc < columns; ccc++)
                {
                    Console.Write($"{arr[rrr, ccc]} \t");
                }
                Console.WriteLine();
            }
            //b
            string[] arr2 = { "abc", "def", "ghi" };
            Console.WriteLine($"Длина массива: {arr2.Length}");
            foreach (string number in arr2)
            {
                Console.WriteLine(number);
            }
            arr2[1] = "ddeeff";
            Console.WriteLine("--------");
            foreach (string number in arr2)
            {
                Console.WriteLine(number);
            }
            //c
            int[][] arr3 = new int[3][];
            arr3[0] = new int[] { 1, 3 };
            arr3[1] = new int[] { 1, 3, 5 };
            arr3[2] = new int[] { 1, 3, 4, 7 };

            foreach (int[] row in arr3)
            {
                foreach (int number in row)
                {
                    Console.Write($"{number} \t");
                }
                Console.WriteLine();
            }
            //d
            var arr4 = new object[0];


            //4TUPLE
            //a,b
            (int, string, char, string, ulong) tup = (5, "efgh", 'a', "abcd", 12345);
            Console.WriteLine(tup);
            Console.WriteLine(tup.Item1);
            Console.WriteLine(tup.Item3);
            Console.WriteLine(tup.Item5);
            //c
            /*(int i, string str, char c, string str2, ulong ul) = tup;*/
            var (i, str, c, str2, ul) = tup;
            Console.WriteLine($"items: {tup} {str}");
            (int i2, _, _, _, ulong ul2) = tup;
            //d
            var tup1 = (3, 2, 4, 5, 6, 3, 5);
            var tup2 = (3, 2, 4, 5, 5, 3, 5);
            if (tup1 == tup2)
            {
                Console.WriteLine("true");
            }
            else
            { Console.WriteLine("false"); }

            //5FUNC

            (int, int, int, char) LocalFunction(int[] numbers, string str1)
            {
                int max = numbers[0];
                int min =numbers[0];
                int sum = 0;

                for (int iiii = 0; iiii < numbers.Length; iiii++)
                {
                    if (numbers[iiii] > max)
                    {
                        max = numbers[iiii];
                    }
                    if (numbers[iiii] < min)
                    {
                       min = numbers[iiii];
                    }
                    sum += numbers[iiii];
                }
                char smb = str1[0];
                var tuple1 = (max, min, sum, smb);
                return tuple1;
            }
            int[] nums = new int[4];
            nums[0] = 20;
            nums[1] = 30;
            nums[2] = 40;
            nums[3] = 100;
            string str5 = "abc";
            Console.WriteLine(LocalFunction(nums, str5));

            //6CHECKED

            int qwe = 100;
            int LocalFunction2()
            {
                int check = Int32.MaxValue;
                unchecked
                {
                    check = check + qwe;
                    Console.WriteLine(check);
                }
                return check;
            }
            int LocalFunction1()
            {
                int check = Int32.MaxValue;
                checked
                {
                    check = check + qwe;
                    Console.WriteLine(check);
                }
                return check;
            }
            Console.WriteLine(LocalFunction2());
            Console.WriteLine(LocalFunction1());
        }
    }
}
