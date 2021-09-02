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
    public class Project_StatusController : ApiController
    {
        private Gabriq_System_DatabaseEntities db = new Gabriq_System_DatabaseEntities();

        // GET: api/Project_Status
        public IQueryable<Project_Status> GetProject_Status()
        {
            return db.Project_Status;
        }

        // GET: api/Project_Status/5
        [ResponseType(typeof(Project_Status))]
        public async Task<IHttpActionResult> GetProject_Status(int id)
        {
            Project_Status project_Status = await db.Project_Status.FindAsync(id);
            if (project_Status == null)
            {
                return NotFound();
            }

            return Ok(project_Status);
        }

        // PUT: api/Project_Status/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProject_Status(int id, Project_Status project_Status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != project_Status.Project_Status_ID)
            {
                return BadRequest();
            }

            db.Entry(project_Status).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Project_StatusExists(id))
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

        // POST: api/Project_Status
        [ResponseType(typeof(Project_Status))]
        public async Task<IHttpActionResult> PostProject_Status(Project_Status project_Status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Project_Status.Add(project_Status);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Project_StatusExists(project_Status.Project_Status_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = project_Status.Project_Status_ID }, project_Status);
        }

        // DELETE: api/Project_Status/5
        [ResponseType(typeof(Project_Status))]
        public async Task<IHttpActionResult> DeleteProject_Status(int id)
        {
            Project_Status project_Status = await db.Project_Status.FindAsync(id);
            if (project_Status == null)
            {
                return NotFound();
            }

            db.Project_Status.Remove(project_Status);
            await db.SaveChangesAsync();

            return Ok(project_Status);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Project_StatusExists(int id)
        {
            return db.Project_Status.Count(e => e.Project_Status_ID == id) > 0;
        }
    }
}