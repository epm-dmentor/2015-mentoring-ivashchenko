using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListIpl
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> lst = new LinkedList<int>();
            lst.AddHead(8);
            lst.AddTail(7);
            lst.AddTail(6);
            lst.AddTail(5);
            lst.AddTail(4);
            lst.AddHead(9);
//            lst.Print();
//            Console.WriteLine("Insert new element");
//            lst.InsertAt(2, 22);
//            lst.Print();
//            Console.WriteLine("Insert new element to head");
            lst.InsertAt(3, 10);
//            lst.Print();
//            Console.WriteLine("Insert new element to tail");
//            lst.InsertAt(7, 77);
            lst.Print(); 

            LinkedList<string> lstStr = new LinkedList<string>();
            lstStr.AddTail("Tail");
            lstStr.AddHead("Head");
            lstStr.InsertAt(1,"Middle");
            lstStr.Print();
            Console.WriteLine("\nRemove tail node....\n");
            lstStr.RemoveTail();
            lstStr.Print();
            Console.WriteLine("\nRemove head node....\n");
            lstStr.RemoveHead();
            lstStr.Print();
        }
    }
}
