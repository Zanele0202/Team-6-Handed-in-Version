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
    public class Rental_LineController : ApiController
    {
        private Gabriq_System_DatabaseEntities db = new Gabriq_System_DatabaseEntities();

        // GET: api/Rental_Line
        public IQueryable<Rental_Line> GetRental_Line()
        {
            return db.Rental_Line;
        }

        // GET: api/Rental_Line/5
        [ResponseType(typeof(Rental_Line))]
        public async Task<IHttpActionResult> GetRental_Line(int id)
        {
            Rental_Line rental_Line = await db.Rental_Line.FindAsync(id);
            if (rental_Line == null)
            {
                return NotFound();
            }

            return Ok(rental_Line);
        }

        // PUT: api/Rental_Line/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRental_Line(int id, Rental_Line rental_Line)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rental_Line.Rental_Line_ID)
            {
                return BadRequest();
            }

            db.Entry(rental_Line).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Rental_LineExists(id))
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

        // POST: api/Rental_Line
        [ResponseType(typeof(Rental_Line))]
        public async Task<IHttpActionResult> PostRental_Line(Rental_Line rental_Line)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rental_Line.Add(rental_Line);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Rental_LineExists(rental_Line.Rental_Line_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = rental_Line.Rental_Line_ID }, rental_Line);
        }

        // DELETE: api/Rental_Line/5
        [ResponseType(typeof(Rental_Line))]
        public async Task<IHttpActionResult> DeleteRental_Line(int id)
        {
            Rental_Line rental_Line = await db.Rental_Line.FindAsync(id);
            if (rental_Line == null)
            {
                return NotFound();
            }

            db.Rental_Line.Remove(rental_Line);
            await db.SaveChangesAsync();

            return Ok(rental_Line);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Rental_LineExists(int id)
        {
            return db.Rental_Line.Count(e => e.Rental_Line_ID == id) > 0;
        }
    }
}