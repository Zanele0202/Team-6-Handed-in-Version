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
    public class Subcontractor_PhaseController : ApiController
    {
        private Gabriq_System_DatabaseEntities db = new Gabriq_System_DatabaseEntities();

        // GET: api/Subcontractor_Phase
        public IQueryable<Subcontractor_Phase> GetSubcontractor_Phase()
        {
            return db.Subcontractor_Phase;
        }

        // GET: api/Subcontractor_Phase/5
        [ResponseType(typeof(Subcontractor_Phase))]
        public async Task<IHttpActionResult> GetSubcontractor_Phase(int id)
        {
            Subcontractor_Phase subcontractor_Phase = await db.Subcontractor_Phase.FindAsync(id);
            if (subcontractor_Phase == null)
            {
                return NotFound();
            }

            return Ok(subcontractor_Phase);
        }

        // PUT: api/Subcontractor_Phase/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSubcontractor_Phase(int id, Subcontractor_Phase subcontractor_Phase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subcontractor_Phase.Subcontractor_Phase_ID)
            {
                return BadRequest();
            }

            db.Entry(subcontractor_Phase).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Subcontractor_PhaseExists(id))
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

        // POST: api/Subcontractor_Phase
        [ResponseType(typeof(Subcontractor_Phase))]
        public async Task<IHttpActionResult> PostSubcontractor_Phase(Subcontractor_Phase subcontractor_Phase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Subcontractor_Phase.Add(subcontractor_Phase);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Subcontractor_PhaseExists(subcontractor_Phase.Subcontractor_Phase_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = subcontractor_Phase.Subcontractor_Phase_ID }, subcontractor_Phase);
        }

        // DELETE: api/Subcontractor_Phase/5
        [ResponseType(typeof(Subcontractor_Phase))]
        public async Task<IHttpActionResult> DeleteSubcontractor_Phase(int id)
        {
            Subcontractor_Phase subcontractor_Phase = await db.Subcontractor_Phase.FindAsync(id);
            if (subcontractor_Phase == null)
            {
                return NotFound();
            }

            db.Subcontractor_Phase.Remove(subcontractor_Phase);
            await db.SaveChangesAsync();

            return Ok(subcontractor_Phase);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Subcontractor_PhaseExists(int id)
        {
            return db.Subcontractor_Phase.Count(e => e.Subcontractor_Phase_ID == id) > 0;
        }
    }
}