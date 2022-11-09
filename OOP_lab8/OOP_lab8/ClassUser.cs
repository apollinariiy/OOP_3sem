using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab8
{

    public delegate void Fine(string message);

    public delegate void Increase(string message);

    class Director {
        public int salary;
        public string post;
        public Director(string pos, int sal)
        {
            salary = sal;
            post = pos;
        }

        public event Increase increase;
        
        public void IncreaseSalary(int _salary)
        {
            salary += _salary;
            if (increase != null)
            {
                increase?.Invoke($"Зарплата повышена на {_salary} рублей для {post}");
            }
        }
        public event Fine fine;
        public void FineSalary(int _salary)
        {
            salary -= _salary;
            if (fine != null)
            {
                fine($"Штраф на {_salary} рублей для {post}");
            }
        }


      
        public override string ToString()
        {
            Console.WriteLine("Post: " + post + " Salary: " + salary);
            return "";
        }

    }
   
   
}
