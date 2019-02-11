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

namespace PKDSS.MonoApp.Helper
{
    public class SoilNutritionModel
    {
        //const string BASE_PYTHON = @"C:\installdir\Python\Python37\python.exe";
        //const string OUTPUT_MODEL_FILE = @"C:\BalitTanah\PythonScript\PythonNIR\output.json";
        //readonly string CMD = ConfigurationManager.AppSettings["PythonSript"];
        //public string InferenceModel(string FileCSV)
        //{
        //    try
        //    {
        //        var args = $"{FileCSV}";
        //        Console.WriteLine(args);
        //        ProcessStartInfo start = new ProcessStartInfo();
        //        start.FileName = BASE_PYTHON;//"python";
        //        start.Arguments = string.Format("{0} {1}", CMD, args);
        //        start.UseShellExecute = false;
        //        start.CreateNoWindow = true;
        //        start.RedirectStandardOutput = true;
        //        start.RedirectStandardError = true;
        //        using (Process process = Process.Start(start))
        //        {
        //            using (StreamReader reader = process.StandardOutput)
        //            {
        //                string result = reader.ReadToEnd();
        //                Console.Write(result);
        //                return result;
        //            }
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        Console.WriteLine("Execute python failed:"+ex.Message);
        //    }
        //    return "";
        //}

        public void InferenceModel()
        {
            var DataRekomendasi = ConfigurationManager.AppSettings["DataRekomendasi"];
            var WorkingDirectory = ConfigurationManager.AppSettings["WorkingDirectory"];
            var ModelScript = ConfigurationManager.AppSettings["ModelScript"];
            var SensorData = ConfigurationManager.AppSettings["SensorData"];
            var AnacondaFolder = ConfigurationManager.AppSettings["AnacondaFolder"];

            ModelRunner ml = new ModelRunner(WorkingDirectory, ModelScript, SensorData, AnacondaFolder);

            var hasil = ml.InferenceModel(false, true);
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

        //public ModelOutput GetOutputData(string PathFile = OUTPUT_MODEL_FILE)
        //{
        //    if (File.Exists(PathFile))
        //    {
        //        var strModel = File.ReadAllText(PathFile);
        //        var OutputModelData = JsonConvert.DeserializeObject<ModelOutput>(strModel);
        //        File.Delete(PathFile);
        //        return OutputModelData;
        //    }else
        //        Console.WriteLine("File output is not found.");
        //    return null;
        //}


    }
}
