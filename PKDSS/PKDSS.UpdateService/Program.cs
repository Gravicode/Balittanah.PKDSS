using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;
using PKDSS.Shared;
using Newtonsoft.Json.Linq;
using System.IO.Compression;
using System.Diagnostics;

namespace PKDSS.UpdateService
{
    class Program
    {
        public static IConfigurationRoot Configuration;
        public static string AppPath { get; set; }
        public static string ServiceUrl { get; set; }
        static HttpClient client;

        static int UpdateDelay=60*1000*60; //hourly

        const string HistoryFileName = "update-history.json";

        static string ExecuteableFile="PKDSS.MonoApp.exe";

        static UpdateInfo LatestUpdate;

        static List<UpdateInfo> ListHistory;

        static void Main(string[] args)
        {
            Console.WriteLine("Service is Started...");
            if (ReadConfig())
            {
               
                Task task1 = new Task(ServiceLoop);
                task1.Start();
            }
            Console.ReadKey();
        }
        public static string GetAbsolutePath(string relativePath)
        {
            //FileInfo _dataRoot = new FileInfo(this.GetType().Assembly.Location);
            string assemblyFolderPath = System.IO.Directory.GetCurrentDirectory();

            string fullPath = Path.Combine(assemblyFolderPath, relativePath);

            return fullPath;
        }
        static  void ReadUpdateHistory()
        {
           
            var filePath = GetAbsolutePath(HistoryFileName);
            if (!File.Exists(filePath))
            {
                ListHistory = new List<UpdateInfo>();
                var json = JsonConvert.SerializeObject(ListHistory);
                File.WriteAllText(filePath, json);

            }
            else
            {
                var json = File.ReadAllText(filePath);
                ListHistory = JsonConvert.DeserializeObject<List<UpdateInfo>>(json);
                LatestUpdate = ListHistory.OrderByDescending(x => x.ReleaseDate).FirstOrDefault();

            }
        }
        static void WriteUpdateHistory()
        {

            var filePath = GetAbsolutePath(HistoryFileName);

            var json = JsonConvert.SerializeObject(ListHistory);
            File.WriteAllText(filePath, json);

        }
        static async void ServiceLoop()
        {
            while (true)
            {
                try
                {
                    if (!IsInternetAvailable())
                        Console.WriteLine("no internet available for update..");
                    else
                    {
                        var resp = await client.GetAsync(ServiceUrl);
                        if (resp.IsSuccessStatusCode)
                        {
                            var data = JsonConvert.DeserializeObject<OutputData>(await resp.Content.ReadAsStringAsync());
                            var items = ((JArray)data.Data).ToObject<List<UpdateInfo>>();
                            var NewUpdate = items.OrderByDescending(x => x.ReleaseDate).FirstOrDefault();
                            if (LatestUpdate == null || LatestUpdate.ReleaseDate < NewUpdate.ReleaseDate)
                            {
                                Console.WriteLine($"Find new update => {NewUpdate.Description} / v{NewUpdate.Version} -> {NewUpdate.UrlFirmware}");
                                //close main app
                                KillProcess(ExecuteableFile);

                                Console.WriteLine("try to download new firmware");
                                //download file 
                                var file = await client.GetByteArrayAsync(NewUpdate.UrlFirmware);
                                var tmpZip = Path.GetTempFileName() + ".zip";
                                File.WriteAllBytes(tmpZip, file);
                                ZipFile.ExtractToDirectory(tmpZip, AppPath, true);

                                //run main app
                                var ExePath = $"{AppPath}\\{ExecuteableFile}";
                                if (File.Exists(ExePath))
                                {
                                    ExecuteApp(ExePath);
                                }

                                Console.WriteLine($"[{DateTime.Now}] -> New firmware has been updated successfully...");
                                LatestUpdate = NewUpdate;
                                ListHistory.Add(LatestUpdate);
                                //write history
                                WriteUpdateHistory();
                                Console.WriteLine("history list has been updated");
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"error when updating... {ex}");
                }
                Thread.Sleep(UpdateDelay);
            }
            

        }
        static void KillProcess(string AppExeName)
        {
            bool isKilled = false;
            var proc = Process.GetProcessesByName(AppExeName);
            if (proc.Length > 0)
            {
                proc[0].CloseMainWindow();
                Console.WriteLine("main app has been killed...");
            }else
                Console.WriteLine("main app is not running...");
            /*
            Process[] runningProcesses = Process.GetProcesses();
            foreach (Process process in runningProcesses)
            {
                // now check the modules of the process
                foreach (ProcessModule module in process.Modules)
                {
                    if (module.FileName.Equals(AppExeName))//MyProcess.exe"
                    {
                        process.Kill();
                        Console.WriteLine("main app has been killed...");
                        isKilled = true;
                    }
                    
                }
            }
            if(!isKilled)
                Console.WriteLine("main app is not running...");*/
        }
        static void ExecuteApp(string PathFile)
        {
           
            Process p = new Process();
            ProcessStartInfo pi = new ProcessStartInfo();
            pi.UseShellExecute = true;
            pi.FileName =PathFile;
            p.StartInfo = pi;

            try
            {
                p.Start();
                Console.WriteLine("main app has been executed..");
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Fail to execute main app:"+Ex.ToString());
            }
        }
        static bool ReadConfig()
        {
            try
            {
               
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Path.Combine(AppContext.BaseDirectory))
                    .AddJsonFile("appsettings.json", optional: true);
               
                //get config
                Configuration = builder.Build();
                AppPath = Configuration["AppPath"];
                ServiceUrl = Configuration["ServiceUrl"];
                UpdateDelay = int.Parse(Configuration["UpdateDelay"]);
                ReadUpdateHistory();
                if (client == null) client = new HttpClient();
                return true;
            }
            catch
            {
                Console.WriteLine("Read config is failed");
                return false;
            }
        }
        static bool IsInternetAvailable()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                return (reply.Status == IPStatus.Success);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
   
}
