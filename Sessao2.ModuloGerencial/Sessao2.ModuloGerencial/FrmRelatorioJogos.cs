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
        private void FrmRelatorioJogos_Load(object sender, EventArgs e)
        {

        }
        public async void GetJogosMenorSalarioGanhador()
        {
            List<Jogos> jogosList = new List<Jogos>();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{URI}/GetJogosMenorFolhaSalarialVenceu");
                var jogos = await response.Content.ReadAsStringAsync();
                jogosList = new JavaScriptSerializer().Deserialize<List<Jogos>>(jogos);

            }
        }
    }
}
