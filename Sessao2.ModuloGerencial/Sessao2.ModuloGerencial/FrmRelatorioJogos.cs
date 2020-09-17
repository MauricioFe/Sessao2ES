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
        List<List<Jogos>> jogosList = new List<List<Jogos>>();
        private void FrmRelatorioJogos_Load(object sender, EventArgs e)
        {


        }
        public async void GetJogosMenorSalarioGanhador()
        {

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("tokenTowersGerencia", "fb29e141-7b39-46a0-a36d-e5ae3c828da9");
                var response = await client.GetAsync($"{URI}/GetJogosMenorFolhaSalarialVenceu");
                var jogos = await response.Content.ReadAsStringAsync();
                jogosList = new JavaScriptSerializer().Deserialize<List<List<Jogos>>>(jogos);
                int cont = 0;
                foreach (var list in jogosList)
                {
                    if (list.Count > 0)
                    {
                        foreach (var item in list)
                        {
                            if (cont > 0)
                            {
                                locationCampeonatos = GeraPanelCampeonato(item.Campeonatos).Height + (GeraPanelJogos(item.Time1, item.Time2, item.Resultado, item.Data.ToString("dd/MM/yyyy")).Height * list.Count);
                                locationJogos = locationCampeonatos++;
                            }
                            else
                            {
                                locationCampeonatos = 0;
                                locationJogos = 0;
                            }
                            panel1.Controls.Add(GeraPanelCampeonato(item.Campeonatos));
                            panel1.Controls.Add(GeraPanelJogos(item.Time1, item.Time2, item.Resultado, item.Data.ToString("dd/MM/yyyy")));
                            cont++;
                        }
                    }
                }

            }
        }



        int locationCampeonatos = 0;
        public Panel GeraPanelCampeonato(string camp)
        {
            Panel pnlCampeonato = new Panel();
            pnlCampeonato.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(107)))));
            pnlCampeonato.ForeColor = System.Drawing.Color.White;
            pnlCampeonato.Location = new System.Drawing.Point(0, 0 + locationCampeonatos);
            pnlCampeonato.Name = "pnlCampeonato";
            pnlCampeonato.Size = new System.Drawing.Size(928, 43);
            pnlCampeonato.TabIndex = 0;
            pnlCampeonato.Controls.Add(GeraLabelCameonato(camp));
            return pnlCampeonato;
        }
        int locationJogos = 0;
        public Panel GeraPanelJogos(string time1, string time2, int resultado, string data)
        {
            Panel pnlJogos = new Panel();
            pnlJogos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            pnlJogos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlJogos.ForeColor = System.Drawing.Color.White;
            pnlJogos.Location = new System.Drawing.Point(0, 43 + locationJogos);
            pnlJogos.Name = "pnlJogos";
            pnlJogos.Size = new System.Drawing.Size(928, 43);
            pnlJogos.TabIndex = 1;
            pnlJogos.Controls.Add(GeraLabelData(data));
            pnlJogos.Controls.Add(GeraLabelTime1(time1));
            pnlJogos.Controls.Add(GeraLabelV());
            pnlJogos.Controls.Add(GeraLabelTime2(time2));
            pnlJogos.Controls.Add(GeraLabelResultado(resultado));
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

        private Label GeraLabelTime1(string time1)
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
        private Label GeraLabelV()
        {
            Label lblV = new Label();
            lblV.AutoSize = true;
            lblV.Location = new System.Drawing.Point(140, 13);
            lblV.Name = "lblV";
            lblV.Size = new System.Drawing.Size(17, 18);
            lblV.TabIndex = 1;
            lblV.Text = "v";
            return lblV;
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
            if (resultado == 1)
            {
                lblResultado.Text = "Vencedor: Casa";
            }else if (resultado == 2)
            {
                lblResultado.Text = "Vencedor: Fora";
            }
            else
            {
                lblResultado.Text = "Empate";
            }
           
            return lblResultado;
        }

        private void btnJogos3_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            if (cboTipoRelatorio.SelectedIndex == 2)
            {
                GetJogosMenorSalarioGanhador();
            } 
            else if(cboTipoRelatorio.SelectedIndex == 1)
            {
                GetJogosDiferencaSalarialMaiorQue50();
            }
            else
            {
                GetJogosAtuarIntervaloMenorQue3Dias();
            }
        }

        private async void GetJogosAtuarIntervaloMenorQue3Dias()
        {
            locationCampeonatos = 0;
            locationJogos = 0;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("tokenTowersGerencia", "fb29e141-7b39-46a0-a36d-e5ae3c828da9");
                var response = await client.GetAsync($"{URI}/GetJogosAtuarIntervaloMenorQue3Dias");
                var jogos = await response.Content.ReadAsStringAsync();
                jogosList = new JavaScriptSerializer().Deserialize<List<List<Jogos>>>(jogos);
                int cont = 1;
                foreach (var list in jogosList)
                {
                    if (list.Count > 0)
                    {
                        foreach (var item in list)
                        {
                            if (item.Cod_camp == cont)
                            {
                                panel1.Controls.Add(GeraPanelCampeonato(item.Campeonatos));
                                locationCampeonatos += (list.Count * GeraPanelJogos(item.Time1, item.Time2, item.Resultado, item.Data.ToString("dd/MM/yyyy")).Height + GeraPanelCampeonato(item.Campeonatos).Height);
                                cont++;
                                if (locationJogos != 0)
                                {
                                    locationJogos += 43;
                                }
                            }
                            panel1.Controls.Add(GeraPanelJogos(item.Time1, item.Time2, item.Resultado, item.Data.ToString("dd/MM/yyyy")));
                            locationJogos += GeraPanelCampeonato(item.Campeonatos).Height;
                        }
                    }
                }

            }
        }

        private async void GetJogosDiferencaSalarialMaiorQue50()
        {
            locationCampeonatos =0;
            locationJogos =0;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("tokenTowersGerencia", "fb29e141-7b39-46a0-a36d-e5ae3c828da9");
                var response = await client.GetAsync($"{URI}/GetJogosDiferencaSalarialMaiorQue50");
                var jogos = await response.Content.ReadAsStringAsync();
                jogosList = new JavaScriptSerializer().Deserialize<List<List<Jogos>>>(jogos);
                int cont = 1;
                foreach (var list in jogosList)
                {
                    if (list.Count > 0)
                    {
                        foreach (var item in list)
                        {
                            if (item.Cod_camp == cont)
                            {
                                panel1.Controls.Add(GeraPanelCampeonato(item.Campeonatos));
                                locationCampeonatos += (list.Count * GeraPanelJogos(item.Time1, item.Time2, item.Resultado, item.Data.ToString("dd/MM/yyyy")).Height + GeraPanelCampeonato(item.Campeonatos).Height);
                                cont++;
                                if (locationJogos != 0)
                                {
                                    locationJogos += 43;
                                }
                            }
                            panel1.Controls.Add(GeraPanelJogos(item.Time1, item.Time2, item.Resultado, item.Data.ToString("dd/MM/yyyy")));
                           locationJogos += GeraPanelCampeonato(item.Campeonatos).Height;
                        }
                    }
                }

            }
        }
    }
}
