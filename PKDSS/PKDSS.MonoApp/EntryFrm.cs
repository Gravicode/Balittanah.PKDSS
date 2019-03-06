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

namespace PKDSS.MonoApp
{
    public partial class EntryFrm : Form
    {
        Channel channel = new Channel("localhost:50051", ChannelCredentials.Insecure);
        string ComPort = ConfigurationManager.AppSettings["ComPort"];
        Thread LoopCheckDevice;
        int statusProcess = 0;
        public static ModelOutput Data = new ModelOutput();

        //NamedPipesCom comm;
        public EntryFrm()
        {
            InitializeComponent();
            Setup();

            //Looping check device is ready
            LoopCheckDevice = new Thread(RequestIsDeviceReady);
            LoopCheckDevice.Start();

            Data = null;
            statusProcess = 1;
            CheckRefences();
            ReadLog();
            pnlAdvance.Hide();
            pnlUser.Show();
            
            var gps = new GpsDevice2(ComPort);
            gps.StartGPS();
        }

        void Setup()
        {
            //comm = new NamedPipesCom();
            //comm.DataReceived += (string Message)=>
            //{
            //    Console.WriteLine("data from named pipes :" + Message);
            //};
            //this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            cbKomoditas.Items.Clear();
            cbKomoditas.Items.Add("Padi");
            cbKomoditas.Items.Add("Jagung");
            cbKomoditas.Items.Add("Kedelai");
            cbKomoditas.SelectedIndex = 0;
            cbResolution.SelectedIndex = 0;
            cbObticalGian.SelectedIndex = 0;

            GpsPoint CurrentLocation = new GpsPoint();
            txtX.Text = CurrentLocation.Longitude.ToString();
            txtY.Text = CurrentLocation.Latitude.ToString();

            chkAdvance.Checked = false;

            //populate propinsi
            cbProvinsi.Items.Clear();
            foreach (var item in LocationHelper.GetPropinsi())
            {
                cbProvinsi.Items.Add(item);
            }

            cbProvinsi.SelectedIndexChanged += cbProvinsi_SelectionChanged;
            cbProvinsi.SelectedIndex = 0;

            //BtnProcess.Click += (a, b) => { MessageBox.Show("Maaf, fungsi belum tersedia"); };
            //BtnViewChart.Click += BtnViewChart_Click;

            TimerFile.Enabled = true;
            TimerFile.Start();

            btnProcess.Enabled = false;
            btnScan.Enabled = false;
        }

