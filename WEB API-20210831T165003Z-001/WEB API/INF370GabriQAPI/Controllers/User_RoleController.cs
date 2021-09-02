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
    public class User_RoleController : ApiController
    {
        private Gabriq_System_DatabaseEntities db = new Gabriq_System_DatabaseEntities();

        // GET: api/User_Role
        public IQueryable<User_Role> GetUser_Role()
        {
            return db.User_Role;
        }

        // GET: api/User_Role/5
        [ResponseType(typeof(User_Role))]
        public async Task<IHttpActionResult> GetUser_Role(int id)
        {
            User_Role user_Role = await db.User_Role.FindAsync(id);
            if (user_Role == null)
            {
                return NotFound();
            }

            return Ok(user_Role);
        }

        // PUT: api/User_Role/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUser_Role(int id, User_Role user_Role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user_Role.User_Role_ID)
            {
                return BadRequest();
            }

            db.Entry(user_Role).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!User_RoleExists(id))
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

        // POST: api/User_Role
        [ResponseType(typeof(User_Role))]
        public async Task<IHttpActionResult> PostUser_Role(User_Role user_Role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.User_Role.Add(user_Role);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (User_RoleExists(user_Role.User_Role_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = user_Role.User_Role_ID }, user_Role);
        }

        // DELETE: api/User_Role/5
        [ResponseType(typeof(User_Role))]
        public async Task<IHttpActionResult> DeleteUser_Role(int id)
        {
            User_Role user_Role = await db.User_Role.FindAsync(id);
            if (user_Role == null)
            {
                return NotFound();
            }

            db.User_Role.Remove(user_Role);
            await db.SaveChangesAsync();

            return Ok(user_Role);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool User_RoleExists(int id)
        {
            return db.User_Role.Count(e => e.User_Role_ID == id) > 0;
        }
    }
}