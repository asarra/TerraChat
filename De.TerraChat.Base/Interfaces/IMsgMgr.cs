using De.TerraChat.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.TerraChat.Base.Interfaces
{
    public interface IMsgMgr
    {
        Guid AddAttatchment(byte[] data, string mime);
        void Add(Message msg);

        /// <summary>
        /// Aufsteigend nach Datum
        /// </summary>
        /// <param name="count">Anzahl der Nachrichten</param>
        /// <returns></returns>
        Message[] GetMessages(int count=20);
    }
}
