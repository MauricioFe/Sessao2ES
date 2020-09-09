using Sessao2.ModuloAdm.Models;
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

namespace Sessao2.ModuloAdm
{
    public partial class FrmGerenciaJogadores : Form
    {
        public FrmGerenciaJogadores()
        {
            InitializeComponent();
        }
        public async void AtaulizaGridAsync()
        {
            List<Jogadores> jogadoresList = new List<Jogadores>();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{FrmMenu.URI}/jogadores");
                var jogadores = await response.Content.ReadAsStringAsync();
                jogadoresList = new JavaScriptSerializer().Deserialize<List<Jogadores>>(jogadores);
                //dgvJogos.DataSource = jogosList;
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
                cboTime.DataSource = posicoesList;
                cboTime.DisplayMember = "Nom_time";
                cboTime.ValueMember = "Cod_time";
            }
        }
        private void FrmGerenciaJogadores_Load(object sender, EventArgs e)
        {
            AtualizaCboTime();
            AtaulizaGridAsync();
        }
    }
}
