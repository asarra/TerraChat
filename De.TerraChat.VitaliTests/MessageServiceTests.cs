using Microsoft.VisualStudio.TestTools.UnitTesting;
using De.TerraChat.Vitali;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using De.TerraChat.Base.Interfaces;

namespace De.TerraChat.Vitali.Tests
{
    [TestClass()]
    public class MessageServiceTests
    {
        [TestMethod()]
        public void GetMessagesTest()
        {
            IMsgMgr ms = new MessageService();
            IUserMgr us = new CheckUserService();

            var u = us.Authenticate("Andi","andi");
            var alt = ms.GetMessages();
            Assert.IsTrue(alt.Length > 0);
            ms.Add(new Base.Models.Message()
            {
                DateCre=DateTime.Now,
                Id=0,
                Text="Nachrischt von Sam...",
                UserId=u.Id
            });
            var neu = ms.GetMessages();
            Assert.IsTrue(neu.Length > alt.Length);

        }
    }
}