using Sessao2Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sessao2Api.Data
{
    public interface ICampeonatosDAL
    {
        IEnumerable<Campeonatos> GetAll();
        void Add(Campeonatos campeonatos);
        void Update(Campeonatos campeonatos, int codCampeonato);
        bool Remove(int codCampeonato);
        bool ValidaEdicaoData(int codCamp, int Ano, string dataInicio, string dataFim);
    }
}