        void CheckRefences()
        {
            if(cbResolution.SelectedIndex > -1)
            {
                imgResolution.Visible = true;
            }
            
            if(cbObticalGian.SelectedIndex > -1)
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

            chkAdvance.Checked = false;
            pnlAdvance.Hide();
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
            txtCadd.Text = "";
            txtClay.Text = "";
            txtCOrganik.Text = "";
            txtJumlah.Text = "";
            txtK205.Text = "";
            txtKadd.Text = "";
            txtKTK.Text = "";
            txtMgdd.Text = "";
            txtMorgan.Text = "";
            txtNa.Text = "";
            txtNTotal.Text = "";
            txtP205.Text = "";
            txtPbray.Text = "";
            txtPH.Text = "";
            txtPhKcl.Text = "";
            txtPOlsen.Text = "";
            txtRetensi.Text = "";
            txtSAND.Text = "";
            txtSILT.Text = "";
            txtWbc.Text = "";
            txtKbAjusted.Text = "";

            txtKtkuser.Text = "";
            txtK205user.Text = "";
            txtKdduser.Text = "";
            txtNtotaluser.Text = "";
            txtP205user.Text = "";
            txtPbrayuser.Text = "";
            txtPhuser.Text = "";
            txtRetensiuser.Text = "";
            txtCOrganikuser.Text = "";

            txtSP36.Text = "";
            txtUrea.Text = "";
            txtKCL.Text = "";
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
                    
                    //check neospectra device
                    if (statusProcess == 1)
                    {
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
                    }
                    //check background
                    else if (statusProcess == 2)
                    {
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
                    }
                    //check scan
                    else if (statusProcess == 3)
                    {
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
                    }
                    //check data
                    else if (statusProcess == 4)
                    {
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
                                        txtPH.Text = Data.PH_H2O.ToString();
                                        txtK205.Text = Data.HCl25_K2O.ToString();
                                        txtCOrganik.Text = Data.C_N.ToString();
                                        txtRetensi.Text = Data.RetensiP.ToString();
                                        txtNTotal.Text = Data.KJELDAHL_N.ToString();
                                        txtKadd.Text = Data.K.ToString();
                                        txtKTK.Text = Data.KTK.ToString();
                                        txtCadd.Text = Data.Ca.ToString();
                                        txtPbray.Text = Data.Bray1_P2O5.ToString();
                                        txtMgdd.Text = Data.Mg.ToString();
                                        txtPOlsen.Text = Data.Olsen_P2O5.ToString();
                                        txtP205.Text = Data.HCl25_P2O5.ToString();
                                        txtSAND.Text = Data.SAND.ToString();
                                        txtSILT.Text = Data.SILT.ToString();
                                        txtClay.Text = Data.CLAY.ToString();
                                        txtJumlah.Text = Data.Jumlah.ToString();
                                        txtKbAjusted.Text = Data.KB_adjusted.ToString();
                                        txtMorgan.Text = Data.Morgan_K2O.ToString();
                                        txtNa.Text = Data.Na.ToString();
                                        txtPhKcl.Text = Data.PH_KCL.ToString();
                                        txtWbc.Text = Data.WBC.ToString();

                                        txtK205user.Text = Data.HCl25_K2O.ToString();
                                        txtCOrganikuser.Text = Data.C_N.ToString();
                                        txtKdduser.Text = Data.K.ToString();
                                        txtKtkuser.Text = Data.KTK.ToString();
                                        txtNtotaluser.Text = Data.KJELDAHL_N.ToString();
                                        txtP205user.Text = Data.Olsen_P2O5.ToString();
                                        txtPbrayuser.Text = Data.Bray1_P2O5.ToString();
                                        txtPhuser.Text = Data.PH_H2O.ToString();
                                        txtRetensiuser.Text = Data.RetensiP.ToString();

                                            // textbox rekomendasi
                                            var calc = new FertilizerCalculator(DataRekomendasi);
                                        txtUrea.Text = calc.GetFertilizerDoze(Data.C_N, "Padi", "Urea").ToString();
                                        txtSP36.Text = calc.GetFertilizerDoze(Data.HCl25_P2O5, "Padi", "SP36").ToString();
                                        txtKCL.Text = calc.GetFertilizerDoze(Data.HCl25_K2O, "Padi", "KCL").ToString();

                                        Writelog("Process Finish....");
                                        setButtonEnable(true);
                                        Data = null;
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
                                        txtPH.Text = Data.PH_H2O.ToString();
                                        txtK205.Text = Data.HCl25_K2O.ToString();
                                        txtCOrganik.Text = Data.C_N.ToString();
                                        txtRetensi.Text = Data.RetensiP.ToString();
                                        txtNTotal.Text = Data.KJELDAHL_N.ToString();
                                        txtKadd.Text = Data.K.ToString();
                                        txtKTK.Text = Data.KTK.ToString();
                                        txtCadd.Text = Data.Ca.ToString();
                                        txtPbray.Text = Data.Bray1_P2O5.ToString();
                                        txtMgdd.Text = Data.Mg.ToString();
                                        txtPOlsen.Text = Data.Olsen_P2O5.ToString();
                                        txtP205.Text = Data.HCl25_P2O5.ToString();
                                        txtSAND.Text = Data.SAND.ToString();
                                        txtSILT.Text = Data.SILT.ToString();
                                        txtClay.Text = Data.CLAY.ToString();
                                        txtJumlah.Text = Data.Jumlah.ToString();
                                        txtKbAjusted.Text = Data.KB_adjusted.ToString();
                                        txtMorgan.Text = Data.Morgan_K2O.ToString();
                                        txtNa.Text = Data.Na.ToString();
                                        txtPhKcl.Text = Data.PH_KCL.ToString();
                                        txtWbc.Text = Data.WBC.ToString();

                                        txtK205user.Text = Data.HCl25_K2O.ToString();
                                        txtCOrganikuser.Text = Data.C_N.ToString();
                                        txtKdduser.Text = Data.K.ToString();
                                        txtKtkuser.Text = Data.KTK.ToString();
                                        txtNtotaluser.Text = Data.KJELDAHL_N.ToString();
                                        txtP205user.Text = Data.Olsen_P2O5.ToString();
                                        txtPbrayuser.Text = Data.Bray1_P2O5.ToString();
                                        txtPhuser.Text = Data.PH_H2O.ToString();
                                        txtRetensiuser.Text = Data.RetensiP.ToString();

                                        // textbox rekomendasi
                                        var calc = new FertilizerCalculator(DataRekomendasi);
                                        txtUrea.Text = calc.GetFertilizerDoze(Data.C_N, "Padi", "Urea").ToString();
                                        txtSP36.Text = calc.GetFertilizerDoze(Data.HCl25_P2O5, "Padi", "SP36").ToString();
                                        txtKCL.Text = calc.GetFertilizerDoze(Data.HCl25_K2O, "Padi", "KCL").ToString();

                                        Writelog("Process Finish....");
                                        setButtonEnable(true);
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
            if (statusProcess == 1)
            {
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
            }
            else if (statusProcess == 2)
            {
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
            }
            if (statusProcess == 3)
            {
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
            }
            if (statusProcess == 4)
            {
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
                    foreach(var series in chartWave.Series)
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

        //private async Task CalcProcess_DoWork()
        //{
        //    var DataRekomendasi = ConfigurationManager.AppSettings["DataRekomendasi"];
        //    try
        //    {
        //        MethodInvoker doProcessInvoker = delegate ()
        //        {
        //            Writelog("Do Calculating Elements.... Please wait for a while....");
        //            statusProcess = 4;
        //            setButtonEnable(false);
        //            SoilNutritionModel snm = new SoilNutritionModel();
        //            var Data = snm.InferenceModel();

        //            if (Data != null)
        //            {
        //                // textbox unsur tanah
        //                txtPH.Text = Data.PH_H2O.ToString();
        //                txtK205.Text = Data.HCl25_K2O.ToString();
        //                txtCOrganik.Text = Data.C_N.ToString();
        //                txtRetensi.Text = Data.RetensiP.ToString();
        //                txtNTotal.Text = Data.KJELDAHL_N.ToString();
        //                txtKadd.Text = Data.K.ToString();
        //                txtKTK.Text = Data.KTK.ToString();
        //                txtCadd.Text = Data.Ca.ToString();
        //                txtPbray.Text = Data.Bray1_P2O5.ToString();
        //                txtMgdd.Text = Data.Mg.ToString();
        //                txtPOlsen.Text = Data.Olsen_P2O5.ToString();
        //                txtP205.Text = Data.HCl25_P2O5.ToString();
        //                txtSAND.Text = Data.SAND.ToString();
        //                txtSILT.Text = Data.SILT.ToString();
        //                txtClay.Text = Data.CLAY.ToString();
        //                txtJumlah.Text = Data.Jumlah.ToString();
        //                txtxKbAjusted.Text = Data.KB_adjusted.ToString();
        //                txtMorgan.Text = Data.Morgan_K2O.ToString();
        //                txtNa.Text = Data.Na.ToString();
        //                txtPhKcl.Text = Data.PH_KCL.ToString();
        //                txtWbc.Text = Data.WBC.ToString();

        //                txtK205user.Text = Data.HCl25_K2O.ToString();
        //                txtCOrganikuser.Text = Data.C_N.ToString();
        //                txtKdduser.Text = Data.K.ToString();
        //                txtKtkuser.Text = Data.KTK.ToString();
        //                txtNtotaluser.Text = Data.KJELDAHL_N.ToString();
        //                txtP205user.Text = Data.Olsen_P2O5.ToString();
        //                txtPbrayuser.Text = Data.Bray1_P2O5.ToString();
        //                txtPhuser.Text = Data.PH_H2O.ToString();
        //                txtRetensiuser.Text = Data.RetensiP.ToString();

        //                // textbox rekomendasi
        //                var calc = new FertilizerCalculator(DataRekomendasi);
        //                txtUrea.Text = calc.GetFertilizerDoze(Data.C_N, "Padi", "Urea").ToString();
        //                txtSP36.Text = calc.GetFertilizerDoze(Data.HCl25_P2O5, "Padi", "SP36").ToString();
        //                txtKCL.Text = calc.GetFertilizerDoze(Data.HCl25_K2O, "Padi", "KCL").ToString();

        //                Writelog("Process Finish....");
        //                setButtonEnable(true);
        //                statusProcess = 0;
        //            }
        //        };
        //        if (this.InvokeRequired)
        //        { this.Invoke(doProcessInvoker); }
        //        //else
        //        //{
        //        //    Writelog("Do Calculating Elements.... Please wait for a while....");
        //        //    statusProcess = 4;
        //        //    setButtonEnable(false);
        //        //    SoilNutritionModel snm = new SoilNutritionModel();
        //        //    var Data = snm.InferenceModel();

        //        //    if (Data != null)
        //        //    {
        //        //        // textbox unsur tanah
        //        //        txtPH.Text = Data.PH_H2O.ToString();
        //        //        txtK205.Text = Data.HCl25_K2O.ToString();
        //        //        txtCOrganik.Text = Data.C_N.ToString();
        //        //        txtRetensi.Text = Data.RetensiP.ToString();
        //        //        txtNTotal.Text = Data.KJELDAHL_N.ToString();
        //        //        txtKadd.Text = Data.K.ToString();
        //        //        txtKTK.Text = Data.KTK.ToString();
        //        //        txtCadd.Text = Data.Ca.ToString();
        //        //        txtPbray.Text = Data.Bray1_P2O5.ToString();
        //        //        txtMgdd.Text = Data.Mg.ToString();
        //        //        txtPOlsen.Text = Data.Olsen_P2O5.ToString();
        //        //        txtP205.Text = Data.HCl25_P2O5.ToString();
        //        //        txtSAND.Text = Data.SAND.ToString();
        //        //        txtSILT.Text = Data.SILT.ToString();
        //        //        txtClay.Text = Data.CLAY.ToString();
        //        //        txtJumlah.Text = Data.Jumlah.ToString();
        //        //        txtxKbAjusted.Text = Data.KB_adjusted.ToString();
        //        //        txtMorgan.Text = Data.Morgan_K2O.ToString();
        //        //        txtNa.Text = Data.Na.ToString();
        //        //        txtPhKcl.Text = Data.PH_KCL.ToString();
        //        //        txtWbc.Text = Data.WBC.ToString();

        //        //        txtK205user.Text = Data.HCl25_K2O.ToString();
        //        //        txtCOrganikuser.Text = Data.C_N.ToString();
        //        //        txtKdduser.Text = Data.K.ToString();
        //        //        txtKtkuser.Text = Data.KTK.ToString();
        //        //        txtNtotaluser.Text = Data.KJELDAHL_N.ToString();
        //        //        txtP205user.Text = Data.Olsen_P2O5.ToString();
        //        //        txtPbrayuser.Text = Data.Bray1_P2O5.ToString();
        //        //        txtPhuser.Text = Data.PH_H2O.ToString();
        //        //        txtRetensiuser.Text = Data.RetensiP.ToString();

        //        //        // textbox rekomendasi
        //        //        var calc = new FertilizerCalculator(DataRekomendasi);
        //        //        txtUrea.Text = calc.GetFertilizerDoze(Data.C_N, "Padi", "Urea").ToString();
        //        //        txtSP36.Text = calc.GetFertilizerDoze(Data.HCl25_P2O5, "Padi", "SP36").ToString();
        //        //        txtKCL.Text = calc.GetFertilizerDoze(Data.HCl25_K2O, "Padi", "KCL").ToString();

        //        //        Writelog("Process Finish....");
        //        //        setButtonEnable(true);
        //        //        statusProcess = 0;
        //        //    }
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex);
        //        Logs.WriteAppLog(ex.ToString());
        //    }
        //}

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

        private void EntryFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoopCheckDevice.Abort();
            //Process.Start("shutdown", "/s /t 5");
            Environment.Exit(0);
        }

        private void chkAdvance_OnChange(object sender, EventArgs e)
        {
            if (chkAdvance.Checked == true)
            {
                pnlAdvance.Show();
                pnlUser.Hide();
            }
            else if (chkAdvance.Checked == false)
            {
                pnlUser.Show();
                pnlAdvance.Hide();
            }
        }
    }

    public class FileScan
    {
        public DateTime CreatedDate { get; set; }
        public string FullName { get; set; }
        public string Name { get; set; }
    }
}
