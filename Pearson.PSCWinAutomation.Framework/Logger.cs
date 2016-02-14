using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace Pearson.PSCWinAutomation.Framework
{
    public static class Logger
    {
        public static string filePath;
        public static StreamWriter streamWriter;
        public static string fullFilePath;
        public static string fullFolderPath;

        public static string CreateLogsFolder(string filePath)
        {
            fullFolderPath = filePath + "2-12_" + DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH'_'mm'_'ss")+"//";
            Directory.CreateDirectory(fullFolderPath);
            return fullFolderPath;
        }    
        public static void CreateLogFile(string filePath)
        {
            fullFilePath = filePath + "2-12_" + DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH'_'mm'_'ss") + ".txt";
            
            if(!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            
            using(StreamWriter streamWriter = File.CreateText(fullFilePath))
            {
                streamWriter.WriteLine("************************************STARTING TEST EXECUTION***********************************");
            }
        }
        public static void InsertLineSeparator()
        {
            using (StreamWriter streamWriter = new StreamWriter(fullFilePath, true))
            {
                streamWriter.WriteLine("**********************************************************************************************");
            }
        }

        public static void InsertTestHeaderLine(string testHeaderText)
        {
            using (StreamWriter streamWriter = new StreamWriter(fullFilePath, true))
            {
                streamWriter.WriteLine("**********************************************************************************************");
                streamWriter.WriteLine(DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH'_'mm'_'ss") + ": Starting test execution "+testHeaderText);
            }
        }

        public static void InsertLogLine(string logText)
        {
            using (StreamWriter streamWriter = new StreamWriter(fullFilePath, true))
            {
                streamWriter.WriteLine(DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH'_'mm'_'ss") + ": " + logText);
            }
        }

        public static void InsertTestEndLine(string endText)
        {
            using (StreamWriter streamWriter = new StreamWriter(fullFilePath, true))
            {
                streamWriter.WriteLine(DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH'_'mm'_'ss") + ": Completed test execution " + endText);
                streamWriter.WriteLine("**********************************************************************************************");
            }
        }

        public static void InsertExceptionMessage(string message)
        {
            using (StreamWriter streamWriter = new StreamWriter(fullFilePath, true))
            {
                streamWriter.WriteLine(DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH'_'mm'_'ss") + ": Test Failed with Exception " + message);
            }
        }

        public static void InsertEndLine()
        {
            using (StreamWriter streamWriter = new StreamWriter(fullFilePath, true))
            {
                streamWriter.WriteLine("************************************ENDING TEST EXECUTION***********************************");
            }
        }
        public static string CreateScreenshot(Bitmap image)
        {
            string screenshotFilePath =fullFolderPath + "2-12_" + DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH'_'mm'_'ss") + ".jpeg";
            image.Save(screenshotFilePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            using (StreamWriter streamWriter = new StreamWriter(fullFilePath, true))
            {
                streamWriter.WriteLine(DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH'_'mm'_'ss") + ": Created a screenshot with the file path: " + screenshotFilePath);
            }
            return screenshotFilePath;
        }
    }
}
