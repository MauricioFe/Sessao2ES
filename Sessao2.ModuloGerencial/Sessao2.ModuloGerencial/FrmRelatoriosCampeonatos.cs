using Sessao2.ModuloGerencial.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
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
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (cboTipoRelatorio.SelectedIndex == 0)
            {
                dgvTabela.Visible = true;
                chart1.Visible = true;
            }
        }

        private void FrmRelatoriosCampeonatos_Load(object sender, EventArgs e)
        {
            AtualizaGrid();
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
            var r = chart1.HitTest(e.X, e.Y);

            if (r.ChartElementType == ChartElementType.DataPoint)

            {
                var pointEndX = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
                var list = (List<Tabela>)chart1.DataSource;

                //round to the nearest whole number
                pointEndX = Math.Round(pointEndX, 0);

                //subtract 1 because bars start at 1 and List/Array are 0 indexed
                int index = ((int)pointEndX) - 1;

                if (index < 0 || index >= list.Count)
                    return;

                var tabela = list[index];
                MessageBox.Show(tabela.Campeonato + " " + tabela.Time);
            }
        }
    }
}
