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
    public class RentalsController : ApiController
    {
        private Gabriq_System_DatabaseEntities db = new Gabriq_System_DatabaseEntities();

        // GET: api/Rentals
        public IQueryable<Rental> GetRentals()
        {
            return db.Rentals;
        }

        // GET: api/Rentals/5
        [ResponseType(typeof(Rental))]
        public async Task<IHttpActionResult> GetRental(int id)
        {
            Rental rental = await db.Rentals.FindAsync(id);
            if (rental == null)
            {
                return NotFound();
            }

            return Ok(rental);
        }

        // PUT: api/Rentals/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRental(int id, Rental rental)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rental.Rental_ID)
            {
                return BadRequest();
            }

            db.Entry(rental).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentalExists(id))
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

        // POST: api/Rentals
        [ResponseType(typeof(Rental))]
        public async Task<IHttpActionResult> PostRental(Rental rental)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rentals.Add(rental);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RentalExists(rental.Rental_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = rental.Rental_ID }, rental);
        }

        // DELETE: api/Rentals/5
        [ResponseType(typeof(Rental))]
        public async Task<IHttpActionResult> DeleteRental(int id)
        {
            Rental rental = await db.Rentals.FindAsync(id);
            if (rental == null)
            {
                return NotFound();
            }

            db.Rentals.Remove(rental);
            await db.SaveChangesAsync();

            return Ok(rental);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RentalExists(int id)
        {
            return db.Rentals.Count(e => e.Rental_ID == id) > 0;
        }
    }
}