using PagedList;
using support_project.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace support_project.Controllers
{
    public class BookController : Controller
    {
        suppport_hunreEntities objsuppport_hunreEntities = new suppport_hunreEntities();
        

        public ActionResult Book(string currentFilter, string search, int? page)
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
            int pageMax = 3;
            int pageMin = (page ?? 1);
            lstBook = lstBook.OrderByDescending(n => n.id_sach).ToList();
            return View(lstBook.ToPagedList(pageMin, pageMax));
        }
        public FileResult Download(string FileName)
        {
            var FileVirtualPath = "~/Files/" + FileName;
            return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));
        }

    }

}