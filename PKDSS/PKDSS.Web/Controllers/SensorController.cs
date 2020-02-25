using Microsoft.AspNetCore.Mvc;
using PKDSS.Web.Data;
using PKDSS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PKDSS.Web.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    //[Authorize]
    public class SensorController : ControllerBase
    {
        private readonly PKDSSSDb _context;

        public SensorController(PKDSSSDb context)
        {
            _context = context;
           
        }



        /// <summary>
        /// get all data sensor
        /// </summary>
    
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllData()
        {

            await _context.Database.EnsureCreatedAsync();
            var hasil = new OutputData() { IsSucceed = true };
            try
            {
                var datas = from x in _context.SensorDatas
                            select x;
                hasil.Data = datas.ToList();
            }
            catch (Exception ex)
            {
                hasil.IsSucceed = false;
                hasil.ErrorMessage = ex.Message;
            }
            return Ok(hasil);
        }

        /// <summary>
        /// Push data sensor from device to cloud
        /// </summary>
        /// <param name="ListData"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<IActionResult> PushSensorData([FromBody]List<SensorData> ListData)
        {
            var hasil = new OutputData() { IsSucceed = true };
            try
            {
                //HashSet<string> TransactionIDS = new HashSet<string>();
                foreach (var item in ListData)
                {
                    _context.SensorDatas.Add(item);
                    
                }
               

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                hasil.IsSucceed = false;
                hasil.ErrorMessage = ex.Message;
            }
            return Ok(hasil);
        }

    }
}
