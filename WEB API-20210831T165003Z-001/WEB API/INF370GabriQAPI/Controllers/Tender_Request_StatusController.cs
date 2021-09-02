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
    public class Tender_Request_StatusController : ApiController
    {
        private Gabriq_System_DatabaseEntities db = new Gabriq_System_DatabaseEntities();

        // GET: api/Tender_Request_Status
        public IQueryable<Tender_Request_Status> GetTender_Request_Status()
        {
            return db.Tender_Request_Status;
        }

        // GET: api/Tender_Request_Status/5
        [ResponseType(typeof(Tender_Request_Status))]
        public async Task<IHttpActionResult> GetTender_Request_Status(int id)
        {
            Tender_Request_Status tender_Request_Status = await db.Tender_Request_Status.FindAsync(id);
            if (tender_Request_Status == null)
            {
                return NotFound();
            }

            return Ok(tender_Request_Status);
        }

        // PUT: api/Tender_Request_Status/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTender_Request_Status(int id, Tender_Request_Status tender_Request_Status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tender_Request_Status.Tender_Request_Status_ID)
            {
                return BadRequest();
            }

            db.Entry(tender_Request_Status).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tender_Request_StatusExists(id))
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

        // POST: api/Tender_Request_Status
        [ResponseType(typeof(Tender_Request_Status))]
        public async Task<IHttpActionResult> PostTender_Request_Status(Tender_Request_Status tender_Request_Status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tender_Request_Status.Add(tender_Request_Status);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Tender_Request_StatusExists(tender_Request_Status.Tender_Request_Status_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tender_Request_Status.Tender_Request_Status_ID }, tender_Request_Status);
        }

        // DELETE: api/Tender_Request_Status/5
        [ResponseType(typeof(Tender_Request_Status))]
        public async Task<IHttpActionResult> DeleteTender_Request_Status(int id)
        {
            Tender_Request_Status tender_Request_Status = await db.Tender_Request_Status.FindAsync(id);
            if (tender_Request_Status == null)
            {
                return NotFound();
            }

            db.Tender_Request_Status.Remove(tender_Request_Status);
            await db.SaveChangesAsync();

            return Ok(tender_Request_Status);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tender_Request_StatusExists(int id)
        {
            return db.Tender_Request_Status.Count(e => e.Tender_Request_Status_ID == id) > 0;
        }
    }
}