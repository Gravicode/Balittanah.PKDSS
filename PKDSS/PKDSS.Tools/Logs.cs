using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PKDSS.Tools
{
    class Logs
    {
        #region Path
        public static string getPath()
        {
            String Pth = Directory.GetCurrentDirectory();
            return Pth;
        }
        #endregion

        #region App Logs
        public static void WriteAppLog(string StrMessage)
        {
            string Filename = null;
            string Dirs = null;
            string path = getPath();
            Filename = "APPLOG-" + DateTime.Now.ToString("dd-MMM-yyyy") + ".log";
            Dirs = @"\Logs\";
            DirectoryInfo drInfo = new DirectoryInfo(path + Dirs);
            if (!drInfo.Exists)
            {
                drInfo.Create();
            }
            Filename = path + Dirs + Filename;
            StrMessage = $"{DateTime.Now.ToString("dd/MMM/yyyy HH:mm:ss")} -> {StrMessage}";
            if (File.Exists(Filename))
            {
                FileWriter.AppendToFile(StrMessage, Filename);
            }
            else
            {
                FileWriter.WriteFile(StrMessage, Filename);
            }
            drInfo.Refresh();
        }

        public static void RemoveAppLog()
        {
            string Filename = null;
            string Dirs = null;
            string path = getPath();

            Filename = "APPLOG-" + DateTime.Now.ToString("dd-MMM-yyyy") + ".log";
            Dirs = "\\Logs\\";

            DirectoryInfo drInfo = new DirectoryInfo(path + Dirs);
            if (!drInfo.Exists)
            {
                return;
            }
            FileInfo[] AllFiles = drInfo.GetFiles();
            Filename = path + Dirs + Filename;
            foreach (FileInfo MyLogFile in AllFiles)
            {
                if (MyLogFile.FullName.ToLower() != Filename.ToLower())
                {
                    MyLogFile.Delete();
                }
            }
        }
        #endregion

        #region App Logs
        public static void WriteLog(string StrMessage)
        {
            string Filename = null;
            string Dirs = null;
            string path = getPath();
            Filename = "LOG-" + DateTime.Now.ToString("dd-MMM-yyyy") + ".log";
            Dirs = @"\Logs\";
            DirectoryInfo drInfo = new DirectoryInfo(path + Dirs);
            if (!drInfo.Exists)
            {
                drInfo.Create();
            }
            Filename = path + Dirs + Filename;
            StrMessage = $"{DateTime.Now.ToString("dd/MMM/yyyy HH:mm:ss")} -> {StrMessage}";
            if (File.Exists(Filename))
            {
                FileWriter.AppendToFile(StrMessage, Filename);
            }
            else
            {
                FileWriter.WriteFile(StrMessage, Filename);
            }
            drInfo.Refresh();
        }
        public static void RemoveLog()
        {
            string Filename = null;
            string Dirs = null;
            string path = getPath();

            Filename = "LOG-" + DateTime.Now.ToString("dd-MMM-yyyy") + ".log";
            Dirs = "\\Logs\\";

            DirectoryInfo drInfo = new DirectoryInfo(path + Dirs);
            if (!drInfo.Exists)
            {
                return;
            }
            FileInfo[] AllFiles = drInfo.GetFiles();
            Filename = path + Dirs + Filename;
            foreach (FileInfo MyLogFile in AllFiles)
            {
                if (MyLogFile.FullName.ToLower() != Filename.ToLower())
                {
                    MyLogFile.Delete();
                }
            }
        }
        #endregion
    }
}
