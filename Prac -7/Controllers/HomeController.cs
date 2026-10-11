
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Practical7.Models;

namespace Practical7.Controllers
{
    public class HomeController : Controller
    {
        private static readonly List<Feedback> feedbackList =
            new List<Feedback>();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GiveFeedback()
        {
            LoadSubjects();
            return View(new Feedback());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GiveFeedback(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                feedbackList.Add(feedback);
                TempData["Message"] =
                    "Your feedback has been submitted successfully!";

                return RedirectToAction("ViewFeedback");
            }

            LoadSubjects();
            return View(feedback);
        }

        public ActionResult ViewFeedback()
        {
            return View(feedbackList.AsEnumerable().Reverse().ToList());
        }

        private void LoadSubjects()
        {
            ViewBag.Subjects = new SelectList(
                new[]
                {
                    "Artificial Intelligence",
                    "Data Structures",
                    "Database Management",
                    "Computer Networks",
                    ".NET Technologies",
                    "Operating Systems"
                }
            );
        }
    }
}
