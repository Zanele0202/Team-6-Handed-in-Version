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
    public class Password_HistoryController : ApiController
    {
        private Gabriq_System_DatabaseEntities db = new Gabriq_System_DatabaseEntities();

        // GET: api/Password_History
        public IQueryable<Password_History> GetPassword_History()
        {
            return db.Password_History;
        }

        // GET: api/Password_History/5
        [ResponseType(typeof(Password_History))]
        public async Task<IHttpActionResult> GetPassword_History(int id)
        {
            Password_History password_History = await db.Password_History.FindAsync(id);
            if (password_History == null)
            {
                return NotFound();
            }

            return Ok(password_History);
        }

        // PUT: api/Password_History/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPassword_History(int id, Password_History password_History)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != password_History.Password_ID)
            {
                return BadRequest();
            }

            db.Entry(password_History).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Password_HistoryExists(id))
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

        // POST: api/Password_History
        [ResponseType(typeof(Password_History))]
        public async Task<IHttpActionResult> PostPassword_History(Password_History password_History)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Password_History.Add(password_History);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Password_HistoryExists(password_History.Password_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = password_History.Password_ID }, password_History);
        }

        // DELETE: api/Password_History/5
        [ResponseType(typeof(Password_History))]
        public async Task<IHttpActionResult> DeletePassword_History(int id)
        {
            Password_History password_History = await db.Password_History.FindAsync(id);
            if (password_History == null)
            {
                return NotFound();
            }

            db.Password_History.Remove(password_History);
            await db.SaveChangesAsync();

            return Ok(password_History);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Password_HistoryExists(int id)
        {
            return db.Password_History.Count(e => e.Password_ID == id) > 0;
        }
    }
}