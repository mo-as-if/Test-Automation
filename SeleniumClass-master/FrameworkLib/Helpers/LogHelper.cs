using System;
using System.IO;

namespace FrameworkLib.Helpers
{
    public class LogHelper
    {
        //log file name (Global Declaration)
      
        private static StreamWriter _streamWriter = null;
        public static void CreateTestRunLog()
        {
            string _logFileName = String.Format($"TestRunLog{0:yyyymmdd}", DateTime.Now);
            string LogPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\Desktop\AutomationQATestReport\TestRunLog\";

            try
            {
                if (Directory.Exists(LogPath))
                {
                    _streamWriter = File.AppendText($"{LogPath}{_logFileName}-{Guid.NewGuid().ToString()}.log");
                }
                else
                {
                    Directory.CreateDirectory(LogPath);
                    _streamWriter= File.AppendText($"{LogPath}{_logFileName}-{Guid.NewGuid().ToString()}.log");
                }
            }
            catch (IOException e)
            {
                if (e.Source != null) Console.WriteLine("IOException source: {0}", e.Source);
                throw;
            }
        }

        //method which will write the text in the log file
        public static void Write(string LogMessage)
        {
            if(_streamWriter is null)
            {
                CreateTestRunLog();
            }
            _streamWriter.Write("{0} {1}", DateTime.Now.ToLongDateString(),
             DateTime.Now.ToLongDateString());
            _streamWriter.WriteLine(" {0}", LogMessage);
            _streamWriter.Flush();
                
               
        }

    }
}
