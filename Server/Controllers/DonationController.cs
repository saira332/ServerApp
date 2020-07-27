using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server.Controllers
{
    public class DonationController : ApiController
    {
        private steptocharityEntities context = new steptocharityEntities();



        public IHttpActionResult Get(bool related = false)
        {

            List<donation> query = context.donations.ToList();
            return Ok(new { results = query });
        }

        public IHttpActionResult post([FromBody] donation adata)
        {
            donation p = adata;
            context.donations.Add(p);
            context.SaveChanges();

            return Ok(new { results = adata });

        }

        public IHttpActionResult Get(int id)
        {
            donation a = context.donations.Single(donation => donation.donation_id== id);

            return Ok(new { results = a });

        }



       


        

      
    }
}
