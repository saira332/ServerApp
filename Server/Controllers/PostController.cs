using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server.Controllers
{
    public class PostController : ApiController
    {
        private steptocharityEntities context = new steptocharityEntities();



        public IHttpActionResult Get(bool related = false)
        {

            List<post> query = context.posts.ToList();
            return Ok(new { results = query });
        }

        public IHttpActionResult post([FromBody] post adata)
        {
            post p = adata;
            context.posts.Add(p);
            context.SaveChanges();


            return Ok(new { results = adata });

        }

        public IHttpActionResult Get(int id)
        {
            post a = context.posts.Single(post => post.post_id== id);

            return Ok(new { results = a });

        }



        //public Dictionary<string, string> post()
        //{
        //    try
        //    {
        //        Docupload d = new Docupload();
        //        var file = Request.Form.Files[0];
        //        var folderName = Path.Combine("Resources", "Images");
        //        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

        //        if (file.Length > 0)
        //        {
        //            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        //            var fullPath = Path.Combine(pathToSave, fileName);
        //            var dbPath = Path.Combine(folderName, fileName);
        //            using (var stream = new FileStream(fullPath, FileMode.Create))
        //            {
        //                file.CopyTo(stream);
        //            }
        //            d.DocName = fileName;
        //            d.Path = dbPath;
        //            //d.AccepterId = Convert.ToInt32(Message);
        //            context.Add(d);
        //            context.SaveChanges();

        //            return Ok();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex}");
        //    }
        //}


        public IHttpActionResult Put(int id, [FromBody] post s)
        {
            post a = context.posts.Single(post => post.post_id == id);
            a.title = s.title;
            a.category = s.category;
            a.description = s.description;
            a.target_amount = s.target_amount;
            a.received_amount = s.received_amount;


            //context.Update(s);
            context.SaveChanges();
            return Ok();

        }

        public void delete(int id)
        {
            var result = context.posts.Single(post => post.post_id == id);
            context.posts.Remove(result);
            context.SaveChanges();
        }

    }
}
