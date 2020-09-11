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

        [HttpGet]
        [Route("times/{codTime}")]
        public IEnumerable<Jogadores> GetByTime(int codTime)
        {
            return _dal.GetByTime(codTime);
        }

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Post([FromHeader] string tokenTowersAdm, [FromBody] Jogadores jogadores)
        {
            if (tokenTowersAdm == null || tokenTowersAdm != "a5b01115-7d82-4f6a-bc45-9fd49eacd2e7")
            {
                return BadRequest(new
                {
                    Result = "authentication_error",
                    Mesage = "Você não está autorizado a acessar esses dados"
                });
            }
            if (jogadores == null)
            {
                return BadRequest(new
                {
                    Result = "error",
                    Mesage = "Contact the admnistrator"
                });
            }
            DateTime dataNascimento = DateTime.Parse(jogadores.DataNascimento.Insert(4, "-").Insert(7, "-"));
            int idade = new DateTime(DateTime.Now.Subtract(dataNascimento).Ticks).Year;
            DateTime anosPercorridos = dataNascimento.AddYears(idade);
            if (anosPercorridos > DateTime.Now)
            {
                idade -= 1;
            }
            if (idade < 17)
            {
                return BadRequest(new
                {
                    Result = "Business_rule_error",
                    Mesage = "A idade do jogador deve ser maior que 17"
                });
            }
            foreach (var item in _dal.GetAll())
            {
                jogadores.Cod_jog = item.Cod_jog;
            }
            jogadores.Cod_jog++;
            _dal.Add(jogadores);

            return Ok(new
            {
                Result = "Sucess",
                Message = "Operação realizada com sucesso"
            });
        }

        [Route("atualizar/{codJogador}")]
        public IActionResult Put([FromHeader] string tokenTowersAdm, int codJogador, [FromBody] Jogadores jogadores)
        {
            if (tokenTowersAdm == null || tokenTowersAdm != "a5b01115-7d82-4f6a-bc45-9fd49eacd2e7")
            {
                return BadRequest(new
                {
                    Result = "authentication_error",
                    Mesage = "Você não está autorizado a acessar esses dados"
                });
            }
            if (jogadores == null)
            {
                return BadRequest(new
                {
                    Result = "error",
                    Mesage = "Contact the admnistrator"
                });
            }
            DateTime dataNascimento = DateTime.Parse(jogadores.DataNascimento.Insert(4, "-").Insert(7, "-"));
            int idade = new DateTime(DateTime.Now.Subtract(dataNascimento).Ticks).Year;
            DateTime anosPercorridos = dataNascimento.AddYears(idade);
            if (anosPercorridos > DateTime.Now)
            {
                idade -= 1;
            }
            if (idade < 17)
            {
                return BadRequest(new
                {
                    Result = "Business_rule_error",
                    Mesage = "A idade do jogador deve ser maior que 17"
                });
            }
            _dal.Update(jogadores, codJogador);

            return Ok(new
            {
                Result = "Sucess",
                Message = "Operação realizada com sucesso"
            });
        }

        [Route("excluir/{codJogador}")]
        public IActionResult Delete([FromHeader] string tokenTowersAdm, int codJogador)
        {
            if (tokenTowersAdm == null || tokenTowersAdm != "a5b01115-7d82-4f6a-bc45-9fd49eacd2e7")
            {
                return BadRequest(new
                {
                    Result = "authentication_error",
                    Mesage = "Você não está autorizado a acessar esses dados"
                });
            }
            if (_dal.Remove(codJogador))
            {
                return Ok(new
                {
                    Result = "Sucess",
                    Message = "Operação realizada com sucesso"
                });
            }
            return BadRequest(new
            {
                Result = "Error",
                Message = "Contact the administrator"
            });


        }
    }
}
