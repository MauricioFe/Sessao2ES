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
            try
            {
                using (var cliente = new HttpClient())
                {
                    var parseJson = new DataContractJsonSerializer(typeof(Jogos));
                    MemoryStream memory = new MemoryStream();
                    parseJson.WriteObject(memory, jogos);
                    var jsonString = Encoding.UTF8.GetString(memory.ToArray());
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    var result = await cliente.PostAsync($"{FrmMenu.URI}/jogos/cadastrar", content);
                    AtaulizaGridAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
            MessageBox.Show("Inserido com sucesso");
        }
        public async void Put(Jogos jogos, int cod_camp, int cod_time1, int cod_time2)
        {
            try
            {
                using (var cliente = new HttpClient())
                {
                    var parseJson = new DataContractJsonSerializer(typeof(Jogos));
                    MemoryStream memory = new MemoryStream();
                    parseJson.WriteObject(memory, jogos);
                    var jsonString = Encoding.UTF8.GetString(memory.ToArray());
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    var result = await cliente.PutAsync($"{FrmMenu.URI}/jogos/atualizar/{cod_camp}/{cod_time1}/{cod_time2}", content);
                    AtaulizaGridAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
            MessageBox.Show("Editado com sucesso");
        }
        public async void Delete(int cod_camp, int cod_time1, int cod_time2)
        {
            try
            {
                using (var cliente = new HttpClient())
                {
                    var result = await cliente.DeleteAsync($"{FrmMenu.URI}/jogos/excluir/{cod_camp}/{cod_time1}/{cod_time2}");
                    AtaulizaGridAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
            MessageBox.Show("Deletado com sucesso");
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
            List<Campeonatos> campeonatosList = new List<Campeonatos>();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{FrmMenu.URI}/campeonatos");
                var campeonatos = await response.Content.ReadAsStringAsync();
                campeonatosList = new JavaScriptSerializer().Deserialize<List<Campeonatos>>(campeonatos);
                cboCampeonato.DataSource = campeonatosList;
                cboCampeonato.DisplayMember = "Dsc_camp";
                cboCampeonato.ValueMember = "Cod_camp";
            }
        }
        public async void AtualizaCboTime1()
        {
            List<Times> timesList = new List<Times>();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{FrmMenu.URI}/times");
                var times = await response.Content.ReadAsStringAsync();
                timesList = new JavaScriptSerializer().Deserialize<List<Times>>(times);
                cboTime1.DataSource = timesList;
                cboTime1.DisplayMember = "Nom_time";
                cboTime1.ValueMember = "Cod_time";
            }
        }
        public async void AtualizaCboTime2()
        {
            List<Times> timesList = new List<Times>();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{FrmMenu.URI}/times");
                var times = await response.Content.ReadAsStringAsync();
                timesList = new JavaScriptSerializer().Deserialize<List<Times>>(times);
                cboTime2.DataSource = timesList;
                cboTime2.DisplayMember = "Nom_time";
                cboTime2.ValueMember = "Cod_time";
            }
        }

        public async void AtualizaCboEstadios()
        {
            List<Estadios> estadiosList = new List<Estadios>();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{FrmMenu.URI}/estadios");
                var estadios = await response.Content.ReadAsStringAsync();
                estadiosList = new JavaScriptSerializer().Deserialize<List<Estadios>>(estadios);
                cboEstadio.DataSource = estadiosList;
                cboEstadio.DisplayMember = "Nom_est";
                cboEstadio.ValueMember = "Cod_est";
            }
        }
        private void FrmGerenciaJogos_Load(object sender, EventArgs e)
        {
            AtaulizaGridAsync();
            AtualizaCboCampeonatos();
            AtualizaCboTime1();
            AtualizaCboTime2();
            AtualizaCboEstadios();
        }

        private void dgvJogos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cboCampeonato.SelectedValue = dgvJogos.Rows[e.RowIndex].Cells[0].Value;
            cboTime1.SelectedValue = dgvJogos.Rows[e.RowIndex].Cells[1].Value;
            cboTime2.SelectedValue = dgvJogos.Rows[e.RowIndex].Cells[2].Value;
            cboEstadio.SelectedValue = dgvJogos.Rows[e.RowIndex].Cells[3].Value;
            dtpData.Value = Convert.ToDateTime(dgvJogos.Rows[e.RowIndex].Cells[4].Value);
            txtVencedor.Text = dgvJogos.Rows[e.RowIndex].Cells[5].Value.ToString();

        }

        private void btnEditar_Click(object sender, EventArgs e)
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
                Put(jogos, Convert.ToInt32(cboCampeonato.SelectedValue), Convert.ToInt32(cboTime1.SelectedValue), Convert.ToInt32(cboTime2.SelectedValue));

            }
            else
            {
                MessageBox.Show("Preencha todos os campos");
            }
        }
    }
}
