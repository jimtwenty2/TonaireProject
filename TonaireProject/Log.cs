using System;
using System.IO;

namespace TonaireProject
{


    public static class Log
    {
        
        private static string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", "errors.txt");

        public static void LogError(Exception ex)
        {
           
                // Ensure the folder exists
                Directory.CreateDirectory(Path.GetDirectoryName(logFilePath)!);

                // Append error message with timestamp
                File.AppendAllText(logFilePath, $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {ex.Message}\n{ex.StackTrace}\n\n");
            
        }
    }
}

