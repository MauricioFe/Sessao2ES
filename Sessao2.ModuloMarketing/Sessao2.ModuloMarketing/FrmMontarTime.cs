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
    public partial class FrmMontarTime : Form
    {
        public FrmMontarTime()
        {
            InitializeComponent();
        }

        private void FrmMontarTime_Load(object sender, EventArgs e)
        {
            FrmMenu.ArredondaButton(btnArte);
            GerarCamisas();
        }

        private void GerarCamisas()
        {
            throw new NotImplementedException();
        }
    }
}
