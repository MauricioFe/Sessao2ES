using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sessao2Api.Models
{
    public class Jogos
    {
        public int Cod_camp { get; set; }
        public int Cod_time1 { get; set; }
        public int Cod_time2 { get; set; }
        public int Cod_estadio { get; set; }
        public DateTime Data { get; set; }
        public int resultado { get; set; }
    }
}
