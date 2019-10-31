using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using TCOnline.UserInterface.HttpHelper;
using TCOnline.UserInterface.Models;

namespace TCOnline.UserInterface.Controllers
{
    public class FeedbackController : Controller
    {
        // GET: Feedback
        public ActionResult Index()
        {
            try
            {
                HttpClientHelper httpObj = new HttpClientHelper();
                HttpResponseMessage response = httpObj.GetResponse("api/review/GetAllFeedbacks");
                response.EnsureSuccessStatusCode();
                List<FeedbackViewModel> feedbacks = response.Content.ReadAsAsync<List<FeedbackViewModel>>().Result;

                return View(feedbacks);
            }
            catch (Exception)
            {
                throw;
            }

        } // end of method()

        [HttpGet]
        public ActionResult CreateOrReview(int id = 0)
        {
            FeedbackViewModel feedbackui = new FeedbackViewModel();
            if (id == 0)
                return View(feedbackui);
            else
            {
                HttpClientHelper httpObj = new HttpClientHelper();
                HttpResponseMessage response = httpObj.GetResponse("api/review/FindFeedback?id=" + id.ToString());
                response.EnsureSuccessStatusCode();

                feedbackui = response.Content.ReadAsAsync<FeedbackViewModel>().Result;
                return View(feedbackui);
            }
        } // end of method()

        [HttpPost]
        public ActionResult CreateOrReview(FeedbackViewModel feedbackui)
        {
            if (feedbackui.Id == 0 && ModelState.IsValid)
            {
                HttpClientHelper httpObj = new HttpClientHelper();
                HttpResponseMessage response = httpObj.PostResponse("api/review/InsertFeedback", feedbackui);
                response.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }
            else if (feedbackui.Id == 0 && !ModelState.IsValid)
                return View(feedbackui);
            else
                return RedirectToAction("Index");
        }

    }
}