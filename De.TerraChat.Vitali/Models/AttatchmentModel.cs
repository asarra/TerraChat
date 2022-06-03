using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.TerraChat.Vitali
{
    public class AttatchmentModel
    {
        public Guid Id { get; set; }
        public byte[] Content { get; set; }
        public string MimeType { get; set; }
    }
}
