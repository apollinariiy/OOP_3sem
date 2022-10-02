using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab3
{
    class Owner
    {
        public int id;
        public string name;
        public string organization;
        public Owner(int id, string name, string organization)
        {
            this.id = id;
            this.name = name;
            this.organization = organization;
        }
        public void Show()
        {
            Console.WriteLine("ID: " + id);
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Organization: " + organization);
        }
    }
}
