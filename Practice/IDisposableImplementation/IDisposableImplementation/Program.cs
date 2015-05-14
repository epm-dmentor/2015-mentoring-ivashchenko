using System;

namespace NetMentoring
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var logger = new MemoryStreamLogger())
                for(var i = 0; i < 10000; i++)
                    WriteLog(logger, "Interation number #" + i);

            Console.WriteLine("Finished");
            Console.ReadKey();
        }

        private static void WriteLog(MemoryStreamLogger logger, string str)
        {
//          var logger = new MemoryStreamLogger();
            logger.Log(str);
        }
    }
}
