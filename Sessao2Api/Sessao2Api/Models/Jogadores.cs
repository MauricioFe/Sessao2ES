using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sessao2Api.Models
{
    public class jogadores
    {
        public int Cod_jog { get; set; }
        public DateTime Dat_nasc { get; set; }
        public decimal Salario { get; set; }
        public int  Cod_pos { get; set; }
        public string Nom_jog { get; set; }
        public int Cod_time { get; set; }
    }
}
