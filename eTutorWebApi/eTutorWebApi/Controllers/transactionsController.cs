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
    public class transactionsController : ApiController
    {
        private eTutorEntities1 db = new eTutorEntities1();

        // GET: api/transactions
        public IQueryable<transaction> Gettransactions()
        {
            return db.transactions;
        }

        // GET: api/transactions/5
        [ResponseType(typeof(transaction))]
        public async Task<IHttpActionResult> Gettransaction(int id)
        {
            transaction transaction = await db.transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);
        }

        // PUT: api/transactions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Puttransaction(int id, transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transaction.transactions_id)
            {
                return BadRequest();
            }

            db.Entry(transaction).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!transactionExists(id))
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

        // POST: api/transactions
        [ResponseType(typeof(transaction))]
        public async Task<IHttpActionResult> Posttransaction(transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.transactions.Add(transaction);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (transactionExists(transaction.transactions_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = transaction.transactions_id }, transaction);
        }

        // DELETE: api/transactions/5
        [ResponseType(typeof(transaction))]
        public async Task<IHttpActionResult> Deletetransaction(int id)
        {
            transaction transaction = await db.transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }

            db.transactions.Remove(transaction);
            await db.SaveChangesAsync();

            return Ok(transaction);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool transactionExists(int id)
        {
            return db.transactions.Count(e => e.transactions_id == id) > 0;
        }
    }
}