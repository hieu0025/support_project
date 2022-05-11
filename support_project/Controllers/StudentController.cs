using support_project.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace support_project.Controllers
{
    public class StudentController : Controller
    {
        suppport_hunreEntities objsuppport_hunreEntities = new suppport_hunreEntities();
        // GET: Student
        public ActionResult Index()
        {
            
            return View();
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
        public ActionResult Create([Bind(Include = "id_sinh_vien,ten_sinh_vien,gioi_tinh, ngay_sinh, sdt, email,mo_ta,id_khoa,id_cong_ty")] sinh_vien sv)
        {
            if (ModelState.IsValid)
            {
                objsuppport_hunreEntities.sinh_viens.Add(sv);
                objsuppport_hunreEntities.SaveChanges();
                return RedirectToAction("create");

            }
            ViewBag.id_cong_ty = new SelectList(objsuppport_hunreEntities.cong_tys, "id_cong_ty", "ten_cong_ty");
            ViewBag.id_khoa = new SelectList(objsuppport_hunreEntities.khoas, "id_khoa", "ten_khoa");
            return View(sv);
        }
    }
}