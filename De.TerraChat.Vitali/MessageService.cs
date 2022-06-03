using De.TerraChat.Base.Interfaces;
using De.TerraChat.Base.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.TerraChat.Vitali
{
    public class MessageService : IMsgMgr
    {
        public CHAT_DBContext Ctx { get; set; } = new CHAT_DBContext();



        /// <summary>
        /// Nachricht in DB ablegen
        /// </summary>
        /// <param name="msg"></param>
        public void Add(Message msg)
        {
            try
            {
                if (msg != null)
                {
                    Ctx.Add(msg);
                    Ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }




        /// <summary>
        /// Anhang in DB ablegen
        /// </summary>
        /// <param name="data"></param>
        /// <param name="mime"></param>
        /// <returns></returns>
        public Guid AddAttatchment(byte[] data, string mime)
        {
            AttatchmentModel attatchmentModel = new AttatchmentModel();
            attatchmentModel.Id = Guid.NewGuid();
            attatchmentModel.Content = data;
            attatchmentModel.MimeType = mime;


            try
            {
                Ctx.Add(attatchmentModel);
                Ctx.SaveChanges();

                return attatchmentModel.Id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        /// <summary>
        /// Nachrichten aus DB holen
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public Message[] GetMessages(int count = 20)
        {
            try
            {
                return Ctx.Messages
                                
                                .OrderByDescending(x=>x.DateCre)
                                .Take(count)
                                .ToArray();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
