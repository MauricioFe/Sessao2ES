using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sessao2Api.Models
{
    public class Campeonatos
    {
        public int Cod_camp { get; set; }
        public string Descricao { get; set; }
        public int  Ano { get; set; }
        public string Tipo { get; set; }
        public string DataInicio{ get; set; }
        public string DataFim { get; set; }
        public string Def_tipo { get; set; }
    }
}
