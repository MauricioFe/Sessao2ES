﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Sessao2Api.Controllers
{
    [Route("wstowers/api/[controller]")]
    [ApiController]
    public class TesteController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            return "Api is Working!";
        }

    }
}
