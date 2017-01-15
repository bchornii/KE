using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Pro_MVC_24_ModelBinding.Models;

namespace Pro_MVC_24_ModelBinding.Controllers
{
    public class HomeController : Controller
    {
        #region data
        private Person[] _personData =
        {
            new Person
            {
                PersonId = 1,
                FirstName = "Adam",
                LastName = "Freeman",
                Role = Role.Admin
            },
            new Person
            {
                PersonId = 2,
                FirstName = "Jacqui",
                LastName = "Griffyth",
                Role = Role.User
            },
            new Person
            {
                PersonId = 3,
                FirstName = "John",
                LastName = "Smith",
                Role = Role.User
            },
            new Person
            {
                PersonId = 4,
                FirstName = "Anne",
                LastName = "Jones",
                Role = Role.Guest
            }
        };
        #endregion

        public ActionResult Index(int id = 1) => View(_personData.First(p => p.PersonId == id));

        public ActionResult CreatePerson() => View(new Person());

        [HttpPost]
        public ActionResult CreatePerson(Person model) => View("Index", model);

        [HttpPost]
        public ActionResult CreatePersonManBind()
        {
            var model = new Person();
            UpdateModel(model);
            return View("Index", model);
        }

        public ActionResult DisplaySummary([Bind(Prefix = "HomeAddress", Exclude = "Country")]AddressSummary summary) => View(summary);

        // Binding of arrays
        //public ActionResult Names(string[] names)
        //{
        //    names = names ?? new string[0];
        //    return View(names);
        //}

        // Binding collections
        public ActionResult Names(IList<string> names)
        {
            names = names ?? new List<string>();
            return View(names);
        }

        // Strongly typed collection
        public ActionResult Address(IList<AddressSummary> addresses)
        {
            addresses = addresses ?? new List<AddressSummary>();
            return View(addresses);
        }
    }
}