using De.TerraChat.Base.Interfaces;
using De.TerraChat.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarnielsWPFClient
{
    public class TestProxy : IChatProxy
    {
        public string ApiBaseAddress { set => throw new NotImplementedException(); }

        public void AddMessage(Message msg)
        {
            
        }

        public Message[] GetMessages()
        {
            return new Message[]
            {
                new Message()
                {
                    User = new User(){Name = "Klaus" },
                    Text = "Hallo"
                },               new Message()
                {
                    User = new User(){Name = "Dieter" },
                    Text = "Jo was geht"
                },               new Message()
                {
                    User = new User(){Name = "Hans" },
                    Text = "Alles fresh?"
                }
            };
        }

        public User GetUser(string name, string pwd)
        {
            throw new NotImplementedException();
        }
    }
}
