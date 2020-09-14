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
    }
}
