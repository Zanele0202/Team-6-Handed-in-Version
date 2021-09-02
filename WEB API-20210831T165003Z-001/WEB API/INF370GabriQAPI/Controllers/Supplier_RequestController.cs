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
    public class Supplier_RequestController : ApiController
    {
        private Gabriq_System_DatabaseEntities db = new Gabriq_System_DatabaseEntities();

        // GET: api/Supplier_Request
        public IQueryable<Supplier_Request> GetSupplier_Request()
        {
            return db.Supplier_Request;
        }

        // GET: api/Supplier_Request/5
        [ResponseType(typeof(Supplier_Request))]
        public async Task<IHttpActionResult> GetSupplier_Request(int id)
        {
            Supplier_Request supplier_Request = await db.Supplier_Request.FindAsync(id);
            if (supplier_Request == null)
            {
                return NotFound();
            }

            return Ok(supplier_Request);
        }

        // PUT: api/Supplier_Request/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSupplier_Request(int id, Supplier_Request supplier_Request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != supplier_Request.Supplier_Request_ID)
            {
                return BadRequest();
            }

            db.Entry(supplier_Request).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Supplier_RequestExists(id))
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

        // POST: api/Supplier_Request
        [ResponseType(typeof(Supplier_Request))]
        public async Task<IHttpActionResult> PostSupplier_Request(Supplier_Request supplier_Request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Supplier_Request.Add(supplier_Request);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Supplier_RequestExists(supplier_Request.Supplier_Request_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = supplier_Request.Supplier_Request_ID }, supplier_Request);
        }

        // DELETE: api/Supplier_Request/5
        [ResponseType(typeof(Supplier_Request))]
        public async Task<IHttpActionResult> DeleteSupplier_Request(int id)
        {
            Supplier_Request supplier_Request = await db.Supplier_Request.FindAsync(id);
            if (supplier_Request == null)
            {
                return NotFound();
            }

            db.Supplier_Request.Remove(supplier_Request);
            await db.SaveChangesAsync();

            return Ok(supplier_Request);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Supplier_RequestExists(int id)
        {
            return db.Supplier_Request.Count(e => e.Supplier_Request_ID == id) > 0;
        }
    }
}