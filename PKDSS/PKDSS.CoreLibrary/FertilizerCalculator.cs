using Newtonsoft.Json;
using PKDSS.CoreLibrary.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
namespace PKDSS.CoreLibrary
{
    public class FertilizerCalculator
    {
        bool IsReady = false;
        public string DataPath { get; set; }
        public List<FertilizerData> Datas { get; set; }
        public FertilizerCalculator()
        {
            if (Datas == null)
            {
                Datas = JsonConvert.DeserializeObject<List<FertilizerData>>(Resources.Data);
                IsReady = true;
            }
        }

        public FertilizerCalculator(string PathToData)
        {
            try
            {
                if (File.Exists(PathToData))
                {
                    this.DataPath = PathToData;
                    Datas = JsonConvert.DeserializeObject<List<FertilizerData>>(File.ReadAllText(PathToData));
                    IsReady = true;
                }
            }
            catch
            {
                IsReady = false;
            }
        }

        public double GetFertilizerDoze(double Unsur, string Tanaman = "Padi", string Pupuk = "Urea")
        {
            if (!IsReady) throw new Exception("Recommendation Data is not found.");

            var selConstant = from x in Datas
                              where x.Pupuk == Pupuk && x.Tanaman == Tanaman
                              select x;
            if (selConstant != null && selConstant.Count() > 0)
            {
                var Node = selConstant.SingleOrDefault();
                return (1 - Node.C1 * Unsur) / Node.C2;
            }
            return -1;
        }
    }

    public class FertilizerData
    {
        public int No { get; set; }
        public string Tanaman { get; set; }
        public double C1 { get; set; }
        public double C2 { get; set; }
        public string Pupuk { get; set; }
    }
}
