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
        public void Post([FromBody] Jogos jogos)
        {
            _dal.Add(jogos);
        }

        
        [HttpPut("{id}")]
        public void Put(int codCampeonato, int codTime1, int codTime2, [FromBody] Jogos jogos)
        {
            _dal.Update(jogos, codCampeonato, codTime1, codTime2);
        }

        
        [HttpDelete("{id}")]
        public void Delete(int codCampeonato, int codTime1, int codTime2)
        {
            _dal.Remove(codCampeonato, codTime1, codTime2);
        }
    }
}
