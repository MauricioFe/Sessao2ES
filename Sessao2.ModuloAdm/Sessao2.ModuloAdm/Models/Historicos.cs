using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sessao2.ModuloAdm.Models
{
    public class Historicos
    {
        public int Cod_jog { get; set; }
        public DateTime Dat_ini { get; set; }
        public int Cod_time { get; set; }
        public Nullable<DateTime> Dat_fim { get; set; }
    }
}
