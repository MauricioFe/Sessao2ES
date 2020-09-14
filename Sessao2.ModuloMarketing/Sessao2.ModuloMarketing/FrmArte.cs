using Sessao2.ModuloMarketing.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sessao2.ModuloMarketing
{
    public partial class FrmArte : Form
    {
        Jogos jogos;
        List<string> suplentesList;
        public FrmArte(Jogos jogos, List<string> suplentesList, Bitmap escalacao)
        {
            InitializeComponent();
            this.jogos = jogos;
            this.suplentesList = suplentesList;
            lblCampeonato.Text = jogos.Campeonatos.ToUpper();
            lblTime1.Text = jogos.Time1.ToUpper();
            lblTime2.Text = jogos.Time2.ToUpper();
            lblSeuTime.Text.ToUpper();
            lblSuplentes.Text.ToUpper();
            lblData.Text = jogos.Data.Date.ToString("dd/MM/yyyy").ToUpper();
            lblEstadio.Text = jogos.Estadio.ToUpper();
            ptbEscalacao.Image = (Image)escalacao;
            ptbEscalacao.SizeMode = PictureBoxSizeMode.Zoom;
            foreach (var item in suplentesList)
            {
                this.Controls.Add(GeraSuplentes(item));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void FrmArte_Load(object sender, EventArgs e)
        {
            Bitmap bitmapArte = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bitmapArte, new Rectangle(0, 0, this.Width, this.Height));
            bitmapArte.Save(@"C:\Users\mauri\Desktop\Bacon.jpg", ImageFormat.Jpeg);
            this.Dispose();
        }
        int location = 0;
        public Label GeraSuplentes(string nome)
        {
            Label lblSuplentes = new Label();
            lblSuplentes.Location = new System.Drawing.Point(407, 323 + location);
            lblSuplentes.Name = nome;
            lblSuplentes.Size = new System.Drawing.Size(142, 19);
            lblSuplentes.TabIndex = 11;
            lblSuplentes.Text = nome;
            location += 23;
            return lblSuplentes;
        }
    }
}
