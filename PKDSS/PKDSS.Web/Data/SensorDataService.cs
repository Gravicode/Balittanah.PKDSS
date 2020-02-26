using PKDSS.Web.Helpers;
using PKDSS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PKDSS.Web.Data
{
    public class SensorDataService
    {
        PKDSSSDb context;
        public SensorDataService(PKDSSSDb db)
        {
            context = db;
        }
        public Task<List<SensorData>> GetAllData()
        {
            var datas = context.SensorDatas.ToList();
            for(int i=0;i<datas.Count;i++)
            {
                var item = datas[i];
                if((double.IsNaN(item.Latitude) && double.IsNaN(item.Longitude)) || (item.Latitude==0 && item.Longitude==0))
                {
                    if (!string.IsNullOrEmpty(item.Kecamatan) && !string.IsNullOrEmpty(item.Propinsi))
                    {
                        var loc = GeoHelpers.GetLocationFromAddress($"{item.Kecamatan}, {item.Propinsi}");
                        item.Latitude = loc.lat;
                        item.Longitude = loc.lon;
                    }
                }
            }
            return Task.FromResult(datas);
        }
    }
}
