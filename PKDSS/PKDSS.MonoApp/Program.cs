using PKDSS.MonoApp.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PKDSS.Tools;
using System.Net.Sockets;
using System.Threading;
using Grpc.Core;

namespace PKDSS.MonoApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //var ischecked = CheckChannel();

            //if (ischecked)
            //{
                Logs.WriteAppLog("Application run....");
                var main_form = new EntryFrm();
                main_form.Show();

                Application.Run();
            //}
        }

        static bool CheckChannel()
        {
            bool isloop = true;

            while(isloop)
            {
                Channel channel = new Channel("localhost:50051", ChannelCredentials.Insecure);
                var start = channel.ConnectAsync();
                start.Wait();
                if (start.Status == TaskStatus.RanToCompletion)
                {
                    isloop = false;
                    channel.ConnectAsync().Wait();
                    return true;
                }
                channel.ConnectAsync().Wait();
            }
            return false;
        }
    }
}
