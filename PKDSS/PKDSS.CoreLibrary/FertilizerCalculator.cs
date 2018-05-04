using Newtonsoft.Json;
using PKDSS.CoreLibrary.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
namespace PKDSS.CoreLibrary
{
    public class FertilizerCalculator
    {
        public List<FertilizerData> Datas { get; set; }
        public FertilizerCalculator()
        {
            if(Datas == null)
            {
                Datas = JsonConvert.DeserializeObject<List<FertilizerData>>(Resources.Data);
            }
        }

        public double GetFertilizerDoze(double Unsur, string Tanaman="Padi", string Pupuk="Urea")
        {
            var selConstant = from x in Datas
                              where x.Pupuk == Pupuk && x.Tanaman == Tanaman
                              select x;
            if(selConstant!=null && selConstant.Count() > 0)
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
