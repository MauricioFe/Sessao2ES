using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Sessao2.ModuloGerencial.Models
{
    class Tabela
    {
        public string Campeonato { get; set; }
        public string Time { get; set; }
        public int Derrotas { get; set; }
        public int Empate { get; set; }
        public int Vitorias { get; set; }
        public int CodTime { get; set; }
        public int CodCamp { get; set; }
        public List<int> CodTime1List { get; internal set; }
    }
}
