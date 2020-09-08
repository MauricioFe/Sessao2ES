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
using System.Windows.Forms;

namespace Sessao2.ModuloAdm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string URI = "http://localhost:5005/wstowers/api/jogos/cadastrar";

        private async void Form1_Load(object sender, EventArgs e)
        {
            Jogos jogos = new Jogos();
            jogos.Cod_camp = 3;
            jogos.Cod_time1 = 1;
            jogos.Cod_time2 = 2;
            jogos.Cod_estadio = 7;
            jogos.Data = DateTime.Now.Date;
            jogos.Resultado = 0;

            using (var cliente = new HttpClient())
            {
                var parseJson = new DataContractJsonSerializer(typeof(Jogos));
                MemoryStream memory = new MemoryStream();
                parseJson.WriteObject(memory,jogos);
                var jsonString = Encoding.UTF8.GetString(memory.ToArray());
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var result = await cliente.PostAsync(URI, content);
                
            }
            

        }
    }
}
