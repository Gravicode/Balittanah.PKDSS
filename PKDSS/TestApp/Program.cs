using Newtonsoft.Json;
using PKDSS.CoreLibrary;
using PKDSS.CoreLibrary.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
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
}
