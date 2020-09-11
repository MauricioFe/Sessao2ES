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
                panel1.Controls.Add(GetlblPosicao(item.PosicaoStr));
                panel1.Controls.Add(GetptbCamisa());
                panel1.Controls.Add(GetlblNome(item.Nome));
            }

        }
        int location = 0;
        int location1 = 0;
        int location2 = 0;
        private PictureBox GetptbCamisa()
        {
            PictureBox ptbCamisa = new PictureBox();
            ptbCamisa.Image = global::Sessao2.ModuloMarketing.Properties.Resources.camisa;
            ptbCamisa.Location = new System.Drawing.Point(37 + location, 76);
            ptbCamisa.Name = "ptbCamisa" + location;
            ptbCamisa.Size = new System.Drawing.Size(111, 103);
            ptbCamisa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            ptbCamisa.TabIndex = 1;
            ptbCamisa.TabStop = false;
            location += 195;
            return ptbCamisa;
        }

        private Label GetlblNome(string nome)
        {
            Label lblNome = new Label();

            lblNome.AutoSize = true;
            lblNome.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblNome.Location = new System.Drawing.Point(68 + location1, 184);
            lblNome.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lblNome.Name = "lblNome"+location1;
            lblNome.Size = new System.Drawing.Size(61, 28);
            lblNome.TabIndex = 3;
            lblNome.Text = nome;
            location1 += 68-263;
            return lblNome;
        }

        public Label GetlblPosicao(string posicao )
        {
            Label lblPosicao = new Label();
            lblPosicao.AutoSize = true;
            lblPosicao.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblPosicao.Location = new System.Drawing.Point(34 + location2, 43);
            lblPosicao.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lblPosicao.Name = "lblPosicao1" + location2;
            lblPosicao.Size = new System.Drawing.Size(98, 28);
            lblPosicao.TabIndex = 2;
            lblPosicao.Text = posicao;
            location2 += 261-66;
            return lblPosicao;
        }

    }
}
