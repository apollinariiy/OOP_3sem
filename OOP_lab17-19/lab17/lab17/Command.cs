using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17
{
    interface ICommand
    {
        void Execute();
        void Undo();
    }

    // Receiver - Получатель
    class Info
    {
        public void Enrolled()
        {
            Console.WriteLine("Абитуриент поступил!");
        }

        public void Failed()
        {
            Console.WriteLine("Абитуриент не поступил...");
        }
    }

    class InfoOnCommand : ICommand
    {
        Info inf;
        public InfoOnCommand(Info infSet)
        {
            inf = infSet;
        }
        public void Execute()
        {
            inf.Enrolled();
        }
        public void Undo()
        {
            inf.Failed();
        }
    }

    // Invoker - инициатор
    class InfFacult
    {
        ICommand command;

        public InfFacult() { }

        public void SetCommand(ICommand com)
        {
            command = com;
        }

        public void EnrollInfo()
        {
            command.Execute();
        }
        public void FailedInfo()
        {
            command.Undo();
        }
    }
}
