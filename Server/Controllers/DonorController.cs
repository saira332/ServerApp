using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;

namespace Server.Controllers
{
    public class DonorController : ApiController
    {
        private steptocharityEntities context = new steptocharityEntities();



        public IHttpActionResult Get(bool related = false)
        {

            List<donor> query = context.donors.ToList();
            return Ok(new { results = query });
        }

        public IHttpActionResult Post([FromBody] donor adata)
        {
            
            donor p = adata;
            context.donors.Add(p);

            notification n = new notification();
            n.donor_id = p.donor_id;
            n.title = "Need Verification for Donor";
            n.status = "0";
            context.notifications.Add(n);

            context.SaveChanges();
            donor a = context.donors.Single(donor => donor.email == adata.email);
            n.donor_id = a.donor_id;
            context.SaveChanges();

            return Ok(new { results = a });

        }

        public IHttpActionResult Get(int id)
        {
            donor a = context.donors.Single(donor => donor.donor_id == id);

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


        public IHttpActionResult Put(int id, [FromBody] donor s)
        {
            donor a = context.donors.Single(donor => donor.donor_id == id);
            a.donor_name = s.donor_name;
           
            a.email = s.email;
            a.password = s.password;
            a.contact_no = s.contact_no;
            a.CNIC = s.CNIC;
            a.DOB = s.DOB;
            a.country = s.country;
            a.city = s.city;
            a.state = s.state;
            a.address = s.address;
            a.zip_code = s.zip_code;
            a.gender = s.gender;
            a.occupation = s.occupation;
           //context.Update(s);
            context.SaveChanges();
            return Ok();

        }

        public void delete(int id)
        {
            var result = context.donors.Single(donor => donor.donor_id == id);
            context.donors.Remove(result);
            context.SaveChanges();
        }

    }
}
