using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKDSS.MonoApp.Helper
{
    public class AppConstants
    {
        public static string DeviceID { get; set; }

        public static string AddItemUrl { set; get; } = "https://pkdssweb.azurewebsites.net/api/Sensor/PushSensorData";
        public static string GetAllData { set; get; } = "https://pkdssweb.azurewebsites.net/api/Sensor/GetAllData";
    }
}
