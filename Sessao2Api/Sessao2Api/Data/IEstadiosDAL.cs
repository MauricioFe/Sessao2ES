using Sessao2Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sessao2Api.Data
{
    public interface IEstadiosDAL
    {
        IEnumerable<Estadios> GetAll();
        //void add(times jogos);
        //void update(times jogos, int codcampeonato, int codtime1, int codtime2);
        //void remove(int codcampeonato, int codtime1, int codtime2);
    }
}
