﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sessao2Api.Models
{
    public class Jogadores
    {
        public int Cod_jog { get; set; }
        public DateTime Dat_nasc { get; set; }
        public decimal Salario { get; set; }
        public int  Cod_pos { get; set; }
        public string Nom_jog { get; set; }
        public int Cod_time { get; set; }
        public string Time { get; set; }
        public string Posicao { get; set; }
    }
}
