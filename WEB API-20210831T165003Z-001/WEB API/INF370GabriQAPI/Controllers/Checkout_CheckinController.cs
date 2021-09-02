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
    public class Checkout_CheckinController : ApiController
    {
        private Gabriq_System_DatabaseEntities db = new Gabriq_System_DatabaseEntities();

        // GET: api/Checkout_Checkin
        public IQueryable<Checkout_Checkin> GetCheckout_Checkin()
        {
            return db.Checkout_Checkin;
        }

        // GET: api/Checkout_Checkin/5
        [ResponseType(typeof(Checkout_Checkin))]
        public async Task<IHttpActionResult> GetCheckout_Checkin(int id)
        {
            Checkout_Checkin checkout_Checkin = await db.Checkout_Checkin.FindAsync(id);
            if (checkout_Checkin == null)
            {
                return NotFound();
            }

            return Ok(checkout_Checkin);
        }

        // PUT: api/Checkout_Checkin/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCheckout_Checkin(int id, Checkout_Checkin checkout_Checkin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != checkout_Checkin.Checkout_ID)
            {
                return BadRequest();
            }

            db.Entry(checkout_Checkin).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Checkout_CheckinExists(id))
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

        // POST: api/Checkout_Checkin
        [ResponseType(typeof(Checkout_Checkin))]
        public async Task<IHttpActionResult> PostCheckout_Checkin(Checkout_Checkin checkout_Checkin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Checkout_Checkin.Add(checkout_Checkin);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Checkout_CheckinExists(checkout_Checkin.Checkout_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = checkout_Checkin.Checkout_ID }, checkout_Checkin);
        }

        // DELETE: api/Checkout_Checkin/5
        [ResponseType(typeof(Checkout_Checkin))]
        public async Task<IHttpActionResult> DeleteCheckout_Checkin(int id)
        {
            Checkout_Checkin checkout_Checkin = await db.Checkout_Checkin.FindAsync(id);
            if (checkout_Checkin == null)
            {
                return NotFound();
            }

            db.Checkout_Checkin.Remove(checkout_Checkin);
            await db.SaveChangesAsync();

            return Ok(checkout_Checkin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Checkout_CheckinExists(int id)
        {
            return db.Checkout_Checkin.Count(e => e.Checkout_ID == id) > 0;
        }
    }
}