using Microsoft.VisualStudio.TestTools.UnitTesting;
using De.TerraChat.ChrisLu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using De.TerraChat.Base.Interfaces;

namespace De.TerraChat.ChrisLu.Tests
{
    [TestClass()]
    public class ChatProxyTests
    {
        [TestMethod()]
        public void GetMessagesTest()
        {
            IChatProxy p = new ChatProxy();
            var res = p.GetMessages();
            Assert.IsTrue(res.Length > 0);
        }

        [TestMethod()]
        public void AddMessageTest()
        {
            IChatProxy p = new ChatProxy();

            p.AddMessage(new Base.Models.Message()
            {
                Id = 0,
                UserId = Guid.Parse("222c8cc4-829a-462f-9bde-67266f376272"),
                Text = "chrilu test"
            });

            p = new ChatProxy();
            var msgs = p.GetMessages();
            Assert.AreEqual(msgs[0].Text, "chrilu test");


        }

        [TestMethod()]
        public void GetUserTest()
        {
            var p = new ChatProxy();
            Assert.IsNull(p.GetUser("sdfdsf", "sdfsdf"));
            Assert.IsNotNull(p.GetUser("Andi", "andi"));
        }
    }
}