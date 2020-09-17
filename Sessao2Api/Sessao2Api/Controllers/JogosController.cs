using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using Sessao2Api.Data;
using Sessao2Api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sessao2Api.Controllers
{
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly IJogosDAL _dal;

        public JogosController(IJogosDAL dal)
        {
            _dal = dal;
        }
        [Route("wstowers/api/[controller]")]
        [HttpGet]
        public IEnumerable<Jogos> Get()
        {
            return _dal.GetAll();
        }
        [HttpGet]
        [Route("wstowers/api/[controller]/arte")]
        public IEnumerable<Jogos> GetArt()
        {
            return _dal.GetJogosArte();
        }
        [HttpGet]
        [Route("wstowers/api/relatorios/GetJogosDiferencaSalarialMaiorQue50")]
        public IEnumerable<List<Jogos>> GetJogosDiferencaSalarialMaiorQue50([FromHeader] string tokenTowersGerencia, [FromHeader] string tipoRetorno)
        {
            if (tokenTowersGerencia != "fb29e141-7b39-46a0-a36d-e5ae3c828da9")
            {
                return null;
            }
            if (tipoRetorno == "XML")
            {
                HttpContext.Response.ContentType = "Application/xml";
                return _dal.GetJogosDiferencaSalarialMaiorQue50();
            }
            return _dal.GetJogosDiferencaSalarialMaiorQue50();
        }

        [HttpGet]

        [Route("wstowers/api/relatorios/GetJogosAtuarIntervaloMenorQue3Dias")]
        public IEnumerable<List<Jogos>> GetJogosAtuarIntervaloMenorQue3Dias([FromHeader] string tokenTowersGerencia, [FromHeader] string tipoDeRetorno)
        {
            if (tokenTowersGerencia != "fb29e141-7b39-46a0-a36d-e5ae3c828da9")
            {
                return null;
            }
            if (tipoDeRetorno == "XML")
            {
                HttpContext.Response.ContentType = "Application/xml";
                return _dal.GetJogosAtuarIntervaloMenorQue3Dias();
            }
            return _dal.GetJogosAtuarIntervaloMenorQue3Dias();
        }

        [HttpGet]
        [Route("wstowers/api/relatorios/GetJogosMenorFolhaSalarialVenceu")]
        public IEnumerable<List<Jogos>> GetJogosMenorFolhaSalarialVenceu([FromHeader] string tokenTowersGerencia, [FromHeader] string tipoRetorno)
        {

            if (tokenTowersGerencia != "fb29e141-7b39-46a0-a36d-e5ae3c828da9")
            {
                return null;
            }
            if (tipoRetorno == "XML")
            {
                HttpContext.Response.ContentType = "Application/xml";
                return _dal.GetJogosMenorFolhaSalarialVenceu();
            }
            return _dal.GetJogosMenorFolhaSalarialVenceu();
        }
        [HttpPost]
        [Route("wstowers/api/[controller]/cadastrar")]
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

        [Route("wstowers/api/[controller]/atualizar/{codCamp}/{codtime1}/{codtime2}")]
        public IActionResult Put(int codCamp, int codTime1, int codTime2, [FromBody] Jogos jogos)
        {
            if (jogos == null)
            {
                return BadRequest();
            }
            _dal.Update(jogos, codCamp, codTime1, codTime2);
            return Ok("Operação realizada com sucesso");
        }

        [Route("wstowers/api/[controller]/excluir/{codCamp}/{codtime1}/{codtime2}")]
        public IActionResult Delete(int codCamp, int codTime1, int codTime2)
        {
            _dal.Remove(codCamp, codTime1, codTime2);
            return Ok("Operação realizada com sucesso");
        }
    }
}
