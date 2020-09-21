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
            }
        }
    }
}
