using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab17
{
    class Program
    {
      
        static void Main(string[] args)
        {
            //BIULDER

            Student Student = new Student();

            BiologyBuilder builder = new BiologyBuilder();

            Faculty ryeFaculty = Student.Facult(builder);
            Console.WriteLine(ryeFaculty.ToString());
            
            MathBuilder builder1 = new MathBuilder();
            Faculty wheatFaculty = Student.Facult(builder1);
            Console.WriteLine(wheatFaculty.ToString());

            //abstract factory
            Console.WriteLine();
            Leaver lever1 = new Leaver(new BioFactory()); //биология
            lever1.Enrol_course();
            lever1.passing_score();
            
            Leaver lever2 = new Leaver(new MathFactory());
            lever2.Enrol_course();
            lever2.passing_score();
            
            //Singleton
            Console.WriteLine();
            Abitur abitur = new Abitur();
            abitur.FIO("Glushenya Polina Andreevna");
            Console.WriteLine(abitur.Inform.Name);
    
            Console.WriteLine();
            InfAdmin name1 = new InfAdmin("Сергей", "Серегеевич");
            // применяем глубокое копирование
            InfAdmin name2 = name1.DeepCopy() as InfAdmin;
            name1.FioAdmin.Name = "Федор";
            name1.GetInfo();
            name2.GetInfo();

            Console.WriteLine();
            //Adapter
            // абитуриент
            Abiturient abiturient = new Abiturient();
            // химия
            Chemistry lesson1 = new Chemistry();
            // изучаем химию
            abiturient.State(lesson1);
            // встретилась география 
            Geography lesson2 = new Geography();
            // используем адаптер
            InewLesson Lessongeography = new GeographyTonewCourseAdapter(lesson2);
            // продолжаем с географией
            abiturient.State(Lessongeography);

            Console.WriteLine();
            //Decorator
            Speciality speciality1 = new Technical();
            speciality1 = new Humanitarian(speciality1); 
            Console.WriteLine("Название предметов: {0}", speciality1.Name);
            Console.WriteLine("Проходной балл: {0}", speciality1.GetScore());

            Speciality speciality2 = new Technical();
            speciality2 = new Bio(speciality2);
            Console.WriteLine("Название предметов: {0}", speciality2.Name);
            Console.WriteLine("Проходной балл: {0}", speciality2.GetScore());

            Speciality speciality3 = new Ecomonic();
            speciality3 = new Humanitarian(speciality3);
            speciality3 = new Bio(speciality3);
            Console.WriteLine("Название предметов: {0}", speciality3.Name);
            Console.WriteLine("Проходной балл: {0}", speciality3.GetScore());
            
            Console.WriteLine();

            //Command
            InfFacult pult = new InfFacult();
            Info inf = new Info();
            pult.SetCommand(new InfoOnCommand(inf));
            pult.EnrollInfo();
            pult.FailedInfo();

            Console.WriteLine();

            //Memento
            Graduate graduate = new Graduate();
            graduate.GetLabs();
            LabsHistory labs = new LabsHistory();     
            labs.History.Push(graduate.SaveState());      
            graduate.GetLabs(); 
            graduate.RestoreState(labs.History.Pop());
            graduate.GetLabs(); 
            
            Console.WriteLine();
            //Strategy
            Study stud = new Study("Saturday", new NeedStudy());
            stud.Need();
            stud.Studing = new DontNeedStudy();
            stud.Need();

        }
    }
    
  
}