using GiMeToMVCWeb.Models;
using De.TerraChat.ChrisLu;
using De.TerraChat.Base;
using Microsoft.AspNetCore.Mvc;
using De.TerraChat.ChrisLu;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using De.TerraChat.Base.Models;
using Microsoft.AspNetCore.Http;

namespace GiMeToMVCWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        [HttpPost]
        public IActionResult isLoggedIn(string name, string password)
        {
            var user = new ChatProxy().GetUser(name, password);
            if (user!=null)
            {
                Response.Cookies.Append("name", name);
                Response.Cookies.Append("password", password);
                return RedirectToAction("Chatfenster");
            }
            else return RedirectToAction("Error");
        }

        public IActionResult Chatfenster()
        {
            return View(new ChatProxy().GetMessages());
        }



        [HttpPost]
        public IActionResult sendMessage(string text)
        {
            if (text == null) return RedirectToAction("Chatfenster");
            else 
            {
                var cp = new ChatProxy();
                Message message = new Message();
                var user = cp.GetUser(Request.Cookies["name"], Request.Cookies["password"]);

                message.Text = text;
                message.UserId = user.Id;
                message.Id = 0;
                message.DateCre = DateTime.Now;
                cp.AddMessage(message);
            }
            return RedirectToAction("Chatfenster");
        }

        public IActionResult getMessages()
        {
            new ChatProxy().GetMessages();
            return RedirectToAction("Chatfenster");
        }

        public PartialViewResult NurMessages()
        {
            return PartialView(new ChatProxy().GetMessages());
        }


    }
}
