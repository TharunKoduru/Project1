using Ex19.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ex19.Controllers
{
    public class TouristController : Controller
    {
        TouristPlaceContext dal = null;
        public TouristController()
        {
            dal = new TouristPlaceContext();
        }
        public ActionResult Display()
        {
            List<TouristPlace> tplist = dal.tourists.ToList();
            return View(tplist);
        }

        public ActionResult Index()
        {
            List<TouristPlace> tplist = dal.tourists.ToList();
            return View(tplist);
        }

        public ActionResult AddPlace()
        {
            return View();
        }
        public ActionResult SavePlace(TouristPlace tp)
        {
            
            tp.Files = Request.Files[0];
            tp.ImagePath = "/Images/TouristPlace/" + tp.Files.FileName;
            
            //if (ModelState.IsValid)
            //{
                tp.Files.SaveAs(Server.MapPath(tp.ImagePath));
                dal.tourists.Add(tp);
                dal.SaveChanges();
                return RedirectToAction("Display");
            //}
            //else
            //{
            //    return View("AddPlace", tp);
            //}
            
        }
        public ActionResult EditPlace(int id)
        {
            TouristPlace t = dal.tourists.Find(id);
            return View(t);
        }
        [HttpPost]
        public ActionResult Edit(TouristPlace tp)
        {
            TouristPlace x = dal.tourists.Find(tp.TouristPlaceId);
            x.TouristPlaceId = tp.TouristPlaceId;
            x.TouristPlaceName = tp.TouristPlaceName;
            x.Description = tp.Description;
            x.Location = tp.Location;
            x.MoreInfo = tp.MoreInfo;
            if (Request.Files.Count == 1)
            {
                tp.Files = Request.Files[0];
                tp.ImagePath = "/Images/TouristPlace/" + tp.Files.FileName;
                tp.Files.SaveAs(Server.MapPath(tp.ImagePath));
            }
            dal.tourists.Add(tp);
            dal.SaveChanges();
            return RedirectToAction("Display");
        }   
        public ActionResult Details (int id)
        {
            return View(dal.tourists.Find(id));
        }
        public ActionResult Delete(int id)
        {
            TouristPlace t = dal.tourists.Find(id);
            dal.tourists.Remove(t);
            dal.SaveChanges();
            return RedirectToAction ("Index");
        }

       public ActionResult Employee()
        {
            return View();
        }
    }
}