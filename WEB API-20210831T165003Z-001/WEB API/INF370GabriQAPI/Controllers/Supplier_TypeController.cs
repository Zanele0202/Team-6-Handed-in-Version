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
    public class Supplier_TypeController : ApiController
    {
        private Gabriq_System_DatabaseEntities db = new Gabriq_System_DatabaseEntities();

        // GET: api/Supplier_Type
        public IQueryable<Supplier_Type> GetSupplier_Type()
        {
            return db.Supplier_Type;
        }

        // GET: api/Supplier_Type/5
        [ResponseType(typeof(Supplier_Type))]
        public async Task<IHttpActionResult> GetSupplier_Type(int id)
        {
            Supplier_Type supplier_Type = await db.Supplier_Type.FindAsync(id);
            if (supplier_Type == null)
            {
                return NotFound();
            }

            return Ok(supplier_Type);
        }

        // PUT: api/Supplier_Type/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSupplier_Type(int id, Supplier_Type supplier_Type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != supplier_Type.Supplier_Type_ID)
            {
                return BadRequest();
            }

            db.Entry(supplier_Type).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Supplier_TypeExists(id))
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

        // POST: api/Supplier_Type
        [ResponseType(typeof(Supplier_Type))]
        public async Task<IHttpActionResult> PostSupplier_Type(Supplier_Type supplier_Type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Supplier_Type.Add(supplier_Type);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Supplier_TypeExists(supplier_Type.Supplier_Type_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = supplier_Type.Supplier_Type_ID }, supplier_Type);
        }

        // DELETE: api/Supplier_Type/5
        [ResponseType(typeof(Supplier_Type))]
        public async Task<IHttpActionResult> DeleteSupplier_Type(int id)
        {
            Supplier_Type supplier_Type = await db.Supplier_Type.FindAsync(id);
            if (supplier_Type == null)
            {
                return NotFound();
            }

            db.Supplier_Type.Remove(supplier_Type);
            await db.SaveChangesAsync();

            return Ok(supplier_Type);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Supplier_TypeExists(int id)
        {
            return db.Supplier_Type.Count(e => e.Supplier_Type_ID == id) > 0;
        }
    }
}