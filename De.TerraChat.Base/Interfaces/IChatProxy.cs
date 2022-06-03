using De.TerraChat.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.TerraChat.Base.Interfaces
{
    public interface IChatProxy
    {
        string ApiBaseAddress { set; }

        User GetUser(string name, string pwd);
        void AddMessage(Message msg);
        Message[] GetMessages();
    }
}
