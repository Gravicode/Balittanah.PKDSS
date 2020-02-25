using Newtonsoft.Json;
using PKDSS.CoreLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PKDSS.MonoApp.Helper
{
    public class CloudService
    {
        static HttpClient client;

        public CloudService()
        {
            if (client == null) client = new HttpClient();
        }
        static bool IsInternetAvailable()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                return (reply.Status == IPStatus.Success);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> PushDataToServer(SensorData data)
        {
            if (!IsInternetAvailable()) return false;
            var resp = await client.PostAsync(AppConstants.AddItemUrl, new StringContent(JsonConvert.SerializeObject(new List<SensorData>() { data }), Encoding.UTF8, "application/json"));
            if (resp.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
