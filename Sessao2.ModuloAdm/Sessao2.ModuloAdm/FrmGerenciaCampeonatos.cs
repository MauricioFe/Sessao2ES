using Sessao2.ModuloAdm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Resources;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Sessao2.ModuloAdm
{
    public partial class FrmGerenciaCampeonatos : Form
    {
        public FrmGerenciaCampeonatos()
        {
            InitializeComponent();
        }
        int codCampeonato = 0;
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void FrmGerenciaCampeonatos_Load(object sender, EventArgs e)
        {
            AtualizaGrid();
        }
        public async void AtualizaGrid()
        {
            List<Campeonatos> campeonatosList = new List<Campeonatos>();
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync($"{FrmMenu.URI}/campeonatos");
                    var campeonatos = await response.Content.ReadAsStringAsync();
                    campeonatosList = new JavaScriptSerializer().Deserialize<List<Campeonatos>>(campeonatos);
                    dgvCampeonato.DataSource = campeonatosList;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Erro ao conectar com a api");
            }

        }

        public async void Post(Campeonatos campeonatos)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var parseJson = new JavaScriptSerializer().Serialize(campeonatos);
                    var content = new StringContent(parseJson, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("tokenTowersAdm", "a5b01115-7d82-4f6a-bc45-9fd49eacd2e7");
                    var result = await client.PostAsync($"{FrmMenu.URI}/campeonatos/cadastrar", content);
                    if (result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Inserido com sucesso");
                        AtualizaGrid();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao realizar requisição");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao conectar com a api");
            }
        }
        public async void Put(Campeonatos campeonatos, int codCampeonato)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var parseJson = new JavaScriptSerializer().Serialize(campeonatos);
                    var content = new StringContent(parseJson, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("tokenTowersAdm", "a5b01115-7d82-4f6a-bc45-9fd49eacd2e7");
                    var result = await client.PutAsync($"{FrmMenu.URI}/campeonatos/atualizar/{codCampeonato}", content);
                    if (result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Editado com sucesso");
                        AtualizaGrid();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao realizar requisição");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao conectar com a api");
            }
        }
        public async void Delete(int codCampeonato)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("tokenTowersAdm", "a5b01115-7d82-4f6a-bc45-9fd49eacd2e7");
                    var result = await client.DeleteAsync($"{FrmMenu.URI}/campeonatos/excluir/{codCampeonato}");
                    if (result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Excluído com sucesso");
                        AtualizaGrid();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao realizar requisição");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao conectar com a api");
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Campeonatos campeonatos = new Campeonatos();
            if (txtDescrição.Text != "" && txtAno.Text != "" && cboTipo.Text != "")
            {
                for (int i = 0; i < dgvCampeonato.Rows.Count; i++)
                {
                    campeonatos.Cod_camp = Convert.ToInt32(dgvCampeonato.Rows[i].Cells["Cod_camp"].Value);
                }
                campeonatos.Cod_camp++;
                campeonatos.Descricao = txtDescrição.Text;
                campeonatos.Ano = Convert.ToInt32(txtAno.Text);
                campeonatos.Tipo = cboTipo.Text.Substring(0, 1);
                campeonatos.DataInicio = dtpDataInicio.Value.Date.ToString("yyyyMMdd");
                campeonatos.DataFim = dtpDataFim.Value.Date.ToString("yyyyMMdd");
                campeonatos.Def_tipo = txtTipo.Text == " " ? null : txtTipo.Text;
                Post(campeonatos);
            }
        }

        private void dgvCampeonato_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            codCampeonato = int.Parse(dgvCampeonato.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtDescrição.Text = dgvCampeonato.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtAno.Text = dgvCampeonato.Rows[e.RowIndex].Cells[2].Value.ToString();
            if (dgvCampeonato.Rows[e.RowIndex].Cells[3].Value.ToString() == "E")
            {
                cboTipo.SelectedIndex = 0;
            }
            else if (dgvCampeonato.Rows[e.RowIndex].Cells[3].Value.ToString() == "R")
            {
                cboTipo.SelectedIndex = 2;
            }
            else
            {
                cboTipo.SelectedIndex = 1;
            }
            dtpDataInicio.Value = Convert.ToDateTime(dgvCampeonato.Rows[e.RowIndex].Cells[4].Value);
            dtpDataFim.Value = Convert.ToDateTime(dgvCampeonato.Rows[e.RowIndex].Cells[5].Value);
            txtTipo.Text = dgvCampeonato.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Campeonatos campeonatos = new Campeonatos();
            if (txtDescrição.Text != "" && txtAno.Text != "" && cboTipo.Text != "")
            {
                campeonatos.Cod_camp = codCampeonato;
                campeonatos.Descricao = txtDescrição.Text;
                campeonatos.Ano = Convert.ToInt32(txtAno.Text);
                campeonatos.Tipo = cboTipo.Text.Substring(0, 1);
                campeonatos.DataInicio = dtpDataInicio.Value.Date.ToString("yyyyMMdd");
                campeonatos.DataFim = dtpDataFim.Value.Date.ToString("yyyyMMdd");
                campeonatos.Def_tipo = txtTipo.Text == " " ? null : txtTipo.Text;
                Put(campeonatos, codCampeonato);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Delete(codCampeonato);
        }
    }
}
