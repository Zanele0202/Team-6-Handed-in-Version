using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using INF370GabriQAPI.Models;

namespace INF370GabriQAPI.Controllers
{
    public class Tender_RequestController : ApiController
    {
        private Gabriq_System_DatabaseEntities db = new Gabriq_System_DatabaseEntities();

        // GET: api/Tender_Request
        public IQueryable<Tender_Request> GetTender_Request()
        {
            return db.Tender_Request;
        }

        // GET: api/Tender_Request/5
        [ResponseType(typeof(Tender_Request))]
        public async Task<IHttpActionResult> GetTender_Request(int id)
        {
            Tender_Request tender_Request = await db.Tender_Request.FindAsync(id);
            if (tender_Request == null)
            {
                return NotFound();
            }

            return Ok(tender_Request);
        }

        // PUT: api/Tender_Request/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTender_Request(int id, Tender_Request tender_Request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tender_Request.Tender_Request_ID)
            {
                return BadRequest();
            }

            db.Entry(tender_Request).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tender_RequestExists(id))
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

        // POST: api/Tender_Request
        [ResponseType(typeof(Tender_Request))]
        public async Task<IHttpActionResult> PostTender_Request(Tender_Request tender_Request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tender_Request.Add(tender_Request);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Tender_RequestExists(tender_Request.Tender_Request_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tender_Request.Tender_Request_ID }, tender_Request);
        }

        // DELETE: api/Tender_Request/5
        [ResponseType(typeof(Tender_Request))]
        public async Task<IHttpActionResult> DeleteTender_Request(int id)
        {
            Tender_Request tender_Request = await db.Tender_Request.FindAsync(id);
            if (tender_Request == null)
            {
                return NotFound();
            }

            db.Tender_Request.Remove(tender_Request);
            await db.SaveChangesAsync();

            return Ok(tender_Request);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tender_RequestExists(int id)
        {
            return db.Tender_Request.Count(e => e.Tender_Request_ID == id) > 0;
        }
    }
}