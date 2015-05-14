using System;
using System.IO;

namespace NetMentoring
{
    public class MemoryStreamLogger : IDisposable
    {
        private FileStream memoryStream;
        private StreamWriter streamWriter;

        public MemoryStreamLogger()
        {
            string dir = AppDomain.CurrentDomain.BaseDirectory;
            memoryStream = new FileStream(dir + @"\log.txt", FileMode.OpenOrCreate);
            streamWriter = new StreamWriter(memoryStream);
        }

        public void Log(string message)
        {
            streamWriter.WriteLine(message);
        }

        #region IDisposable interface implementation

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing) //call from user code
                {                    
                    if (streamWriter != null)
                        streamWriter.Dispose();
                    if(memoryStream != null)
                        memoryStream.Dispose();

                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}