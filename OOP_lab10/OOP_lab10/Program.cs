using OOP_lab10;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab10
{
    class Program
    {
        static void Main(string[] args)
            
        {
            //ЗАДАНИЕ 1
            Console.WriteLine("-----------------------------ЗАДАНИЕ 1---------------------------------");
            string[] months = { "December", "January", "February", "March", "April", "May", "September", "October", "November", "June", "July", "August", };

            Console.WriteLine("Введите n:");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nПоследовательность месяцев с длиной строки равной n:");
            var monthsWithNLength = from m in months
                                    where m.Length == n
                                    select m;
            foreach (var m in monthsWithNLength)
            {
                Console.WriteLine(m);
            }
            
            Console.WriteLine("\nЗапрос возвращающий только летние и зимние месяцы:");
            var summerAndWinterMonths = from m in months
                                        where Array.IndexOf(months, m) < 3  || Array.IndexOf(months, m) > 8
                                        select m;
            foreach (var m in summerAndWinterMonths)
            {
                Console.WriteLine(m);
            }

            Console.WriteLine("\nЗапрос вывода месяцев в алфавитном порядке:");
            var monthsInAlphabetOrder = from m in months
                                        orderby m
                                        select m;
            foreach (var m in monthsInAlphabetOrder)
            {
                Console.WriteLine(m);
            }

            Console.WriteLine("\nЗапрос считающий месяцы содержащие букву «u» и длиной имени не менее 4-х:");
            var monthsWithU = from m in months
                              where (m.Contains("u") || m.Contains("U")) && m.Length >= 4
                              select m;
            foreach (var m in monthsWithU)
            {
                Console.WriteLine(m);
            }

            //ЗАДАНИЕ 2
            Console.WriteLine("-----------------------------ЗАДАНИЕ 2---------------------------------");

            List<Student> students = new List<Student>();

            Student stud1 = new Student("Smirnova", "Polina", "Andreevna", 2000, "Belorusskaya Street", 375297778888, "FIT", 3, 5);
            Student stud2 = new Student("Ivanov", "Ivan", "Ivanovich", 1999, "Pushkina Street", 375297778888, "FIT", 3, 5);
            Student stud3 = new Student("Petrov", "Petr", "Petrovich", 1998, "Lenina Street", 375297778888, "FIT", 3, 5);
            Student stud4 = new Student("Sidorov", "Sidor", "Sidorovich", 1997, "Kalinina Street", 375297778888, "FIT", 3, 5);
            Student stud5 = new Student("Smirnov", "Sergey", "Sergeevich", 1996, "Kirova Street", 375297778888, "FIT", 3, 5);
            Student stud6 = new Student("Kozlov", "Ivan", "Ivanovich", 1995, "Kalinina Street", 375297778888, "XTIT", 3, 4);
            Student stud7 = new Student("Kuznetsov", "Petr", "Petrovich", 1994, "Kalinina Street", 375297778888, "XTIT", 3, 4);
            Student stud8 = new Student("Ivanova", "Polina", "Andreevna", 1993, "Kalinina Street", 375297778888, "XTIT", 3, 4);
            Student stud9 = new Student("Petrova", "Irina", "Ivanovna", 1992, "Kalinina Street", 375297778888, "XTIT", 3, 4);
            Student stud10 = new Student("Sidorova", "Svetlana", "Sergeevna", 1991, "Kalinina Street", 375297778888, "XTIT", 3, 4);

            students.Add(stud1);
            students.Add(stud2);
            students.Add(stud3);
            students.Add(stud4);
            students.Add(stud5);
            students.Add(stud6);
            students.Add(stud7);
            students.Add(stud8);
            students.Add(stud9);
            students.Add(stud10);
            
            Console.WriteLine("\nCписок студентов заданной специальности по алфавиту(XTIT):");
            var studentsBySpecialty = from s in students
                                      where s.Faculty == "XTIT"
                                      orderby s.Surname
                                      select s;
            foreach (var s in studentsBySpecialty)
            {
                Console.WriteLine(s.Surname +" "+s.Name);
            }

            Console.WriteLine("\nCписок заданной учебной группы и факультета(FIT,5):");
            var studentsByGroup = from s in students
                                  where s.Faculty == "FIT" && s.Group == 5
                                  select s;
            foreach (var s in studentsByGroup)
            {
                Console.WriteLine(s.Surname + " " + s.Name);
            }

            /* Console.WriteLine("\nCамый молодой студент:");
             var youngestStudent = from s in students
                                   orderby s.Birthday
                                   where s.FirstOrDefault
                                   select s;
             foreach (var s in youngestStudent)
             {
                 Console.WriteLine(s.Surname + " " + s.Name);
             }*/
            
            Console.WriteLine("\nCамый молодой студент:");
            int minYeras = students.Max(a => a.Birthday);   /// находим минимальное кол-во страниц через лямбда-выражение
            var result = students.FirstOrDefault(a => a.Birthday == minYeras);/// выбираем только один объект у которого
                                                                              /// поле совпадает с минимальным значением
            Console.WriteLine(result.Surname + " " + result.Name);

            
            Console.WriteLine("\nКоличество студентов заданной группы упорядоченных по фамилии(4):");
            var studentsByGroupAndSurname = from s in students
                                            where s.Group == 4
                                            orderby s.Surname
                                            select s;
            var count = studentsByGroupAndSurname.Count();
            Console.WriteLine(count);
            foreach (var s in studentsByGroupAndSurname)
            {
                Console.WriteLine(s.Surname + " " + s.Name);
            }

            Console.WriteLine("\nПервого студента с заданным именем(Petr):");
            var studentsByName = from s in students
                                 where s.Name == "Petr"
                                 select s;

            foreach (var s in studentsByName.Take(1))
            {
                Console.WriteLine(s.Surname + " " + s.Name);
            }

            //Задание 3
            Console.WriteLine("-----------------------------ЗАДАНИЕ 3---------------------------------");
            
            Console.WriteLine("Введите условия для поиска студентов:");
            Console.WriteLine("Факультет:");
            string faculty = Console.ReadLine();
            var studentsByFaculty = from s in students
                                    where s.Faculty == faculty//условия(where)-определяет фильтр выборки
                                    orderby s.Surname//упорядочивания(orderby)-упорядочивает элементы по возрастанию
                                    select s;//проекций(select)-определяет, какие поля будут включены в результат
            var count2 = studentsByFaculty.Count();//агрегация(count)-подсчитывает количество элементов коллекции, которые удовлетворяют определенному условию
            Console.WriteLine("Количество студентов заданного факультета: " + count2);
            foreach (var s in studentsByFaculty.Take(3)) //разбиение(take)-выбирает определенное количество элементов
            {
                Console.WriteLine(s.Surname + " " + s.Name);
            }

        }
    }
}