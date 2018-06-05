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
    public class messagesController : ApiController
    {
        private eTutorEntities1 db = new eTutorEntities1();

        // GET: api/messages
        public IQueryable<message> Getmessages()
        {
            return db.messages;
        }

        // GET: api/messages/5
        [ResponseType(typeof(message))]
        public async Task<IHttpActionResult> Getmessage(int id)
        {
            message message = await db.messages.FindAsync(id);
            if (message == null)
            {
                return NotFound();
            }

            return Ok(message);
        }

        // PUT: api/messages/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putmessage(int id, message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != message.message_id)
            {
                return BadRequest();
            }

            db.Entry(message).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!messageExists(id))
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

        // POST: api/messages
        [ResponseType(typeof(message))]
        public async Task<IHttpActionResult> Postmessage(message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.messages.Add(message);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (messageExists(message.message_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = message.message_id }, message);
        }

        // DELETE: api/messages/5
        [ResponseType(typeof(message))]
        public async Task<IHttpActionResult> Deletemessage(int id)
        {
            message message = await db.messages.FindAsync(id);
            if (message == null)
            {
                return NotFound();
            }

            db.messages.Remove(message);
            await db.SaveChangesAsync();

            return Ok(message);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool messageExists(int id)
        {
            return db.messages.Count(e => e.message_id == id) > 0;
        }
    }
}