using Sessao2.ModuloAdm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Sessao2.ModuloAdm
{
    public partial class FrmGerenciaJogos : Form
    {
        public FrmGerenciaJogos()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Jogos jogos = new Jogos();
            if (cboTime1.Text != "" && cboTime2.Text != "" && cboCampeonato.Text != "" && cboEstadio.Text != "" && dtpData.Value != null && txtVencedor.Text != "")
            {
                jogos.Cod_camp = int.Parse(cboCampeonato.SelectedValue.ToString());
                jogos.Cod_time1 = int.Parse(cboTime1.SelectedValue.ToString());
                jogos.Cod_estadio = int.Parse(cboEstadio.SelectedValue.ToString());
                jogos.Cod_time2 = int.Parse(cboTime2.SelectedValue.ToString());
                jogos.Data = dtpData.Value;
                jogos.Resultado = int.Parse(txtVencedor.Text);
                Post(jogos);
            }
            else
            {
                MessageBox.Show("Preencha todos os campos");
            }
        }
        public async void Post(Jogos jogos)
        {
            using (var cliente = new HttpClient())
            {
                var parseJson = new DataContractJsonSerializer(typeof(Jogos));
                MemoryStream memory = new MemoryStream();
                parseJson.WriteObject(memory, jogos);
                var jsonString = Encoding.UTF8.GetString(memory.ToArray());
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var result = await cliente.PostAsync($"{FrmMenu.URI}/jogos/cadastrar", content);
            }
        }
        public async void AtaulizaGridAsync()
        {
            List<Jogos> jogosList = new List<Jogos>();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{FrmMenu.URI}/jogos");
                var jogos = await response.Content.ReadAsStringAsync();
                jogosList = new JavaScriptSerializer().Deserialize<List<Jogos>>(jogos);
                dgvJogos.DataSource = jogosList;
            }
        }
        public async void AtualizaCboCampeonatos()
        {
            List<Campeonatos> jogosList = new List<Campeonatos>();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{FrmMenu.URI}/campeonatos");
                var campeonatos = await response.Content.ReadAsStringAsync();
                jogosList = new JavaScriptSerializer().Deserialize<List<Campeonatos>>(campeonatos);
                .DataSource = jogosList;
            }
        }
        private void FrmGerenciaJogos_Load(object sender, EventArgs e)
        {
            AtaulizaGridAsync();
        }
    }
}
