using Sessao2.ModuloAdm.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Sessao2.ModuloAdm
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }
        public static string URI = "http://localhost:5005/wstowers/api";

        public static void ArredondaButton(Button btn)
        {
            Rectangle Rect = new Rectangle(0, 0, btn.Width, btn.Height);
            GraphicsPath GraphPath = new GraphicsPath();
            GraphPath.AddArc(Rect.X, Rect.Y, 50, 50, 180, 90);
            GraphPath.AddArc(Rect.X + Rect.Width - 50, Rect.Y, 50, 50, 270, 90);
            GraphPath.AddArc(Rect.X + Rect.Width - 50, Rect.Y + Rect.Height - 50, 50, 50, 0, 90);
            GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - 50, 50, 50, 90, 90);
            btn.Region = new Region(GraphPath);
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            ArredondaButton(btnJogos);
            ArredondaButton(btnJogadores);
            ArredondaButton(btnCampeonatos);
        }
        private void btnJogos_Click(object sender, EventArgs e)
        {
            FrmGerenciaJogos form = new FrmGerenciaJogos();
            form.ShowDialog();
        }

        private void btnJogadores_Click(object sender, EventArgs e)
        {
            FrmGerenciaJogadores form = new FrmGerenciaJogadores();
            form.ShowDialog();
        }

        private void btnCampeonatos_Click(object sender, EventArgs e)
        {
            FrmGerenciaCampeonatos form = new FrmGerenciaCampeonatos();
            form.ShowDialog();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
