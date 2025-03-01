﻿using System;
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
    public class EstadiosController : ControllerBase
    {
        private readonly IEstadiosDAL _dal;

        public EstadiosController(IEstadiosDAL dal)
        {
            _dal = dal;
        }

        [HttpGet]
        public IEnumerable<Estadios> Get()
        {
            return _dal.GetAll();
        }

        //[HttpPost]
        //[Route("cadastrar")]
        //public IActionResult Post([FromBody] Estadios estadios)
        //{
        //    if (estadios == null)
        //    {
        //        return BadRequest();
        //    }
        //    _dal.Add(estadios);
        //    return Ok("Operação realizada com sucesso");
        //}

        //[Route("atualizar/{codCamp}/{codtime1}/{codtime2}")]
        //public IActionResult Put(int codCamp, [FromBody] Estadios estadios)
        //{
        //    if (estadios == null)
        //    {
        //        return BadRequest();
        //    }
        //    _dal.Update(estadios, codCamp);
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
