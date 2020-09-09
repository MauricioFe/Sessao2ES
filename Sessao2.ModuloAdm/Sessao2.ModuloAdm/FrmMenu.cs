﻿using Sessao2.ModuloAdm.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        public static string URI = "http://localhost:5005/wstowers/api/jogos";

        public static void ArredondaButton(Button btn)
        {
            Rectangle Rect = new Rectangle(0, 0, btn.Width, btn.Height);
            GraphicsPath GraphPath = new GraphicsPath();
            GraphPath.AddArc(Rect.X, Rect.Y, 50, 50, 180, 90);
            GraphPath.AddArc(Rect.X + Rect.Width - 50, Rect.Y, 50, 50, 270, 90);
            GraphPath.AddArc(Rect.X + Rect.Width - 50, Rect.Y + Rect.Height - 50, 50, 50, 0, 90);
            GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - 50, 50, 50, 90, 90);
            btn.Region = new Region(GraphPath);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ArredondaButton(btnJogos);
            ArredondaButton(btnJogadores);
            ArredondaButton(btnCampeonatos);
            //Delete(3, 1, 3);
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


        private void btnJogos_Click(object sender, EventArgs e)
        {
            FrmGerenciaJogos form = new FrmGerenciaJogos();
            form.Show();
            this.Hide();
        }

        private void btnJogadores_Click(object sender, EventArgs e)
        {
            FrmGerenciaJogadores form = new FrmGerenciaJogadores();
            form.Show();
            this.Hide();
        }

        private void btnCampeonatos_Click(object sender, EventArgs e)
        {
            FrmGerenciaCampeonatos form = new FrmGerenciaCampeonatos();
            form.Show();
            this.Hide();
        }
    }
}
