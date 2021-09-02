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
    public class Phase_InventoryController : ApiController
    {
        private Gabriq_System_DatabaseEntities db = new Gabriq_System_DatabaseEntities();

        // GET: api/Phase_Inventory
        public IQueryable<Phase_Inventory> GetPhase_Inventory()
        {
            return db.Phase_Inventory;
        }

        // GET: api/Phase_Inventory/5
        [ResponseType(typeof(Phase_Inventory))]
        public async Task<IHttpActionResult> GetPhase_Inventory(int id)
        {
            Phase_Inventory phase_Inventory = await db.Phase_Inventory.FindAsync(id);
            if (phase_Inventory == null)
            {
                return NotFound();
            }

            return Ok(phase_Inventory);
        }

        // PUT: api/Phase_Inventory/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPhase_Inventory(int id, Phase_Inventory phase_Inventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != phase_Inventory.Phase_Inventory_ID)
            {
                return BadRequest();
            }

            db.Entry(phase_Inventory).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Phase_InventoryExists(id))
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

        // POST: api/Phase_Inventory
        [ResponseType(typeof(Phase_Inventory))]
        public async Task<IHttpActionResult> PostPhase_Inventory(Phase_Inventory phase_Inventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Phase_Inventory.Add(phase_Inventory);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Phase_InventoryExists(phase_Inventory.Phase_Inventory_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = phase_Inventory.Phase_Inventory_ID }, phase_Inventory);
        }

        // DELETE: api/Phase_Inventory/5
        [ResponseType(typeof(Phase_Inventory))]
        public async Task<IHttpActionResult> DeletePhase_Inventory(int id)
        {
            Phase_Inventory phase_Inventory = await db.Phase_Inventory.FindAsync(id);
            if (phase_Inventory == null)
            {
                return NotFound();
            }

            db.Phase_Inventory.Remove(phase_Inventory);
            await db.SaveChangesAsync();

            return Ok(phase_Inventory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Phase_InventoryExists(int id)
        {
            return db.Phase_Inventory.Count(e => e.Phase_Inventory_ID == id) > 0;
        }
    }
}