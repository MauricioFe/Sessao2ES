using Sessao2Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sessao2Api.Data
{
    public interface IPosicoesDAL
    {
        IEnumerable<Posicoes> GetAll();
        //void add(posicoes jogos);
        //void update(posicoes jogos, int codcampeonato, int codtime1, int codtime2);
        //void remove(int codcampeonato, int codtime1, int codtime2);
    }
}
