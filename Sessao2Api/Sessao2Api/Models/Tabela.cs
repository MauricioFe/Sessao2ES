using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sessao2Api.Models
{
    public class Tabela
    {
        public string Campeonato { get; set; }
        public string Time { get; set; }
        public int Derrotas { get; set; }
        public int Empate { get; set; }
        public int Vitorias { get; set; }
        public int CodTime { get; internal set; }
        public int Codcamp { get; internal set; }
    }
}
