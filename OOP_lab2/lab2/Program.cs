using System;
using System.Collections;
/*Создать класс Customer: id, Фамилия, Имя, Отчество, 
Адрес, Номер кредитной карточки, баланс. Свойства и 
конструкторы должны обеспечивать проверку 
корректности. Добавить методы зачисления и списания
сумм на счет.
 Создать массив объектов. Вывести:
a) список покупателей в алфавитном порядке;
b) список покупателей, у которых номер кредитной карточки 
находится в заданном интервале.
Создать класс Student: id, Фамилия, Имя, Отчество, 
Дата рождения, Адрес, Телефон, Факультет, Курс, 
Группа. Свойства и конструкторы должны обеспечивать 
проверку корректности. Добавить метод расчет возраста 
студента
 Создать массив объектов. Вывести:
a) список студентов заданного факультета;
d) список учебной группы*/
namespace lab03
{
    //сделайте класс partial
    public partial class Customer
    {
        // поле - только для чтения 
        private readonly int id;
        private string lastname;
        private string firstname;
        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }
        private string patronymic;
        public string Patronymic
        {
            get { return patronymic; }
            set { patronymic = value; }
        }
        private int year;
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private ulong number;
        public ulong Number
        {
            get { return number; }
            set { number = value; }
        }

        private string facult;
        public string Facult
        {
            get { return facult; }
            set { facult = value; }
        }
        private int course;
        public int Course
        {
            get { return course; }
            set { course = value; }  
        }
        private int group;
        public int Group
        {
            get { return group; }
            set { group = value; }
        }
        //Не менее трех конструкторов
        public Customer(int i, string l, string f, string p,int y, string a, ulong n, string b, int z, int x) { id = i; lastname = l; firstname = f; patronymic = p; year = y; address = a; number = n; facult = b;course =z;group = x; count++; }
        public Customer(int iii) { id = iii; lastname = "unknown"; firstname = "unknown"; patronymic = "unknown"; address = "unknown"; number = 0; facult = "unknown"; course = 0; group = 0; count++; }
        public Customer(int ii, string ll, string ff, string pp) { id = ii; lastname = ll; firstname = ff; patronymic = pp; address = "Belorusskaya Street"; number = 375445558888; facult = "FIT";course = 2; group = 3; count++; }

        //статический конструктор
        static Customer()
        {
            Console.WriteLine("Customers:");
        }
        //закрытый конструктор
        //private Customer() {}

        //поле- константу
        public const string city = "Minsk";

        //в одном из методов класса для работы с аргументами используйте
        //ref - и out-параметры.
        public void Years(out int Plus)
        {
            Plus = year + 1000;
            year = Plus;
        }
        
        public void App(ref string FIT)
        {
            facult = FIT; 
        }

        /*создайте в классе статическое поле, хранящее количество созданных 
        объектов (инкрементируется в конструкторе) и статический 
        метод вывода информации о классе.*/

        public static int count;
        public Customer(int x, string y)
        {
            count++;
            id = x;
            lastname = y;
            Customer.count++;
        }


        /* переопределяете методы класса Object: Equals, для сравнения объектов,
        GetHashCode; для алгоритма вычисления хэша руководствуйтесь 
        стандартными рекомендациями, ToString – вывода строки –
        информации об объекте.*/
        public override int GetHashCode()
        {
            Console.WriteLine($"Hashcode of lastname: {lastname.GetHashCode()}");
            return lastname.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            return base.Equals(obj);
        }
        public override string ToString()
        {
            return $"{id}\t{lastname}\t{firstname}\t{patronymic}\t{year}\t{address}\t{number}\t{facult}\t{course}\t{group}\t{city}";
        }

        //Создать массив объектов.
        public static void Array()
        {
            var Customer = new Customer[3];
            Customer[0] = new Customer(1, "Smirnova", "Polina","Andreevna",2000, "Belorusskaya Street",375297778888,"FIT",3,4);
            Customer[1] = new Customer(2, "Vorotnickiy", "Vova", "Sergeevich", 2001, "Belorusskaya Street", 375297779988, "XTiT", 2, 15);
            Customer[2] = new Customer(3, "Golodok", "Anastasisa", "Yuryena", 20003, "Belorusskaya Street", 375297778118, "FIT", 2, 4);
            //a) список покупателей в алфавитном порядке;
            string[] words = { Customer[0].lastname, Customer[1].lastname, Customer[2].lastname };
            foreach (var item in words)
                Console.WriteLine(item);
            char[] a = words[0].ToCharArray();
            char[] b = words[1].ToCharArray();
            char[] c = words[2].ToCharArray();
            if (a[0] < b[0] & a[0] < c[0])
            {
                if (b[0] < c[0])
                {
                    Console.WriteLine(words[0] + "\t" + words[1] + "\t" + words[1]);
                }
                else { Console.WriteLine(words[0] + "\t" + words[2] + "\t" + words[1]); }
            }
            else if (b[0] < c[0] & b[0] < a[0])
            {
                if (a[0] < c[0])
                    Console.WriteLine(words[1] + "\t" + words[0] + "\t" + words[2]);
                else { Console.WriteLine(words[1] + "\t" + words[2] + "\t" + words[0]); }
            }
            else if (c[0] < a[0] & c[0] < b[0])
            {
                if (a[0] < b[0])
                    Console.WriteLine(words[2] + "\t" + words[0] + "\t" + words[1]);
                else { Console.WriteLine(words[2] + "\t" + words[1] + "\t" + words[0]); }
            }

            /*b) список покупателей, у которых номер кредитной карточки 
            находится в заданном интервале.*/
            Console.WriteLine("Введите верх интервала(16 цифр): ");
            ulong j = ulong.Parse(Console.ReadLine());
            Console.WriteLine("Введите низ интервала(16 цифр): ");
            ulong t = ulong.Parse(Console.ReadLine());
            Console.WriteLine("Покупатель: ");
            foreach (var d in Customer)
            {
                if (d.number < j & d.number > t)
                    Console.WriteLine(d);
            }
        }

        public void GetInfo()
        {
            Console.WriteLine("___________________________________________________________________________________________________________________________________________________________");
            Console.WriteLine($"Id: {id} | Lastname: {lastname} | Firstname: {firstname} | Patronymic: {patronymic} | Address: {address} | Number of credit card: {number} | Balance: {balance} | City: {city}");
            Console.WriteLine("___________________________________________________________________________________________________________________________________________________________");
            //id = 5;
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            Customer Sam = new Customer(1, "John", "Sam", "Tom", "Stret 3", 74789372897736777, 5020);
            Customer Tom = new Customer(2);
            Tom.Number = 6748585;
            ulong number = Tom.Number;
            Customer Kris = new Customer(3, "Shkoda", "Kristina", "Mihailovna");
            int y;
            Sam.Crediting(out y);
            Sam.GetInfo();
            Tom.GetInfo();
            int x = 3948;
            Kris.Debiting(ref x);
            Kris.GetInfo();
            Kris.GetHashCode();
            Tom.GetHashCode();
            Console.WriteLine(Tom.ToString());
            bool r = Tom.Equals(Sam);
            bool rr = Tom.Equals(Tom);
            Console.WriteLine($"Tom-Sam: {r}\tTom-Tom: {rr}");
            Console.WriteLine($"Количество: {Customer.count}");
            Customer.Array();
            //анонимный тип
            var user = new { lastname = "Dorofeeva", name = "Diana" };
            Console.WriteLine(user.lastname);
        }
    }
}