using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sessao2Api.Models
{
    public class Historicos
    {
        public int Cod_jog { get; set; }
        public DateTime Dat_ini { get; set; }
        public int Cod_time { get; set; }
        public Nullable<DateTime> Dat_fim { get; set; }
        public string Time { get; set; }
        public string Jogador { get; set; }
    }
}
