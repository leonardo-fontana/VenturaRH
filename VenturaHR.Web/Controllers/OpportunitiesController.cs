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
using VenturaHR.Web.Models;

namespace VenturaHR.Web.Controllers
{
    public class OpportunitiesController : Controller
    {
        private Model1Container db = new Model1Container();
        private static List<OpportunityViewModel> _opportunity = new List<OpportunityViewModel>();

        // GET: Opportunities
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
        public ActionResult Create()
        {
            OpportunityViewModel opportunityViewModel = new OpportunityViewModel();
            opportunityViewModel.Id = _opportunity.Count;
            return View(opportunityViewModel);
        }

        // POST: Opportunities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OpportunityViewModel opportunity)
        {
            //List<Criteria> criterion = new List<Criteria>();
            using (var client = new HttpClient())
            {
                if (ModelState.IsValid)
                {                                            
                    client.BaseAddress = new Uri("https://localhost:44351/api/Opportunities");

                    //opportunity.Name = ViewBag.Data;
                    var postTask = client.PostAsJsonAsync<OpportunityViewModel>("opportunities", opportunity);
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
            Opportunity opportunity = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44351/api/");
                var responseTask = client.GetAsync("opportunities?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Opportunity>();
                    readTask.Wait();

                    opportunity = readTask.Result;
                }
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
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:44351/api/opportunities");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Opportunity>("opportunities", opportunity);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(opportunity);
        }

        // GET: Opportunities/Delete/5
        [Authorize(Roles = "Enterprise")]
        public ActionResult Delete(int? id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:44351/api/");

                var deleteTask = client.DeleteAsync("opportunities/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
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
