using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ServiceProcess;

namespace Sessao2Api.Models
{
    public class Participacoes
    {
        public int Cod_camp { get; set; }
        public int Cod_time { get; set; }
        public int Pontos { get; set; }
        public int Classificacao { get; set; }
    }
}
