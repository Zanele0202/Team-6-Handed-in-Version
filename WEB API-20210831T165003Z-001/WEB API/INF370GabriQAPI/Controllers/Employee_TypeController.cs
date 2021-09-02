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
    public class Employee_TypeController : ApiController
    {
        private Gabriq_System_DatabaseEntities db = new Gabriq_System_DatabaseEntities();

        // GET: api/Employee_Type
        public IQueryable<Employee_Type> GetEmployee_Type()
        {
            return db.Employee_Type;
        }

        // GET: api/Employee_Type/5
        [ResponseType(typeof(Employee_Type))]
        public async Task<IHttpActionResult> GetEmployee_Type(int id)
        {
            Employee_Type employee_Type = await db.Employee_Type.FindAsync(id);
            if (employee_Type == null)
            {
                return NotFound();
            }

            return Ok(employee_Type);
        }

        // PUT: api/Employee_Type/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmployee_Type(int id, Employee_Type employee_Type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee_Type.Employee_Type_ID)
            {
                return BadRequest();
            }

            db.Entry(employee_Type).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Employee_TypeExists(id))
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

        // POST: api/Employee_Type
        [ResponseType(typeof(Employee_Type))]
        public async Task<IHttpActionResult> PostEmployee_Type(Employee_Type employee_Type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employee_Type.Add(employee_Type);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Employee_TypeExists(employee_Type.Employee_Type_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = employee_Type.Employee_Type_ID }, employee_Type);
        }

        // DELETE: api/Employee_Type/5
        [ResponseType(typeof(Employee_Type))]
        public async Task<IHttpActionResult> DeleteEmployee_Type(int id)
        {
            Employee_Type employee_Type = await db.Employee_Type.FindAsync(id);
            if (employee_Type == null)
            {
                return NotFound();
            }

            db.Employee_Type.Remove(employee_Type);
            await db.SaveChangesAsync();

            return Ok(employee_Type);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Employee_TypeExists(int id)
        {
            return db.Employee_Type.Count(e => e.Employee_Type_ID == id) > 0;
        }
    }
}