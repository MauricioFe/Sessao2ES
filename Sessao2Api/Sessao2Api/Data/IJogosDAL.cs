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
        IEnumerable<Jogos> GetTimeCampeonato(int codCamp, int codTime, int resultado);
        IEnumerable<List<Jogos>> GetJogosAtuarIntervaloMenorQue3Dias();
        IEnumerable<List<Jogos>> GetJogosDiferencaSalarialMaiorQue50();
        IEnumerable<List<Jogos>> GetJogosMenorFolhaSalarialVenceu();
        IEnumerable<Jogos> GetJogosArte();
        void Add(Jogos jogos);
        void Update(Jogos jogos, int codCampeonato, int codTime1, int codTime2);
        void Remove(int codCampeonato, int codTime1, int codTime2);
        bool ValidaJogo48H(int cod_time1, int cod_time2, DateTime data);
        bool ValidaJogoCampeonato(int cod_camp, int cod_time1, int cod_time2);
        bool ValidaDataCampeonato(int cod_camp, DateTime date);

    }
}
