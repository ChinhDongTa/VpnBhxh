using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetMacAddress
{
    public partial class mainFrm : Form
    {
        public mainFrm()
        {
            InitializeComponent();
        }

        private void mainFrm_Load(object sender, EventArgs e)
        {
            var host = Dns.GetHostAddresses(Dns.GetHostName());
            textBox1.Text= NetworkMacAddress.InsertString(NetworkMacAddress.GetMacAddress(host[1]).ToString());
        }
    }
}
