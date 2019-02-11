using Grpc.Core;
using PKDSS.CoreLibrary;
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
        //NamedPipesCom comm;
        public EntryFrm()
        {
            InitializeComponent();
            Setup();

            //Looping check device is ready
            Thread LoopCheckDevice = new Thread(RequestIsDeviceReady);
            LoopCheckDevice.Start();
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
            cbTekstur.Items.Clear();
            cbKomoditas.Items.Add("Padi");
            cbKomoditas.Items.Add("Jagung");
            cbKomoditas.Items.Add("Kedelai");
            cbTekstur.Items.Add("Sand");
            cbTekstur.Items.Add("Loamy Sand");
            cbTekstur.Items.Add("Sandy Loam");
            cbTekstur.Items.Add("Loam");
            cbTekstur.Items.Add("Loamy Silt");
            cbTekstur.Items.Add("Silt");
            cbTekstur.Items.Add("Silty Loam");
            cbTekstur.Items.Add("Sandy Clay Loam");
            cbTekstur.Items.Add("Silty Clay Loam");
            cbTekstur.Items.Add("Sandy Clay");
            cbTekstur.Items.Add("Silty Clay");
            cbTekstur.Items.Add("Clay");
            btnCalc.Click += BtnCalculate_Click;
            //just for demo
            txtNTotal.Text = "0.01";
            txtP205.Text = "2";
            txtK205.Text = "2";
            cbKomoditas.SelectedIndex = 0;
            cbTekstur.SelectedIndex = 0;
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

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                var calc = new FertilizerCalculator();
                txtUrea.Text = calc.GetFertilizerDoze(double.Parse(txtNTotal.Text), cbKomoditas.SelectedItem.ToString(), "Urea").ToString();
                txtSP36.Text = calc.GetFertilizerDoze(double.Parse(txtP205.Text), cbKomoditas.SelectedItem.ToString(), "SP36").ToString();
                txtKCL.Text = calc.GetFertilizerDoze(double.Parse(txtK205.Text), cbKomoditas.SelectedItem.ToString(), "KCL").ToString();
            }
            catch { }
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
        }

        private async void btnScan_Click_1(object sender, EventArgs e)
        {
            var client = new Datahub.MessageHub.MessageHubClient(channel);
            var reply = await client.DoScanAsync(new Datahub.DataRequest { Parameter = "" });

            //channel.ShutdownAsync().Wait();
            //comm.SendMessage("Scan");
        }

        private void btnProcess_Click_1(object sender, EventArgs e)
        {

        }
    }

    public class DataGelombang
    {
        public List<double> wavenumber { get; set; }
        public List<double> absorbance { get; set; }

    }
    public class FileScan
    {
        public DateTime CreatedDate { get; set; }
        public string FullName { get; set; }
        public string Name { get; set; }
    }
}
