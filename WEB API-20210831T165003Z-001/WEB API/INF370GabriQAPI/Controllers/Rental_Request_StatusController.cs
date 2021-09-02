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
    public class Rental_Request_StatusController : ApiController
    {
        private Gabriq_System_DatabaseEntities db = new Gabriq_System_DatabaseEntities();

        // GET: api/Rental_Request_Status
        public IQueryable<Rental_Request_Status> GetRental_Request_Status()
        {
            return db.Rental_Request_Status;
        }

        // GET: api/Rental_Request_Status/5
        [ResponseType(typeof(Rental_Request_Status))]
        public async Task<IHttpActionResult> GetRental_Request_Status(int id)
        {
            Rental_Request_Status rental_Request_Status = await db.Rental_Request_Status.FindAsync(id);
            if (rental_Request_Status == null)
            {
                return NotFound();
            }

            return Ok(rental_Request_Status);
        }

        // PUT: api/Rental_Request_Status/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRental_Request_Status(int id, Rental_Request_Status rental_Request_Status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rental_Request_Status.Rental_Request_Status_ID)
            {
                return BadRequest();
            }

            db.Entry(rental_Request_Status).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Rental_Request_StatusExists(id))
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

        // POST: api/Rental_Request_Status
        [ResponseType(typeof(Rental_Request_Status))]
        public async Task<IHttpActionResult> PostRental_Request_Status(Rental_Request_Status rental_Request_Status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rental_Request_Status.Add(rental_Request_Status);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Rental_Request_StatusExists(rental_Request_Status.Rental_Request_Status_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = rental_Request_Status.Rental_Request_Status_ID }, rental_Request_Status);
        }

        // DELETE: api/Rental_Request_Status/5
        [ResponseType(typeof(Rental_Request_Status))]
        public async Task<IHttpActionResult> DeleteRental_Request_Status(int id)
        {
            Rental_Request_Status rental_Request_Status = await db.Rental_Request_Status.FindAsync(id);
            if (rental_Request_Status == null)
            {
                return NotFound();
            }

            db.Rental_Request_Status.Remove(rental_Request_Status);
            await db.SaveChangesAsync();

            return Ok(rental_Request_Status);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Rental_Request_StatusExists(int id)
        {
            return db.Rental_Request_Status.Count(e => e.Rental_Request_Status_ID == id) > 0;
        }
    }
}