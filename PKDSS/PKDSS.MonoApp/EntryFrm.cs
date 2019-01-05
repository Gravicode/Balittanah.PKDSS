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

namespace PKDSS.MonoApp
{
    public partial class EntryFrm : Form
    {
        NamedPipesCom comm;
        public EntryFrm()
        {
            InitializeComponent();
            Setup();
        }

        void Setup()
        {
            comm = new NamedPipesCom();
            comm.DataReceived += (string Message)=>
            {
                Console.WriteLine("data from named pipes :" + Message);
            };
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            CmbKomoditas.Items.Clear();
            CmbTekstur.Items.Clear();
            CmbKomoditas.Items.Add("Padi");
            CmbKomoditas.Items.Add("Jagung");
            CmbKomoditas.Items.Add("Kedelai");
            CmbTekstur.Items.Add("Sand");
            CmbTekstur.Items.Add("Loamy Sand");
            CmbTekstur.Items.Add("Sandy Loam");
            CmbTekstur.Items.Add("Loam");
            CmbTekstur.Items.Add("Loamy Silt");
            CmbTekstur.Items.Add("Silt");
            CmbTekstur.Items.Add("Silty Loam");
            CmbTekstur.Items.Add("Sandy Clay Loam");
            CmbTekstur.Items.Add("Silty Clay Loam");
            CmbTekstur.Items.Add("Sandy Clay");
            CmbTekstur.Items.Add("Silty Clay");
            CmbTekstur.Items.Add("Clay");
            BtnCalculate.Click += BtnCalculate_Click;
            BtnBack.Click += BtnBack_Click;
            //just for demo
            TxtNTotal.Text = "0.01";
            TxtP205.Text = "2";
            TxtK205.Text = "2";
            CmbKomoditas.SelectedIndex = 0;
            CmbTekstur.SelectedIndex = 0;
            //populate propinsi
            CmbPropinsi.Items.Clear();
            foreach (var item in LocationHelper.GetPropinsi())
            {
                CmbPropinsi.Items.Add(item);
            }

            CmbPropinsi.SelectedIndexChanged += CmbPropinsi_SelectionChanged;         
            CmbPropinsi.SelectedIndex = 0;

            BtnProcess.Click += (a, b) => { MessageBox.Show("Maaf, fungsi belum tersedia"); };
            BtnViewChart.Click += BtnViewChart_Click;
            BtnScan.Click += BtnScan_Click;
                
            TimerFile.Enabled = true;
            TimerFile.Start();
   
        }

      

        private async void BtnScan_Click(object sender, EventArgs e)
        {
            /*
            Channel channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);

            var client = new Datahub.MessageHub.MessageHubClient(channel);
          
            var reply = await client.DoScanAsync(new Datahub.DataRequest { Parameter = "" });

            TxtStatus.Text = reply.Result;

            channel.ShutdownAsync().Wait();
            */
            comm.SendMessage("Scan");
        }

        private void BtnViewChart_Click(object sender, EventArgs e)
        {
            var FileSel = LstFiles.SelectedValue.ToString();
            if (FileSel != null)
            {
                RawChart chart = new RawChart();
                chart.LoadFile(FileSel);
                var dt = chart.GetDataGelombangInXY();
                chart1.DataSource = dt;
                chart1.Series["Series1"].XValueMember = "X";
                chart1.Series["Series1"].YValueMembers = "Y";
                chart1.Series["Series1"].ChartType = SeriesChartType.Line;
                chart1.Series["Series1"].IsVisibleInLegend = false;

                chart1.ChartAreas[0].AxisX.Title = "Wave Number";
                chart1.ChartAreas[0].AxisY.Title = "Absorbance";
                chart1.ChartAreas[0].AxisY.LabelStyle.Format = "";
            }
                /*
                var FileSel = LstFiles.SelectedValue.ToString();
                if (FileSel != null)
                {
                    RawChart chart = new RawChart();
                    chart.LoadFile(FileSel);
                    var brush = new SolidBrush(Color.Green);
                    var bmp = chart.DrawChart(PicChart.Size, new Pen(brush));
                    PicChart.Image = bmp;
                    PicChart.Refresh();
                }*/
            }

        private void CmbPropinsi_SelectionChanged(object sender, EventArgs e)
        {
            CmbKabupaten.Items.Clear();
            var selProp = CmbPropinsi.SelectedItem.ToString();
            foreach (var item in LocationHelper.GetKabupaten(selProp))
            {
                CmbKabupaten.Items.Add(item);
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            var newFrm = new Form1();
            newFrm.Show();
            TimerFile.Stop();
            comm.Dispose();
            this.Close();

        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                var calc = new FertilizerCalculator();
                TxtUrea.Text = calc.GetFertilizerDoze(double.Parse(TxtNTotal.Text), CmbKomoditas.SelectedItem.ToString(), "Urea").ToString();
                TxtSP36.Text = calc.GetFertilizerDoze(double.Parse(TxtP205.Text), CmbKomoditas.SelectedItem.ToString(), "SP36").ToString();
                TxtKCL.Text = calc.GetFertilizerDoze(double.Parse(TxtK205.Text), CmbKomoditas.SelectedItem.ToString(), "KCL").ToString();
            }
            catch { }
        }

        static List<FileScan> ScannedFiles;
        private void TimerFile_Tick(object sender, EventArgs e)
        {
            var PathScan = ConfigurationManager.AppSettings["ScanFolder"];
            if (ScannedFiles == null)
                ScannedFiles = new List<FileScan>();
            else
                ScannedFiles.Clear();
            if (Directory.Exists(PathScan))
            {
                var files = Directory.GetFiles(PathScan, "*.json");
                foreach(var item in files)
                {
                    var FileNameNude = Path.GetFileName(item).Replace(Path.GetExtension(item),"");
                    ScannedFiles.Add(new FileScan() { FullName = item, Name=FileNameNude, CreatedDate = new DateTime(  ) });
                }
                //LstFiles.Items.Clear();
                LstFiles.DisplayMember = "Name";
                LstFiles.ValueMember = "FullName";
                LstFiles.DataSource = ScannedFiles;
                
            }
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
