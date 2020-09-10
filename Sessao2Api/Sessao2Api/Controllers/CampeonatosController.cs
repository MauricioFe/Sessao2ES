using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sessao2Api.Data;
using Sessao2Api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sessao2Api.Controllers
{
    [Route("wstowers/api/[controller]")]
    [ApiController]
    public class CampeonatosController : ControllerBase
    {
        private readonly ICampeonatosDAL _dal;

        public CampeonatosController(ICampeonatosDAL dal)
        {
            _dal = dal;
        }

        [HttpGet]
        public IEnumerable<Campeonatos> Get()
        {
            return _dal.GetAll();
        }

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Post([FromHeader] string tokenTowersAdm, [FromBody] Campeonatos campeonatos)
        {
            DateTime dataFim = DateTime.Parse(campeonatos.DataFim.Insert(4, "-").Insert(7, "-"));
            DateTime dataInicio = DateTime.Parse(campeonatos.DataInicio.Insert(4,"-").Insert(7,"-"));
            if (tokenTowersAdm == null || tokenTowersAdm != "a5b01115-7d82-4f6a-bc45-9fd49eacd2e7")
            {
                return BadRequest(new
                {
                    Result = "authentication_error",
                    Mesage = "Você não está autorizado a acessar esses dados"
                });
            }
            if (campeonatos == null)
            {
                return BadRequest(new
                {
                    Result = "error",
                    Mesage = "Contact the admnistrator"
                });
            }
            if (campeonatos.Ano != dataInicio.Year && campeonatos.Ano != dataFim.Year)
            {

                return BadRequest(new
                {
                    Result = "Business_rule_error",
                    Mesage = "O ano das datas está diferente do ano do campeonato"
                });
            }
            if (dataInicio.AddMonths(2) > dataFim)
            {
                return BadRequest(new
                {
                    Result = "Business_rule_error",
                    Mesage = "Um campeonato tem que ter uma duração de no mínimo dois meses"
                });
            }
            foreach (var item in _dal.GetAll())
            {
                campeonatos.Cod_camp = item.Cod_camp;
            }
            campeonatos.Cod_camp++;
            _dal.Add(campeonatos);

            return Ok(new
            {
                Result = "Sucess",
                Message = "Operação realizada com sucesso"
            });
        }

        [Route("atualizar/{codCamp}")]
        public IActionResult Put(int codCamp, [FromBody] Campeonatos campeonatos)
        {
            DateTime dataFim = DateTime.Parse(campeonatos.DataFim.Insert(4, "-").Insert(7, "-"));
            DateTime dataInicio = DateTime.Parse(campeonatos.DataInicio.Insert(4, "-").Insert(7, "-"));
            if (campeonatos == null)
            {
                return BadRequest(new
                {
                    Result = "error",
                    Mesage = "Contact the admnistrator"
                });
            }
            if (campeonatos.Ano != dataInicio.Year && campeonatos.Ano != dataFim.Year)
            {

                return BadRequest(new
                {
                    Result = "Business_rule_error",
                    Mesage = "O ano das datas está diferente do ano do campeonato"
                });
            }
            if (dataInicio.AddMonths(2) > dataFim)
            {
                return BadRequest(new
                {
                    Result = "Business_rule_error",
                    Mesage = "Um campeonato tem que ter uma duração de no mínimo dois meses"
                });
            }
            if (_dal.ValidaEdicaoData(codCamp, campeonatos.Ano, campeonatos.DataInicio, campeonatos.DataFim))
            {
                return BadRequest(new
                {
                    Result = "Business_rule_error",
                    Mesage = "Não é possível editar a data desse campeonato pois ainda tem jogos para acontecer"
                });
            }
            _dal.Update(campeonatos, codCamp);

            return Ok(new
            {
                Result = "Sucess",
                Message = "Operação realizada com sucesso"
            });
        }

        [Route("excluir/{codCamp}")]
        public IActionResult Delete(int codCamp)
        {
            if (_dal.Remove(codCamp))
            {
                return Ok(new
                {
                    Result = "Sucess",
                    Message = "Operação realizada com sucesso"
                });
            }
            else
            {
                return BadRequest(new
                {
                    Result = "error",
                    Mesage = "Contact the admnistrator"
                });
            }         
        }
    }
}
