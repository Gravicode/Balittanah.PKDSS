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
    public partial class MessageBoxForm : Form
    {
        public bool dialogResult;
        public MessageBoxForm(string message)
        {
            InitializeComponent();

            lbMessage.Text = message;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            dialogResult = true;
            this.Close();
        }

        private void bunifuImageButtoN2_Click(object sender, EventArgs e)
        {
            dialogResult = false;
            this.Close();
        }
    }
}
