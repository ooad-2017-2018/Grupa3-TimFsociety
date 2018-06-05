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
    public class coursController : ApiController
    {
        private eTutorEntities1 db = new eTutorEntities1();

        // GET: api/cours
        public IQueryable<cours> Getcourses()
        {
            return db.courses;
        }

        // GET: api/cours/5
        [ResponseType(typeof(cours))]
        public async Task<IHttpActionResult> Getcours(int id)
        {
            cours cours = await db.courses.FindAsync(id);
            if (cours == null)
            {
                return NotFound();
            }

            return Ok(cours);
        }

        // PUT: api/cours/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putcours(int id, cours cours)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cours.course_id)
            {
                return BadRequest();
            }

            db.Entry(cours).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!coursExists(id))
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

        // POST: api/cours
        [ResponseType(typeof(cours))]
        public async Task<IHttpActionResult> Postcours(cours cours)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.courses.Add(cours);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (coursExists(cours.course_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cours.course_id }, cours);
        }

        // DELETE: api/cours/5
        [ResponseType(typeof(cours))]
        public async Task<IHttpActionResult> Deletecours(int id)
        {
            cours cours = await db.courses.FindAsync(id);
            if (cours == null)
            {
                return NotFound();
            }

            db.courses.Remove(cours);
            await db.SaveChangesAsync();

            return Ok(cours);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool coursExists(int id)
        {
            return db.courses.Count(e => e.course_id == id) > 0;
        }
    }
}