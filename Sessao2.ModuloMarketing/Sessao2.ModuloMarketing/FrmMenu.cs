using Sessao2.ModuloMarketing.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Sessao2.ModuloMarketing
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }
        public static string URI = "http://localhost:5005/wstowers/api";

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
        public async void AtaulizaGridAsync()
        {
            List<Jogos> jogosList = new List<Jogos>();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{URI}/jogos");
                var jogos = await response.Content.ReadAsStringAsync();
                jogosList = new JavaScriptSerializer().Deserialize<List<Jogos>>(jogos);
                //dgvJogos.DataSource = jogosList;
                dgvJogos.Rows.Clear();
                foreach (var item in jogosList)
                {
                    int n = dgvJogos.Rows.Add();
                    dgvJogos.Rows[n].Cells[0].Value = item.Campeonatos;
                    dgvJogos.Rows[n].Cells[1].Value = item.Time1;
                    dgvJogos.Rows[n].Cells[2].Value = item.Time2;
                    dgvJogos.Rows[n].Cells[3].Value = item.Estadio;
                    dgvJogos.Rows[n].Cells[4].Value = item.Data;
                    dgvJogos.Rows[n].Cells[5].Value = item.Resultado;
                    dgvJogos.Rows[n].Cells[6].Value = item.Cod_camp;
                    dgvJogos.Rows[n].Cells[7].Value = item.Cod_time1;
                    dgvJogos.Rows[n].Cells[8].Value = item.Cod_time2;
                    dgvJogos.Rows[n].Cells[9].Value = item.Cod_estadio;

                }
            }
        }
        private void FrmMenu_Load(object sender, EventArgs e)
        {
            ArredondaButton(btnEscalar);
            AtaulizaGridAsync();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnEscalar_Click(object sender, EventArgs e)
        {

        }
    }
}
