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
        public OutputConfigFrm()
        {
            InitializeComponent();
            ReadConfig();
        }

        private void ReadConfig()
        {
            string AppPath = Application.StartupPath + "\\outputconfig.json";
            List<OutputData> ReadData = JsonConvert.DeserializeObject<List<OutputData>>(File.ReadAllText(AppPath));

            foreach (var y in ReadData)
            {
                foreach (var i in chklbOutput.Items)
                {
                    if (y.Name == chklbOutput.GetItemText(i) && y.Status == CheckState.Checked)
                    {
                        chklbOutput.SetItemChecked(chklbOutput.Items.IndexOf(i), true);
                        break;
                    }
                }
            };
        }

        private void btnConfigOK_Click(object sender, EventArgs e)
        {
            string message = "Aksi ini membutuhkan restart applikasi \nApakah anda ingin restart?";

            var obj = new MessageBoxForm(message);
            obj.ShowDialog();

            if (obj.dialogResult == true)
            {
                List<OutputData> Datas = new List<OutputData>();
                foreach (object item in chklbOutput.Items)
                {
                    OutputData data1 = new OutputData
                    {
                        Name = chklbOutput.GetItemText(item),
                        Status = chklbOutput.GetItemCheckState(chklbOutput.Items.IndexOf(item)),
                    };

                    Datas.Add(data1);
                }

                var jsonData = JsonConvert.SerializeObject(Datas, Formatting.None);
                string AppPath = Application.StartupPath;
                File.WriteAllText(AppPath + "\\outputconfig.json", jsonData);

                //var EntryFrm = new EntryFrm();
                //EntryFrm.ReadConfig();
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
        public CheckState Status { get; set; }
    }
}
