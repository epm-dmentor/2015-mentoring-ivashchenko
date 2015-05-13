using System.IO;

namespace NetMentoring
{
    public class MemoryStreamLogger
    {
        private FileStream memoryStream;
        private StreamWriter streamWriter;

        public MemoryStreamLogger()
        {
            memoryStream = new FileStream(@"\log.txt", FileMode.OpenOrCreate);
            streamWriter = new StreamWriter(memoryStream);
        }

        public void Log(string message)
        {
            streamWriter.Write(message);
        }

   }
}