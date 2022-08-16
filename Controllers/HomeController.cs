using CoreWebApi.DB_Connection;
using CoreWebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;

namespace CoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ApplicationDBC dbobj;
        public HomeController(ApplicationDBC obj)
        {
            dbobj = obj;
        }

        [Route("Post/Create")]
        [HttpPost]
        public HttpResponseMessage Create(SoftwareEnginnerModel mdlobj)
        {
            if(mdlobj.ID == 0)
            {
                dbobj.softwareEnginners.Add(mdlobj);
                dbobj.SaveChanges();
            }
            else
            {
                dbobj.softwareEnginners.Update(mdlobj);
                dbobj.SaveChanges();
            }

            HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK);

            return hrm;
        }

        [Route("Get/Read")]
        [HttpGet]
        public List<SoftwareEnginnerModel> Read()
        {
            var Data = dbobj.softwareEnginners.ToList();

            return Data;
        }

        [Route("Get/Update")]
        [HttpGet]
        public SoftwareEnginnerModel Update(int ID)
        {
            var Update = dbobj.softwareEnginners.Where(a => a.ID == ID).FirstOrDefault();

            return Update;
        }
        [Route("Get/Delete")]
        [HttpGet]
        public HttpResponseMessage Delete(int ID)
        {
            var Update = dbobj.softwareEnginners.Where(a => a.ID == ID).FirstOrDefault();

            dbobj.softwareEnginners.Remove(Update);

            dbobj.SaveChanges();

            HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK);

            return hrm;
        }
    }
}
