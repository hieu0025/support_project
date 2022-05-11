using support_project.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace support_project.Controllers
{
    public class DetailJobController : Controller
    {
        suppport_hunreEntities objsuppport_hunreEntities = new suppport_hunreEntities();
        // GET: DetailJob
        public ActionResult DetailJob(int Id) 
        {
            var objCompany = objsuppport_hunreEntities.cong_tys.Where(n => n.id_cong_ty == Id).FirstOrDefault();
            return View(objCompany);
        }
        
    }
}