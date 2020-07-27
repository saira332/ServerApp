using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server.Controllers
{
    public class AdminController : ApiController
    {
        private steptocharityEntities context = new steptocharityEntities();



        public IHttpActionResult Get(bool related = false)
        {

            List<admin> query = context.admins.ToList();
            return Ok(new { results = query });
        }

        public IHttpActionResult post([FromBody] admin adata)
        {
            admin p = adata;
            context.admins.Add(p);
            context.SaveChanges();

            return Ok(new { results = adata });

        }

        public IHttpActionResult Get(int id)
        {
            admin a = context.admins.Single(admin => admin.admin_id == id);

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


        public IHttpActionResult Put(int id, [FromBody] admin s)
        {
            admin a = context.admins.Single(admin => admin.admin_id == id);
            a.admin_name = s.admin_name;
            a.email = s.email;
            a.password = s.password;
            a.contact_no = s.contact_no;
            a.CNIC = s.CNIC;
            a.DOB = s.DOB;
            a.country = s.country;
            a.city = s.city;
            a.state = s.state;
            a.address = s.address;
            a.gender = s.gender;
          

            //context.Update(s);
            context.SaveChanges();
            return Ok();

        }

        public void delete(int id)
        {
            var result = context.admins.Single(admin => admin.admin_id == id);
            context.admins.Remove(result);
            context.SaveChanges();
        }

    }
}
