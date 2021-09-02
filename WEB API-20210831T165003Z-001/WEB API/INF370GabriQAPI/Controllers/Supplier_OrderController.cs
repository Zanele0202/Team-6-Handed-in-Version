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
    public class Supplier_OrderController : ApiController
    {
        private Gabriq_System_DatabaseEntities db = new Gabriq_System_DatabaseEntities();

        // GET: api/Supplier_Order
        public IQueryable<Supplier_Order> GetSupplier_Order()
        {
            return db.Supplier_Order;
        }

        // GET: api/Supplier_Order/5
        [ResponseType(typeof(Supplier_Order))]
        public async Task<IHttpActionResult> GetSupplier_Order(int id)
        {
            Supplier_Order supplier_Order = await db.Supplier_Order.FindAsync(id);
            if (supplier_Order == null)
            {
                return NotFound();
            }

            return Ok(supplier_Order);
        }

        // PUT: api/Supplier_Order/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSupplier_Order(int id, Supplier_Order supplier_Order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != supplier_Order.Supplier_Order_ID)
            {
                return BadRequest();
            }

            db.Entry(supplier_Order).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Supplier_OrderExists(id))
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

        // POST: api/Supplier_Order
        [ResponseType(typeof(Supplier_Order))]
        public async Task<IHttpActionResult> PostSupplier_Order(Supplier_Order supplier_Order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Supplier_Order.Add(supplier_Order);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Supplier_OrderExists(supplier_Order.Supplier_Order_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = supplier_Order.Supplier_Order_ID }, supplier_Order);
        }

        // DELETE: api/Supplier_Order/5
        [ResponseType(typeof(Supplier_Order))]
        public async Task<IHttpActionResult> DeleteSupplier_Order(int id)
        {
            Supplier_Order supplier_Order = await db.Supplier_Order.FindAsync(id);
            if (supplier_Order == null)
            {
                return NotFound();
            }

            db.Supplier_Order.Remove(supplier_Order);
            await db.SaveChangesAsync();

            return Ok(supplier_Order);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Supplier_OrderExists(int id)
        {
            return db.Supplier_Order.Count(e => e.Supplier_Order_ID == id) > 0;
        }
    }
}