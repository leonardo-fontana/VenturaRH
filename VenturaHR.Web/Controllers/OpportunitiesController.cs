using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ventura.HR.Domain;

namespace VenturaHR.Web.Controllers
{
    
    public class OpportunitiesController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Opportunities
        [Authorize (Roles="Users")]
        public ActionResult Index()
        {
            return View(db.OpportunitySet.ToList());
        }

        // GET: Opportunities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opportunity opportunity = db.OpportunitySet.Find(id);
            if (opportunity == null)
            {
                return HttpNotFound();
            }
            return View(opportunity);
        }

        // GET: Opportunities/Create
        [Authorize (Roles= "Enterprise")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Opportunities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,CriterionList")] Opportunity opportunity)
        {
            if (ModelState.IsValid)
            {
                DateTime current_date = DateTime.Now;
                opportunity.CreateDate = current_date.ToString();
                opportunity.ExpireDate = current_date.AddDays(30).ToString();

                db.OpportunitySet.Add(opportunity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(opportunity);
        }

        // GET: Opportunities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opportunity opportunity = db.OpportunitySet.Find(id);
            if (opportunity == null)
            {
                return HttpNotFound();
            }
            return View(opportunity);
        }

        // POST: Opportunities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,CriterionList,ExpireDate,CreateDate")] Opportunity opportunity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(opportunity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(opportunity);
        }

        // GET: Opportunities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opportunity opportunity = db.OpportunitySet.Find(id);
            if (opportunity == null)
            {
                return HttpNotFound();
            }
            return View(opportunity);
        }

        // POST: Opportunities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Opportunity opportunity = db.OpportunitySet.Find(id);
            db.OpportunitySet.Remove(opportunity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
