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
    public class WriteOff_InventoryController : ApiController
    {
        private Gabriq_System_DatabaseEntities db = new Gabriq_System_DatabaseEntities();

        // GET: api/WriteOff_Inventory
        public IQueryable<WriteOff_Inventory> GetWriteOff_Inventory()
        {
            return db.WriteOff_Inventory;
        }

        // GET: api/WriteOff_Inventory/5
        [ResponseType(typeof(WriteOff_Inventory))]
        public async Task<IHttpActionResult> GetWriteOff_Inventory(int id)
        {
            WriteOff_Inventory writeOff_Inventory = await db.WriteOff_Inventory.FindAsync(id);
            if (writeOff_Inventory == null)
            {
                return NotFound();
            }

            return Ok(writeOff_Inventory);
        }

        // PUT: api/WriteOff_Inventory/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWriteOff_Inventory(int id, WriteOff_Inventory writeOff_Inventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != writeOff_Inventory.WriteoffInventory_ID)
            {
                return BadRequest();
            }

            db.Entry(writeOff_Inventory).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WriteOff_InventoryExists(id))
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

        // POST: api/WriteOff_Inventory
        [ResponseType(typeof(WriteOff_Inventory))]
        public async Task<IHttpActionResult> PostWriteOff_Inventory(WriteOff_Inventory writeOff_Inventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WriteOff_Inventory.Add(writeOff_Inventory);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WriteOff_InventoryExists(writeOff_Inventory.WriteoffInventory_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = writeOff_Inventory.WriteoffInventory_ID }, writeOff_Inventory);
        }

        // DELETE: api/WriteOff_Inventory/5
        [ResponseType(typeof(WriteOff_Inventory))]
        public async Task<IHttpActionResult> DeleteWriteOff_Inventory(int id)
        {
            WriteOff_Inventory writeOff_Inventory = await db.WriteOff_Inventory.FindAsync(id);
            if (writeOff_Inventory == null)
            {
                return NotFound();
            }

            db.WriteOff_Inventory.Remove(writeOff_Inventory);
            await db.SaveChangesAsync();

            return Ok(writeOff_Inventory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WriteOff_InventoryExists(int id)
        {
            return db.WriteOff_Inventory.Count(e => e.WriteoffInventory_ID == id) > 0;
        }
    }
}