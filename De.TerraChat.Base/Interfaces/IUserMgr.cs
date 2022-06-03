using De.TerraChat.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.TerraChat.Base.Interfaces
{
    public interface IUserMgr
    {
        User Authenticate(string name, string pwd);
        User Get(Guid id);
    }
}
