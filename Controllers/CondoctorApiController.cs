using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class CondoctorApiController : ApiController
    {
        Internship1Entities db = new Internship1Entities();

        [HttpGet]
        public IHttpActionResult Getdata()
        {
            List<condoctor> obj= db.condoctors.ToList();
            return Ok(obj);
        }
        /*[HttpGet]
        public IHttpActionResult GetData()
        {
            Class1 obj=new Class1();
            obj.connection();
            obj.selectData();
            return Ok();
        }*/
        [HttpGet]
        public IHttpActionResult Getdata(int id)
        {
            var obj = db.condoctors.Where(model=>model.c_id == id).ToList().FirstOrDefault();
            return Ok(obj);
        }

        [HttpPost]
        public IHttpActionResult InsertData(condoctor c)
        {
            int id= c.c_id;
            string name=c.c_name;
            string route = c.bus_route;

            Class1 obj = new Class1();
            obj.connection();
            obj.insertData(id,name,route);
            //db.condoctors.Add(c);
            //db.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult updateData(condoctor c)
        {
            var con = db.condoctors.Where(model => model.c_id == c.c_id).FirstOrDefault();
            if(con!=null)
            {
                int id=c.c_id;
                string name =c.c_name;
                string route=c.bus_route;

                Class1 obj = new Class1();
                obj.connection();
                obj.updateData(id,name,route);
                //con.c_id = c.c_id;
                //con.c_name = c.c_name;
                //con.bus_route = c.bus_route;
                //db.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult deleteData(int id)
        {
            //var obj = db.condoctors.Where(model => model.c_id == c.c_id).ToList().FirstOrDefault();
            //int id= obj.c_id;
            Class1 cls = new Class1();
            cls.connection();
            cls.deleteData(id);
            //db.Entry(obj).State = System.Data.Entity.EntityState.Deleted;
           // db.SaveChanges();
            return Ok();
        }
    }
}
