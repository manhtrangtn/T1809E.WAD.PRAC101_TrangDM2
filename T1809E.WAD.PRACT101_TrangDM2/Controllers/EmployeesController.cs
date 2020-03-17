using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using T1809E.WAD.PRACT101_TrangDM2.Data;
using T1809E.WAD.PRACT101_TrangDM2.Models;

namespace T1809E.WAD.PRACT101_TrangDM2.Controllers
{
    public class EmployeesController : Controller
    {
        private DataContext db = new DataContext();

        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return PartialView("Error");
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return PartialView("Error");
            }
            return View(employee);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Department,Salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
              db.Employees.Add(employee);
              try
              {
                db.SaveChanges();
              }
              catch (Exception e)
              {
                Debug.WriteLine(e);
                ViewBag.Message = "This employe ID is exist! Please choose other.";
                return View(employee);
              }
              return RedirectToAction("Index");
            }
            return View(employee);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
              return PartialView("Error");
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
              return PartialView("Error");
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Department,Salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
              return PartialView("Error");
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
              return PartialView("Error");
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
