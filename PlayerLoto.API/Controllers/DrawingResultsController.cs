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
    public class DrawingResultsController : ApiController
    {
        private PlayerLotoContext db = new PlayerLotoContext();

        // GET: api/DrawingResults
        public IQueryable<DrawingResult> GetDrawingResults()
        {
            return db.DrawingResults;
        }

        // GET: api/DrawingResults/5
        [ResponseType(typeof(DrawingResult))]
        public IHttpActionResult GetDrawingResult(int id)
        {
            DrawingResult drawingResult = db.DrawingResults.Find(id);
            if (drawingResult == null)
            {
                return NotFound();
            }

            return Ok(drawingResult);
        }

        // PUT: api/DrawingResults/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDrawingResult(int id, DrawingResult drawingResult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != drawingResult.Id)
            {
                return BadRequest();
            }

            db.Entry(drawingResult).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrawingResultExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/DrawingResults
        [ResponseType(typeof(DrawingResult))]
        public IHttpActionResult PostDrawingResult(DrawingResult drawingResult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DrawingResults.Add(drawingResult);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = drawingResult.Id }, drawingResult);
        }

        // DELETE: api/DrawingResults/5
        [ResponseType(typeof(DrawingResult))]
        public IHttpActionResult DeleteDrawingResult(int id)
        {
            DrawingResult drawingResult = db.DrawingResults.Find(id);
            if (drawingResult == null)
            {
                return NotFound();
            }

            db.DrawingResults.Remove(drawingResult);
            db.SaveChanges();

            return Ok(drawingResult);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DrawingResultExists(int id)
        {
            return db.DrawingResults.Count(e => e.Id == id) > 0;
        }
    }
}