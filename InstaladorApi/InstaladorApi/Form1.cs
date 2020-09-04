using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstaladorApi
{
    public partial class FrmApi : Form
    {
        public FrmApi()
        {
            InitializeComponent();
            label1.Text = "Bem-vindo ao Serviço \n WSTowers";
        }

        private void FrmApi_Load(object sender, EventArgs e)
        {

        }
        Process processo = new Process();
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            lblStaus.Text = "INICIADO";
            lblStaus.Visible = true;
            processo.StartInfo.FileName = @"C:\ApiWSTower\Sessao2Api.exe";
            processo.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            processo.Start();

            
        }

        private void btnParar_Click(object sender, EventArgs e)
        {

            Process[] macProcessos = Process.GetProcessesByName("Sessao2Api"); 
            lblStaus.Text = "PARADO";
            lblStaus.Visible = true;

            foreach (Process processo in macProcessos)
            {
                processo.CloseMainWindow();
            }
        }
    }
}
