using System;
using System.IO;

namespace PriceBookClassLibrary
{
    public class General
    {
        public static void LogError(Exception exception)
        {
            string filePath = @"C:\Debugging\PriceBookApplicationErrorLog.txt";

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("-----------------------------------------------------------------------------");
                writer.WriteLine("Date : " + DateTime.Now.ToString());
                writer.WriteLine();

                while (exception != null)
                {
                    writer.WriteLine(exception.GetType().FullName);
                    writer.WriteLine("Message : " + exception.Message);
                    writer.WriteLine("StackTrace : " + exception.StackTrace);

                    exception = exception.InnerException;
                }
            }
        }
    }
}
