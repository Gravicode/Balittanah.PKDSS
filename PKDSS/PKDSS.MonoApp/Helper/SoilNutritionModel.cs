using Newtonsoft.Json;
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
        const string BASE_PYTHON = @"C:\Program Files (x86)\Microsoft Visual Studio\Shared\Python36_64\python.exe";
        const string OUTPUT_MODEL_FILE = @"C:\jobs\BalitTanah\PythonScript\PythonNIR\output.json";
        readonly string CMD = ConfigurationManager.AppSettings["PythonSript"];
        public string InferenceModel(string FileCSV)
        {
            try
            {
                var args = $"{FileCSV}";
                Console.WriteLine(args);
                ProcessStartInfo start = new ProcessStartInfo();
                start.FileName = BASE_PYTHON;//"python";
                start.Arguments = string.Format("{0} {1}", CMD, args);
                start.UseShellExecute = false;
                start.CreateNoWindow = true;
                start.RedirectStandardOutput = true;
                start.RedirectStandardError = true;
                using (Process process = Process.Start(start))
                {
                    using (StreamReader reader = process.StandardOutput)
                    {
                        string result = reader.ReadToEnd();
                        Console.Write(result);
                        return result;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Execute python failed:"+ex.Message);
            }
            return "";
        }
        public ModelOutput GetOutputData(string PathFile =OUTPUT_MODEL_FILE)
        {
            if (File.Exists(PathFile))
            {
                var strModel = File.ReadAllText(PathFile);
                var OutputModelData = JsonConvert.DeserializeObject<ModelOutput>(strModel);
                File.Delete(PathFile);
                return OutputModelData;
            }else
                Console.WriteLine("File output is not found.");
            return null;
        }


    }
}
