using De.TerraChat.Base.Interfaces;
using De.TerraChat.Base.Models;
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
    public class MessageController : ControllerBase
    {
        public IMsgMgr MsgMgr { get; set; } = new De.TerraChat.Vitali.MessageService();
        public IUserMgr UsrMgr { get; set; } = new De.TerraChat.Vitali.CheckUserService();
        [HttpGet]
        public IActionResult Get()
        {
            var erg = MsgMgr.GetMessages();
            foreach (var m in erg)
            {
                m.User = UsrMgr.Get(m.UserId);
            }
            return Ok(erg);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Message msg)
        {
            MsgMgr.Add(msg);
            return Ok();
        }
    }
}
