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
using Newtonsoft.Json.Linq;
using PlayerLoto.DataEF;
using PlayerLoto.Domain;

namespace PlayerLoto.API.Controllers
{
    [RoutePrefix("api/DrawingResults")]
    public class DrawingResultsController : ApiController
    {
        private PlayerLotoContext db = new PlayerLotoContext();

        [HttpPost]
        [Route("History")]
        public IHttpActionResult DrawingResultByDate(JObject form)
        {
            dynamic jsonObject = form;
            DateTime initialDate;
            DateTime finalDate;

            try
            {
                initialDate = jsonObject.initial_date.Value;
                finalDate = jsonObject.final_date.Value;
                if(finalDate.CompareTo(initialDate) < 0)
                {
                    return BadRequest("final date can not lowwer than initial date");
                }
                return Ok(db.DrawingResults.Where(d => d.Date >= initialDate && d.Date <= finalDate)); 
            }
            catch (Exception ex)
            {

                return BadRequest("Elements not found");
            }
            
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