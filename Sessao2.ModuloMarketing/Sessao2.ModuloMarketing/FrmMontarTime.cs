using Sessao2.ModuloMarketing.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Sessao2.ModuloMarketing
{
    public partial class FrmMontarTime : Form
    {
        public FrmMontarTime()
        {
            InitializeComponent();
        }
        int codTime = 0;
        public FrmMontarTime(int codTime)
        {
            InitializeComponent();
            this.codTime = codTime;
           

        }

        private void FrmMontarTime_Load(object sender, EventArgs e)
        {
            FrmMenu.ArredondaButton(btnArte);
            GerarCamisas(codTime);
        }
        List<Jogadores> jogadoresList = new List<Jogadores>();
        private async void GerarCamisas(int codTime)
        {

            using (var client = new HttpClient())
            {
                var parseJson = await client.GetAsync($"{FrmMenu.URI}/jogadores/times/{codTime}");
                var result = await parseJson.Content.ReadAsStringAsync();
                jogadoresList = new JavaScriptSerializer().Deserialize<List<Jogadores>>(result);
            }

            foreach (var item in jogadoresList)
            {
                this.Controls.Add(GetPanelTimes(GetptbCamisa(), GetlblNome(item.Nome), GetlblPosicao(item.PosicaoStr)));
            }

        }
        int location = 0;
        PictureBox ptbCamisa;
        Panel pnlJogador;
        private Panel GetPanelTimes(PictureBox ptbCamisa, Label lblNome, Label lblPosicao)
        {
            pnlJogador = new Panel();
            pnlJogador.Controls.Add(lblNome);
            pnlJogador.Controls.Add(lblPosicao);
            pnlJogador.Controls.Add(ptbCamisa);
            pnlJogador.Location = new System.Drawing.Point(500 + location, 64);
            pnlJogador.Name = "pnlJogador";
            pnlJogador.BringToFront();
            pnlJogador.Size = new System.Drawing.Size(153, 158);
            pnlJogador.TabIndex = 0;
            location += 150;
            return pnlJogador;
        }
        private PictureBox GetptbCamisa()
        {
            ptbCamisa = new PictureBox();
            ptbCamisa.AllowDrop = true;
            ptbCamisa.Image = global::Sessao2.ModuloMarketing.Properties.Resources.camisa;
            ptbCamisa.Location = new System.Drawing.Point(45, 30);
            ptbCamisa.Name = "ptbCamisa";
            ptbCamisa.Size = new System.Drawing.Size(100, 95);
            ptbCamisa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            ptbCamisa.TabIndex = 1;
            ptbCamisa.TabStop = false;
            return ptbCamisa;
        }

        Label lblNome;
        private Label GetlblNome(string nome)
        {
            lblNome = new Label();
            lblNome.AutoSize = true;
            lblNome.AllowDrop = true;
            lblNome.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblNome.Location = new System.Drawing.Point(46, 128);
            lblNome.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lblNome.Name = "lblNome";
            lblNome.Size = new System.Drawing.Size(150, 28);
            lblNome.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            lblNome.TabIndex = 3;
            lblNome.Text = nome;
            return lblNome;
        }
        Label lblPosicao;
        public Label GetlblPosicao(string posicao)
        {
            lblPosicao = new Label();
            lblPosicao.AutoSize = true;
            lblPosicao.AllowDrop = true;
            lblPosicao.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblPosicao.Location = new System.Drawing.Point(46, 9);
            lblPosicao.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lblPosicao.Name = "lblPosicao1";
            lblPosicao.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            lblPosicao.Size = new System.Drawing.Size(98, 28);
            lblPosicao.TabIndex = 2;
            lblPosicao.Text = posicao;
            return lblPosicao;
        }

        private void ptbCamisa_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ptbCamisa.DoDragDrop(ptbCamisa.Image, DragDropEffects.Move);
                lblPosicao.DoDragDrop(lblPosicao.Text, DragDropEffects.Move);
                lblNome.DoDragDrop(lblNome.Text, DragDropEffects.Move);
            }
        }
        Point dragPoint = Point.Empty;
        bool dragging = false;
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragPoint = new Point(e.X, e.Y);
        }
        private void pic_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
                label1.Location = new Point(label1.Location.X + e.X - dragPoint.X, label1.Location.Y + e.Y - dragPoint.Y);
        }

        private void pic_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}