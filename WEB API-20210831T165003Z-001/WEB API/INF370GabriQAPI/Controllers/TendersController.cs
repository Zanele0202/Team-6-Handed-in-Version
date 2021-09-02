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
    public class TendersController : ApiController
    {
        private Gabriq_System_DatabaseEntities db = new Gabriq_System_DatabaseEntities();

        // GET: api/Tenders
        public IQueryable<Tender> GetTenders()
        {
            return db.Tenders;
        }

        // GET: api/Tenders/5
        [ResponseType(typeof(Tender))]
        public async Task<IHttpActionResult> GetTender(int id)
        {
            Tender tender = await db.Tenders.FindAsync(id);
            if (tender == null)
            {
                return NotFound();
            }

            return Ok(tender);
        }

        // PUT: api/Tenders/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTender(int id, Tender tender)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tender.Tender_ID)
            {
                return BadRequest();
            }

            db.Entry(tender).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TenderExists(id))
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

        // POST: api/Tenders
        [ResponseType(typeof(Tender))]
        public async Task<IHttpActionResult> PostTender(Tender tender)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tenders.Add(tender);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TenderExists(tender.Tender_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tender.Tender_ID }, tender);
        }

        // DELETE: api/Tenders/5
        [ResponseType(typeof(Tender))]
        public async Task<IHttpActionResult> DeleteTender(int id)
        {
            Tender tender = await db.Tenders.FindAsync(id);
            if (tender == null)
            {
                return NotFound();
            }

            db.Tenders.Remove(tender);
            await db.SaveChangesAsync();

            return Ok(tender);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TenderExists(int id)
        {
            return db.Tenders.Count(e => e.Tender_ID == id) > 0;
        }
    }
}