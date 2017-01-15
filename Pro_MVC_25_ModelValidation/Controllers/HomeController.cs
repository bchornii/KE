using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Pro_MVC_25_ModelValidation.Models;

namespace Pro_MVC_25_ModelValidation.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult MakeBooking()
        {
            return View(new Appointment { Date = DateTime.Now });
        }

        [HttpPost]
        public ViewResult MakeBooking(Appointment appointment)
        {
            //return View("Completed", appointment);

            // The most direct way to do validation
            //if (string.IsNullOrEmpty(appointment.ClientName))
            //{
            //    ModelState.AddModelError(nameof(appointment.ClientName), "Please enter your name");
            //}
            //if (ModelState.IsValidField("Date") && DateTime.Now > appointment.Date)
            //{
            //    ModelState.AddModelError(nameof(appointment.Date), "Please enter a date in the future");
            //}
            //if (!appointment.TermsAccepted)
            //{
            //    ModelState.AddModelError(nameof(appointment.TermsAccepted), "You must accept the terms");
            //}
            //if (ModelState.IsValidField(nameof(appointment.ClientName)) && 
            //    ModelState.IsValidField(nameof(appointment.Date)) && 
            //    appointment.ClientName == "Joe" && 
            //    appointment.Date.DayOfWeek == DayOfWeek.Monday)
            //{
            //    ModelState.AddModelError("", "Joe cannot book appointments on Mondays");
            //}

            return ModelState.IsValid ? View("Completed", appointment) : View();
        }

        public JsonResult ValidateDate(string date)
        {
            DateTime parsedDate;
            if (!DateTime.TryParse(date, out parsedDate))
            {
                return Json("Please enter a valid date (mm/dd/yyyy)", JsonRequestBehavior.AllowGet);
            }
            if (DateTime.Now > parsedDate)
            {
                return Json("Please enter date in future", JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetAsync()
        {
            await Task.Delay(1000);
            DoNothing();
            await Task.Delay(1000);

            return View("MakeBooking");
        }

        private void DoNothing()
        {
            const int a = 10;
            const int b = 20;
            var c = a + b;
        }
    }
}