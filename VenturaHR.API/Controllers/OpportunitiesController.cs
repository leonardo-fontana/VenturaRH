using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Ventura.HR.Domain;

namespace VenturaHR.API.Controllers
{
    public class OpportunitiesController : ApiController
    {
        private Model1Container db = new Model1Container();

        // GET: api/Opportunities
        public IQueryable<Opportunity> GetOpportunitySet()
        {
            return db.OpportunitySet;
        }

        // GET: api/Opportunities/5
        [ResponseType(typeof(Opportunity))]
        public IHttpActionResult GetOpportunity(int id)
        {
            Opportunity opportunity = db.OpportunitySet.Find(id);
            if (opportunity == null)
            {
                return NotFound();
            }

            return Ok(opportunity);
        }

        // PUT: api/Opportunities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOpportunity(int id, Opportunity opportunity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != opportunity.Id)
            {
                return BadRequest();
            }

            db.Entry(opportunity).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OpportunityExists(id))
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

        // POST: api/Opportunities
        [ResponseType(typeof(Opportunity))]
        public IHttpActionResult PostOpportunity(Opportunity opportunity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OpportunitySet.Add(opportunity);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = opportunity.Id }, opportunity);
        }

        // DELETE: api/Opportunities/5
        [ResponseType(typeof(Opportunity))]
        public IHttpActionResult DeleteOpportunity(int id)
        {
            Opportunity opportunity = db.OpportunitySet.Find(id);
            if (opportunity == null)
            {
                return NotFound();
            }

            db.OpportunitySet.Remove(opportunity);
            db.SaveChanges();

            return Ok(opportunity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OpportunityExists(int id)
        {
            return db.OpportunitySet.Count(e => e.Id == id) > 0;
        }
    }
}