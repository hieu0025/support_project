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
    public class BookController : Controller
    {
        suppport_hunreEntities objsuppport_hunreEntities = new suppport_hunreEntities();
        // GET: Admin/Company

        public ActionResult Index(string currentFilter, string search, int? page)
        {
            var lstBook = new List<sach>();
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

                lstBook = objsuppport_hunreEntities.sachs.Where(n => n.ten_sach.Contains(search)).ToList();
            }
            else
            {
                lstBook = objsuppport_hunreEntities.sachs.ToList();
            }
            ViewBag.CurrentFilter = search;
            int pageMax = 4;
            int pageMin = (page ?? 1);
            lstBook = lstBook.OrderByDescending(n => n.id_sach).ToList();
            return View(lstBook.ToPagedList(pageMin, pageMax));
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.id_khoa = new SelectList(objsuppport_hunreEntities.khoas, "id_khoa", "ten_khoa");
            return View();
        }
        [HttpPost]
        public ActionResult Create(sach objsach)
        {
            try
            {
                if (objsach.ImageUpload != null && objsach.FileUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objsach.ImageUpload.FileName);
                    string extension = Path.GetExtension(objsach.ImageUpload.FileName);
                    fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                    objsach.anh = fileName;
                    objsach.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                
                    string fileName1 = Path.GetFileNameWithoutExtension(objsach.FileUpload.FileName);
                    string extension1 = Path.GetExtension(objsach.FileUpload.FileName);
                    fileName1 = fileName1 + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension1;
                    objsach.duong_dan = fileName1;
                    objsach.FileUpload.SaveAs(Path.Combine(Server.MapPath("~/Files/"), fileName1));
                }

                objsuppport_hunreEntities.sachs.Add(objsach);
                objsuppport_hunreEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewBag.id_khoa = new SelectList(objsuppport_hunreEntities.khoas, "id_khoa", "ten_khoa");
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var objBook = objsuppport_hunreEntities.sachs.Where(n => n.id_sach == id).FirstOrDefault();
            return View(objBook);
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            sach sach = objsuppport_hunreEntities.sachs.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sach sach = objsuppport_hunreEntities.sachs.Find(id);
            objsuppport_hunreEntities.sachs.Remove(sach);
            objsuppport_hunreEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sach sach = objsuppport_hunreEntities.sachs.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_khoa = new SelectList(objsuppport_hunreEntities.khoas, "id_khoa", "ten_khoa", sach.id_khoa);
            return View(sach);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(sach sach)
        {
            if (ModelState.IsValid)
            {
                objsuppport_hunreEntities.Entry(sach).State = EntityState.Modified;
                objsuppport_hunreEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_khoa = new SelectList(objsuppport_hunreEntities.khoas, "id_khoa", "ten_khoa", sach.id_khoa);
            return View(sach);
        }
        public ActionResult Downloads()
        {
            var dir = new System.IO.DirectoryInfo(Server.MapPath("~/Files/"));
            System.IO.FileInfo[] fileNames = dir.GetFiles("*.*"); List<string> items = new List<string>();
            foreach (var file in fileNames)
            {
                items.Add(file.Name);
            }
            return View(items);
        }

        public FileResult Download(string FileName)
        {
            var FileVirtualPath = "~/Files/" + FileName;
            return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));
        }
    }
}