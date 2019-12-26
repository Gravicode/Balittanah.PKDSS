using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace PKDSS.MonoApp
{
    public partial class OutputConfigFrm : Form
    {
        List<OutputData> ReadDataSort = new List<OutputData>();
        public OutputConfigFrm()
        {
            InitializeComponent();
            ReadConfig();
        }

        private void ReadConfig()
        {
            chklbOutput.Items.Clear();
            string AppPath = Application.StartupPath + "\\outputconfig.json";
            List<OutputData> ReadData = JsonConvert.DeserializeObject<List<OutputData>>(File.ReadAllText(AppPath));
            ReadDataSort = ReadData.OrderBy(x => x.No).ToList<OutputData>();

            foreach (var y in ReadDataSort)
            {
                chklbOutput.Items.Add(y.Initial, y.Status);
            };
        }

        private void btnConfigOK_Click(object sender, EventArgs e)
        {
            string message = "Aksi ini membutuhkan restart applikasi \nApakah anda ingin restart?";

            var obj = new MessageBoxForm(message);
            obj.ShowDialog();

            if (obj.dialogResult == true)
            {
                //List<OutputData> Datas = new List<OutputData>();
                foreach (var item in chklbOutput.Items)
                {
                    foreach (var data in ReadDataSort)
                    {
                        if (data.Initial == chklbOutput.GetItemText(item))
                        {
                            data.Status = chklbOutput.GetItemCheckState(chklbOutput.Items.IndexOf(item));
                        }
                    }
                }

                var jsonData = JsonConvert.SerializeObject(ReadDataSort, Formatting.None);
                string AppPath = Application.StartupPath;
                File.WriteAllText(AppPath + "\\outputconfig.json", jsonData);

                this.Close();
                Application.Restart();
            }
        }

        private void btnConfigCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class OutputData
    {
        public string Name { get; set; }
        public string Initial { get; set; }
        public int No { get; set; }
        public CheckState Status { get; set; }
    }
}
