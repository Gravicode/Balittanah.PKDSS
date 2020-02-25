using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PKDSS.CoreLibrary;
using PKDSS.CoreLibrary.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsInternetAvailable());
            //TestApi();
            //GpsDevice2 gps = new GpsDevice2("COM5");
            //gps.StartGPS();
           
            Console.ReadKey();
            return;
            var DataRekomendasi = ConfigurationManager.AppSettings["DataRekomendasi"];
            var WorkingDirectory = ConfigurationManager.AppSettings["WorkingDirectory"];
            var ModelScript = ConfigurationManager.AppSettings["ModelScript"];
            var SensorData = ConfigurationManager.AppSettings["SensorData"];
            var AnacondaFolder = ConfigurationManager.AppSettings["AnacondaFolder"];

            ModelRunner ml = new ModelRunner(WorkingDirectory, ModelScript, SensorData, AnacondaFolder);
          
            var hasil = ml.InferenceModel();
            if (hasil.IsSucceed)
            {
                try
                {

                    Console.WriteLine("start recommendation procecss");
                    var calc = new FertilizerCalculator(DataRekomendasi);
                    var TxtUrea = calc.GetFertilizerDoze(hasil.Result.C_N, "Padi", "Urea").ToString();
                    var TxtSP36 = calc.GetFertilizerDoze(hasil.Result.HCl25_P2O5, "Padi", "SP36").ToString();
                    var TxtKCL = calc.GetFertilizerDoze(hasil.Result.HCl25_K2O, "Padi", "KCL").ToString();
                    Console.WriteLine($"Rekomendasi KCL : {TxtKCL}, SP36 : {TxtSP36}, Urea : {TxtUrea}");



                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            Console.ReadLine();
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
        static async void TestApi()
        {
            const string URLAuth = "https://pkdssweb.azurewebsites.net/Users/authenticate";
            const string AddItem = "https://pkdssweb.azurewebsites.net/api/Sensor/PushSensorData";
            const string GetAllData = "https://pkdssweb.azurewebsites.net/api/Sensor/GetAllData";
                var Token = "";
                var client = new HttpClient();
                //get token bearer with api key
                Console.WriteLine("--get token from api--");
                var resp = await client.PostAsync(URLAuth, new StringContent("{\"apiKey\": \"123qweasd\"}", Encoding.UTF8, "application/json"));
                if (resp.IsSuccessStatusCode)
                {
                    Token = JsonConvert.DeserializeObject<User>(await resp.Content.ReadAsStringAsync()).Token;
                    Console.WriteLine($"Token from api : {Token}");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
                }
                //if (!string.IsNullOrEmpty(Token))
                {
                Random rnd = new Random();

                    //update quota
                    Console.WriteLine("--add data");
                    resp = await client.PostAsync(AddItem, new StringContent(JsonConvert.SerializeObject(new List<SensorData>() { new SensorData() { 
                     DeviceID="SSK001", CreatedDate=DateTime.Now, Bray1_P2O5 = rnd.Next(), Ca= rnd.Next(), CLAY= rnd.Next(), C_N= rnd.Next(), Desa="...",
                      HCl25_K2O= rnd.Next(), HCl25_P2O5= rnd.Next(), Jumlah= rnd.Next(), K= rnd.Next(), Kabupaten="...", KB_adjusted= rnd.Next(), KCL= rnd.Next(),
                       Kecamatan="...", KJELDAHL_N= rnd.Next(), Komoditas="Padi", KTK= rnd.Next(), Latitude= rnd.Next(), Longitude= rnd.Next(),
                        Mg= rnd.Next(), Morgan_K2O= rnd.Next(), Na= rnd.Next(), NPK15= rnd.Next(), Olsen_P2O5= rnd.Next(), PH_H2O= rnd.Next(),
                         PH_KCL= rnd.Next(), Propinsi="...", RetensiP= rnd.Next(), SAND= rnd.Next(), SILT= rnd.Next(), SP36= rnd.Next(), Urea= rnd.Next(),
                          Urea15= rnd.Next(), WBC= rnd.Next()
                    } }), Encoding.UTF8, "application/json"));
                    if (resp.IsSuccessStatusCode)
                    {
                        Console.WriteLine("client with id 1 is updated with 11 quota");
                    }
                    else
                    {
                        Console.WriteLine("fail to update quota");
                    }


                    //get all client

                    Console.WriteLine("--Get all users--");
                    resp = await client.GetAsync(GetAllData);
                    if (resp.IsSuccessStatusCode)
                    {
                        var data = JsonConvert.DeserializeObject<OutputData>(await resp.Content.ReadAsStringAsync());
                        var users = ((JArray)data.Data).ToObject<List<SensorData>>();
                        foreach (var usr in users)
                        {
                            Console.WriteLine($"devid: {usr.DeviceID} - created: {usr.CreatedDate}");
                        }
                    }
                }
                Console.WriteLine("finished.");
                Console.ReadLine();
            }
    
        /*
   static void Main(string[] args)
{
   Stopwatch sw = new Stopwatch();
   Console.WriteLine("start python...");
   sw.Start();
   try
   {
       var ListCmd = new List<string>(new string[] { "cd C:\\Users\\LattePanda\\Documents\\BalitTanah\\PythonScript\\PythonNIR", "python PLSRmodelv2a.py Measurement_Perc_1.Spectrum" });
       var Arg = "/K C:\\ProgramData\\Anaconda3\\Scripts\\activate.bat C:\\ProgramData\\Anaconda3";
       var WD = "C:\\Users\\LattePanda\\Documents\\BalitTanah\\PythonScript\\PythonNIR";
       RunCommands(ListCmd, Arg, WD);
   }
   catch (Exception ex)
   {
       Console.WriteLine(ex);
   }
   sw.Stop();
   Console.WriteLine("model inference proces is completed...");
   Console.WriteLine($"total time for model execution: {sw.ElapsedMilliseconds} ms");
   Console.WriteLine("try to read output...");
   var PathToOutput = "C:\\Users\\LattePanda\\Documents\\BalitTanah\\PythonScript\\PythonNIR\\output.json";
   if (File.Exists(PathToOutput))
   {
       var InferenceData = File.ReadAllText(PathToOutput);
       Console.WriteLine("hasil inference model:");
       Console.WriteLine(InferenceData);
       File.Delete(PathToOutput);
   }
   else
   {
       Console.WriteLine("output tidak ditemukan, kegagalan eksekusi model");
   }

   Console.WriteLine("end program...");
}

static void RunCommands(List<string> cmds, string CmdArg = "", string workingDirectory = "")
{
   var process = new Process();
   var psi = new ProcessStartInfo();
   psi.FileName = "cmd.exe";
   psi.RedirectStandardInput = true;
   psi.RedirectStandardOutput = true;
   psi.RedirectStandardError = true;
   psi.UseShellExecute = false;
   psi.WorkingDirectory = workingDirectory;
   psi.Arguments = CmdArg;
   process.StartInfo = psi;
   process.Start();
   process.OutputDataReceived += (sender, e) => { Console.WriteLine(e.Data); };
   process.ErrorDataReceived += (sender, e) => { Console.WriteLine(e.Data); };
   process.BeginOutputReadLine();
   process.BeginErrorReadLine();
   using (StreamWriter sw = process.StandardInput)
   {
       foreach (var cmd in cmds)
       {
           sw.WriteLine(cmd);
       }
   }
   process.WaitForExit();
}*/
    }
    public class OutputData
    {
        public bool IsSucceed { set; get; }
        public object Data { set; get; }
        public string ErrorMessage { set; get; }
    }
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
    
}
