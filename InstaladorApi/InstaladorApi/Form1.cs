using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Management;
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

            this.BackColor = Color.Magenta;
            this.TransparencyKey = Color.Magenta;
            this.FormBorderStyle = FormBorderStyle.None;

        }

        private void FrmApi_Load(object sender, EventArgs e)
        {
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            //GraphicsPath path = new GraphicsPath();
            //path.AddEllipse(0, 0, btnIniciar.Width, btnIniciar.Height);
            //btnIniciar.Region = new Region(path);
        }
        Process processo = new Process();
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            bool ativo = isFirewallEnabled();
            if (!ativo)
            {
                lblStaus.Text = "INICIADO";
                lblStaus.Visible = true;
                processo.StartInfo.FileName = @"C:\ApiWSTower\Sessao2Api.exe";
                processo.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                lblFirewall.Visible = false;
                processo.Start();
            }
            else
            {
                lblStaus.Text = "PARADO";
                lblStaus.Visible = true;
                lblFirewall.Visible = true;
            }



        }

        private void btnParar_Click(object sender, EventArgs e)
        {

            Process[] macProcessos = Process.GetProcessesByName("Sessao2Api");
            lblStaus.Text = "PARADO";
            lblStaus.Visible = true;
            lblFirewall.Visible = false;
            foreach (Process processo in macProcessos)
            {
                processo.CloseMainWindow();
            }
        }

        public static bool isFirewallEnabled()
        {
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Services\\SharedAccess\\Parameters\\FirewallPolicy\\StandardProfile"))
                {
                    if (key == null)
                    {
                        return false;
                    }
                    else
                    {
                        Object o = key.GetValue("EnableFirewall");
                        if (o == null)
                        {
                            return false;
                        }
                        else
                        {
                            int firewall = (int)o;
                            if (firewall == 1)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmApi_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process[] macProcessos = Process.GetProcessesByName("Sessao2Api");
            foreach (Process processo in macProcessos)
            {
                processo.CloseMainWindow();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
