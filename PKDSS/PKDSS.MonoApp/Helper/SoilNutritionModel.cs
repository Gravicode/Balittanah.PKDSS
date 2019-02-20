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
        public ModelOutput InferenceModel()
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
                    var Urea = calc.GetFertilizerDoze(hasil.Result.C_N, "Padi", "Urea").ToString();
                    var SP36 = calc.GetFertilizerDoze(hasil.Result.HCl25_P2O5, "Padi", "SP36").ToString();
                    var KCL = calc.GetFertilizerDoze(hasil.Result.HCl25_K2O, "Padi", "KCL").ToString();
                    Console.WriteLine($"Rekomendasi KCL : {KCL}, SP36 : {SP36}, Urea : {Urea}");

                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return hasil.Result;
            //Console.ReadLine();
        }


    }
}
