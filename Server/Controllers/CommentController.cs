using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server.Controllers
{
    public class CommentController : ApiController
    {
        private steptocharityEntities context = new steptocharityEntities();



        public IHttpActionResult Get(bool related = false)
        {

            List<comment> query = context.comments.ToList();
            return Ok(new { results = query });
        }

        public IHttpActionResult post([FromBody] comment adata)
        {
            comment p = adata;
            context.comments.Add(p);
            context.SaveChanges();

            return Ok(new { results = adata });

        }

        public IHttpActionResult Get(int id)
        {
            var results = (from row in context.comments where row.post_id == id select row).ToList();
            //comment a = context.comments.Single(comment=> comment.comment_id == id);

            return Ok(new { results = results });

        }


        public IHttpActionResult Put(int id, [FromBody] comment s)
        {
            comment a = context.comments.Single(comment => comment.comment_id== id);
            a.comment_text = s.comment_text;
            context.SaveChanges();
            return Ok();

        }

        public void delete(int id)
        {
            var result = context.comments.Single(comment=> comment.post_id == id);
            context.comments.Remove(result);
            context.SaveChanges();
        }

    }
}
