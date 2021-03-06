﻿using PKDSS.MonoApp.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PKDSS.Tools;
using System.Net.Sockets;
using System.Threading;
using Grpc.Core;
using System.Configuration;

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

            Logs.WriteAppLog("Application run....");
            AppConstants.DeviceID = ConfigurationManager.AppSettings["DeviceID"];
            AppConstants.AddItemUrl = ConfigurationManager.AppSettings["AddServiceUrl"];

            var main_form = new EntryFrm();
            main_form.Show();

            Application.Run();
        }
    }
}
