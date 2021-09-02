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
    public class Tender_StatusController : ApiController
    {
        private Gabriq_System_DatabaseEntities db = new Gabriq_System_DatabaseEntities();

        // GET: api/Tender_Status
        public IQueryable<Tender_Status> GetTender_Status()
        {
            return db.Tender_Status;
        }

        // GET: api/Tender_Status/5
        [ResponseType(typeof(Tender_Status))]
        public async Task<IHttpActionResult> GetTender_Status(int id)
        {
            Tender_Status tender_Status = await db.Tender_Status.FindAsync(id);
            if (tender_Status == null)
            {
                return NotFound();
            }

            return Ok(tender_Status);
        }

        // PUT: api/Tender_Status/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTender_Status(int id, Tender_Status tender_Status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tender_Status.Tender_Status_ID)
            {
                return BadRequest();
            }

            db.Entry(tender_Status).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tender_StatusExists(id))
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

        // POST: api/Tender_Status
        [ResponseType(typeof(Tender_Status))]
        public async Task<IHttpActionResult> PostTender_Status(Tender_Status tender_Status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tender_Status.Add(tender_Status);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Tender_StatusExists(tender_Status.Tender_Status_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tender_Status.Tender_Status_ID }, tender_Status);
        }

        // DELETE: api/Tender_Status/5
        [ResponseType(typeof(Tender_Status))]
        public async Task<IHttpActionResult> DeleteTender_Status(int id)
        {
            Tender_Status tender_Status = await db.Tender_Status.FindAsync(id);
            if (tender_Status == null)
            {
                return NotFound();
            }

            db.Tender_Status.Remove(tender_Status);
            await db.SaveChangesAsync();

            return Ok(tender_Status);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tender_StatusExists(int id)
        {
            return db.Tender_Status.Count(e => e.Tender_Status_ID == id) > 0;
        }
    }
}