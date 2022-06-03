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
    public class CheckUserServiceTests
    {
        [TestMethod()]
        public void AuthenticateTest()
        {
            IUserMgr m = new CheckUserService();
            var res = m.Authenticate("sdgsdg", "ysdfsdf");
            Assert.IsNull(res);
            res = m.Authenticate("Andi", "andi");
            Assert.IsNotNull(res);
        }
    }
}