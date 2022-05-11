using PagedList;
using support_project.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace support_project.Areas.Admin.Controllers
{
    public class FacultyController : Controller
    {
        suppport_hunreEntities objsuppport_hunreEntities = new suppport_hunreEntities();
        // GET: Admin/Faculty
        public ActionResult Index(string currentFilter, string search, int? page)
        {
            var lstFaculty = new List<khoa>();
            if (search != null)
            {
                page = 1;
            }
            else
            {
                search = currentFilter;
            }
            if (!string.IsNullOrEmpty(search))
            {
                lstFaculty = objsuppport_hunreEntities.khoas.Where(n => n.ten_khoa.Contains(search)).ToList();
            }
            else
            {
                lstFaculty = objsuppport_hunreEntities.khoas.ToList();
            }
            ViewBag.CurrentFilter = search;
            int pageMax = 4;
            int pageMin = (page ?? 1);
            lstFaculty = lstFaculty.OrderByDescending(n => n.id_khoa).ToList();
            return View(lstFaculty.ToPagedList(pageMin, pageMax));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(khoa objkhoa)
        {
                objsuppport_hunreEntities.khoas.Add(objkhoa);
                objsuppport_hunreEntities.SaveChanges();
                return RedirectToAction("Index");  
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            khoa kh = objsuppport_hunreEntities.khoas.Find(id);
            if (kh == null)
            {
                return HttpNotFound();
            }
            return View(kh);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            khoa kh = objsuppport_hunreEntities.khoas.Find(id);
            objsuppport_hunreEntities.khoas.Remove(kh);
            objsuppport_hunreEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            khoa kh = objsuppport_hunreEntities.khoas.Find(id);
            if (kh == null)
            {
                return HttpNotFound();
            }
            return View(kh);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(khoa kh)
        {
            if (ModelState.IsValid)
            {
                objsuppport_hunreEntities.Entry(kh).State = EntityState.Modified;
                objsuppport_hunreEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kh);
        }
    }
}