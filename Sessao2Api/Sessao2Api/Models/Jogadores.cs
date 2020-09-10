using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sessao2Api.Models
{
    public class Jogadores
    {
        public int Cod_jog { get; set; }
        public string DataNascimento { get; set; }
        public decimal Salario { get; set; }
        public int  Posicao { get; set; }
        public string Nome { get; set; }
        public int Time { get; set; }
        public string TimeStr { get; set; }
        public string PosicaoStr { get; set; }
    }
}
