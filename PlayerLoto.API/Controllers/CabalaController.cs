using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PlayerLoto.DataEF;
using PlayerLoto.Domain;

namespace PlayerLoto.API.Controllers
{
    [RoutePrefix("api/Cabala")]
    public class CabalaController : ApiController
    {
        private PlayerLotoContext db = new PlayerLotoContext();

        
        [Route("Numbers")]
        [HttpGet]
        public IHttpActionResult GetNumbers()
        {
            return Ok(db.Cabala_Numero.ToList());
        }

        [Route("Words")]
        [HttpGet]
        public IHttpActionResult GetWords()
        {
            return Ok(db.Cabala_Palabra.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

       
    }
}