using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PKDSS.PortableApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Setup();
        }

        void Setup()
        {
            BtnEntry.Click += AllButton_Click;
            BtnAbout.Click += AllButton_Click;
            BtnPengaturan.Click += AllButton_Click;
            BtnRekomendasi.Click += AllButton_Click;
            BtnUpdate.Click += AllButton_Click;
            BtnExit.Click += AllButton_Click;
            BtnExit.Visibility = Visibility.Collapsed;
            /*
            var newWidth = this.Width / 2;
            BtnEntry.Width = newWidth;
            BtnAbout.Width = newWidth;
            BtnPengaturan.Width = newWidth;
            BtnRekomendasi.Width = newWidth;
            BtnUpdate.Width = newWidth;
            */
        }

        private async void AllButton_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            switch (btn.Name)
            {
                case "BtnEntry":
                    Frame.Navigate(typeof(EntryPage),"Nothing");
                    break;
                case "BtnExit":
                    CoreApplication.Exit();
                    break;
                default:
                    var dialog = new MessageDialog("Maaf, menu belum tersedia");
                    await dialog.ShowAsync();
                    //do nothing
                    break;
            }
        }
    }
}
