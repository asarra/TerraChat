using De.TerraChat.Base.Interfaces;
using De.TerraChat.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.TerraChat.Vitali
{
    public class CheckUserService : IUserMgr
    {
        public CHAT_DBContext Ctx { get; set; } = new CHAT_DBContext();


        /// <summary>
        /// Überprüfe User-Berechtigungen
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public User Authenticate(string name, string pwd)
        {
            try
            {
                return Ctx.Users.ToList().Single(x => x.Name == name && x.Pwd == pwd);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public User Get(Guid id)
        {
            return Ctx.Users.Single(x=>x.Id==id);
        }
    }
}
