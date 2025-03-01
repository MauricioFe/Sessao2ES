﻿using Sessao2.ModuloGerencial.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Sessao2.ModuloGerencial
{
    public partial class FrmRelatoriosCampeonatos : Form
    {
        public FrmRelatoriosCampeonatos()
        {
            InitializeComponent();
        }
        string URI = "http://localhost:5005/wstowers/api/campeonatos";
        string URI_JOGOS = "http://localhost:5005/wstowers/api";
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (cboTipoRelatorio.SelectedIndex == 0)
            {
                dgvTabela.Visible = true;
                chart1.Visible = true;
                dgvPares.Visible = false;
            }
            else if (cboTipoRelatorio.SelectedIndex == 1)
            {
                dgvTabela.Visible = false;
                chart1.Visible = false;
                dgvPares.Visible = true;
            }
        }

        private void FrmRelatoriosCampeonatos_Load(object sender, EventArgs e)
        {
            AtualizaGrid();
            AtualizaGridPares();
        }

        List<Tabela> tabelaList = new List<Tabela>();
        private async void AtualizaGrid()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{URI}/tabela");
                var tabela = await response.Content.ReadAsStringAsync();
                tabelaList = new JavaScriptSerializer().Deserialize<List<Tabela>>(tabela);
                dgvTabela.DataSource = tabelaList;
                chart1.DataSource = tabelaList;

                foreach (var item in tabelaList)
                {
                    chart1.Series[0].Points.AddXY(item.Time + "\n" + item.Campeonato, item.Empate);
                    chart1.Series[1].Points.AddXY(item.Time, item.Vitorias);
                    chart1.Series[2].Points.AddXY(item.Time, item.Derrotas);
                }

                chart1.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
                chart1.ChartAreas[0].AxisX.Interval = 1;
                chart1.ChartAreas[0].AxisX.Minimum = 0;
                chart1.ChartAreas[0].AxisX.Maximum = tabelaList.Count;


            }
        }


        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            // objeto da classe HitTest que serve para mapear o gráfico a partir dos eixos X e Y da tela
            //Nesse caso estou pegando a partir de onde foi clicado
            var result = chart1.HitTest(e.X, e.Y);
            //verificando se o click foi dentro dos dados que vem do gráfico
            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                //pegando a posição aproximada a partir do click do mouse em pixels
                var pointEndX = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
                var bacon = result.Series.Name;

                //instaciando a lista que está no data source do grafico
                var list = (List<Tabela>)chart1.DataSource;
                //Como o valor da posicao vem em pixels ele é um double com isso é arredondado para o inteiro mais proximo
                pointEndX = Math.Round(pointEndX, 0);

                //Aqui como o index de uma lista começa em 0 vou subtrair do pointEndX por 1 ja que a posição da
                //primeira coluna é um e ficar compativel com o indice certo na lista.
                int index = ((int)pointEndX) - 1;
                //valido o index
                if (index < 0 || index >= list.Count)
                    return;
                //pego um objeto de tabela baseado no index clicado
                var tabela = list[index];
                if (bacon == "Empates")
                {
                    JogosTime(tabela.CodCamp, tabela.CodTime, 0);
                }
                else if (bacon == "Vitorias")
                {
                    JogosTime(tabela.CodCamp, tabela.CodTime, 1);
                }
                else if (bacon == "Derrotas")
                {
                    JogosTime(tabela.CodCamp, tabela.CodTime, 2);
                }

                MessageBox.Show("Aguarde alguns segundo para processar a requisicao");
            }
        }

        private async void JogosTime(int codCamp, int codTime, int resultado)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{URI_JOGOS}/jogos/{codCamp}/{codTime}/{resultado}");
                var jogos = await response.Content.ReadAsStringAsync();
                var jogosList = new JavaScriptSerializer().Deserialize<List<Jogos>>(jogos);
                FrmResultGraphClick form = new FrmResultGraphClick(jogosList);
                form.ShowDialog();
            }
        }

        private async void AtualizaGridPares()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{URI}/pares");
                var campeonatos = await response.Content.ReadAsStringAsync();
                var campeonatosList = new JavaScriptSerializer().Deserialize<List<List<Campeonato>>>(campeonatos);
                List<Pares> paresList = new List<Pares>();
                List<Campeonato> pares1 = campeonatosList[0];
                List<Campeonato> pares2 = campeonatosList[1];
                for (int j = 0; j < pares1.Count; j++)
                {
                    for (int i = j + 1; i < pares1.Count; i++)
                    {
                        Pares par = new Pares();
                        par.Campeonato1 = pares1[j].Descricao;
                        par.Campeonato2 = pares1[i].Descricao;
                        paresList.Add(par);
                    }
                }
                for (int j = 0; j < pares2.Count; j++)
                {
                    for (int i = j + 1; i < pares2.Count; i++)
                    {
                        Pares par = new Pares();
                        par.Campeonato1 = pares2[j].Descricao;
                        par.Campeonato2 = pares2[i].Descricao;
                        paresList.Add(par);
                    }
                }
                dgvPares.DataSource = paresList;

            }
        }
    }
}
