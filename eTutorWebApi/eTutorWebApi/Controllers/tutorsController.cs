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
    public class tutorsController : ApiController
    {
        private eTutorEntities1 db = new eTutorEntities1();

        // GET: api/tutors
        public IQueryable<tutor> Gettutors()
        {
            return db.tutors;
        }

        // GET: api/tutors/5
        [ResponseType(typeof(tutor))]
        public async Task<IHttpActionResult> Gettutor(int id)
        {
            tutor tutor = await db.tutors.FindAsync(id);
            if (tutor == null)
            {
                return NotFound();
            }

            return Ok(tutor);
        }

        // PUT: api/tutors/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Puttutor(int id, tutor tutor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tutor.tutor_id)
            {
                return BadRequest();
            }

            db.Entry(tutor).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tutorExists(id))
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

        // POST: api/tutors
        [ResponseType(typeof(tutor))]
        public async Task<IHttpActionResult> Posttutor(tutor tutor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tutors.Add(tutor);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (tutorExists(tutor.tutor_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tutor.tutor_id }, tutor);
        }

        // DELETE: api/tutors/5
        [ResponseType(typeof(tutor))]
        public async Task<IHttpActionResult> Deletetutor(int id)
        {
            tutor tutor = await db.tutors.FindAsync(id);
            if (tutor == null)
            {
                return NotFound();
            }

            db.tutors.Remove(tutor);
            await db.SaveChangesAsync();

            return Ok(tutor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tutorExists(int id)
        {
            return db.tutors.Count(e => e.tutor_id == id) > 0;
        }
    }
}