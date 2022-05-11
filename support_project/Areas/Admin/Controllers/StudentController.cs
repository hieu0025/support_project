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
    public class StudentController : Controller
    {
        suppport_hunreEntities objsuppport_hunreEntities = new suppport_hunreEntities();
        // GET: Admin/Student
        public ActionResult Index(string currentFilter, string search, int? page)
        {
            var lstStudent = new List<sinh_vien>();
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
                lstStudent = objsuppport_hunreEntities.sinh_viens.Where(n => n.ten_sinh_vien.Contains(search)).ToList();
            }
            else
            {
                lstStudent = objsuppport_hunreEntities.sinh_viens.ToList();
            }
            ViewBag.CurrentFilter = search;
            int pageMax = 4;
            int pageMin = (page ?? 1);
            lstStudent = lstStudent.OrderByDescending(n => n.id_sinh_vien).ToList();
            return View(lstStudent.ToPagedList(pageMin, pageMax));

        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.id_cong_ty = new SelectList(objsuppport_hunreEntities.cong_tys, "id_cong_ty", "ten_cong_ty");
            ViewBag.id_khoa = new SelectList(objsuppport_hunreEntities.khoas, "id_khoa", "ten_khoa");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="id_sinh_vien,ten_sinh_vien,gioi_tinh, ngay_sinh, sdt, email,mo_ta,id_khoa,id_cong_ty")]sinh_vien sv)
        {
            if (ModelState.IsValid)
            {
                objsuppport_hunreEntities.sinh_viens.Add(sv);
                objsuppport_hunreEntities.SaveChanges();
                return RedirectToAction("Index");

            }
            ViewBag.id_cong_ty = new SelectList(objsuppport_hunreEntities.cong_tys, "id_cong_ty", "ten_cong_ty");
            ViewBag.id_khoa = new SelectList(objsuppport_hunreEntities.khoas, "id_khoa", "ten_khoa");
            return View(sv);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sinh_vien sv = objsuppport_hunreEntities.sinh_viens.Find(id);
            if (sv == null)
            {
                return HttpNotFound();
            }
            return View(sv);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sinh_vien sv = objsuppport_hunreEntities.sinh_viens.Find(id);
            if (sv == null)
            {
                return HttpNotFound();
            }
            return View(sv);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sinh_vien sv = objsuppport_hunreEntities.sinh_viens.Find(id);
            objsuppport_hunreEntities.sinh_viens.Remove(sv);
            objsuppport_hunreEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sinh_vien sv = objsuppport_hunreEntities.sinh_viens.Find(id);
            if (sv == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cong_ty = new SelectList(objsuppport_hunreEntities.cong_tys, "id_cong_ty", "ten_cong_ty", sv.id_cong_ty);
            ViewBag.id_khoa = new SelectList(objsuppport_hunreEntities.khoas, "id_khoa", "ten_khoa", sv.id_khoa);
            return View(sv);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_sinh_vien,ten_sinh_vien,gioi_tinh, ngay_sinh, sdt, email,mo_ta,id_khoa,id_cong_ty")] sinh_vien sv)
        {
            if (ModelState.IsValid)
            {
                objsuppport_hunreEntities.Entry(sv).State = EntityState.Modified;
                objsuppport_hunreEntities.SaveChanges();
                return RedirectToAction("Index");

            }
            ViewBag.id_cong_ty = new SelectList(objsuppport_hunreEntities.cong_tys, "id_cong_ty", "ten_cong_ty", sv.id_cong_ty);
            ViewBag.id_khoa = new SelectList(objsuppport_hunreEntities.khoas, "id_khoa", "ten_khoa", sv.id_khoa);
            return View(sv);
        }
    }
}