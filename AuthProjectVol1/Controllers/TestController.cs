using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthProjectVol1.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]


    public class TestController : ControllerBase
    {
  
        public string Index()
        {
            return "Yetkilendirme başarılı...";
        }
    }
}
