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
    public class passwordsController : ApiController
    {
        private eTutorEntities1 db = new eTutorEntities1();

        // GET: api/passwords
        public IQueryable<password> Getpasswords()
        {
            return db.passwords;
        }

        // GET: api/passwords/5
        [ResponseType(typeof(password))]
        public async Task<IHttpActionResult> Getpassword(int id)
        {
            password password = await db.passwords.FindAsync(id);
            if (password == null)
            {
                return NotFound();
            }

            return Ok(password);
        }

        // PUT: api/passwords/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putpassword(int id, password password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != password.password_id)
            {
                return BadRequest();
            }

            db.Entry(password).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!passwordExists(id))
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

        // POST: api/passwords
        [ResponseType(typeof(password))]
        public async Task<IHttpActionResult> Postpassword(password password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.passwords.Add(password);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (passwordExists(password.password_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = password.password_id }, password);
        }

        // DELETE: api/passwords/5
        [ResponseType(typeof(password))]
        public async Task<IHttpActionResult> Deletepassword(int id)
        {
            password password = await db.passwords.FindAsync(id);
            if (password == null)
            {
                return NotFound();
            }

            db.passwords.Remove(password);
            await db.SaveChangesAsync();

            return Ok(password);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool passwordExists(int id)
        {
            return db.passwords.Count(e => e.password_id == id) > 0;
        }
    }
}