using Sessao2.ModuloGerencial.Models;
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

namespace Sessao2.ModuloGerencial
{
    public partial class FrmRelatorioJogos : Form
    {
        public FrmRelatorioJogos()
        {
            InitializeComponent();
            
        }
        string URI = "http://localhost:5005/wstowers/api/jogos";
        List<Jogos> jogosList = new List<Jogos>();
        private void FrmRelatorioJogos_Load(object sender, EventArgs e)
        {
            GetJogosMenorSalarioGanhador();
            
        }
        public async void GetJogosMenorSalarioGanhador()
        {

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{URI}/GetJogosMenorFolhaSalarialVenceu");
                var jogos = await response.Content.ReadAsStringAsync();
                string cod_campTemp = null;
                jogosList = new JavaScriptSerializer().Deserialize<List<Jogos>>(jogos);
                foreach (var item in jogosList)
                {
                    cod_campTemp = item.Campeonatos
                    panel1.Controls.Add(GeraPanelCampeonato(item.Campeonatos));
                    panel1.Controls.Add(GeraPanelJogos(item.Time1, item.Time2, item.Resultado, item.Data.ToString("dd/MM/yyyy")));
                }
            }
        }
        int location = 0;
        public Panel GeraPanelCampeonato(string camp)
        {
            Panel pnlCampeonato = new Panel();
            pnlCampeonato.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(107)))));
            pnlCampeonato.ForeColor = System.Drawing.Color.White;
            pnlCampeonato.Location = new System.Drawing.Point(0, 0);
            pnlCampeonato.Name = "pnlCampeonato";
            pnlCampeonato.Size = new System.Drawing.Size(928, 36);
            pnlCampeonato.TabIndex = 0;
            pnlCampeonato.Controls.Add(GeraLabelCameonato(camp));
            return pnlCampeonato;
        }

        public Panel GeraPanelJogos(string time1, string time2, int resultado, string data)
        {
            Panel pnlJogos = new Panel();
            pnlJogos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            pnlJogos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlJogos.ForeColor = System.Drawing.Color.White;
            pnlJogos.Location = new System.Drawing.Point(0, 36 + location);
            pnlJogos.Name = "pnlJogos";
            pnlJogos.Size = new System.Drawing.Size(928, 43);
            pnlJogos.TabIndex = 1;
            pnlJogos.Controls.Add(GeraLabelData(data));
            pnlJogos.Controls.Add(GeraLabelTime1(time1));
            pnlJogos.Controls.Add(GeraLabelTime2(time2));
            pnlJogos.Controls.Add(GeraLabelResultado(resultado));
            location += 43;

            return pnlJogos;
        }
        private Label GeraLabelCameonato(string camp)
        {
            Label lblCampeonato = new Label();
            lblCampeonato.Location = new System.Drawing.Point(3, 0);
            lblCampeonato.Name = "lblCampeonato";
            lblCampeonato.Size = new System.Drawing.Size(928, 36);
            lblCampeonato.TabIndex = 0;
            lblCampeonato.Text = camp;
            lblCampeonato.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            return lblCampeonato;
        }
        private Label GeraLabelData(string data)
        {
            Label lblData = new Label();
            lblData.AutoSize = true;
            lblData.Location = new System.Drawing.Point(816, 13);
            lblData.Name = "lblData";
            lblData.Size = new System.Drawing.Size(88, 17);
            lblData.TabIndex = 4;
            lblData.Text = data;
            return lblData;
        }

        private Label GeraLabelTime1 (string time1)
        {
            Label lblTime1 = new Label();
            lblTime1.AutoSize = true;
            lblTime1.Location = new System.Drawing.Point(3, 13);
            lblTime1.Name = "lblTime1";
            lblTime1.Size = new System.Drawing.Size(88, 17);
            lblTime1.TabIndex = 4;
            lblTime1.Text = time1;
            return lblTime1;
        }
        private Label GeraLabelTime2(string time2)
        {
            Label lblTime2 = new Label();
            lblTime2.AutoSize = true;
            lblTime2.Location = new System.Drawing.Point(217, 13);
            lblTime2.Name = "lblTime2";
            lblTime2.Size = new System.Drawing.Size(88, 17);
            lblTime2.TabIndex = 4;
            lblTime2.Text = time2;
            return lblTime2;
        }
        private Label GeraLabelResultado(int resultado)
        {
            Label lblResultado = new Label();
            lblResultado.AutoSize = true;
            lblResultado.Location = new System.Drawing.Point(435, 13);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new System.Drawing.Size(88, 17);
            lblResultado.TabIndex = 4;
            lblResultado.Text = resultado ==1 ?"Vencedor: Casa": "Vencedor: Fora";
            return lblResultado;
        }

    }
}
