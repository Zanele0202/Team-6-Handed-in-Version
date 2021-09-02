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
    public class Order_StatusController : ApiController
    {
        private Gabriq_System_DatabaseEntities db = new Gabriq_System_DatabaseEntities();

        // GET: api/Order_Status
        public IQueryable<Order_Status> GetOrder_Status()
        {
            return db.Order_Status;
        }

        // GET: api/Order_Status/5
        [ResponseType(typeof(Order_Status))]
        public async Task<IHttpActionResult> GetOrder_Status(int id)
        {
            Order_Status order_Status = await db.Order_Status.FindAsync(id);
            if (order_Status == null)
            {
                return NotFound();
            }

            return Ok(order_Status);
        }

        // PUT: api/Order_Status/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOrder_Status(int id, Order_Status order_Status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order_Status.Order_Status_ID)
            {
                return BadRequest();
            }

            db.Entry(order_Status).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Order_StatusExists(id))
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

        // POST: api/Order_Status
        [ResponseType(typeof(Order_Status))]
        public async Task<IHttpActionResult> PostOrder_Status(Order_Status order_Status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Order_Status.Add(order_Status);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Order_StatusExists(order_Status.Order_Status_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = order_Status.Order_Status_ID }, order_Status);
        }

        // DELETE: api/Order_Status/5
        [ResponseType(typeof(Order_Status))]
        public async Task<IHttpActionResult> DeleteOrder_Status(int id)
        {
            Order_Status order_Status = await db.Order_Status.FindAsync(id);
            if (order_Status == null)
            {
                return NotFound();
            }

            db.Order_Status.Remove(order_Status);
            await db.SaveChangesAsync();

            return Ok(order_Status);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Order_StatusExists(int id)
        {
            return db.Order_Status.Count(e => e.Order_Status_ID == id) > 0;
        }
    }
}