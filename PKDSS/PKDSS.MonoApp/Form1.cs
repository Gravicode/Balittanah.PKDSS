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
    public partial class Form1 : Form
    {
        Helper.GpsDevice gps;
        public Form1()
        {
            InitializeComponent();
            gps = new Helper.GpsDevice("COM11");
            gps.StartGPS();
            Setup();
        }

        void Setup()
        {
            //this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            /*
            TxtTitle1.Width = this.Width - 40;
            TxtTitle1.Left = 20;
            TxtTitle1.TextAlign = ContentAlignment.MiddleCenter;
            TxtTitle1.Font = new Font("Arial", 32, FontStyle.Bold);

            TxtTitle2.Width = this.Width - 40;
            TxtTitle2.Left = 20;
            TxtTitle2.TextAlign = ContentAlignment.MiddleCenter;
            TxtTitle2.Font = new Font("Arial", 24, FontStyle.Bold);
            TxtTitle2.Top = TxtTitle1.Top + 40;

            TxtTitle3.Width = this.Width - 40;
            TxtTitle3.Left = 20;
            TxtTitle3.TextAlign = ContentAlignment.MiddleCenter;
            TxtTitle3.Font = new Font("Arial", 18, FontStyle.Bold);
            TxtTitle3.Top = TxtTitle2.Top + 30;*/

            BtnEntry.Click += AllButton_Click; ;
            BtnAbout.Click += AllButton_Click;
            BtnPengaturan.Click += AllButton_Click;
            BtnRekomendasi.Click += AllButton_Click;
            BtnUpdate.Click += AllButton_Click;
            BtnExit.Click += AllButton_Click;
            
            /*
            var newWidth = this.Width / 2;
            BtnEntry.Width = newWidth;
            BtnAbout.Width = newWidth;
            BtnPengaturan.Width = newWidth;
            BtnRekomendasi.Width = newWidth;
            BtnUpdate.Width = newWidth;
            */
        }



        private void AllButton_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            switch (btn.Name)
            {
                case "BtnEntry":
                    var newFrm = new EntryFrm();
                    newFrm.Show();
                    this.Close();

                    break;
                case "BtnExit":
                    Application.Exit();
                    break;
                default:
                    MessageBox.Show("Maaf, menu belum tersedia");

                    break;
            }
        }
    }
}
