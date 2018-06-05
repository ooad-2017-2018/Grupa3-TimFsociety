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
using eTutorWebApi.Models;

namespace eTutorWebApi.Controllers
{
    public class etutor_organizationController : ApiController
    {
        private eTutorEntities1 db = new eTutorEntities1();

        // GET: api/etutor_organization
        public IQueryable<etutor_organization> Getetutor_organization()
        {
            return db.etutor_organization;
        }

        // GET: api/etutor_organization/5
        [ResponseType(typeof(etutor_organization))]
        public async Task<IHttpActionResult> Getetutor_organization(int id)
        {
            etutor_organization etutor_organization = await db.etutor_organization.FindAsync(id);
            if (etutor_organization == null)
            {
                return NotFound();
            }

            return Ok(etutor_organization);
        }

        // PUT: api/etutor_organization/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putetutor_organization(int id, etutor_organization etutor_organization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != etutor_organization.e_tutor_daily_id)
            {
                return BadRequest();
            }

            db.Entry(etutor_organization).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!etutor_organizationExists(id))
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

        // POST: api/etutor_organization
        [ResponseType(typeof(etutor_organization))]
        public async Task<IHttpActionResult> Postetutor_organization(etutor_organization etutor_organization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.etutor_organization.Add(etutor_organization);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (etutor_organizationExists(etutor_organization.e_tutor_daily_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = etutor_organization.e_tutor_daily_id }, etutor_organization);
        }

        // DELETE: api/etutor_organization/5
        [ResponseType(typeof(etutor_organization))]
        public async Task<IHttpActionResult> Deleteetutor_organization(int id)
        {
            etutor_organization etutor_organization = await db.etutor_organization.FindAsync(id);
            if (etutor_organization == null)
            {
                return NotFound();
            }

            db.etutor_organization.Remove(etutor_organization);
            await db.SaveChangesAsync();

            return Ok(etutor_organization);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool etutor_organizationExists(int id)
        {
            return db.etutor_organization.Count(e => e.e_tutor_daily_id == id) > 0;
        }
    }
}