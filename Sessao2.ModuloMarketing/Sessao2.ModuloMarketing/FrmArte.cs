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
        public FrmArte()
        {
            InitializeComponent();
            lblCampeonato.Text.ToUpper();
            lblTime1.Text.ToUpper();
            lblTime2.Text.ToUpper();
            lblSeuTime.Text.ToUpper();
            lblSuplentes.Text.ToUpper();
            lblData.Text.ToUpper();
            lblEstadio.Text.ToUpper();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
