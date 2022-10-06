using lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
//Создать класс Student: id, Фамилия, Имя, Отчество, Дата рождения, Адрес, Телефон, Факультет, Курс, Группа. Свойства и конструкторы должны обеспечивать проверку корректности. Создать массив объектов. Вывести:a) список студентов заданного факу
namespace lab2
{
    //----------------------------------
    class Class1
    {
        static void Main(string[] args)
        {//массив объектов
            Student[] student = new Student[5];
            student[0] = new Student("Smirnova", "Polina", "Andreevna", 2000, "Belorusskaya Street", 375297778888, "FIT", 3, 4);
            student[1] = new Student("Ivanov", "Ivan", 2000, "XTIT", 3, 5);
            student[2] = new Student();
            student[3] = new Student("Aleksandrov", "Nikita", "Sergeevich", 1998, "Belorusskaya Street", 375446668888, "FIT", 3, 4);
            student[4] = new Student("Kazakov", "Vladimir", "Nikolaevich", 2003, "Kypalavskaya street", 375297778888, "IEF", 1, 1);
            Console.WriteLine("Кол-во студентов: " + Student.count);
            /*        student[0].GetInfo();*/
            int ageStudent1 = student[1].Birthday;

            int age = student[0].Age(ref ageStudent1);
            Console.WriteLine("Возраст первого студента: " + age);

            //поиск по факультету
            string fac;
            Console.WriteLine("Поиск студента по факультету. Введите факультет:");
            fac = Console.ReadLine();
            foreach (Student student1 in student)
            {
                if (student1.Faculty == fac)
                    student1.ToString();
            }

            //поиск по группе
            int gr, cour;
            Console.WriteLine("Поиск студента по группе. Введите группу: ");
            gr = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите курс: ");
            cour = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите факультет: ");
            fac = Console.ReadLine();


            foreach (Student student1 in student)
            {
                if (student1.Group == gr && student1.Course == cour && student1.Faculty == fac)
                {
                    student1.ToString();
                    Console.WriteLine("----------------------------------------------------------------------------------------");
                }
            }
            //сравнение объектов
            if (student[0].Equals(student[1]))
                Console.WriteLine("\n\n   1-ый и 2-ой студент одинаковые.");
            else
                Console.WriteLine("\n\n   1-ый и 2-ой студент  не одинаковые.");

            //Анонимный тип (по образцу вашего класса). 
            var Anonim = new { Name = "Kate", Age = 22 };
            Console.WriteLine(Anonim.Name + " " + Anonim.Age);

        }
    }
}      



