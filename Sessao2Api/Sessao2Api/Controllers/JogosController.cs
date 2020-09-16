using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sessao2Api.Data;
using Sessao2Api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sessao2Api.Controllers
{
    [Route("wstowers/api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly IJogosDAL _dal;

        public JogosController(IJogosDAL dal)
        {
            _dal = dal;
        }

        [HttpGet]
        public IEnumerable<Jogos> Get()
        {
            return _dal.GetAll();
        }
        [HttpGet]
        [Route("arte")]
        public IEnumerable<Jogos> GetArt()
        {
            return _dal.GetJogosArte();
        }
        [HttpGet]
        [Route("GetJogosDiferencaSalarialMaiorQue50")]
        public IEnumerable<List<Jogos>> GetJogosDiferencaSalarialMaiorQue50()
        {
            return _dal.GetJogosDiferencaSalarialMaiorQue50();
        }

        [HttpGet]
        [Route("GetJogosAtuarIntervaloMenorQue3Dias")]
        public IEnumerable<Jogos> GetJogosAtuarIntervaloMenorQue3Dias()
        {
            var teste = _dal.GetJogosAtuarIntervaloMenorQue3Dias().FirstOrDefault(j => j.Cod_camp == 5 && j.Cod_time1 == 10 && j.Cod_time2 == 7 && j.Data.ToString("yyyy-MM-dd") == "2020-03-27");
            return _dal.GetJogosAtuarIntervaloMenorQue3Dias();
        }

        [HttpGet]
        [Route("GetJogosMenorFolhaSalarialVenceu")]
        public IEnumerable<Jogos> GetJogosMenorFolhaSalarialVenceu()
        {
            return _dal.GetJogosMenorFolhaSalarialVenceu();
        }
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Post([FromBody] Jogos jogos)
        {
            if (jogos == null)
            {
                return BadRequest();
            }

            if (!_dal.ValidaJogo48H(jogos.Cod_time1, jogos.Cod_time2, jogos.Data))
            {
                return BadRequest("Os jogos devem ter um espaço maior que 48 horas para acontecerem");
            }
            if (!_dal.ValidaJogoCampeonato(jogos.Cod_camp, jogos.Cod_time1, jogos.Cod_time2))
            {
                return BadRequest("Os times precisam estar inscritos no mesmo campeonato");
            }
            if (!_dal.ValidaDataCampeonato(jogos.Cod_camp, jogos.Data))
            {
                return BadRequest("A data tem que estar nos limites do campeonato");
            }

            _dal.Add(jogos);
            return Ok("Operação realizada com sucesso");
        }

        [Route("atualizar/{codCamp}/{codtime1}/{codtime2}")]
        public IActionResult Put(int codCamp, int codTime1, int codTime2, [FromBody] Jogos jogos)
        {
            if (jogos == null)
            {
                return BadRequest();
            }
            _dal.Update(jogos, codCamp, codTime1, codTime2);
            return Ok("Operação realizada com sucesso");
        }

        [Route("excluir/{codCamp}/{codtime1}/{codtime2}")]
        public IActionResult Delete(int codCamp, int codTime1, int codTime2)
        {
            _dal.Remove(codCamp, codTime1, codTime2);
            return Ok("Operação realizada com sucesso");
        }
    }
}
