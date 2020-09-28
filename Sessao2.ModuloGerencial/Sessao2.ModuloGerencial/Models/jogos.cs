using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sessao2.ModuloGerencial.Models
{
    public class Jogos
    {
        public int Cod_camp { get; set; }
        public int Cod_time1 { get; set; }
        public int Cod_time2 { get; set; }
        public int Cod_estadio { get; set; }
        public DateTime Data { get; set; }
        public int Resultado { get; set; }
        public string Time1 { get; set; }
        public string Time2 { get; set; }
        public string Estadio { get; set; }
        public string Campeonatos { get; set; }
    }
}
