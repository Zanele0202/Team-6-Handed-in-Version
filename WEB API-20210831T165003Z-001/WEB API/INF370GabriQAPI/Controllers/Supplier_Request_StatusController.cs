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
    public class Supplier_Request_StatusController : ApiController
    {
        private Gabriq_System_DatabaseEntities db = new Gabriq_System_DatabaseEntities();

        // GET: api/Supplier_Request_Status
        public IQueryable<Supplier_Request_Status> GetSupplier_Request_Status()
        {
            return db.Supplier_Request_Status;
        }

        // GET: api/Supplier_Request_Status/5
        [ResponseType(typeof(Supplier_Request_Status))]
        public async Task<IHttpActionResult> GetSupplier_Request_Status(int id)
        {
            Supplier_Request_Status supplier_Request_Status = await db.Supplier_Request_Status.FindAsync(id);
            if (supplier_Request_Status == null)
            {
                return NotFound();
            }

            return Ok(supplier_Request_Status);
        }

        // PUT: api/Supplier_Request_Status/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSupplier_Request_Status(int id, Supplier_Request_Status supplier_Request_Status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != supplier_Request_Status.Supplier_Request_Status_ID)
            {
                return BadRequest();
            }

            db.Entry(supplier_Request_Status).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Supplier_Request_StatusExists(id))
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

        // POST: api/Supplier_Request_Status
        [ResponseType(typeof(Supplier_Request_Status))]
        public async Task<IHttpActionResult> PostSupplier_Request_Status(Supplier_Request_Status supplier_Request_Status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Supplier_Request_Status.Add(supplier_Request_Status);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Supplier_Request_StatusExists(supplier_Request_Status.Supplier_Request_Status_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = supplier_Request_Status.Supplier_Request_Status_ID }, supplier_Request_Status);
        }

        // DELETE: api/Supplier_Request_Status/5
        [ResponseType(typeof(Supplier_Request_Status))]
        public async Task<IHttpActionResult> DeleteSupplier_Request_Status(int id)
        {
            Supplier_Request_Status supplier_Request_Status = await db.Supplier_Request_Status.FindAsync(id);
            if (supplier_Request_Status == null)
            {
                return NotFound();
            }

            db.Supplier_Request_Status.Remove(supplier_Request_Status);
            await db.SaveChangesAsync();

            return Ok(supplier_Request_Status);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Supplier_Request_StatusExists(int id)
        {
            return db.Supplier_Request_Status.Count(e => e.Supplier_Request_Status_ID == id) > 0;
        }
    }
}