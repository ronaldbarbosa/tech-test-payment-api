using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TechTest_PaymentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesApiController : ControllerBase
    {
        [HttpGet]
        public IActionResult SearchSale()
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateSale()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult RegisterSale() 
        {
            return Ok();
        }
    }
}