using PagedList;
using support_project.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace support_project.Areas.Admin.Controllers
{
    public class CompanyController : Controller
    {
        suppport_hunreEntities objsuppport_hunreEntities = new suppport_hunreEntities();
        // GET: Admin/Company

        public ActionResult Index(string currentFilter, string search, int? page)
        {
            var lstCompany = new List<cong_ty>();
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
                    lstCompany = objsuppport_hunreEntities.cong_tys.Where(n => n.ten_cong_ty.Contains(search)).ToList();
                }
                else
                {
                    lstCompany = objsuppport_hunreEntities.cong_tys.ToList();
                }
                ViewBag.CurrentFilter = search;
                int pageMax = 4;
                int pageMin = (page ?? 1);
                lstCompany = lstCompany.OrderByDescending(n => n.id_cong_ty).ToList();
                return View(lstCompany.ToPagedList(pageMin, pageMax));
            }
        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]      
        public ActionResult Create(cong_ty objcong_ty)
        {
            try
            {
                if (objcong_ty.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objcong_ty.ImageUpload.FileName);
                    string extension = Path.GetExtension(objcong_ty.ImageUpload.FileName);
                    fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                    objcong_ty.anh = fileName;
                    objcong_ty.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                }
                objsuppport_hunreEntities.cong_tys.Add(objcong_ty);
                objsuppport_hunreEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var objComp = objsuppport_hunreEntities.cong_tys.Where(n => n.id_cong_ty == id).FirstOrDefault();
            return View(objComp);
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            cong_ty cty = objsuppport_hunreEntities.cong_tys.Find(id);
            if (cty == null)
            {
                return HttpNotFound();
            }
            return View(cty);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cong_ty cty = objsuppport_hunreEntities.cong_tys.Find(id);
            objsuppport_hunreEntities.cong_tys.Remove(cty);
            objsuppport_hunreEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cong_ty cty = objsuppport_hunreEntities.cong_tys.Find(id);
            if (cty == null)
            {
                return HttpNotFound();
            }
            return View(cty);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(cong_ty cty)
        {
            if (ModelState.IsValid)
            {
                objsuppport_hunreEntities.Entry(cty).State = EntityState.Modified;
                objsuppport_hunreEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cty);
        }
       /* public ActionResult searchI(string search)
        {
            ViewBag.Keyword = search;
            var searchComp = objsuppport_hunreEntities.cong_tys.Include(b => b.id_cong_ty);
            if (!String.IsNullOrEmpty(search))
            {
                var searchComp = searchComp.Where(b => b.ten_cong_ty.Contains(search));

            }
           
            return View(searchComp.ToList());
        }*/
    } 
}