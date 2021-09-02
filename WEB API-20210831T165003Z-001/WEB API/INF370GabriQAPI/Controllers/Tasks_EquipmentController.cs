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
    public class Tasks_EquipmentController : ApiController
    {
        private Gabriq_System_DatabaseEntities db = new Gabriq_System_DatabaseEntities();

        // GET: api/Tasks_Equipment
        public IQueryable<Tasks_Equipment> GetTasks_Equipment()
        {
            return db.Tasks_Equipment;
        }

        // GET: api/Tasks_Equipment/5
        [ResponseType(typeof(Tasks_Equipment))]
        public async Task<IHttpActionResult> GetTasks_Equipment(int id)
        {
            Tasks_Equipment tasks_Equipment = await db.Tasks_Equipment.FindAsync(id);
            if (tasks_Equipment == null)
            {
                return NotFound();
            }

            return Ok(tasks_Equipment);
        }

        // PUT: api/Tasks_Equipment/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTasks_Equipment(int id, Tasks_Equipment tasks_Equipment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tasks_Equipment.Tasks_Equipment_ID)
            {
                return BadRequest();
            }

            db.Entry(tasks_Equipment).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tasks_EquipmentExists(id))
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

        // POST: api/Tasks_Equipment
        [ResponseType(typeof(Tasks_Equipment))]
        public async Task<IHttpActionResult> PostTasks_Equipment(Tasks_Equipment tasks_Equipment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tasks_Equipment.Add(tasks_Equipment);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Tasks_EquipmentExists(tasks_Equipment.Tasks_Equipment_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tasks_Equipment.Tasks_Equipment_ID }, tasks_Equipment);
        }

        // DELETE: api/Tasks_Equipment/5
        [ResponseType(typeof(Tasks_Equipment))]
        public async Task<IHttpActionResult> DeleteTasks_Equipment(int id)
        {
            Tasks_Equipment tasks_Equipment = await db.Tasks_Equipment.FindAsync(id);
            if (tasks_Equipment == null)
            {
                return NotFound();
            }

            db.Tasks_Equipment.Remove(tasks_Equipment);
            await db.SaveChangesAsync();

            return Ok(tasks_Equipment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tasks_EquipmentExists(int id)
        {
            return db.Tasks_Equipment.Count(e => e.Tasks_Equipment_ID == id) > 0;
        }
    }
}