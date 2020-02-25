using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PKDSS.Web.Models
{
    public class SensorData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string DeviceID { get; set; }
        public double Bray1_P2O5 { get; set; }
        public double Ca { get; set; }
        public double CLAY { get; set; }
        public double C_N { get; set; }
        public double HCl25_K2O { get; set; }
        public double HCl25_P2O5 { get; set; }
        public double Jumlah { get; set; }
        public double K { get; set; }
        public double KB_adjusted { get; set; }
        public double KJELDAHL_N { get; set; }
        public double KTK { get; set; }
        public double Mg { get; set; }
        public double Morgan_K2O { get; set; }
        public double Na { get; set; }
        public double Olsen_P2O5 { get; set; }
        public double PH_H2O { get; set; }
        public double PH_KCL { get; set; }
        public double RetensiP { get; set; }
        public double SAND { get; set; }
        public double SILT { get; set; }
        public double WBC { get; set; }
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
        public DateTime CreatedDate { get; set; }
    }
}
