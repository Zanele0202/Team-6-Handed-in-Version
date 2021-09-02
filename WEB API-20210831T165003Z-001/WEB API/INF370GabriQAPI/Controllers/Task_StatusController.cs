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
    public class Task_StatusController : ApiController
    {
        private Gabriq_System_DatabaseEntities db = new Gabriq_System_DatabaseEntities();

        // GET: api/Task_Status
        public IQueryable<Task_Status> GetTask_Status()
        {
            return db.Task_Status;
        }

        // GET: api/Task_Status/5
        [ResponseType(typeof(Task_Status))]
        public async Task<IHttpActionResult> GetTask_Status(int id)
        {
            Task_Status task_Status = await db.Task_Status.FindAsync(id);
            if (task_Status == null)
            {
                return NotFound();
            }

            return Ok(task_Status);
        }

        // PUT: api/Task_Status/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTask_Status(int id, Task_Status task_Status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != task_Status.Task_Status_ID)
            {
                return BadRequest();
            }

            db.Entry(task_Status).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Task_StatusExists(id))
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

        // POST: api/Task_Status
        [ResponseType(typeof(Task_Status))]
        public async Task<IHttpActionResult> PostTask_Status(Task_Status task_Status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Task_Status.Add(task_Status);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Task_StatusExists(task_Status.Task_Status_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = task_Status.Task_Status_ID }, task_Status);
        }

        // DELETE: api/Task_Status/5
        [ResponseType(typeof(Task_Status))]
        public async Task<IHttpActionResult> DeleteTask_Status(int id)
        {
            Task_Status task_Status = await db.Task_Status.FindAsync(id);
            if (task_Status == null)
            {
                return NotFound();
            }

            db.Task_Status.Remove(task_Status);
            await db.SaveChangesAsync();

            return Ok(task_Status);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Task_StatusExists(int id)
        {
            return db.Task_Status.Count(e => e.Task_Status_ID == id) > 0;
        }
    }
}