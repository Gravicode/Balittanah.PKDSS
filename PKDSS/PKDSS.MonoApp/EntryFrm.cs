using Grpc.Core;
using PKDSS.CoreLibrary;
using PKDSS.CoreLibrary.Model;
using PKDSS.MonoApp.Helper;
using PKDSS.MonoApp.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using PKDSS.Tools;
using Newtonsoft.Json;
using GemBox.Spreadsheet;
using GemBox.Spreadsheet.WinFormsUtilities;
using Bunifu.Framework;

namespace PKDSS.MonoApp
{
    public partial class EntryFrm : Form
    {
        static CloudService cloud;
        static GpsDevice2 gps;
        Channel channel = new Channel("localhost:50051", ChannelCredentials.Insecure);
        string ComPort = string.Empty;
        //string DataRekomendasi = ConfigurationManager.AppSettings["DataRekomendasi"];
        Thread LoopCheckDevice;
        int statusProcess = 0;
        public static ModelOutput Data = new ModelOutput();
        HashSet<string> listOfControls;
        MessageBoxForm CustomMessageBox;
        List<OutputData> ReadDataSort = new List<OutputData>();
        FertilizerCalculator calc = new FertilizerCalculator();


        public EntryFrm()
        {
            // Gembox Serial Key
            string SpreadsheetKey = ConfigurationManager.AppSettings["GemboxSpreadsheetKey"];
            SpreadsheetInfo.SetLicense(SpreadsheetKey);

            InitializeComponent();
            Setup();

            //Looping check device is ready
            LoopCheckDevice = new Thread(RequestIsDeviceReady);
            LoopCheckDevice.Start();

            ReadConfig();
            Data = null;
            statusProcess = 1;
            CheckRefences();
            ClearText();
            ReadLog();
            pnlUser.Show();

            btnBackground.Enabled = false;
            btnProcess.Enabled = false;
            btnReset.Enabled = false;
            btnScan.Enabled = false;
            ComPort = ConfigurationManager.AppSettings["ComPort"];
            if (!string.IsNullOrEmpty(ComPort))
            {
                //Looping Gps
                gps = new GpsDevice2(ComPort);
                gps.PositionUpdate += (x) =>
                {
                    MethodInvoker method = delegate ()
                    {

                        txtX.Text = x.Longitude.ToString();
                        txtY.Text = x.Latitude.ToString();

                    };

                    if (this.InvokeRequired)
                    { this.Invoke(method); }
                    else
                    {
                        txtX.Text = x.Longitude.ToString();
                        txtY.Text = x.Latitude.ToString();
                    }

                };
                gps.StartGPS();

            }

            cloud = new CloudService();
            BtnSync.Click += async (a, b) =>
            {
                try
                {
                    if (Data != null)
                    {
                        var newData = new SensorData()
                        {
                            Bray1_P2O5 = Data.Bray1_P2O5 > 0 ? float.Parse(Data.Bray1_P2O5.ToString("n2")) : 0,
                            Ca = Data.Ca > 0 ? float.Parse(Data.Ca.ToString("n2")) : 0,
                            CLAY = Data.CLAY > 0 ? float.Parse(Data.CLAY.ToString("n2")) : 0,
                            C_N = Data.C_N > 0 ? float.Parse(Data.C_N.ToString("n2")) : 0,
                            HCl25_K2O = Data.HCl25_K2O > 0 ? float.Parse(Data.HCl25_K2O.ToString("n2")) : 0,
                            HCl25_P2O5 = Data.HCl25_P2O5 > 0 ? float.Parse(Data.HCl25_P2O5.ToString("n2")) : 0,
                            Jumlah = Data.Jumlah > 0 ? float.Parse(Data.Jumlah.ToString("n2")) : 0,
                            K = Data.K > 0 ? float.Parse(Data.K.ToString("n2")) : 0,
                            KB_adjusted = Data.KB_adjusted > 0 ? float.Parse(Data.KB_adjusted.ToString("n2")) : 0,
                            KJELDAHL_N = Data.KJELDAHL_N > 0 ? float.Parse(Data.KJELDAHL_N.ToString("n2")) : 0,
                            KTK = Data.KTK > 0 ? float.Parse(Data.KTK.ToString("n2")) : 0,
                            Mg = Data.Mg > 0 ? float.Parse(Data.Mg.ToString("n2")) : 0,
                            Morgan_K2O = Data.Morgan_K2O > 0 ? float.Parse(Data.Morgan_K2O.ToString("n2")) : 0,
                            Na = Data.Na > 0 ? float.Parse(Data.Na.ToString("n2")) : 0,
                            Olsen_P2O5 = Data.Olsen_P2O5 > 0 ? float.Parse(Data.Olsen_P2O5.ToString("n2")) : 0,
                            PH_H2O = Data.PH_H2O > 0 ? float.Parse(Data.PH_H2O.ToString("n2")) : 0,
                            PH_KCL = Data.PH_KCL > 0 ? float.Parse(Data.PH_KCL.ToString("n2")) : 0,
                            RetensiP = Data.RetensiP > 0 ? float.Parse(Data.RetensiP.ToString("n2")) : 0,
                            SAND = Data.SAND > 0 ? float.Parse(Data.SAND.ToString("n2")) : 0,
                            SILT = Data.SILT > 0 ? float.Parse(Data.SILT.ToString("n2")) : 0,
                            WBC = Data.WBC > 0 ? float.Parse(Data.WBC.ToString("n2")) : 0,
                            CreatedDate = DateTime.Now.Date,
                            Desa = txtDesa.Text,
                            DeviceID = AppConstants.DeviceID,
                            Kabupaten = cbKabupaten.Text,
                            Kecamatan = txtKecamatan.Text,
                            Komoditas = cbKomoditas.Text,
                            Latitude = string.IsNullOrEmpty(txtY.Text) ? 0 : double.Parse(txtY.Text),
                            Longitude = string.IsNullOrEmpty(txtX.Text) ? 0 : double.Parse(txtX.Text),
                            NPK15 = string.IsNullOrEmpty(txtNpk15.Text) ? 0 : float.Parse(txtNpk15.Text),
                            SP36 = string.IsNullOrEmpty(txtSP36.Text) ? 0 : float.Parse(txtSP36.Text),
                            Urea = string.IsNullOrEmpty(txtUrea.Text) ? 0 : float.Parse(txtUrea.Text),
                            Urea15 = string.IsNullOrEmpty(txtUrea15.Text) ? 0 : float.Parse(txtUrea15.Text),
                            Propinsi = cbProvinsi.Text,
                            KCL = string.IsNullOrEmpty(txtKCL.Text) ? 0 : float.Parse(txtKCL.Text)
                        };
                        var res = await cloud.PushDataToServer(newData);
                        if (res)
                        {
                            MessageBox.Show("Sync data berhasil", "Info");
                        }
                        else
                        {
                            MessageBox.Show("Sync data gagal, periksa koneksi internet Anda", "Info");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Data masih kosong, harap lakukan scanning terlebih dahulu", "Info");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Terjadi kesalahan");
                }
            };
            // load sqlite data
            dgUnsur.Font = new Font("Times", 12);
            dgUnsur.DataSource = SqliteDataAccess.LoadUnsur();

            // set datetimepicker date
            dateFrom.Value = DateTime.Now;
            dateUntil.Value = DateTime.Now;
        }

        void Setup()
        {
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;
            cbKomoditas.Items.Clear();
            cbKomoditas.Items.Add("Padi");
            cbKomoditas.Items.Add("Jagung");
            cbKomoditas.Items.Add("Kedelai");
            cbKomoditas.SelectedIndex = 0;
            cbResolution.SelectedIndex = 0;
            cbObticalGian.SelectedIndex = 0;

            //GpsPoint CurrentLocation = new GpsPoint();
            txtX.Text = "0";// CurrentLocation.Longitude.ToString();
            txtY.Text = "0";// CurrentLocation.Latitude.ToString();

            //populate propinsi
            cbProvinsi.Items.Clear();
            foreach (var item in LocationHelper.GetPropinsi())
            {
                cbProvinsi.Items.Add(item);
            }

            cbProvinsi.SelectedIndexChanged += cbProvinsi_SelectionChanged;
            cbProvinsi.SelectedIndex = 0;

            TimerFile.Enabled = true;
            TimerFile.Start();

            btnProcess.Enabled = false;
            btnScan.Enabled = false;
        }

        void CheckRefences()
        {
            if (cbResolution.SelectedIndex > -1)
            {
                imgResolution.Visible = true;
            }

            if (cbObticalGian.SelectedIndex > -1)
            {
                imgOptical.Visible = true;
            }
        }

        private void resetAction()
        {
            Data = null;
            statusProcess = 1;
            Writelog("Reset Config....");
            btnBackground.Enabled = true;
            btnBackground.BackColor = Color.FromArgb(29, 134, 255);
            btnScan.Enabled = false;
            btnScan.BackColor = Color.FromArgb(196, 223, 255);
            btnProcess.Enabled = false;
            btnProcess.BackColor = Color.FromArgb(196, 223, 255);

            pnlUser.Show();

            ClearChart();
            ClearText();
        }

        private void ClearChart()
        {
            foreach (var series in chartWave.Series)
            {
                series.Points.Clear();
            }
            chartWave.DataSource = null;
        }

        private void ClearText()
        {

            foreach (Control pnl in pnlUser.Controls)
            {
                if (pnl is Panel)
                {
                    foreach (Control childpnl in pnl.Controls)
                    {
                        if (childpnl is BunifuCustomTextbox)
                        {
                            var txtBox = (BunifuCustomTextbox)childpnl;
                            txtBox.Text = "0";
                            break;
                        }
                    }
                }
            }

            txtSP36.Text = "0";
            txtUrea.Text = "0";
            txtKCL.Text = "0";
            txtNpk15.Text = "0";
            txtUrea15.Text = "0";

            txtNpk15.Visible = true;
            txtUrea15.Visible = true;
        }

        private async void RequestIsDeviceReady()
        {
            try
            {
                while (true)
                {
                    Thread.Sleep(1000);
                    var client = new Datahub.MessageHub.MessageHubClient(channel);
                    var reply = await client.IsDeviceReadyAsync(new Datahub.DataRequest { Parameter = "" });

                    switch (statusProcess)
                    {

                        //check neospectra device
                        case 1:
                            if (!reply.Status)
                            {
                                MethodInvoker methodInvokerDelegate = delegate ()
                                {
                                    setButtonEnable(false);
                                };
                                if (this.InvokeRequired)
                                { this.Invoke(methodInvokerDelegate); }
                                else
                                { setButtonEnable(false); }
                            }
                            else
                            {
                                MethodInvoker methodInvokerDelegate = delegate ()
                                {
                                    setButtonEnable(true);
                                };
                                if (this.InvokeRequired)
                                { this.Invoke(methodInvokerDelegate); }
                                else
                                { setButtonEnable(true); }
                            }
                            break;

                        case 2:
                            //check background
                            if (reply.Status)
                            {
                                MethodInvoker methodInvokerDelegate = delegate ()
                                {
                                    Writelog("Get Background Done....");
                                    setButtonEnable(true);
                                    statusProcess = 0;
                                };
                                if (this.InvokeRequired)
                                { this.Invoke(methodInvokerDelegate); }
                                else
                                {
                                    Writelog("Get Background Done....");
                                    setButtonEnable(true);
                                    statusProcess = 0;
                                }
                            }
                            break;
                        case 3:
                            //check scan
                            if (reply.Status)
                            {
                                MethodInvoker methodInvokerDelegate = delegate ()
                                {
                                    Writelog("Scan Finish....");
                                    setButtonEnable(true);
                                    statusProcess = 0;
                                    ViewChart();
                                };
                                if (this.InvokeRequired)
                                { this.Invoke(methodInvokerDelegate); }
                                else
                                {
                                    Writelog("Scan Finish....");
                                    setButtonEnable(true);
                                    statusProcess = 0;
                                    ViewChart();
                                }
                            }
                            break;

                        case 4:
                            //check data
                            if (Data != null)
                            {
                                var DataRekomendasi = ConfigurationManager.AppSettings["DataRekomendasi"];
                                try
                                {
                                    MethodInvoker doProcessInvoker = delegate ()
                                    {
                                        if (Data != null)
                                        {
                                            // textbox unsur tanah
                                            TxtBray1_P2O5.Text = Data.Bray1_P2O5 > 0 ? Data.Bray1_P2O5.ToString("n2") : "0";
                                            TxtCa.Text = Data.Ca > 0 ? Data.Ca.ToString("n2") : "0";
                                            TxtCLAY.Text = Data.CLAY > 0 ? Data.CLAY.ToString("n2") : "0";
                                            //C_N.Text = Data.C_N > 0 ? Data.C_N.ToString("n2") : "0";
                                            TxtHCl25_K2O.Text = Data.HCl25_K2O > 0 ? Data.HCl25_K2O.ToString("n2") : "0";
                                            TxtHCl25_P2O5.Text = Data.HCl25_P2O5 > 0 ? Data.HCl25_P2O5.ToString("n2") : "0";
                                            //Jumlah.Text = Data.Jumlah > 0 ? Data.Jumlah.ToString("n2") : "0";
                                            TxtK.Text = Data.K > 0 ? Data.K.ToString("n2") : "0";
                                            TxtKB_adjusted.Text = Data.KB_adjusted > 0 ? Data.KB_adjusted.ToString("n2") : "0";
                                            TxtKJELDAHL_N.Text = Data.KJELDAHL_N > 0 ? Data.KJELDAHL_N.ToString("n2") : "0";
                                            TxtKTK.Text = Data.KTK > 0 ? Data.KTK.ToString("n2") : "0";
                                            TxtMg.Text = Data.Mg > 0 ? Data.Mg.ToString("n2") : "0";
                                            //Morgan_K2O.Text = Data.Morgan_K2O > 0 ? Data.Morgan_K2O.ToString("n2") : "0";
                                            TxtNa.Text = Data.Na > 0 ? Data.Na.ToString("n2") : "0";
                                            TxtOlsen_P2O5.Text = Data.Olsen_P2O5 > 0 ? Data.Olsen_P2O5.ToString("n2") : "0";
                                            TxtPH_H2O.Text = Data.PH_H2O > 0 ? Data.PH_H2O.ToString("n2") : "0";
                                            TxtPH_KCL.Text = Data.PH_KCL > 0 ? Data.PH_KCL.ToString("n2") : "0";
                                            //RetensiP.Text = Data.RetensiP > 0 ? Data.RetensiP.ToString("n2") : "0";
                                            TxtSAND.Text = Data.SAND > 0 ? Data.SAND.ToString("n2") : "0";
                                            TxtSILT.Text = Data.SILT > 0 ? Data.SILT.ToString("n2") : "0";
                                            TxtWBC.Text = Data.WBC > 0 ? Data.WBC.ToString("n2") : "0";

                                            // save data to sqlite
                                            SaveToDB();

                                            string komoditas = cbKomoditas.SelectedItem.ToString();

                                            // textbox rekomendasi
                                            //var calc = new FertilizerCalculator(DataRekomendasi);
                                            var ureaMin = double.Parse(ConfigurationManager.AppSettings["UreaMin"]);
                                            var sp36Min = double.Parse(ConfigurationManager.AppSettings["SP36Min"]);
                                            var kclMin = double.Parse(ConfigurationManager.AppSettings["KCLMin"]);

                                            switch (komoditas)
                                            {
                                                case "Padi":
                                                    var padi_urea = calc.GetFertilizerDoze(Convert.ToDouble(TxtKJELDAHL_N.Text), komoditas, "Urea") * double.Parse(ConfigurationManager.AppSettings["Urea"]);
                                                    if (padi_urea < ureaMin)
                                                    {
                                                        txtUrea.Text = ureaMin.ToString("n2");
                                                    }
                                                    else
                                                    {
                                                        txtUrea.Text = padi_urea.ToString("n2");
                                                    }
                                                    //txtUrea.Text = (calc.GetFertilizerDoze(Convert.ToDouble(TxtKJELDAHL_N.Text), komoditas, "Urea") * double.Parse(ConfigurationManager.AppSettings["Urea"])).ToString("n2");
                                                    var padi_sp36 = calc.GetFertilizerDoze(Convert.ToDouble(TxtHCl25_P2O5.Text), komoditas, "SP36") * double.Parse(ConfigurationManager.AppSettings["SP36"]);
                                                    if (padi_sp36 < sp36Min)
                                                    {
                                                        txtSP36.Text = sp36Min.ToString("n2");
                                                    }
                                                    else
                                                    {
                                                        txtSP36.Text = padi_sp36.ToString("n2");
                                                    }
                                                    //txtSP36.Text = (calc.GetFertilizerDoze(Convert.ToDouble(TxtHCl25_P2O5.Text), komoditas, "SP36") * double.Parse(ConfigurationManager.AppSettings["SP36"])).ToString("n2");
                                                    var padi_kcl = calc.GetFertilizerDoze(Convert.ToDouble(TxtHCl25_K2O.Text), komoditas, "KCL") * double.Parse(ConfigurationManager.AppSettings["KCL"]);
                                                    if (padi_kcl < kclMin)
                                                    {
                                                        txtKCL.Text = kclMin.ToString("n2");
                                                    }
                                                    else
                                                    {
                                                        txtKCL.Text = padi_kcl.ToString("n2");
                                                    }
                                                    //txtKCL.Text = (calc.GetFertilizerDoze(Convert.ToDouble(TxtHCl25_K2O.Text), komoditas, "KCL") * double.Parse(ConfigurationManager.AppSettings["KCL"])).ToString("n2");
                                                    break;

                                                case "Jagung":
                                                    var jagung_urea = calc.GetFertilizerDoze(Convert.ToDouble(TxtKJELDAHL_N.Text), komoditas, "Urea") * double.Parse(ConfigurationManager.AppSettings["Urea"]);
                                                    if (jagung_urea < ureaMin)
                                                    {
                                                        txtUrea.Text = ureaMin.ToString("n2");
                                                    }
                                                    else
                                                    {
                                                        txtUrea.Text = jagung_urea.ToString("n2");
                                                    }
                                                    //txtUrea.Text = (calc.GetFertilizerDoze(Convert.ToDouble(TxtKJELDAHL_N.Text), komoditas, "Urea") * double.Parse(ConfigurationManager.AppSettings["Urea"])).ToString("n2");
                                                    var jagung_sp36 = calc.GetFertilizerDoze(Convert.ToDouble(TxtBray1_P2O5.Text), komoditas, "SP36") * double.Parse(ConfigurationManager.AppSettings["SP36"]);
                                                    if (jagung_sp36 < sp36Min)
                                                    {
                                                        txtSP36.Text = sp36Min.ToString("n2");
                                                    }
                                                    else
                                                    {
                                                        txtSP36.Text = jagung_sp36.ToString("n2");
                                                    }
                                                    //txtSP36.Text = (calc.GetFertilizerDoze(Convert.ToDouble(TxtBray1_P2O5.Text), komoditas, "SP36") * double.Parse(ConfigurationManager.AppSettings["SP36"])).ToString("n2");
                                                    var jagung_kcl = calc.GetFertilizerDoze(Convert.ToDouble(TxtHCl25_K2O.Text), komoditas, "KCL") * double.Parse(ConfigurationManager.AppSettings["KCL"]);
                                                    if (jagung_kcl < kclMin)
                                                    {
                                                        txtKCL.Text = kclMin.ToString("n2");
                                                    }
                                                    else
                                                    {
                                                        txtKCL.Text = jagung_kcl.ToString("n2");
                                                    }
                                                    //txtKCL.Text = (calc.GetFertilizerDoze(Convert.ToDouble(TxtHCl25_K2O.Text), komoditas, "KCL") * double.Parse(ConfigurationManager.AppSettings["KCL"])).ToString("n2");
                                                    break;

                                                case "Kedelai":
                                                    var kedelai_urea = calc.GetFertilizerDoze(Convert.ToDouble(TxtKJELDAHL_N.Text), komoditas, "Urea") * double.Parse(ConfigurationManager.AppSettings["Urea"]);
                                                    if (kedelai_urea < ureaMin)
                                                    {
                                                        txtUrea.Text = ureaMin.ToString("n2");
                                                    }
                                                    else
                                                    {
                                                        txtUrea.Text = kedelai_urea.ToString("n2");
                                                    }
                                                    //txtUrea.Text = (calc.GetFertilizerDoze(Convert.ToDouble(TxtKJELDAHL_N.Text), komoditas, "Urea") * double.Parse(ConfigurationManager.AppSettings["Urea"])).ToString("n2");
                                                    var kedelai_sp36 = calc.GetFertilizerDoze(Convert.ToDouble(TxtBray1_P2O5.Text), komoditas, "SP36") * double.Parse(ConfigurationManager.AppSettings["SP36"]);
                                                    if (kedelai_sp36 < sp36Min)
                                                    {
                                                        txtSP36.Text = sp36Min.ToString("n2");
                                                    }
                                                    else
                                                    {
                                                        txtSP36.Text = kedelai_sp36.ToString("n2");
                                                    }
                                                    //txtSP36.Text = (calc.GetFertilizerDoze(Convert.ToDouble(TxtBray1_P2O5.Text), komoditas, "SP36") * double.Parse(ConfigurationManager.AppSettings["SP36"])).ToString("n2");
                                                    var kedelai_kcl = calc.GetFertilizerDoze(Convert.ToDouble(TxtK.Text), komoditas, "KCL") * double.Parse(ConfigurationManager.AppSettings["KCL"]);
                                                    if (kedelai_kcl < kclMin)
                                                    {
                                                        txtKCL.Text = kclMin.ToString("n2");
                                                    }
                                                    else
                                                    {
                                                        txtKCL.Text = kedelai_kcl.ToString("n2");
                                                    }
                                                    //txtKCL.Text = (calc.GetFertilizerDoze(Convert.ToDouble(TxtK.Text), komoditas, "KCL") * double.Parse(ConfigurationManager.AppSettings["KCL"])).ToString("n2");
                                                    break;
                                            }

                                            // textbox rekomendasi npk 15:15:15
                                            var x = calc.GetNPKDoze(P2O5: float.Parse(TxtHCl25_P2O5.Text),
                                                K2O: float.Parse(TxtHCl25_K2O.Text), Jenis: komoditas);

                                            txtNpk15.Text = x.NPK.ToString("n2");
                                            if (komoditas == "Kedelai")
                                            {
                                                pnlUrea15.Visible = false;
                                            }
                                            else
                                            {
                                                pnlUrea15.Visible = true;
                                                txtUrea15.Text = x.Urea.ToString("n2");
                                            }

                                            Writelog("Process Finish....");
                                            setButtonEnable(true);
                                            //Data = null;
                                            statusProcess = 0;
                                        }
                                    };
                                    if (this.InvokeRequired)
                                    { this.Invoke(doProcessInvoker); }
                                    else
                                    {
                                        if (Data != null)
                                        {
                                            // textbox unsur tanah
                                            TxtBray1_P2O5.Text = Data.Bray1_P2O5 > 0 ? Data.Bray1_P2O5.ToString("n2") : "0";
                                            TxtCa.Text = Data.Ca > 0 ? Data.Ca.ToString("n2") : "0";
                                            TxtCLAY.Text = Data.CLAY > 0 ? Data.CLAY.ToString("n2") : "0";
                                            //C_N.Text = Data.C_N > 0 ? Data.C_N.ToString("n2") : "0";
                                            TxtHCl25_K2O.Text = Data.HCl25_K2O > 0 ? Data.HCl25_K2O.ToString("n2") : "0";
                                            TxtHCl25_P2O5.Text = Data.HCl25_P2O5 > 0 ? Data.HCl25_P2O5.ToString("n2") : "0";
                                            //Jumlah.Text = Data.Jumlah > 0 ? Data.Jumlah.ToString("n2") : "0";
                                            TxtK.Text = Data.K > 0 ? Data.K.ToString("n2") : "0";
                                            TxtKB_adjusted.Text = Data.KB_adjusted > 0 ? Data.KB_adjusted.ToString("n2") : "0";
                                            TxtKJELDAHL_N.Text = Data.KJELDAHL_N > 0 ? Data.KJELDAHL_N.ToString("n2") : "0";
                                            TxtKTK.Text = Data.KTK > 0 ? Data.KTK.ToString("n2") : "0";
                                            TxtMg.Text = Data.Mg > 0 ? Data.Mg.ToString("n2") : "0";
                                            //Morgan_K2O.Text = Data.Morgan_K2O > 0 ? Data.Morgan_K2O.ToString("n2") : "0";
                                            TxtNa.Text = Data.Na > 0 ? Data.Na.ToString("n2") : "0";
                                            TxtOlsen_P2O5.Text = Data.Olsen_P2O5 > 0 ? Data.Olsen_P2O5.ToString("n2") : "0";
                                            TxtPH_H2O.Text = Data.PH_H2O > 0 ? Data.PH_H2O.ToString("n2") : "0";
                                            TxtPH_KCL.Text = Data.PH_KCL > 0 ? Data.PH_KCL.ToString("n2") : "0";
                                            //RetensiP.Text = Data.RetensiP > 0 ? Data.RetensiP.ToString("n2") : "0";
                                            TxtSAND.Text = Data.SAND > 0 ? Data.SAND.ToString("n2") : "0";
                                            TxtSILT.Text = Data.SILT > 0 ? Data.SILT.ToString("n2") : "0";
                                            TxtWBC.Text = Data.WBC > 0 ? Data.WBC.ToString("n2") : "0";

                                            // save data to sqlite
                                            SaveToDB();

                                            string komoditas = cbKomoditas.SelectedItem.ToString();

                                            // textbox rekomendasi
                                            //var calc = new FertilizerCalculator(DataRekomendasi);
                                            var ureaMin = double.Parse(ConfigurationManager.AppSettings["UreaMin"]);
                                            var sp36Min = double.Parse(ConfigurationManager.AppSettings["SP36Min"]);
                                            var kclMin = double.Parse(ConfigurationManager.AppSettings["KCLMin"]);

                                            switch (komoditas)
                                            {
                                                case "Padi":
                                                    var padi_urea = calc.GetFertilizerDoze(Convert.ToDouble(TxtKJELDAHL_N.Text), komoditas, "Urea") * double.Parse(ConfigurationManager.AppSettings["Urea"]);
                                                    if (padi_urea < ureaMin)
                                                    {
                                                        txtUrea.Text = ureaMin.ToString("n2");
                                                    }
                                                    else
                                                    {
                                                        txtUrea.Text = padi_urea.ToString("n2");
                                                    }
                                                    //txtUrea.Text = (calc.GetFertilizerDoze(Convert.ToDouble(TxtKJELDAHL_N.Text), komoditas, "Urea") * double.Parse(ConfigurationManager.AppSettings["Urea"])).ToString("n2");
                                                    var padi_sp36 = calc.GetFertilizerDoze(Convert.ToDouble(TxtHCl25_P2O5.Text), komoditas, "SP36") * double.Parse(ConfigurationManager.AppSettings["SP36"]);
                                                    if (padi_sp36 < sp36Min)
                                                    {
                                                        txtSP36.Text = sp36Min.ToString("n2");
                                                    }
                                                    else
                                                    {
                                                        txtSP36.Text = padi_sp36.ToString("n2");
                                                    }
                                                    //txtSP36.Text = (calc.GetFertilizerDoze(Convert.ToDouble(TxtHCl25_P2O5.Text), komoditas, "SP36") * double.Parse(ConfigurationManager.AppSettings["SP36"])).ToString("n2");
                                                    var padi_kcl = calc.GetFertilizerDoze(Convert.ToDouble(TxtHCl25_K2O.Text), komoditas, "KCL") * double.Parse(ConfigurationManager.AppSettings["KCL"]);
                                                    if (padi_kcl < kclMin)
                                                    {
                                                        txtKCL.Text = kclMin.ToString("n2");
                                                    }
                                                    else
                                                    {
                                                        txtKCL.Text = padi_kcl.ToString("n2");
                                                    }
                                                    //txtKCL.Text = (calc.GetFertilizerDoze(Convert.ToDouble(TxtHCl25_K2O.Text), komoditas, "KCL") * double.Parse(ConfigurationManager.AppSettings["KCL"])).ToString("n2");
                                                    break;

                                                case "Jagung":
                                                    var jagung_urea = calc.GetFertilizerDoze(Convert.ToDouble(TxtKJELDAHL_N.Text), komoditas, "Urea") * double.Parse(ConfigurationManager.AppSettings["Urea"]);
                                                    if (jagung_urea < ureaMin)
                                                    {
                                                        txtUrea.Text = ureaMin.ToString("n2");
                                                    }
                                                    else
                                                    {
                                                        txtUrea.Text = jagung_urea.ToString("n2");
                                                    }
                                                    //txtUrea.Text = (calc.GetFertilizerDoze(Convert.ToDouble(TxtKJELDAHL_N.Text), komoditas, "Urea") * double.Parse(ConfigurationManager.AppSettings["Urea"])).ToString("n2");
                                                    var jagung_sp36 = calc.GetFertilizerDoze(Convert.ToDouble(TxtBray1_P2O5.Text), komoditas, "SP36") * double.Parse(ConfigurationManager.AppSettings["SP36"]);
                                                    if (jagung_sp36 < sp36Min)
                                                    {
                                                        txtSP36.Text = sp36Min.ToString("n2");
                                                    }
                                                    else
                                                    {
                                                        txtSP36.Text = jagung_sp36.ToString("n2");
                                                    }
                                                    //txtSP36.Text = (calc.GetFertilizerDoze(Convert.ToDouble(TxtBray1_P2O5.Text), komoditas, "SP36") * double.Parse(ConfigurationManager.AppSettings["SP36"])).ToString("n2");
                                                    var jagung_kcl = calc.GetFertilizerDoze(Convert.ToDouble(TxtHCl25_K2O.Text), komoditas, "KCL") * double.Parse(ConfigurationManager.AppSettings["KCL"]);
                                                    if (jagung_kcl < kclMin)
                                                    {
                                                        txtKCL.Text = kclMin.ToString("n2");
                                                    }
                                                    else
                                                    {
                                                        txtKCL.Text = jagung_kcl.ToString("n2");
                                                    }
                                                    //txtKCL.Text = (calc.GetFertilizerDoze(Convert.ToDouble(TxtHCl25_K2O.Text), komoditas, "KCL") * double.Parse(ConfigurationManager.AppSettings["KCL"])).ToString("n2");
                                                    break;

                                                case "Kedelai":
                                                    var kedelai_urea = calc.GetFertilizerDoze(Convert.ToDouble(TxtKJELDAHL_N.Text), komoditas, "Urea") * double.Parse(ConfigurationManager.AppSettings["Urea"]);
                                                    if (kedelai_urea < ureaMin)
                                                    {
                                                        txtUrea.Text = ureaMin.ToString("n2");
                                                    }
                                                    else
                                                    {
                                                        txtUrea.Text = kedelai_urea.ToString("n2");
                                                    }
                                                    //txtUrea.Text = (calc.GetFertilizerDoze(Convert.ToDouble(TxtKJELDAHL_N.Text), komoditas, "Urea") * double.Parse(ConfigurationManager.AppSettings["Urea"])).ToString("n2");
                                                    var kedelai_sp36 = calc.GetFertilizerDoze(Convert.ToDouble(TxtBray1_P2O5.Text), komoditas, "SP36") * double.Parse(ConfigurationManager.AppSettings["SP36"]);
                                                    if (kedelai_sp36 < sp36Min)
                                                    {
                                                        txtSP36.Text = sp36Min.ToString("n2");
                                                    }
                                                    else
                                                    {
                                                        txtSP36.Text = kedelai_sp36.ToString("n2");
                                                    }
                                                    //txtSP36.Text = (calc.GetFertilizerDoze(Convert.ToDouble(TxtBray1_P2O5.Text), komoditas, "SP36") * double.Parse(ConfigurationManager.AppSettings["SP36"])).ToString("n2");
                                                    var kedelai_kcl = calc.GetFertilizerDoze(Convert.ToDouble(TxtK.Text), komoditas, "KCL") * double.Parse(ConfigurationManager.AppSettings["KCL"]);
                                                    if (kedelai_kcl < kclMin)
                                                    {
                                                        txtKCL.Text = kclMin.ToString("n2");
                                                    }
                                                    else
                                                    {
                                                        txtKCL.Text = kedelai_kcl.ToString("n2");
                                                    }
                                                    //txtKCL.Text = (calc.GetFertilizerDoze(Convert.ToDouble(TxtK.Text), komoditas, "KCL") * double.Parse(ConfigurationManager.AppSettings["KCL"])).ToString("n2");
                                                    break;
                                            }

                                            // textbox rekomendasi npk 15:15:15
                                            var x = calc.GetNPKDoze(P2O5: float.Parse(TxtHCl25_P2O5.Text),
                                                K2O: float.Parse(TxtHCl25_K2O.Text), Jenis: komoditas);

                                            txtNpk15.Text = x.NPK.ToString("n2");
                                            if (komoditas == "Kedelai")
                                            {
                                                pnlUrea15.Visible = false;
                                            }
                                            else
                                            {
                                                pnlUrea15.Visible = true;
                                                txtUrea15.Text = x.Urea.ToString("n2");
                                            }

                                            Writelog("Process Finish....");
                                            setButtonEnable(true);
                                            //Data = null;
                                            statusProcess = 0;
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex);
                                    Logs.WriteAppLog(ex.ToString());
                                }
                            }
                            break;
                    }

                    MethodInvoker methodInvokerWrite = delegate ()
                    {
                        TxtDeviceStat.Text = reply.Result;
                    };
                    if (this.InvokeRequired)
                    { this.Invoke(methodInvokerWrite); }
                    else
                    {

                        TxtDeviceStat.Text = reply.Result;
                    }

                    //channel.ShutdownAsync().Wait();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void setButtonEnable(bool param)
        {
            switch (statusProcess)
            {
                case 1:
                    if (param)
                    {
                        this.btnBackground.Enabled = true;
                        this.btnScan.Enabled = false;
                        this.btnProcess.Enabled = false;
                        this.btnReset.Enabled = true;
                    }
                    else
                    {
                        this.btnBackground.Enabled = false;
                        this.btnScan.Enabled = false;
                        this.btnProcess.Enabled = false;
                        this.btnReset.Enabled = false;
                    }
                    break;

                case 2:
                    if (param)
                    {
                        this.btnBackground.Enabled = false;
                        this.btnScan.Enabled = true;
                        this.btnProcess.Enabled = false;
                        this.btnReset.Enabled = true;
                    }
                    else
                    {
                        this.btnBackground.Enabled = false;
                        this.btnScan.Enabled = false;
                        this.btnProcess.Enabled = false;
                        this.btnReset.Enabled = false;
                    }
                    break;

                case 3:
                    if (param)
                    {
                        this.btnBackground.Enabled = false;
                        this.btnScan.Enabled = true;
                        this.btnProcess.Enabled = true;
                        this.btnReset.Enabled = true;
                    }
                    else
                    {
                        this.btnBackground.Enabled = false;
                        this.btnScan.Enabled = false;
                        this.btnProcess.Enabled = false;
                        this.btnReset.Enabled = false;
                    }
                    break;

                case 4:
                    if (param)
                    {
                        this.btnBackground.Enabled = false;
                        this.btnScan.Enabled = true;
                        this.btnProcess.Enabled = true;
                        this.btnReset.Enabled = true;
                    }
                    else
                    {
                        this.btnBackground.Enabled = false;
                        this.btnScan.Enabled = false;
                        this.btnProcess.Enabled = false;
                        this.btnReset.Enabled = false;
                    }
                    break;
            }
        }

        private void ViewChart()
        {
            var WorkingDirectory = ConfigurationManager.AppSettings["WorkingDirectory"];
            var SensorData = ConfigurationManager.AppSettings["SensorData"];
            try
            {
                string filepath = WorkingDirectory + "\\" + SensorData;
                if (!File.Exists(filepath)) throw new Exception("Data is not exists");
                var FileSel = filepath;
                if (FileSel != null)
                {
                    foreach (var series in chartWave.Series)
                    {
                        series.Points.Clear();
                    }

                    RawChart chart = new RawChart();
                    chart.LoadFile(FileSel);
                    var dt = chart.GetDataGelombangInXY();
                    chartWave.DataSource = dt;
                    chartWave.Series["Series1"].XValueMember = "X";
                    chartWave.Series["Series1"].YValueMembers = "Y";
                    chartWave.Series["Series1"].ChartType = SeriesChartType.Line;
                    chartWave.Series["Series1"].IsVisibleInLegend = false;

                    chartWave.ChartAreas[0].AxisX.Title = "Wave Number";
                    chartWave.ChartAreas[0].AxisY.Title = "Absorbance";
                    chartWave.ChartAreas[0].AxisY.LabelStyle.Format = "";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void cbProvinsi_SelectionChanged(object sender, EventArgs e)
        {
            cbKabupaten.Items.Clear();
            var selProp = cbProvinsi.SelectedItem.ToString();
            foreach (var item in LocationHelper.GetKabupaten(selProp))
            {
                cbKabupaten.Items.Add(item);
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            var newFrm = new Form1();
            newFrm.Show();
            TimerFile.Stop();
            //comm.Dispose();
            this.Close();

        }

        # region FileScan
        //static List<FileScan> ScannedFiles;
        //private void TimerFile_Tick(object sender, EventArgs e)
        //{
        //    var PathScan = ConfigurationManager.AppSettings["ScanFolder"];
        //    if (ScannedFiles == null)
        //        ScannedFiles = new List<FileScan>();
        //    else
        //        ScannedFiles.Clear();
        //    if (Directory.Exists(PathScan))
        //    {
        //        var files = Directory.GetFiles(PathScan, "*.Spectrum");
        //        foreach (var item in files)
        //        {
        //            var FileNameNude = Path.GetFileName(item).Replace(Path.GetExtension(item), "");
        //            ScannedFiles.Add(new FileScan() { FullName = item, Name = FileNameNude, CreatedDate = new DateTime() });
        //        }
        //        //LstFiles.Items.Clear();
        //        LstFiles.DisplayMember = "Name";
        //        LstFiles.ValueMember = "FullName";
        //        LstFiles.DataSource = ScannedFiles;

        //    }
        //}
        #endregion FileScan

        private async void btnBackground_Click(object sender, EventArgs e)
        {
            var client = new Datahub.MessageHub.MessageHubClient(channel);
            var reply = await client.DoBackgroundAsync(new Datahub.DataRequest { Parameter = "" });
            //channel.ShutdownAsync().Wait();

            Writelog("Run Background....");
            statusProcess = 2;
            setButtonEnable(false);
            btnBackground.BackColor = Color.FromArgb(65, 88, 114);
            btnScan.BackColor = Color.FromArgb(29, 134, 255);

        }

        private async void btnScan_Click(object sender, EventArgs e)
        {
            var client = new Datahub.MessageHub.MessageHubClient(channel);
            var reply = await client.DoScanAsync(new Datahub.DataRequest { Parameter = "" });

            //channel.ShutdownAsync().Wait();
            //comm.SendMessage("Scan");

            Writelog("Run Scanning....");
            statusProcess = 3;
            setButtonEnable(false);
            ClearChart();
            ClearText();
            btnScan.BackColor = Color.FromArgb(29, 134, 255);
            btnProcess.BackColor = Color.FromArgb(29, 134, 255);
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            SoilNutritionModel snm = new SoilNutritionModel();
            var doit = Task.Run(() => snm.InferenceModel());
            doit.GetAwaiter();

            Writelog("Do Calculating Elements.... Please wait for a while....");
            statusProcess = 4;
            setButtonEnable(false);
        }

        private void SaveToDB()
        {
            UnsurModel dataunsur = new UnsurModel()
            {
                Bray1_P2O5 = Data.Bray1_P2O5 > 0 ? float.Parse(Data.Bray1_P2O5.ToString("n2")) : 0,
                Ca = Data.Ca > 0 ? float.Parse(Data.Ca.ToString("n2")) : 0,
                CLAY = Data.CLAY > 0 ? float.Parse(Data.CLAY.ToString("n2")) : 0,
                C_N = Data.C_N > 0 ? float.Parse(Data.C_N.ToString("n2")) : 0,
                HCl25_K2O = Data.HCl25_K2O > 0 ? float.Parse(Data.HCl25_K2O.ToString("n2")) : 0,
                HCl25_P2O5 = Data.HCl25_P2O5 > 0 ? float.Parse(Data.HCl25_P2O5.ToString("n2")) : 0,
                Jumlah = Data.Jumlah > 0 ? float.Parse(Data.Jumlah.ToString("n2")) : 0,
                K = Data.K > 0 ? float.Parse(Data.K.ToString("n2")) : 0,
                KB_adjusted = Data.KB_adjusted > 0 ? float.Parse(Data.KB_adjusted.ToString("n2")) : 0,
                KJELDAHL_N = Data.KJELDAHL_N > 0 ? float.Parse(Data.KJELDAHL_N.ToString("n2")) : 0,
                KTK = Data.KTK > 0 ? float.Parse(Data.KTK.ToString("n2")) : 0,
                Mg = Data.Mg > 0 ? float.Parse(Data.Mg.ToString("n2")) : 0,
                Morgan_K2O = Data.Morgan_K2O > 0 ? float.Parse(Data.Morgan_K2O.ToString("n2")) : 0,
                Na = Data.Na > 0 ? float.Parse(Data.Na.ToString("n2")) : 0,
                Olsen_P2O5 = Data.Olsen_P2O5 > 0 ? float.Parse(Data.Olsen_P2O5.ToString("n2")) : 0,
                PH_H2O = Data.PH_H2O > 0 ? float.Parse(Data.PH_H2O.ToString("n2")) : 0,
                PH_KCL = Data.PH_KCL > 0 ? float.Parse(Data.PH_KCL.ToString("n2")) : 0,
                RetensiP = Data.RetensiP > 0 ? float.Parse(Data.RetensiP.ToString("n2")) : 0,
                SAND = Data.SAND > 0 ? float.Parse(Data.SAND.ToString("n2")) : 0,
                SILT = Data.SILT > 0 ? float.Parse(Data.SILT.ToString("n2")) : 0,
                WBC = Data.WBC > 0 ? float.Parse(Data.WBC.ToString("n2")) : 0,
                CreatedDate = DateTime.Now.Date
            };

            SqliteDataAccess.SaveUnsur(dataunsur);
            dgUnsur.DataSource = SqliteDataAccess.LoadUnsur();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetAction();
        }

        private void Writelog(string message)
        {
            Logs.WriteAppLog(message);
            ReadLog();
        }

        private void ReadLog()
        {
            string message = Logs.ReadLastLog();
            if (!string.IsNullOrEmpty(message))
            {
                txtLog.Text += message + "\n";
                txtLog.SelectionStart = txtLog.Text.Length;
                txtLog.ScrollToCaret();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            string message = "Apa anda yakin ingin mematikan alat ini?";
            CustomMessageBox = new MessageBoxForm(message);
            CustomMessageBox.ShowDialog();

            if (CustomMessageBox.dialogResult == true)
            {
                LoopCheckDevice.Abort();
                Process.Start("shutdown", "/s /t 5");
                Environment.Exit(0);
            }

        }

        private void btnConfigUser_Click(object sender, EventArgs e)
        {
            var opendialog = new OutputConfigFrm();
            opendialog.ShowDialog();
        }

        public void ReadConfig()
        {
            if (listOfControls == null)
            { listOfControls = new HashSet<string>(); }
            else
            { listOfControls.Clear(); }
            string AppPath = Application.StartupPath + "\\outputconfig.json";
            List<OutputData> ReadData = JsonConvert.DeserializeObject<List<OutputData>>(File.ReadAllText(AppPath));
            ReadDataSort = ReadData.OrderBy(x => x.No).ToList<OutputData>();

            //add textbox
            foreach (var item in ReadData)
            {
                if (item.Status == CheckState.Checked)
                {
                    listOfControls.Add(item.Name);
                }
            }
            DisplayTextBox();
        }

        public void DisplayTextBox()
        {
            const int CellWidth = 270;
            const int CellHeight = 80;
            const int MaxRow = 6;
            int RowCounter = 0;
            int ColCounter = 0;

            foreach (var data in ReadDataSort)
            {
                foreach (Control item in pnlUser.Controls)
                {
                    if (item is Panel && item.Name == data.Name && listOfControls.Contains(item.Tag))
                    {
                        var panel = (Panel)item;
                        panel.Visible = true;
                        panel.Left = 13 + (ColCounter * (CellWidth + 20));
                        panel.Top = 7 + (RowCounter * (CellHeight));
                        RowCounter++;
                    }

                    if (RowCounter >= MaxRow) { ColCounter++; RowCounter = 0; }

                    if (item is Panel && !listOfControls.Contains(item.Tag))
                    {
                        ((Panel)item).Visible = false;
                    }
                }
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XLS files (*.xls)|*.xls|XLSX files (*.xlsx)|*.xlsx|CSV (*.csv)|*.csv";
            saveFileDialog.FileName = "ExportFile" + DateTime.Now.ToString("dd-MM-yyyy-HHMMSS");
            saveFileDialog.FilterIndex = 3;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var workbook = new ExcelFile();
                var worksheet = workbook.Worksheets.Add("Export Unsur");

                // From DataGridView to ExcelFile.
                DataGridViewConverter.ImportFromDataGridView(worksheet, this.dgUnsur, new ImportFromDataGridViewOptions() { ColumnHeaders = true });

                workbook.Save(saveFileDialog.FileName);
            }
        }

        private void BtnResetFilter_Click(object sender, EventArgs e)
        {
            dgUnsur.DataSource = SqliteDataAccess.LoadUnsur();
        }

        private void Recalculate()
        {
            string komoditas = cbKomoditas.SelectedItem.ToString();
            try
            {
                // textbox rekomendasi
                //var calc = new FertilizerCalculator(DataRekomendasi);
                var ureaMin = double.Parse(ConfigurationManager.AppSettings["UreaMin"]);
                var sp36Min = double.Parse(ConfigurationManager.AppSettings["SP36Min"]);
                var kclMin = double.Parse(ConfigurationManager.AppSettings["KCLMin"]);

                switch (komoditas)
                {
                    case "Padi":
                        var padi_urea = calc.GetFertilizerDoze(Convert.ToDouble(TxtKJELDAHL_N.Text), komoditas, "Urea") * double.Parse(ConfigurationManager.AppSettings["Urea"]);
                        if (padi_urea < ureaMin)
                        {
                            txtUrea.Text = ureaMin.ToString("n2");
                        }
                        else
                        {
                            txtUrea.Text = padi_urea.ToString("n2");
                        }
                        //txtUrea.Text = (calc.GetFertilizerDoze(Convert.ToDouble(TxtKJELDAHL_N.Text), komoditas, "Urea") * double.Parse(ConfigurationManager.AppSettings["Urea"])).ToString("n2");
                        var padi_sp36 = calc.GetFertilizerDoze(Convert.ToDouble(TxtHCl25_P2O5.Text), komoditas, "SP36") * double.Parse(ConfigurationManager.AppSettings["SP36"]);
                        if (padi_sp36 < sp36Min)
                        {
                            txtSP36.Text = sp36Min.ToString("n2");
                        }
                        else
                        {
                            txtSP36.Text = padi_sp36.ToString("n2");
                        }
                        //txtSP36.Text = (calc.GetFertilizerDoze(Convert.ToDouble(TxtHCl25_P2O5.Text), komoditas, "SP36") * double.Parse(ConfigurationManager.AppSettings["SP36"])).ToString("n2");
                        var padi_kcl = calc.GetFertilizerDoze(Convert.ToDouble(TxtHCl25_K2O.Text), komoditas, "KCL") * double.Parse(ConfigurationManager.AppSettings["KCL"]);
                        if (padi_kcl < kclMin)
                        {
                            txtKCL.Text = kclMin.ToString("n2");
                        }
                        else
                        {
                            txtKCL.Text = padi_kcl.ToString("n2");
                        }
                        //txtKCL.Text = (calc.GetFertilizerDoze(Convert.ToDouble(TxtHCl25_K2O.Text), komoditas, "KCL") * double.Parse(ConfigurationManager.AppSettings["KCL"])).ToString("n2");
                        break;

                    case "Jagung":
                        var jagung_urea = calc.GetFertilizerDoze(Convert.ToDouble(TxtKJELDAHL_N.Text), komoditas, "Urea") * double.Parse(ConfigurationManager.AppSettings["Urea"]);
                        if (jagung_urea < ureaMin)
                        {
                            txtUrea.Text = ureaMin.ToString("n2");
                        }
                        else
                        {
                            txtUrea.Text = jagung_urea.ToString("n2");
                        }
                        //txtUrea.Text = (calc.GetFertilizerDoze(Convert.ToDouble(TxtKJELDAHL_N.Text), komoditas, "Urea") * double.Parse(ConfigurationManager.AppSettings["Urea"])).ToString("n2");
                        var jagung_sp36 = calc.GetFertilizerDoze(Convert.ToDouble(TxtBray1_P2O5.Text), komoditas, "SP36") * double.Parse(ConfigurationManager.AppSettings["SP36"]);
                        if (jagung_sp36 < sp36Min)
                        {
                            txtSP36.Text = sp36Min.ToString("n2");
                        }
                        else
                        {
                            txtSP36.Text = jagung_sp36.ToString("n2");
                        }
                        //txtSP36.Text = (calc.GetFertilizerDoze(Convert.ToDouble(TxtBray1_P2O5.Text), komoditas, "SP36") * double.Parse(ConfigurationManager.AppSettings["SP36"])).ToString("n2");
                        var jagung_kcl = calc.GetFertilizerDoze(Convert.ToDouble(TxtHCl25_K2O.Text), komoditas, "KCL") * double.Parse(ConfigurationManager.AppSettings["KCL"]);
                        if (jagung_kcl < kclMin)
                        {
                            txtKCL.Text = kclMin.ToString("n2");
                        }
                        else
                        {
                            txtKCL.Text = jagung_kcl.ToString("n2");
                        }
                        //txtKCL.Text = (calc.GetFertilizerDoze(Convert.ToDouble(TxtHCl25_K2O.Text), komoditas, "KCL") * double.Parse(ConfigurationManager.AppSettings["KCL"])).ToString("n2");
                        break;

                    case "Kedelai":
                        var kedelai_urea = calc.GetFertilizerDoze(Convert.ToDouble(TxtKJELDAHL_N.Text), komoditas, "Urea") * double.Parse(ConfigurationManager.AppSettings["Urea"]);
                        if (kedelai_urea < ureaMin)
                        {
                            txtUrea.Text = ureaMin.ToString("n2");
                        }
                        else
                        {
                            txtUrea.Text = kedelai_urea.ToString("n2");
                        }
                        //txtUrea.Text = (calc.GetFertilizerDoze(Convert.ToDouble(TxtKJELDAHL_N.Text), komoditas, "Urea") * double.Parse(ConfigurationManager.AppSettings["Urea"])).ToString("n2");
                        var kedelai_sp36 = calc.GetFertilizerDoze(Convert.ToDouble(TxtBray1_P2O5.Text), komoditas, "SP36") * double.Parse(ConfigurationManager.AppSettings["SP36"]);
                        if (kedelai_sp36 < sp36Min)
                        {
                            txtSP36.Text = sp36Min.ToString("n2");
                        }
                        else
                        {
                            txtSP36.Text = kedelai_sp36.ToString("n2");
                        }
                        //txtSP36.Text = (calc.GetFertilizerDoze(Convert.ToDouble(TxtBray1_P2O5.Text), komoditas, "SP36") * double.Parse(ConfigurationManager.AppSettings["SP36"])).ToString("n2");
                        var kedelai_kcl = calc.GetFertilizerDoze(Convert.ToDouble(TxtK.Text), komoditas, "KCL") * double.Parse(ConfigurationManager.AppSettings["KCL"]);
                        if (kedelai_kcl < kclMin)
                        {
                            txtKCL.Text = kclMin.ToString("n2");
                        }
                        else
                        {
                            txtKCL.Text = kedelai_kcl.ToString("n2");
                        }
                        //txtKCL.Text = (calc.GetFertilizerDoze(Convert.ToDouble(TxtK.Text), komoditas, "KCL") * double.Parse(ConfigurationManager.AppSettings["KCL"])).ToString("n2");
                        break;
                }

                // textbox rekomendasi npk 15:15:15
                var x = calc.GetNPKDoze(P2O5: float.Parse(TxtHCl25_P2O5.Text),
                    K2O: float.Parse(TxtHCl25_K2O.Text), Jenis: komoditas);

                txtNpk15.Text = x.NPK.ToString("n2");
                if (komoditas == "Kedelai")
                {
                    pnlUrea15.Visible = false;
                }
                else
                {
                    pnlUrea15.Visible = true;
                    txtUrea15.Text = x.Urea.ToString("n2");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Logs.WriteAppLog(ex.ToString());
            }

        }

        private void BtnFilter_Click(object sender, EventArgs e)
        {
            DateTime from = dateFrom.Value;
            DateTime until = dateUntil.Value;

            dgUnsur.DataSource = SqliteDataAccess.FilterBydateUnsur(from, until);
        }

        private void BtnClearDB_Click(object sender, EventArgs e)
        {
            string message = "apakah anda yakin ingin menghapus data dari database?";
            CustomMessageBox = new MessageBoxForm(message);
            CustomMessageBox.ShowDialog();

            if (CustomMessageBox.dialogResult == true)
            {
                SqliteDataAccess.DeleteAllUnsur();
                dgUnsur.DataSource = SqliteDataAccess.LoadUnsur();
            }
        }

        private void TxtUrea_TextChanged(object sender, EventArgs e)
        {
            if (float.Parse(txtUrea.Text) < 0)
            {
                txtUrea.Text = "0.50";
            }
        }

        private void TxtSP36_TextChanged(object sender, EventArgs e)
        {
            if (float.Parse(txtSP36.Text) < 0)
            {
                txtSP36.Text = "0.50";
            }
        }

        private void TxtKCL_TextChanged(object sender, EventArgs e)
        {
            if (float.Parse(txtKCL.Text) < 0)
            {
                txtKCL.Text = "0.50";
            }
        }

        private void CbKomoditas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string komoditas = cbKomoditas.SelectedItem.ToString();
            try
            {
                // textbox rekomendasi
                //var calc = new FertilizerCalculator(DataRekomendasi);
                var ureaMin = double.Parse(ConfigurationManager.AppSettings["UreaMin"]);
                var sp36Min = double.Parse(ConfigurationManager.AppSettings["SP36Min"]);
                var kclMin = double.Parse(ConfigurationManager.AppSettings["KCLMin"]);

                switch (komoditas)
                {
                    case "Padi":
                        var padi_urea = calc.GetFertilizerDoze(Convert.ToDouble(TxtKJELDAHL_N.Text), komoditas, "Urea") * double.Parse(ConfigurationManager.AppSettings["Urea"]);
                        if (padi_urea < ureaMin)
                        {
                            txtUrea.Text = ureaMin.ToString("n2");
                        }
                        else
                        {
                            txtUrea.Text = padi_urea.ToString("n2");
                        }
                        //txtUrea.Text = (calc.GetFertilizerDoze(Convert.ToDouble(TxtKJELDAHL_N.Text), komoditas, "Urea") * double.Parse(ConfigurationManager.AppSettings["Urea"])).ToString("n2");
                        var padi_sp36 = calc.GetFertilizerDoze(Convert.ToDouble(TxtHCl25_P2O5.Text), komoditas, "SP36") * double.Parse(ConfigurationManager.AppSettings["SP36"]);
                        if (padi_sp36 < sp36Min)
                        {
                            txtSP36.Text = sp36Min.ToString("n2");
                        }
                        else
                        {
                            txtSP36.Text = padi_sp36.ToString("n2");
                        }
                        //txtSP36.Text = (calc.GetFertilizerDoze(Convert.ToDouble(TxtHCl25_P2O5.Text), komoditas, "SP36") * double.Parse(ConfigurationManager.AppSettings["SP36"])).ToString("n2");
                        var padi_kcl = calc.GetFertilizerDoze(Convert.ToDouble(TxtHCl25_K2O.Text), komoditas, "KCL") * double.Parse(ConfigurationManager.AppSettings["KCL"]);
                        if (padi_kcl < kclMin)
                        {
                            txtKCL.Text = kclMin.ToString("n2");
                        }
                        else
                        {
                            txtKCL.Text = padi_kcl.ToString("n2");
                        }
                        //txtKCL.Text = (calc.GetFertilizerDoze(Convert.ToDouble(TxtHCl25_K2O.Text), komoditas, "KCL") * double.Parse(ConfigurationManager.AppSettings["KCL"])).ToString("n2");
                        break;

                    case "Jagung":
                        var jagung_urea = calc.GetFertilizerDoze(Convert.ToDouble(TxtKJELDAHL_N.Text), komoditas, "Urea") * double.Parse(ConfigurationManager.AppSettings["Urea"]);
                        if (jagung_urea < ureaMin)
                        {
                            txtUrea.Text = ureaMin.ToString("n2");
                        }
                        else
                        {
                            txtUrea.Text = jagung_urea.ToString("n2");
                        }
                        //txtUrea.Text = (calc.GetFertilizerDoze(Convert.ToDouble(TxtKJELDAHL_N.Text), komoditas, "Urea") * double.Parse(ConfigurationManager.AppSettings["Urea"])).ToString("n2");
                        var jagung_sp36 = calc.GetFertilizerDoze(Convert.ToDouble(TxtBray1_P2O5.Text), komoditas, "SP36") * double.Parse(ConfigurationManager.AppSettings["SP36"]);
                        if (jagung_sp36 < sp36Min)
                        {
                            txtSP36.Text = sp36Min.ToString("n2");
                        }
                        else
                        {
                            txtSP36.Text = jagung_sp36.ToString("n2");
                        }
                        //txtSP36.Text = (calc.GetFertilizerDoze(Convert.ToDouble(TxtBray1_P2O5.Text), komoditas, "SP36") * double.Parse(ConfigurationManager.AppSettings["SP36"])).ToString("n2");
                        var jagung_kcl = calc.GetFertilizerDoze(Convert.ToDouble(TxtHCl25_K2O.Text), komoditas, "KCL") * double.Parse(ConfigurationManager.AppSettings["KCL"]);
                        if (jagung_kcl < kclMin)
                        {
                            txtKCL.Text = kclMin.ToString("n2");
                        }
                        else
                        {
                            txtKCL.Text = jagung_kcl.ToString("n2");
                        }
                        //txtKCL.Text = (calc.GetFertilizerDoze(Convert.ToDouble(TxtHCl25_K2O.Text), komoditas, "KCL") * double.Parse(ConfigurationManager.AppSettings["KCL"])).ToString("n2");
                        break;

                    case "Kedelai":
                        var kedelai_urea = calc.GetFertilizerDoze(Convert.ToDouble(TxtKJELDAHL_N.Text), komoditas, "Urea") * double.Parse(ConfigurationManager.AppSettings["Urea"]);
                        if (kedelai_urea < ureaMin)
                        {
                            txtUrea.Text = ureaMin.ToString("n2");
                        }
                        else
                        {
                            txtUrea.Text = kedelai_urea.ToString("n2");
                        }
                        //txtUrea.Text = (calc.GetFertilizerDoze(Convert.ToDouble(TxtKJELDAHL_N.Text), komoditas, "Urea") * double.Parse(ConfigurationManager.AppSettings["Urea"])).ToString("n2");
                        var kedelai_sp36 = calc.GetFertilizerDoze(Convert.ToDouble(TxtBray1_P2O5.Text), komoditas, "SP36") * double.Parse(ConfigurationManager.AppSettings["SP36"]);
                        if (kedelai_sp36 < sp36Min)
                        {
                            txtSP36.Text = sp36Min.ToString("n2");
                        }
                        else
                        {
                            txtSP36.Text = kedelai_sp36.ToString("n2");
                        }
                        //txtSP36.Text = (calc.GetFertilizerDoze(Convert.ToDouble(TxtBray1_P2O5.Text), komoditas, "SP36") * double.Parse(ConfigurationManager.AppSettings["SP36"])).ToString("n2");
                        var kedelai_kcl = calc.GetFertilizerDoze(Convert.ToDouble(TxtK.Text), komoditas, "KCL") * double.Parse(ConfigurationManager.AppSettings["KCL"]);
                        if (kedelai_kcl < kclMin)
                        {
                            txtKCL.Text = kclMin.ToString("n2");
                        }
                        else
                        {
                            txtKCL.Text = kedelai_kcl.ToString("n2");
                        }
                        //txtKCL.Text = (calc.GetFertilizerDoze(Convert.ToDouble(TxtK.Text), komoditas, "KCL") * double.Parse(ConfigurationManager.AppSettings["KCL"])).ToString("n2");
                        break;
                }

                // textbox rekomendasi npk 15:15:15
                var x = calc.GetNPKDoze(P2O5: float.Parse(TxtHCl25_P2O5.Text),
                    K2O: float.Parse(TxtHCl25_K2O.Text), Jenis: komoditas);

                txtNpk15.Text = x.NPK.ToString("n2");
                if (komoditas == "Kedelai")
                {
                    pnlUrea15.Visible = false;
                }
                else
                {
                    pnlUrea15.Visible = true;
                    txtUrea15.Text = x.Urea.ToString("n2");
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex);
                //Logs.WriteAppLog(ex.ToString());
            }
        }

        private void tabRekomendasiPupuk_Click(object sender, EventArgs e)
        {

        }
    }

    public class FileScan
    {
        public DateTime CreatedDate { get; set; }
        public string FullName { get; set; }
        public string Name { get; set; }
    }
}
