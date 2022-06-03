using System;
using System.Collections.Generic;

#nullable disable

namespace De.TerraChat.Base.Models
{
    public partial class Attatchment
    {
        public Attatchment()
        {
            Messages = new HashSet<Message>();
        }

        public Guid Id { get; set; }
        public byte[] Content { get; set; }
        public string MimeType { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}
