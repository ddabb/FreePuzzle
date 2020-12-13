using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreePuzzle.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {

        [HttpGet]
        public String Get()
        {

            return $"Hello, Free Puzzle!\r\n {DateTime.Now.ToString("yyyy.MM.dd HH.mm.ss.fff")}";
        }
    }
}
