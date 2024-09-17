using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WirelessSupport.API.Controllers.Base;

namespace WirelessSupport.API.Controllers
{
    [Route("Ping")]
    public class PingController : BaseController
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("PING! SUCCESS..");
        }
    }
}
