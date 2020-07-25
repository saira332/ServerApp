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

            return Ok(new { results = adata });

        }

        //public IHttpActionResult Get(int id)
        //{
        //    login a = context.logins.Single(login => login.id == id);

        //    return Ok(new { results = a });

        //}

        public IHttpActionResult Get(int id)
        {
            login data = context.logins.Single(login => login.id == id);
            if (data.type == "accepter")
            {
                var res = from m in context.accepters
                          where m.email == data.email
                          select m;
                foreach (var m in res)
                {
                    if (m.email == data.email && m.password == data.password)
                    {
                        id = m.accepter_id;
                    }
                }
                accepter result = context.accepters.Single(accepter => accepter.accepter_id == id);
                return Ok(new { results = result });
            }
            else if (data.type == "donor")
            {
                var res = from m in context.donors
                          where m.email == data.email
                          select m;
                foreach (var m in res)
                {
                    if (m.email == data.email && m.password == data.password)
                    {
                        id = m.donor_id;
                    }
                }
                donor result = context.donors.Single(donor => donor.donor_id == id);
                return Ok(new { results = result });
            }
            else if (data.type == "admin")
            {
                var res = from m in context.admins
                          where m.email == data.email
                          select m;
                foreach (var m in res)
                {
                    if (m.email == data.email && m.password == data.password)
                    {
                        id = m.admin_id;
                    }
                }
                admin result = context.admins.Single(admin => admin.admin_id == id);
                return Ok(new { results = result });
            }
            return Ok();
            
        }







    }

}
