using PKDSS.CoreLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PKDSS.MonoApp
{
    public partial class EntryFrm : Form
    {
        public EntryFrm()
        {
            InitializeComponent();
            Setup();
        }

        void Setup()
        {
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
    }
}
