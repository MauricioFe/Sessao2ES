using Sessao2Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sessao2Api.Data
{
    public interface IJogadoresDAL
    {
        IEnumerable<Jogadores> GetAll();
        void Add(Jogadores jogadores);
        void Update(Jogadores jogadores, int cod_jogadores);
        bool Remove(int cod_jogadores);
    }
}
