using System;
using System.Collections.Generic;

#nullable disable

namespace De.TerraChat.Base.Models
{
    public partial class Message
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public Guid? AttatchmentId { get; set; }
        public string Text { get; set; }
        public DateTime DateCre { get; set; }

        public virtual Attatchment Attatchment { get; set; }
        public virtual User User { get; set; }
    }
}
