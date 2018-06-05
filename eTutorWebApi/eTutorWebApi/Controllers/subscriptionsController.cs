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
    public class subscriptionsController : ApiController
    {
        private eTutorEntities1 db = new eTutorEntities1();

        // GET: api/subscriptions
        public IQueryable<subscription> Getsubscriptions()
        {
            return db.subscriptions;
        }

        // GET: api/subscriptions/5
        [ResponseType(typeof(subscription))]
        public async Task<IHttpActionResult> Getsubscription(int id)
        {
            subscription subscription = await db.subscriptions.FindAsync(id);
            if (subscription == null)
            {
                return NotFound();
            }

            return Ok(subscription);
        }

        // PUT: api/subscriptions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putsubscription(int id, subscription subscription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subscription.subscription_id)
            {
                return BadRequest();
            }

            db.Entry(subscription).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!subscriptionExists(id))
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

        // POST: api/subscriptions
        [ResponseType(typeof(subscription))]
        public async Task<IHttpActionResult> Postsubscription(subscription subscription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.subscriptions.Add(subscription);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (subscriptionExists(subscription.subscription_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = subscription.subscription_id }, subscription);
        }

        // DELETE: api/subscriptions/5
        [ResponseType(typeof(subscription))]
        public async Task<IHttpActionResult> Deletesubscription(int id)
        {
            subscription subscription = await db.subscriptions.FindAsync(id);
            if (subscription == null)
            {
                return NotFound();
            }

            db.subscriptions.Remove(subscription);
            await db.SaveChangesAsync();

            return Ok(subscription);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool subscriptionExists(int id)
        {
            return db.subscriptions.Count(e => e.subscription_id == id) > 0;
        }
    }
}