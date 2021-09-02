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
    public class PhasesController : ApiController
    {
        private Gabriq_System_DatabaseEntities db = new Gabriq_System_DatabaseEntities();

        // GET: api/Phases
        public IQueryable<Phase> GetPhases()
        {
            return db.Phases;
        }

        // GET: api/Phases/5
        [ResponseType(typeof(Phase))]
        public async Task<IHttpActionResult> GetPhase(int id)
        {
            Phase phase = await db.Phases.FindAsync(id);
            if (phase == null)
            {
                return NotFound();
            }

            return Ok(phase);
        }

        // PUT: api/Phases/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPhase(int id, Phase phase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != phase.Phase_ID)
            {
                return BadRequest();
            }

            db.Entry(phase).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhaseExists(id))
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

        // POST: api/Phases
        [ResponseType(typeof(Phase))]
        public async Task<IHttpActionResult> PostPhase(Phase phase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Phases.Add(phase);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PhaseExists(phase.Phase_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = phase.Phase_ID }, phase);
        }

        // DELETE: api/Phases/5
        [ResponseType(typeof(Phase))]
        public async Task<IHttpActionResult> DeletePhase(int id)
        {
            Phase phase = await db.Phases.FindAsync(id);
            if (phase == null)
            {
                return NotFound();
            }

            db.Phases.Remove(phase);
            await db.SaveChangesAsync();

            return Ok(phase);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PhaseExists(int id)
        {
            return db.Phases.Count(e => e.Phase_ID == id) > 0;
        }
    }
}