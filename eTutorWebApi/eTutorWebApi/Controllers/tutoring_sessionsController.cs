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
    public class tutoring_sessionsController : ApiController
    {
        private eTutorEntities1 db = new eTutorEntities1();

        // GET: api/tutoring_sessions
        public IQueryable<tutoring_sessions> Gettutoring_sessions()
        {
            return db.tutoring_sessions;
        }

        // GET: api/tutoring_sessions/5
        [ResponseType(typeof(tutoring_sessions))]
        public async Task<IHttpActionResult> Gettutoring_sessions(int id)
        {
            tutoring_sessions tutoring_sessions = await db.tutoring_sessions.FindAsync(id);
            if (tutoring_sessions == null)
            {
                return NotFound();
            }

            return Ok(tutoring_sessions);
        }

        // PUT: api/tutoring_sessions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Puttutoring_sessions(int id, tutoring_sessions tutoring_sessions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tutoring_sessions.tutoring_session_id)
            {
                return BadRequest();
            }

            db.Entry(tutoring_sessions).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tutoring_sessionsExists(id))
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

        // POST: api/tutoring_sessions
        [ResponseType(typeof(tutoring_sessions))]
        public async Task<IHttpActionResult> Posttutoring_sessions(tutoring_sessions tutoring_sessions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tutoring_sessions.Add(tutoring_sessions);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (tutoring_sessionsExists(tutoring_sessions.tutoring_session_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tutoring_sessions.tutoring_session_id }, tutoring_sessions);
        }

        // DELETE: api/tutoring_sessions/5
        [ResponseType(typeof(tutoring_sessions))]
        public async Task<IHttpActionResult> Deletetutoring_sessions(int id)
        {
            tutoring_sessions tutoring_sessions = await db.tutoring_sessions.FindAsync(id);
            if (tutoring_sessions == null)
            {
                return NotFound();
            }

            db.tutoring_sessions.Remove(tutoring_sessions);
            await db.SaveChangesAsync();

            return Ok(tutoring_sessions);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tutoring_sessionsExists(int id)
        {
            return db.tutoring_sessions.Count(e => e.tutoring_session_id == id) > 0;
        }
    }
}