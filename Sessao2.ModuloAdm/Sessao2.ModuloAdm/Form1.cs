using Sessao2.ModuloAdm.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Sessao2.ModuloAdm
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }
        string URI = "http://localhost:5005/wstowers/api/jogos";

        private void Form1_Load(object sender, EventArgs e)
        {
            Jogos jogos = new Jogos();
            jogos.Cod_camp = 3;
            jogos.Cod_time1 = 1;
            jogos.Cod_time2 = 3;
            jogos.Cod_estadio = 7;
            jogos.Data = DateTime.Now.Date;
            jogos.Resultado = 0;
            Get();
            //Post(jogos);
            //Delete(jogos.Cod_camp, jogos.Cod_time1, jogos.Cod_time2);
            //jogos.Resultado = 1;
            //Put(jogos.Cod_camp, jogos.Cod_time1, jogos.Cod_time2, jogos);
        }

        private async void Get()
        {
            List<Jogos> jogosList = new List<Jogos>();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(URI);
                var jogos = await response.Content.ReadAsStringAsync();
                jogosList = new JavaScriptSerializer().Deserialize<List<Jogos>>(jogos);
                dataGridView1.DataSource = jogosList;
            }
        }

        private async void Put(int cod_camp, int cod_time1, int cod_time2, Jogos jogos)
        {
            using (var cliente = new HttpClient())
            {
                var parseJson = new DataContractJsonSerializer(typeof(Jogos));
                MemoryStream memory = new MemoryStream();
                parseJson.WriteObject(memory, jogos);
                var jsonString = Encoding.UTF8.GetString(memory.ToArray());
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var result = await cliente.PutAsync($"{URI}/atualizar/{cod_camp}/{cod_time1}/{cod_time2}", content);
            }
        }

        private async void Delete(int codCampeonato, int codTime1, int codTime2)
        {
            using (var cliente = new HttpClient())
            {
                var result = await cliente.DeleteAsync($"{URI}/excluir/{codCampeonato}/{codTime1}/{codTime2}");
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
                var result = await cliente.PostAsync($"{URI}/cadastrar", content);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
