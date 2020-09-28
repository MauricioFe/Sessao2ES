using Sessao2.ModuloGerencial.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sessao2.ModuloGerencial
{
    public partial class FrmResultGraphClick : Form
    {
        List<Jogos> jogosList;
        public FrmResultGraphClick(List<Jogos> jogosList)
        {
            this.jogosList = jogosList;
            InitializeComponent();
        }

        private void FrmResultGraphClick_Load(object sender, EventArgs e)
        {
            dgvJogos.Rows.Clear();
            foreach (var item in jogosList)
            {
                int n = dgvJogos.Rows.Add();
                dgvJogos.Rows[n].Cells[0].Value = item.Data.ToString("dd/MM/yyyy");
                dgvJogos.Rows[n].Cells[1].Value = item.Time1;
                dgvJogos.Rows[n].Cells[2].Value = item.Time2;
                dgvJogos.Rows[n].Cells[3].Value = item.Estadio;
            }
        }
    }
}
