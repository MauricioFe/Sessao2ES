using Sessao2.ModuloMarketing.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sessao2.ModuloMarketing
{
    public partial class FrmArte : Form
    {
        Jogos jogos;
        List<Jogadores> jogadoresList;
        public FrmArte(Jogos jogos, List<Jogadores> jogadoresList)
        {
            InitializeComponent();
            this.jogos= jogos;
            this.jogadoresList = jogadoresList;
            lblCampeonato.Text = jogos.Campeonatos.ToUpper();
            lblTime1.Text= jogos.Time1.ToUpper();
            lblTime2.Text= jogos.Time2.ToUpper();
            lblSeuTime.Text.ToUpper();
            lblSuplentes.Text.ToUpper();
            lblData.Text = jogos.Data.Date.ToString("dd/MM/yyyy").ToUpper();
            lblEstadio.Text=jogos.Estadio.ToUpper();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void FrmArte_Load(object sender, EventArgs e)
        {
   
        }


    }
}
