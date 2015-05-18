using System;

namespace Convestudo.Unmanaged
{
    class Program
    {
        private static void Main(string[] args)
        {
            using(var fileWriter = new FileWriter("log.txt"))
                fileWriter.Write("First test string");

            Console.ReadKey();
        }
    }
}
