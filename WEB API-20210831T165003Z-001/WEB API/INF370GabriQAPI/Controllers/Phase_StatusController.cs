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
    public class Phase_StatusController : ApiController
    {
        private Gabriq_System_DatabaseEntities db = new Gabriq_System_DatabaseEntities();

        // GET: api/Phase_Status
        public IQueryable<Phase_Status> GetPhase_Status()
        {
            return db.Phase_Status;
        }

        // GET: api/Phase_Status/5
        [ResponseType(typeof(Phase_Status))]
        public async Task<IHttpActionResult> GetPhase_Status(int id)
        {
            Phase_Status phase_Status = await db.Phase_Status.FindAsync(id);
            if (phase_Status == null)
            {
                return NotFound();
            }

            return Ok(phase_Status);
        }

        // PUT: api/Phase_Status/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPhase_Status(int id, Phase_Status phase_Status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != phase_Status.Phase_Status_ID)
            {
                return BadRequest();
            }

            db.Entry(phase_Status).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Phase_StatusExists(id))
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

        // POST: api/Phase_Status
        [ResponseType(typeof(Phase_Status))]
        public async Task<IHttpActionResult> PostPhase_Status(Phase_Status phase_Status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Phase_Status.Add(phase_Status);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Phase_StatusExists(phase_Status.Phase_Status_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = phase_Status.Phase_Status_ID }, phase_Status);
        }

        // DELETE: api/Phase_Status/5
        [ResponseType(typeof(Phase_Status))]
        public async Task<IHttpActionResult> DeletePhase_Status(int id)
        {
            Phase_Status phase_Status = await db.Phase_Status.FindAsync(id);
            if (phase_Status == null)
            {
                return NotFound();
            }

            db.Phase_Status.Remove(phase_Status);
            await db.SaveChangesAsync();

            return Ok(phase_Status);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Phase_StatusExists(int id)
        {
            return db.Phase_Status.Count(e => e.Phase_Status_ID == id) > 0;
        }
    }
}