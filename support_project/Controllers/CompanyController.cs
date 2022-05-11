using PagedList;
using support_project.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace support_project.Controllers
{
    public class CompanyController : Controller
    {
        suppport_hunreEntities objsuppport_hunreEntities = new suppport_hunreEntities();

        /*public ActionResult Company()
        {
            var listCompany = objsuppport_hunreEntities.cong_tys.ToList();
            return View(listCompany);
        }*/
        public ActionResult Company(string currentFilter, string search, int? page)
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
                lstCompany = objsuppport_hunreEntities.cong_tys.Where(n => n.chuyen_nganh.Contains(search)).ToList();
            }
            else
            {
                lstCompany = objsuppport_hunreEntities.cong_tys.ToList();
            }
            ViewBag.CurrentFilter = search;
            int pageMax = 3;
            int pageMin = (page ?? 1);
            lstCompany = lstCompany.OrderByDescending(n => n.id_cong_ty).ToList();
            return View(lstCompany.ToPagedList(pageMin, pageMax));
        }
    }
}