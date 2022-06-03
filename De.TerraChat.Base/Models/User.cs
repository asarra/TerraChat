using System;
using System.Collections.Generic;

#nullable disable

namespace De.TerraChat.Base.Models
{
    public partial class User
    {
        public User()
        {
            Messages = new HashSet<Message>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Pwd { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}
