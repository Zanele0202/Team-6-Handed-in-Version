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
    public class Checkout_Checkin_DateController : ApiController
    {
        private Gabriq_System_DatabaseEntities db = new Gabriq_System_DatabaseEntities();

        // GET: api/Checkout_Checkin_Date
        public IQueryable<Checkout_Checkin_Date> GetCheckout_Checkin_Date()
        {
            return db.Checkout_Checkin_Date;
        }

        // GET: api/Checkout_Checkin_Date/5
        [ResponseType(typeof(Checkout_Checkin_Date))]
        public async Task<IHttpActionResult> GetCheckout_Checkin_Date(int id)
        {
            Checkout_Checkin_Date checkout_Checkin_Date = await db.Checkout_Checkin_Date.FindAsync(id);
            if (checkout_Checkin_Date == null)
            {
                return NotFound();
            }

            return Ok(checkout_Checkin_Date);
        }

        // PUT: api/Checkout_Checkin_Date/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCheckout_Checkin_Date(int id, Checkout_Checkin_Date checkout_Checkin_Date)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != checkout_Checkin_Date.Checkout_Date_ID)
            {
                return BadRequest();
            }

            db.Entry(checkout_Checkin_Date).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Checkout_Checkin_DateExists(id))
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

        // POST: api/Checkout_Checkin_Date
        [ResponseType(typeof(Checkout_Checkin_Date))]
        public async Task<IHttpActionResult> PostCheckout_Checkin_Date(Checkout_Checkin_Date checkout_Checkin_Date)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Checkout_Checkin_Date.Add(checkout_Checkin_Date);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Checkout_Checkin_DateExists(checkout_Checkin_Date.Checkout_Date_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = checkout_Checkin_Date.Checkout_Date_ID }, checkout_Checkin_Date);
        }

        // DELETE: api/Checkout_Checkin_Date/5
        [ResponseType(typeof(Checkout_Checkin_Date))]
        public async Task<IHttpActionResult> DeleteCheckout_Checkin_Date(int id)
        {
            Checkout_Checkin_Date checkout_Checkin_Date = await db.Checkout_Checkin_Date.FindAsync(id);
            if (checkout_Checkin_Date == null)
            {
                return NotFound();
            }

            db.Checkout_Checkin_Date.Remove(checkout_Checkin_Date);
            await db.SaveChangesAsync();

            return Ok(checkout_Checkin_Date);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Checkout_Checkin_DateExists(int id)
        {
            return db.Checkout_Checkin_Date.Count(e => e.Checkout_Date_ID == id) > 0;
        }
    }
}