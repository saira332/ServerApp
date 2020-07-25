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
            comment a = context.comments.Single(comment=> comment.comment_id == id);

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


        public IHttpActionResult Put(int id, [FromBody] comment s)
        {
            comment a = context.comments.Single(comment => comment.comment_id== s.comment_id);
            a.comment_text = s.comment_text;
            context.SaveChanges();
            return Ok();

        }

        public void delete(int id)
        {
            var result = context.comments.Single(comment=> comment.comment_id == id);
            context.comments.Remove(result);
            context.SaveChanges();
        }

    }
}
