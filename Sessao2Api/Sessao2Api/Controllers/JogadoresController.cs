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
    public class JogadoresController : ControllerBase
    {
        private readonly IJogadoresDAL _dal;

        public JogadoresController(IJogadoresDAL dal)
        {
            _dal = dal;
        }

        [HttpGet]
        public IEnumerable<Jogadores> Get()
        {
            return _dal.GetAll();
        }

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Post([FromBody] Jogadores jogadores)
        {
            if (jogadores == null)
            {
                return BadRequest();
            }
            int idade = new DateTime(DateTime.Now.Subtract(jogadores.Dat_nasc).Ticks).Year;
            DateTime anosPercorridos = jogadores.Dat_nasc.AddYears(idade);
            if (anosPercorridos > DateTime.Now)
            {
                idade -= 1;
            }
            if (idade < 17)
            {
                return BadRequest("A idade do jogador deve ser maior que 17");
            }
            _dal.Add(jogadores);
            return Ok("Operação realizada com sucesso");
        }

        [Route("atualizar/{codJogador}")]
        public IActionResult Put(int codJogador, [FromBody] Jogadores jogadores)
        {
            if (jogadores == null)
            {
                return BadRequest();
            }
            _dal.Update(jogadores, codJogador);
            return Ok("Operação realizada com sucesso");
        }

        [Route("excluir/{codJogador}")]
        public IActionResult Delete(int codJogador)
        {
            _dal.Remove(codJogador);
            return Ok("Operação realizada com sucesso");
        }
    }
}
