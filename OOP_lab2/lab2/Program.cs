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
    partial class Student
    {
        private readonly int id;
        private string surname;
        private string name;
        private string middlename;
        private int birthday;
        private string address;
        private long phone;
        private string faculty;
        private int course;
        private int group;
        public static short count = 0;
        
        public int Id
        {
            get { return id; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Middlename
        {
            get { return middlename; }
            set { middlename = value; }
        }
        public int Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public long Phone
        {
            get
            {
                return phone;
            }
            set
            {
                if (value < 290000000 && value > +450000000)
                {
                    Console.WriteLine("Неправильно введен телефон");
                }
                else
                {
                    phone = value;
                }
            }
        }
        public string Faculty
        {
            get { return faculty; }
            set { faculty = value; }
        }
        public int Course
        {
            get { return course; }
            set { course = value; }
        }
        public int Group
        {
            get { return group; }
            set { group = value; }
        }
        //Конструктор полный
        public Student(
            string Asurname, string Aname, string Amiddlename, int Abirthday, string Aaddress, long Aphone, string Afaculty, int Acourse, int Agroup)
        {
            surname = Asurname;
            name = Aname;
            middlename = Amiddlename;
            birthday = Abirthday;
            address = Aaddress;
            phone = Aphone;
            faculty = Afaculty;
            course = Acourse;
            group = Agroup;
            id=GetHashCode();
            count++;
        }
        //Неполный конструктор
        public Student(string Asurname, string Aname, int Abirthday, string Afaculty, int Acourse, int Agroup)
        {
            surname = Asurname;
            name = Aname;
            middlename = "Unknown";
            birthday = Abirthday;
            address = "Unknown";
            phone = 0;
            faculty = Afaculty;
            course = Acourse;
            group = Agroup;
            id = GetHashCode();
            count++;
        }
        //Конструктор по умолчанию
        public Student() {
            surname = "Unknown";
            name = "Unknown";
            middlename = "Unknown";
            birthday = 0;
            address = "Unknown";
            phone = 0;
            faculty = "Unknown";
            course = 0;
            group = 0;
            id = GetHashCode();
            count++;
        }
        static Student()
        {
            count = 0;

    }

        //поле- константу
        public const string city = "Minsk";
        //----------------------------------
        //метод для вывода информации
        public void GetInfo()
        {
            Console.WriteLine("ID: " + id);
            Console.WriteLine("Фамилия: " + surname);
            Console.WriteLine("Имя: " + name);
            Console.WriteLine("Отчество: " + middlename);
            Console.WriteLine("Дата рождения: " + birthday);
            Console.WriteLine("Адрес: " + address);
            Console.WriteLine("Телефон: " + phone);
            Console.WriteLine("Факультет: " + faculty);
            Console.WriteLine("Курс: " + course);
            Console.WriteLine("Группа: " + group);
            Console.WriteLine("Город: " + city);
        }
        //метод для расчета возраста
        public int Age(ref int birthday)
        {
            int age = 2022 - birthday;
            return age;
        }
         //расчет уникального номера
        private int GetHashCode()   
        {
            var hash = 0;
            foreach (char temp in name)
            {
                hash += Convert.ToInt32(temp);
            }
            return Convert.ToInt32(hash);
        }
    }
}
//----------------------------------
class Class1
{
    static void Main(string[] args)
    {//массив объектов
        Student[] student = new Student[5];
        student[0] = new Student("Smirnova", "Polina", "Andreevna", 2000, "Belorusskaya Street", 375297778888, "FIT", 3, 4);
        student[1] = new Student("Ivanov", "Ivan", 2000, "XTIT", 3, 5);
        student[2] = new Student();
        student[3] = new Student("Aleksandrov", "Nikita", "Sergeevich",1998, "Belorusskaya Street", 375446668888, "FIT",3,4);
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
                student1.GetInfo();
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
                student1.GetInfo();
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
        



