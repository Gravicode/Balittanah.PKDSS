using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Toolkit.Uwp;
using PKDSS.CoreLibrary;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PKDSS.PortableApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EntryPage : Page
    {
        public EntryPage()
        {
           
            this.InitializeComponent();
            Setup();
        }

        void Setup()
        {
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
            foreach(var item in LocationHelper.GetPropinsi())
            {
                CmbPropinsi.Items.Add(item);
            }
            
            CmbPropinsi.SelectionChanged += CmbPropinsi_SelectionChanged;
            CmbPropinsi.SelectedIndex = 0;
        }

        private void CmbPropinsi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CmbKabupaten.Items.Clear();
            var selProp = CmbPropinsi.SelectedItem.ToString();
            foreach (var item in LocationHelper.GetKabupaten(selProp))
            {
                CmbKabupaten.Items.Add(item);
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), "Nothing");
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
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
