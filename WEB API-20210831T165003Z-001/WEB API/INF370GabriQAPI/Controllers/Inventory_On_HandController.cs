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
    public class Inventory_On_HandController : ApiController
    {
        private Gabriq_System_DatabaseEntities db = new Gabriq_System_DatabaseEntities();

        // GET: api/Inventory_On_Hand
        public IQueryable<Inventory_On_Hand> GetInventory_On_Hand()
        {
            return db.Inventory_On_Hand;
        }

        // GET: api/Inventory_On_Hand/5
        [ResponseType(typeof(Inventory_On_Hand))]
        public async Task<IHttpActionResult> GetInventory_On_Hand(int id)
        {
            Inventory_On_Hand inventory_On_Hand = await db.Inventory_On_Hand.FindAsync(id);
            if (inventory_On_Hand == null)
            {
                return NotFound();
            }

            return Ok(inventory_On_Hand);
        }

        // PUT: api/Inventory_On_Hand/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutInventory_On_Hand(int id, Inventory_On_Hand inventory_On_Hand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inventory_On_Hand.Inventory_On_Hand_ID)
            {
                return BadRequest();
            }

            db.Entry(inventory_On_Hand).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Inventory_On_HandExists(id))
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

        // POST: api/Inventory_On_Hand
        [ResponseType(typeof(Inventory_On_Hand))]
        public async Task<IHttpActionResult> PostInventory_On_Hand(Inventory_On_Hand inventory_On_Hand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Inventory_On_Hand.Add(inventory_On_Hand);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Inventory_On_HandExists(inventory_On_Hand.Inventory_On_Hand_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = inventory_On_Hand.Inventory_On_Hand_ID }, inventory_On_Hand);
        }

        // DELETE: api/Inventory_On_Hand/5
        [ResponseType(typeof(Inventory_On_Hand))]
        public async Task<IHttpActionResult> DeleteInventory_On_Hand(int id)
        {
            Inventory_On_Hand inventory_On_Hand = await db.Inventory_On_Hand.FindAsync(id);
            if (inventory_On_Hand == null)
            {
                return NotFound();
            }

            db.Inventory_On_Hand.Remove(inventory_On_Hand);
            await db.SaveChangesAsync();

            return Ok(inventory_On_Hand);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Inventory_On_HandExists(int id)
        {
            return db.Inventory_On_Hand.Count(e => e.Inventory_On_Hand_ID == id) > 0;
        }
    }
}