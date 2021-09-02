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
    public class Payment_TypeController : ApiController
    {
        private Gabriq_System_DatabaseEntities db = new Gabriq_System_DatabaseEntities();

        // GET: api/Payment_Type
        public IQueryable<Payment_Type> GetPayment_Type()
        {
            return db.Payment_Type;
        }

        // GET: api/Payment_Type/5
        [ResponseType(typeof(Payment_Type))]
        public async Task<IHttpActionResult> GetPayment_Type(int id)
        {
            Payment_Type payment_Type = await db.Payment_Type.FindAsync(id);
            if (payment_Type == null)
            {
                return NotFound();
            }

            return Ok(payment_Type);
        }

        // PUT: api/Payment_Type/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPayment_Type(int id, Payment_Type payment_Type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != payment_Type.Payment_Type_ID)
            {
                return BadRequest();
            }

            db.Entry(payment_Type).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Payment_TypeExists(id))
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

        // POST: api/Payment_Type
        [ResponseType(typeof(Payment_Type))]
        public async Task<IHttpActionResult> PostPayment_Type(Payment_Type payment_Type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Payment_Type.Add(payment_Type);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Payment_TypeExists(payment_Type.Payment_Type_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = payment_Type.Payment_Type_ID }, payment_Type);
        }

        // DELETE: api/Payment_Type/5
        [ResponseType(typeof(Payment_Type))]
        public async Task<IHttpActionResult> DeletePayment_Type(int id)
        {
            Payment_Type payment_Type = await db.Payment_Type.FindAsync(id);
            if (payment_Type == null)
            {
                return NotFound();
            }

            db.Payment_Type.Remove(payment_Type);
            await db.SaveChangesAsync();

            return Ok(payment_Type);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Payment_TypeExists(int id)
        {
            return db.Payment_Type.Count(e => e.Payment_Type_ID == id) > 0;
        }
    }
}