using System;
using System.Collections.Generic;
using System.Text;

namespace PKDSS.CoreLibrary.Model
{
    public class SensorData:UnsurModel
    {
        public string DeviceID { get; set; }
    
        public string Komoditas { get; set; }
        public double NPK15 { get; set; }
        public double Urea15 { get; set; }
        public double Urea { get; set; }
        public double SP36 { get; set; }
        public double KCL { get; set; }
        public string Kabupaten { get; set; }
        public string Propinsi { get; set; }
        public string Desa { get; set; }
        public string Kecamatan { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
      
    }
}
