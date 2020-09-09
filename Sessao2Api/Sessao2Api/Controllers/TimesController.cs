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
    public class TimesController : ControllerBase
    {
        private readonly ITimesDAL _dal;

        public TimesController(ITimesDAL dal)
        {
            _dal = dal;
        }

        [HttpGet]
        public IEnumerable<Times> Get()
        {
            return _dal.GetAll();
        }

        //[HttpPost]
        //[Route("cadastrar")]
        //public IActionResult Post([FromBody] Times times)
        //{
        //    if (times == null)
        //    {
        //        return BadRequest();
        //    }
        //    _dal.Add(times);
        //    return Ok("Operação realizada com sucesso");
        //}

        //[Route("atualizar/{codCamp}/{codtime1}/{codtime2}")]
        //public IActionResult Put(int codCamp, [FromBody] Times times)
        //{
        //    if (times == null)
        //    {
        //        return BadRequest();
        //    }
        //    _dal.Update(times, codCamp);
        //    return Ok("Operação realizada com sucesso");
        //}

        //[Route("excluir/{codCamp}/{codtime1}/{codtime2}")]
        //public IActionResult Delete(int codCamp)
        //{
        //    _dal.Remove(codCamp);
        //    return Ok("Operação realizada com sucesso"); 
        //}
    }
}
