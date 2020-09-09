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

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Post([FromBody] Jogos jogos)
        {
            if (jogos == null)
            {
                return BadRequest();
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
