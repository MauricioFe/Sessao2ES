using Sessao2.ModuloMarketing.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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
        Jogos jogos;
        public FrmMontarTime(int codTime, Jogos jogos)
        {
            InitializeComponent();
            this.codTime = codTime;
            GerarCamisas(codTime);
            this.jogos = jogos;
        }

        private void FrmMontarTime_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            FrmMenu.ArredondaButton(btnArte);
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
            int cont = 0;
            foreach (var item in jogadoresList)
            {
                cont++;
                this.Controls.Add(GetPanelTimes(cont, GetptbCamisa(), GetlblNome(item.Nome), GetlblPosicao(item.PosicaoStr)));
            }
            this.Controls.SetChildIndex(pictureBox1, 10000);
            this.Controls.SetChildIndex(panel1, 10000);
            int zIndex = this.Controls.GetChildIndex(pictureBox1);
        }
        int location = 0;
        PictureBox ptbCamisa;
        Panel pnlJogador;
        private Panel GetPanelTimes(int idForName, PictureBox ptbCamisa, Label lblNome, Label lblPosicao)
        {

            pnlJogador = new Panel();
            pnlJogador.Controls.Add(lblNome);
            pnlJogador.Controls.Add(lblPosicao);
            pnlJogador.Controls.Add(ptbCamisa);
            pnlJogador.BackColor = Color.Transparent;
            pnlJogador.Location = new System.Drawing.Point(500 + location, 64);
            pnlJogador.Name = "pnlJogador" + idForName;
            pnlJogador.BringToFront();
            pnlJogador.Size = new System.Drawing.Size(140, 140);
            pnlJogador.TabIndex = 0;
            pnlJogador.MouseDown += pnlJogador_MouseDown;
            pnlJogador.MouseMove += pnlJogador_MouseMove;
            pnlJogador.MouseUp += pnlJogador_MouseUp;
            location += 150;
            return pnlJogador;
        }

        private void pnlJogador_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void pnlJogador_MouseMove(object sender, MouseEventArgs e)
        {
            Panel pnl = (Panel)sender;
            if (dragging)
                pnl.Location = new Point(pnl.Location.X + e.X - dragPoint.X, pnl.Location.Y + e.Y - dragPoint.Y);
        }

        private void pnlJogador_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragPoint = new Point(e.X, e.Y);
        }

        private PictureBox GetptbCamisa()
        {
            ptbCamisa = new PictureBox();
            ptbCamisa.AllowDrop = true;
            ptbCamisa.Image = global::Sessao2.ModuloMarketing.Properties.Resources.camisa;
            ptbCamisa.Location = new System.Drawing.Point(20, 20);
            ptbCamisa.Name = "ptbCamisa";
            ptbCamisa.Size = new System.Drawing.Size(100, 100);
            ptbCamisa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            ptbCamisa.TabIndex = 1;
            ptbCamisa.TabStop = false;
            ptbCamisa.MouseDown += PtbCamisa_MouseDown;
            ptbCamisa.MouseMove += PtbCamisa_MouseMove;
            ptbCamisa.MouseUp += PtbCamisa_MouseUp;
            return ptbCamisa;
        }

        private void PtbCamisa_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void PtbCamisa_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox ptbCamisaJogador = (PictureBox)sender;
            Panel pnl = (Panel)ptbCamisaJogador.Parent;
            if (dragging)
                pnl.Location = new Point(pnl.Location.X + e.X - dragPoint.X, pnl.Location.Y + e.Y - dragPoint.Y);
        }

        private void PtbCamisa_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragPoint = new Point(e.X, e.Y);
        }

        Label lblNome;
        private Label GetlblNome(string nome)
        {
            lblNome = new Label();
            lblNome.AllowDrop = true;
            lblNome.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblNome.Location = new System.Drawing.Point(0, 98);
            lblNome.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lblNome.Name = "lblNome";
            lblNome.Size = new System.Drawing.Size(140, 28);
            lblNome.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            lblNome.TabIndex = 3;
            lblNome.Text = nome;
            lblNome.TextAlign = ContentAlignment.MiddleCenter;
            lblNome.MouseDown += LblNome_MouseDown;
            lblNome.MouseMove += LblNome_MouseMove;
            lblNome.MouseUp += LblNome_MouseUp;
            return lblNome;
        }

        private void LblNome_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void LblNome_MouseMove(object sender, MouseEventArgs e)
        {
            Label lblNomeJogador = (Label)sender;
            Panel pnl = (Panel)lblNomeJogador.Parent;
            if (dragging)
                pnl.Location = new Point(pnl.Location.X + e.X - dragPoint.X, pnl.Location.Y + e.Y - dragPoint.Y);
        }

        private void LblNome_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragPoint = new Point(e.X, e.Y);
        }

        Label lblPosicao;
        public Label GetlblPosicao(string posicao)
        {
            lblPosicao = new Label();
            lblPosicao.AutoSize = false;
            lblPosicao.AllowDrop = true;
            lblPosicao.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblPosicao.Location = new System.Drawing.Point(0, 9);
            lblPosicao.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lblPosicao.Name = "lblPosicao1";
            lblPosicao.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            lblPosicao.Size = new System.Drawing.Size(140, 28);
            lblPosicao.TabIndex = 2;
            lblPosicao.Text = posicao;
            lblPosicao.TextAlign = ContentAlignment.MiddleCenter;
            lblPosicao.MouseDown += LblPosicao_MouseDown;
            lblPosicao.MouseMove += LblPosicao_MouseMove;
            lblPosicao.MouseUp += LblPosicao_MouseUp;
            return lblPosicao;
        }

        private void LblPosicao_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void LblPosicao_MouseMove(object sender, MouseEventArgs e)
        {
            Label lblPosicaoJogador = (Label)sender;
            Panel pnl = (Panel)lblPosicaoJogador.Parent;
            if (dragging)
                pnl.Location = new Point(pnl.Location.X + e.X - dragPoint.X, pnl.Location.Y + e.Y - dragPoint.Y);
        }

        private void LblPosicao_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragPoint = new Point(e.X, e.Y);
        }
        Point dragPoint = Point.Empty;
        bool dragging = false;

        private void btnArte_Click(object sender, EventArgs e)
        {
            List<string> nomesSuplentes = new List<string>();
            foreach (var item in this.Controls)
            {
                if (item is Panel)
                {
                    Panel pnlSuplentes = (Panel)item;
                    if (pnlSuplentes.Location.X > 460)
                    {
                        foreach (var label in pnlSuplentes.Controls)
                        {
                            if (label is Label)
                            {
                                Label lblSuplentes = (Label)label;
                                if (lblSuplentes.Name.Contains("Nome"))
                                {
                                    nomesSuplentes.Add(lblSuplentes.Text);
                                }
                            }
                        }
                        
                    }
                }
            }
            //Definimos qual a dimensão do bitmap
            //A utilização do Bounds.Width irá permitir que o programa "saiba" onde começa a aplicação
            Bitmap printscreen = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(printscreen, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
            String path;


            FrmArte form = new FrmArte(jogos, nomesSuplentes, printscreen);
            form.ShowDialog();


            
            
        }
    }
}