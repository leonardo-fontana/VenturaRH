using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Ventura.RH.Domain;

namespace VenturaHR.Web.Controllers
{
    
    public class OpportunitiesController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Opportunities
        [AllowAnonymous]
        public ActionResult Index()
        {
            IEnumerable<Opportunity> opportunities = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:44351/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Opportunities");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Opportunity>>();
                    readTask.Wait();

                    opportunities = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    opportunities = Enumerable.Empty<Opportunity>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(opportunities);
        }

        [Authorize]
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
        [Authorize(Roles = "Enterprise")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Opportunities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Opportunity opportunity)
        {
            using (var client = new HttpClient())
            {
                if (ModelState.IsValid)
                {
                    client.BaseAddress = new Uri("https://localhost:44351/api/Opportunities");
                    var postTask = client.PostAsJsonAsync<Opportunity>("opportunities", opportunity);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                   
                }
            }
                

            return View(opportunity);
        }

        // GET: Opportunities/Edit/5
        [Authorize(Roles = "Enterprise")]
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
        [Authorize(Roles = "Enterprise")]
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
