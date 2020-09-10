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
    public partial class FrmGerenciaJogadores : Form
    {
        public FrmGerenciaJogadores()
        {
            InitializeComponent();
        }
        int CodJogador = 0;
        public async void AtaulizaGridAsync()
        {
            List<Jogadores> jogadoresList = new List<Jogadores>();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{FrmMenu.URI}/jogadores");
                var jogadores = await response.Content.ReadAsStringAsync();
                jogadoresList = new JavaScriptSerializer().Deserialize<List<Jogadores>>(jogadores);
                dgvJogadores.Rows.Clear();
                foreach (var item in jogadoresList)
                {
                    int n = dgvJogadores.Rows.Add();
                    dgvJogadores.Rows[n].Cells[0].Value = item.Nom_jog;
                    dgvJogadores.Rows[n].Cells[1].Value = item.Dat_nasc;
                    dgvJogadores.Rows[n].Cells[2].Value = item.Salario;
                    dgvJogadores.Rows[n].Cells[3].Value = item.Time;
                    dgvJogadores.Rows[n].Cells[4].Value = item.Posicao;
                    dgvJogadores.Rows[n].Cells[5].Value = item.Cod_jog;
                    dgvJogadores.Rows[n].Cells[6].Value = item.Cod_time;
                    dgvJogadores.Rows[n].Cells[7].Value = item.Cod_pos;
                }
            }
        }
        public async void AtualizaCboTime()
        {
            List<Times> timesList = new List<Times>();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{FrmMenu.URI}/times");
                var times = await response.Content.ReadAsStringAsync();
                timesList = new JavaScriptSerializer().Deserialize<List<Times>>(times);
                cboTime.DataSource = timesList;
                cboTime.DisplayMember = "Nom_time";
                cboTime.ValueMember = "Cod_time";
            }
        }

        public async void AtualizaCboPosicao()
        {
            List<Posicoes> posicoesList = new List<Posicoes>();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{FrmMenu.URI}/posicoes");
                var posicao = await response.Content.ReadAsStringAsync();
                posicoesList = new JavaScriptSerializer().Deserialize<List<Posicoes>>(posicao);
                cboPosicao.DataSource = posicoesList;
                cboPosicao.DisplayMember = "Dsc_pos";
                cboPosicao.ValueMember = "Cod_pos";
            }
        }
        private void FrmGerenciaJogadores_Load(object sender, EventArgs e)
        {
            AtualizaCboTime();
            AtaulizaGridAsync();
            AtualizaCboPosicao();
            FrmMenu.ArredondaButton(btnSalvar);
            FrmMenu.ArredondaButton(btnEditar);
            FrmMenu.ArredondaButton(btnExcluir);
        }


        public async void Post(Jogadores jogadores)
        {
            try
            {

                using (var cliente = new HttpClient())
                {
                    var parseJson = new DataContractJsonSerializer(typeof(Jogadores));
                    MemoryStream memory = new MemoryStream();
                    parseJson.WriteObject(memory, jogadores);
                    var jsonString = Encoding.UTF8.GetString(memory.ToArray());
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    var result = await cliente.PostAsync($"{FrmMenu.URI}/jogadores/cadastrar", content);
                    if (result.IsSuccessStatusCode)
                    {
                        Historicos historicos = new Historicos();
                        historicos.Cod_jog = jogadores.Cod_jog;
                        historicos.Dat_ini = DateTime.Now.Date;
                        historicos.Cod_time = jogadores.Cod_time;
                        PostHistorico(historicos);
                        AtaulizaGridAsync();
                        MessageBox.Show("Inserido com sucesso");
                    }
                    else
                    {
                        MessageBox.Show("Erro ao cadastrar Idade mínima 17");
                    }


                }
            }
            catch (Exception)
            {

            }

        }
        private async void PostHistorico(Historicos historicos)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    var parseJson = new DataContractJsonSerializer(typeof(Historicos));
                    MemoryStream memory = new MemoryStream();
                    parseJson.WriteObject(memory, historicos);
                    var jsonString = Encoding.UTF8.GetString(memory.ToArray());
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync($"{FrmMenu.URI}/historicos/cadastrar", content);
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async void Put(Jogadores jogadores, int codJogador)
        {
            try
            {
                using (var cliente = new HttpClient())
                {
                    var parseJson = new DataContractJsonSerializer(typeof(Jogadores));
                    MemoryStream memory = new MemoryStream();
                    parseJson.WriteObject(memory, jogadores);
                    var jsonString = Encoding.UTF8.GetString(memory.ToArray());
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    var result = await cliente.PutAsync($"{FrmMenu.URI}/jogadores/atualizar/{codJogador}", content);
                   
                    if (result.IsSuccessStatusCode)
                    {
                        Historicos historicos = new Historicos();
                        historicos.Cod_jog = jogadores.Cod_jog;
                        historicos.Dat_ini = DateTime.Now.Date;
                        historicos.Cod_time = jogadores.Cod_time;
                        PostHistorico(historicos);
                        AtaulizaGridAsync();
                        MessageBox.Show("Editado com sucesso");
                    }
                   
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async void Delete(int codJogador)
        {
            try
            {
                using (var cliente = new HttpClient())
                {
                    var result = await cliente.DeleteAsync($"{FrmMenu.URI}/jogadores/excluir/{codJogador}");
                    AtaulizaGridAsync();
                    MessageBox.Show("Deletado com sucesso");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Jogadores jogadores = new Jogadores();
            if (txtNome.Text != "" && txtSalario.Text != "" && cboPosicao.Text != "" && cboTime.Text != "" && dtpDataNascimento.Value != null)
            {
                for (int i = 0; i < dgvJogadores.Rows.Count - 1; i++)
                {
                    jogadores.Cod_jog = Convert.ToInt32(dgvJogadores.Rows[i].Cells[5].Value);
                }
                jogadores.Cod_jog++;
                jogadores.Nom_jog = txtNome.Text;
                jogadores.Salario = Decimal.Parse(txtSalario.Text);
                jogadores.Cod_pos = int.Parse(cboPosicao.SelectedValue.ToString());
                jogadores.Cod_time = int.Parse(cboTime.SelectedValue.ToString());
                jogadores.Dat_nasc = dtpDataNascimento.Value;
                Post(jogadores);
            }
            else
            {
                MessageBox.Show("Preencha todos os campos");
            }
        }

        private void dgvJogadores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNome.Text = dgvJogadores.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtSalario.Text = dgvJogadores.Rows[e.RowIndex].Cells[2].Value.ToString();
            dtpDataNascimento.Value = Convert.ToDateTime(dgvJogadores.Rows[e.RowIndex].Cells[1].Value);
            cboPosicao.SelectedValue = dgvJogadores.Rows[e.RowIndex].Cells[7].Value;
            cboTime.SelectedValue = dgvJogadores.Rows[e.RowIndex].Cells[6].Value;
            CodJogador = Convert.ToInt32(dgvJogadores.Rows[e.RowIndex].Cells[5].Value);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Jogadores jogadores = new Jogadores();
            if (txtNome.Text != "" && txtSalario.Text != "" && cboPosicao.Text != "" && cboTime.Text != "" && dtpDataNascimento.Value != null)
            {

                jogadores.Cod_jog = CodJogador;
                jogadores.Nom_jog = txtNome.Text;
                jogadores.Salario = Decimal.Parse(txtSalario.Text);
                jogadores.Cod_pos = int.Parse(cboPosicao.SelectedValue.ToString());
                jogadores.Cod_time = int.Parse(cboTime.SelectedValue.ToString());
                jogadores.Dat_nasc = dtpDataNascimento.Value;
                Put(jogadores, CodJogador);
            }
            else
            {
                MessageBox.Show("Preencha todos os campos");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

            if (txtNome.Text != "" && txtSalario.Text != "" && cboPosicao.Text != "" && cboTime.Text != "" && dtpDataNascimento.Value != null)
            {
                Delete(CodJogador);
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}

