using De.TerraChat.Base.Interfaces;
using De.TerraChat.Base.Models;
using De.TerraChat.ChrisLu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TiTiMvcWEB.Models;

namespace TiTiMvcWEB.Controllers
{
    public class HomeController : Controller
    {
        ChatProxy Proxy = new ChatProxy();
        User User = new User();
        public IActionResult Index(string error = null)
        {
            return View(error);
        }
        public IActionResult Login(string un, string pwd)
        {
            if (!string.IsNullOrEmpty(un) && !string.IsNullOrEmpty(pwd))
            {
                var nutzer = Proxy.GetUser(un, pwd);
                Response.Cookies.Append("UID", nutzer.Id.ToString());
                User = nutzer;
                if (nutzer.Id != Guid.Empty)
                {
                    return RedirectToAction("ChatSite");
                }
                else
                {
                    return RedirectToAction("Index", (object)"Fehler!");
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public IActionResult ChatSite()
        {
            var messages = Proxy.GetMessages();
            ViewBag.User = User;
            ViewBag.Messages = messages;
            return View();
        }
        public IActionResult Send(string eingabe)
        {
            if (!string.IsNullOrEmpty(eingabe))
            {
                var sendmessage = new Message();
                sendmessage.User = User;
                sendmessage.DateCre = DateTime.Now;
                sendmessage.UserId = Guid.Parse( Request.Cookies["UID"]);
                sendmessage.Text = eingabe;
                Proxy.AddMessage(sendmessage);
                return RedirectToAction("ChatSite");
            }
            else
            {
                return RedirectToAction("ChatSite");
            }

        }
    }
}
