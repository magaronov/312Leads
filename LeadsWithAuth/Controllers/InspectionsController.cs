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
using LeadsWithAuth.Models;

namespace LeadsWithAuth.Controllers
{
    public class InspectionsController : ApiController
    {
        private LeadsWithAuthContext db = new LeadsWithAuthContext();

        // GET api/Inspections
        public IQueryable<Inspection> GetInspections()
        {
            return db.Inspections;
        }

        // GET api/Inspections/5
        [ResponseType(typeof(Inspection))]
        public async Task<IHttpActionResult> GetInspection(int id)
        {
            Inspection inspection = await db.Inspections.FindAsync(id);
            if (inspection == null)
            {
                return NotFound();
            }

            return Ok(inspection);
        }

        // PUT api/Inspections/5
        public async Task<IHttpActionResult> PutInspection(int id, Inspection inspection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inspection.Id)
            {
                return BadRequest();
            }

            db.Entry(inspection).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InspectionExists(id))
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

        // POST api/Inspections
        [ResponseType(typeof(Inspection))]
        public async Task<IHttpActionResult> PostInspection(Inspection inspection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Inspections.Add(inspection);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = inspection.Id }, inspection);
        }

        // DELETE api/Inspections/5
        [ResponseType(typeof(Inspection))]
        public async Task<IHttpActionResult> DeleteInspection(int id)
        {
            Inspection inspection = await db.Inspections.FindAsync(id);
            if (inspection == null)
            {
                return NotFound();
            }

            db.Inspections.Remove(inspection);
            await db.SaveChangesAsync();

            return Ok(inspection);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InspectionExists(int id)
        {
            return db.Inspections.Count(e => e.Id == id) > 0;
        }
    }
}