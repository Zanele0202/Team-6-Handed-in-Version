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
    public class SubcontractorsController : ApiController
    {
        private Gabriq_System_DatabaseEntities db = new Gabriq_System_DatabaseEntities();

        // GET: api/Subcontractors
        public IQueryable<Subcontractor> GetSubcontractors()
        {
            return db.Subcontractors;
        }

        // GET: api/Subcontractors/5
        [ResponseType(typeof(Subcontractor))]
        public async Task<IHttpActionResult> GetSubcontractor(int id)
        {
            Subcontractor subcontractor = await db.Subcontractors.FindAsync(id);
            if (subcontractor == null)
            {
                return NotFound();
            }

            return Ok(subcontractor);
        }

        // PUT: api/Subcontractors/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSubcontractor(int id, Subcontractor subcontractor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subcontractor.Subcontractor_ID)
            {
                return BadRequest();
            }

            db.Entry(subcontractor).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubcontractorExists(id))
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

        // POST: api/Subcontractors
        [ResponseType(typeof(Subcontractor))]
        public async Task<IHttpActionResult> PostSubcontractor(Subcontractor subcontractor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Subcontractors.Add(subcontractor);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SubcontractorExists(subcontractor.Subcontractor_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = subcontractor.Subcontractor_ID }, subcontractor);
        }

        // DELETE: api/Subcontractors/5
        [ResponseType(typeof(Subcontractor))]
        public async Task<IHttpActionResult> DeleteSubcontractor(int id)
        {
            Subcontractor subcontractor = await db.Subcontractors.FindAsync(id);
            if (subcontractor == null)
            {
                return NotFound();
            }

            db.Subcontractors.Remove(subcontractor);
            await db.SaveChangesAsync();

            return Ok(subcontractor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubcontractorExists(int id)
        {
            return db.Subcontractors.Count(e => e.Subcontractor_ID == id) > 0;
        }
    }
}