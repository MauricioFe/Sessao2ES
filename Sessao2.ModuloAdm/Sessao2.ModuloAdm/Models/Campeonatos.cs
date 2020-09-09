using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sessao2.ModuloAdm.Models
{
    class Campeonatos
    {
        public int Cod_camp { get; set; }
        public string Dsc_camp { get; set; }
        public int Ano { get; set; }
        public string Tipo { get; set; }
        public DateTime Data_ini { get; set; }
        public DateTime Data_fim { get; set; }
        public string Def_tipo { get; set; }
    }
}
