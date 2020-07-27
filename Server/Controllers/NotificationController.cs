using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server.Controllers
{
    public class NotificationController : ApiController
    {
        private steptocharityEntities context = new steptocharityEntities();



        public IHttpActionResult Get(bool related = false)
        {

            List<notification> query = context.notifications.ToList();
            return Ok(new { results = query });
        }

        public IHttpActionResult post([FromBody] notification adata)
        {
            notification p = adata;
            context.notifications.Add(p);
            context.SaveChanges();

            return Ok(new { results = adata });

        }

        public IHttpActionResult Get(int id)
        {
            notification a = context.notifications.Single(notification => notification.id == id);

            return Ok(new { results = a });

        }



        


        

        public void delete(int id)
        {
            var result = context.notifications.Single(notification => notification.id == id);
            context.notifications.Remove(result);
            context.SaveChanges();
        }
    }
}
