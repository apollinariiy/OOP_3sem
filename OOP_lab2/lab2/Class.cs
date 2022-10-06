using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            id = GetHashCode();
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
        public Student()
        {
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
        public override string ToString()
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
            return city;
        }
        //метод для расчета возраста
        public int Age(ref int birthday)
        {
            int age = 2022 - birthday;
            return age;
        }
        //расчет уникального номера
        public override int GetHashCode()
        {
            var hash = 0;
            foreach (char temp in name)
            {
                hash += Convert.ToInt32(temp);
            }
            return Convert.ToInt32(hash);
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;

            Student stud = obj as Student;
            if (stud == null)
                return false;
            return this.Surname == stud.Surname && this.Name == stud.Name && this.Middlename == stud.Middlename
                && this.Birthday == stud.Birthday && this.Address == stud.Address && this.Phone == stud.Phone
                && this.Faculty == stud.Faculty && this.Course == stud.Course && this.Group == stud.Group;
        }
    }
}

