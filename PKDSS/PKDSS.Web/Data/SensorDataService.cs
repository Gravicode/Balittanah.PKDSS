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
            return Task.FromResult(datas);
        }
    }
}
