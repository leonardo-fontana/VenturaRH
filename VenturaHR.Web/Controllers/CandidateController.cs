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
    public class CandidateController : Controller
    {

        private Model1Container db = new Model1Container();

        // GET: Candidate
        public ActionResult Index()
        {
            return View();
        }


        
        public ActionResult Candidate(int id)
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

        // POST: Opportunities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
       /* [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Candidate(Opportunity opportunity)
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
        }*/
    }
}