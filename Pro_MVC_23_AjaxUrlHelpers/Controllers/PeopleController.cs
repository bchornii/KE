﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Pro_MVC_23_AjaxUrlHelpers.Models;

namespace Pro_MVC_23_AjaxUrlHelpers.Controllers
{
    public class PeopleController : Controller
    {
        private readonly Person[] _personData = 
        {
            new Person {FirstName = "Adam", LastName = "Freeman", Role = Role.Admin},
            new Person {FirstName = "Jacqui", LastName = "Griffyth", Role = Role.User},
            new Person {FirstName = "John", LastName = "Smith", Role = Role.User},
            new Person {FirstName = "Anne", LastName = "Jones", Role = Role.Guest}
        };

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetPeople(string selectedRole = "All")
        {
            return View((object)selectedRole);
        }
        public PartialViewResult GetPeopleData(string selectedRole = "All")
        {
            return PartialView(GetData(selectedRole));
        }
        public JsonResult GetPeopleDataJson(string selectedRole = "All")
        {
            var data = GetData(selectedRole).Select(p => new
            {
                p.FirstName,
                p.LastName,
                Role = Enum.GetName(typeof(Role), p.Role)
            });
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        #region private methods
        private IEnumerable<Person> GetData(string selectedRole)
        {
            return selectedRole.Equals("All", StringComparison.OrdinalIgnoreCase)
                       ? _personData
                       : _personData.Where(p => p.Role == (Role)Enum.Parse(typeof(Role), selectedRole));
        }
        #endregion
    }
}