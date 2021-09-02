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
    public class Employee_TaskController : ApiController
    {
        private Gabriq_System_DatabaseEntities db = new Gabriq_System_DatabaseEntities();

        // GET: api/Employee_Task
        public IQueryable<Employee_Task> GetEmployee_Task()
        {
            return db.Employee_Task;
        }

        // GET: api/Employee_Task/5
        [ResponseType(typeof(Employee_Task))]
        public async Task<IHttpActionResult> GetEmployee_Task(int id)
        {
            Employee_Task employee_Task = await db.Employee_Task.FindAsync(id);
            if (employee_Task == null)
            {
                return NotFound();
            }

            return Ok(employee_Task);
        }

        // PUT: api/Employee_Task/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmployee_Task(int id, Employee_Task employee_Task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee_Task.Employee_Task_ID)
            {
                return BadRequest();
            }

            db.Entry(employee_Task).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Employee_TaskExists(id))
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

        // POST: api/Employee_Task
        [ResponseType(typeof(Employee_Task))]
        public async Task<IHttpActionResult> PostEmployee_Task(Employee_Task employee_Task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employee_Task.Add(employee_Task);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Employee_TaskExists(employee_Task.Employee_Task_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = employee_Task.Employee_Task_ID }, employee_Task);
        }

        // DELETE: api/Employee_Task/5
        [ResponseType(typeof(Employee_Task))]
        public async Task<IHttpActionResult> DeleteEmployee_Task(int id)
        {
            Employee_Task employee_Task = await db.Employee_Task.FindAsync(id);
            if (employee_Task == null)
            {
                return NotFound();
            }

            db.Employee_Task.Remove(employee_Task);
            await db.SaveChangesAsync();

            return Ok(employee_Task);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Employee_TaskExists(int id)
        {
            return db.Employee_Task.Count(e => e.Employee_Task_ID == id) > 0;
        }
    }
}