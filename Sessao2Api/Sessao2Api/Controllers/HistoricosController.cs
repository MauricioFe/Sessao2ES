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
    public class HistoricosController : ControllerBase
    {
        private readonly IHistoricosDAL _dal;

        public HistoricosController(IHistoricosDAL dal)
        {
            _dal = dal;
        }

        [HttpGet]
        public IEnumerable<Historicos> Get()
        {
            return _dal.GetAll();
        }

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Post([FromBody] Historicos historicos)
        {
            if (historicos == null)
            {
                return BadRequest();
            }
            _dal.Add(historicos);
            return Ok("Operação realizada com sucesso");
        }
    }
}
