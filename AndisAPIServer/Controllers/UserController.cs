using De.TerraChat.Base.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndisAPIServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserMgr UsrMgr { get; set; } = new De.TerraChat.Vitali.CheckUserService();

        [HttpGet]
        public IActionResult Get(string n, string p)
        {
            var usr = UsrMgr.Authenticate(n, p);
            if (usr!=null)
            {
                return Ok(usr);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
