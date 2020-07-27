using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server.Controllers
{
    public class LoginController : ApiController
    {
        private steptocharityEntities context = new steptocharityEntities();

        public int Message { get; set; }

        public IHttpActionResult Get(bool related = false)
        {
            List<login> query = context.logins.ToList();
            return Ok(new { results = query });
        }

        public IHttpActionResult post([FromBody] login adata)
        {
            login p = adata;
            context.logins.Add(p);
            context.SaveChanges();
            
            if (p.type == "accepter")
            {
                var res = from m in context.accepters
                          where m.email == p.email
                          select m;
                foreach (var m in res)
                {
                    if (m.email == p.email && m.password == p.password)
                    {
                        Message = m.accepter_id;
                    }
                }
                accepter result = context.accepters.Single(accepter => accepter.email == p.email);
            }
            else if (p.type == "donor")
            {
                var res = from m in context.donors
                          where m.email == p.email
                          select m;
                foreach (var m in res)
                {
                    if (m.email == p.email && m.password == p.password)
                    {
                        Message = m.donor_id;
                    }
                }
                donor result = context.donors.Single(donor => donor.email == p.email);
            }
            else if (p.type == "admin")
            {
                var res = from m in context.admins
                          where m.email == p.email
                          select m;
                foreach (var m in res)
                {
                    if (m.email == p.email && m.password == p.password)
                    {
                        Message = m.admin_id;
                    }
                }
                admin result = context.admins.Single(admin => admin.email == p.email );
            }

            return Ok(Message);

        }
        


    }

}
