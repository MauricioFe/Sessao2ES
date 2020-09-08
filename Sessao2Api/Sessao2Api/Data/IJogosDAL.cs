using Sessao2Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sessao2Api.Data
{
    public interface IJogosDAL
    {
        IEnumerable<Jogos> GetAll();
        void Add(Jogos jogos);
        void Update(Jogos jogos, int codCampeonato, int codTime1, int codTime2);
        void Remove(int codCampeonato, int codTime1, int codTime2);
    }
}
