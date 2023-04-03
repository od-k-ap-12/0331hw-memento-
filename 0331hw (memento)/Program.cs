using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _0331hw__memento_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter new text: ");
            string Text=Console.ReadLine();
            TextEditor NewText = new TextEditor(Text);
            Caretaker Caretaker = new Caretaker(NewText);
            do
            {
                Console.WriteLine("1.Redo my text \n2.Undo my text \n3.Exit");
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        Caretaker.Backup();
                        Console.WriteLine("Enter new text: ");
                        NewText.Rewrite(Console.ReadLine());
                        break;
                    case '2':
                        Caretaker.Undo();
                        break;
                    case '3':
                        Console.WriteLine("Exit");
                        break;
                    default:
                        break;
                }
            }
            while (Console.ReadKey(true).KeyChar != '3');
        }
    }
}
