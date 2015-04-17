using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LeadsWithAuth.Models;

namespace LeadsWithAuth.Controllers
{
    public class InspectionTypesController : ApiController
    {
        private LeadsWithAuthContext db = new LeadsWithAuthContext();

        // GET api/Default1
        public IQueryable<InspectionType> GetInspectionTypes()
        {
            return db.InspectionTypes;
        }

        // GET api/Default1/5
        [ResponseType(typeof(InspectionType))]
        public async Task<IHttpActionResult> GetInspectionType(int id)
        {
            InspectionType inspectiontype = await db.InspectionTypes.FindAsync(id);
            if (inspectiontype == null)
            {
                return NotFound();
            }

            return Ok(inspectiontype);
        }

        // PUT api/Default1/5
        public async Task<IHttpActionResult> PutInspectionType(int id, InspectionType inspectiontype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inspectiontype.InspectionTypeId)
            {
                return BadRequest();
            }

            db.Entry(inspectiontype).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InspectionTypeExists(id))
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

        // POST api/Default1
        [ResponseType(typeof(InspectionType))]
        public async Task<IHttpActionResult> PostInspectionType(InspectionType inspectiontype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.InspectionTypes.Add(inspectiontype);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = inspectiontype.InspectionTypeId }, inspectiontype);
        }

        // DELETE api/Default1/5
        [ResponseType(typeof(InspectionType))]
        public async Task<IHttpActionResult> DeleteInspectionType(int id)
        {
            InspectionType inspectiontype = await db.InspectionTypes.FindAsync(id);
            if (inspectiontype == null)
            {
                return NotFound();
            }

            db.InspectionTypes.Remove(inspectiontype);
            await db.SaveChangesAsync();

            return Ok(inspectiontype);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InspectionTypeExists(int id)
        {
            return db.InspectionTypes.Count(e => e.InspectionTypeId == id) > 0;
        }
    }
}