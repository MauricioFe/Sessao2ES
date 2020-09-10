using Sessao2Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sessao2Api.Data
{
    public interface IHistoricosDAL
    {
        IEnumerable<Historicos> GetAll();
        void Add(Historicos historicos);
        //void Update(Jogadores historicos, int cod_historicos);
       // void Remove(int cod_historicos);
    }
}
