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
        void Update(Jogadores jogadores);
        void Remove(int id);
    }
}
