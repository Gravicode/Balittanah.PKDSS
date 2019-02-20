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

namespace PKDSS.MonoApp
{
    public partial class EntryFrm : Form
    {
        Channel channel = new Channel("localhost:50051", ChannelCredentials.Insecure);
        string ComPort = ConfigurationManager.AppSettings["ComPort"];
        //NamedPipesCom comm;
        public EntryFrm()
        {
            InitializeComponent();
            Setup();

            //Looping check device is ready
            Thread LoopCheckDevice = new Thread(RequestIsDeviceReady);
            LoopCheckDevice.Start();

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
            this.FormBorderStyle = FormBorderStyle.None;
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

            resetAction();

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

        }

        private void resetAction()
        {
            btnBackground.Enabled = true;
            btnBackground.BackColor = Color.FromArgb(29, 134, 255);
            btnScan.Enabled = false;
            btnScan.BackColor = Color.FromArgb(196, 223, 255);
            btnProcess.Enabled = false;
            btnProcess.BackColor = Color.FromArgb(196, 223, 255);

            txtPH.Text = "";
            txtK205.Text = "";
            txtCOrganik.Text = "";
            txtRetensi.Text = "";
            txtNTotal.Text = "";
            txtKadd.Text = "";
            txtKTK.Text = "";
            txtCadd.Text = "";
            txtPbray.Text = "";
            txtMgdd.Text = "";
            txtPOlsen.Text = "";
            txtAIdd.Text = "";
            txtP205.Text = "";
            txtKejenuhanBasa.Text = "";
            
            txtUrea.Text = "";
            txtSP36.Text = "";
            txtKCL.Text = "";

            foreach (var series in chartWave.Series)
            {
                series.Points.Clear();
            }
            chartWave.DataSource = null;

        }

        public void waiteffect(int loop, int time)
        {
            for (int i = 0; i < loop; i++)
            {
                Thread.Sleep(time);
            }
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

                    //if (reply.Result == "Background measurement completed successfully.")
                    //{
                    //    MessageBox.Show("Background success..");
                    //}
                    //else if (reply.Result == "Measurement completed successfully.")
                    //{
                    //    MessageBox.Show("Run success..");
                    //}

                    TxtDeviceStat.Text = reply.Result;

                    //channel.ShutdownAsync().Wait();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
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

        //private void BtnViewChart_Click(object sender, EventArgs e)
        //{
        //    var FileSel = LstFiles.SelectedValue.ToString();
        //    if (FileSel != null)
        //    {
        //        RawChart chart = new RawChart();
        //        chart.LoadFile(FileSel);
        //        var dt = chart.GetDataGelombangInXY();
        //        chartWave.DataSource = dt;
        //        chartWave.Series["Series1"].XValueMember = "X";
        //        chartWave.Series["Series1"].YValueMembers = "Y";
        //        chartWave.Series["Series1"].ChartType = SeriesChartType.Line;
        //        chartWave.Series["Series1"].IsVisibleInLegend = false;

        //        chartWave.ChartAreas[0].AxisX.Title = "Wave Number";
        //        chartWave.ChartAreas[0].AxisY.Title = "Absorbance";
        //        chartWave.ChartAreas[0].AxisY.LabelStyle.Format = "";
        //    }
        //    /*
        //    var FileSel = LstFiles.SelectedValue.ToString();
        //    if (FileSel != null)
        //    {
        //        RawChart chart = new RawChart();
        //        chart.LoadFile(FileSel);
        //        var brush = new SolidBrush(Color.Green);
        //        var bmp = chart.DrawChart(PicChart.Size, new Pen(brush));
        //        PicChart.Image = bmp;
        //        PicChart.Refresh();
        //    }*/
        //}

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

            btnBackground.Enabled = false;
            btnBackground.BackColor = Color.FromArgb(65, 88, 114);
            btnScan.Enabled = true;
            btnScan.BackColor = Color.FromArgb(29, 134, 255);

            waiteffect(4, 2000);
        }

        private async void btnScan_Click(object sender, EventArgs e)
        {
            var client = new Datahub.MessageHub.MessageHubClient(channel);
            var reply = await client.DoScanAsync(new Datahub.DataRequest { Parameter = "" });

            //channel.ShutdownAsync().Wait();
            //comm.SendMessage("Scan");

            btnScan.Enabled = true;
            btnScan.BackColor = Color.FromArgb(65, 88, 114);
            btnProcess.Enabled = true;
            btnProcess.BackColor = Color.FromArgb(29, 134, 255);

            waiteffect(4, 2000);

            ViewChart();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            var DataRekomendasi = ConfigurationManager.AppSettings["DataRekomendasi"];
            try
            {
                SoilNutritionModel snm = new SoilNutritionModel();
                var Data = snm.InferenceModel();

                if (Data != null)
                {
                    // textbox unsur tanah
                    txtPH.Text = Data.PH_H2O.ToString();
                    txtK205.Text = Data.HCl25_K2O.ToString();
                    txtCOrganik.Text = (Data.KJELDAHL_N / Data.C_N).ToString();
                    txtRetensi.Text = Data.RetensiP.ToString();
                    txtNTotal.Text = Data.KJELDAHL_N.ToString();
                    txtKadd.Text = Data.K.ToString();
                    txtKTK.Text = Data.KTK.ToString();
                    txtCadd.Text = Data.Ca.ToString();
                    txtPbray.Text = Data.Bray1_P2O5.ToString();
                    txtMgdd.Text = Data.Mg.ToString();
                    txtPOlsen.Text = Data.Olsen_P2O5.ToString();
                    txtAIdd.Text = "";
                    txtP205.Text = Data.HCl25_P2O5.ToString();
                    txtKejenuhanBasa.Text = "";
                    txtSAND.Text = Data.SAND.ToString();
                    txtSILT.Text = Data.SILT.ToString();
                    txtClay.Text = Data.CLAY.ToString();

                    // textbox rekomendasi
                    var calc = new FertilizerCalculator(DataRekomendasi);
                    txtUrea.Text = calc.GetFertilizerDoze(Data.C_N, "Padi", "Urea").ToString();
                    txtSP36.Text = calc.GetFertilizerDoze(Data.HCl25_P2O5, "Padi", "SP36").ToString();
                    txtKCL.Text = calc.GetFertilizerDoze(Data.HCl25_K2O, "Padi", "KCL").ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetAction();
        }
    }

    //public class DataGelombang
    //{
    //    public List<double> xList { get; set; }
    //    public List<double> yList { get; set; }

    //}
    public class FileScan
    {
        public DateTime CreatedDate { get; set; }
        public string FullName { get; set; }
        public string Name { get; set; }
    }
}
