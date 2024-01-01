using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelBlog.Entity.Abstract;
using TravelBlog.Models;

namespace TravelBlog.Controllers
{
    public class RegionController : Controller
    {
        private IRegionCrud _regionCrud;

        public RegionController(IRegionCrud regionCrud)
        {
            _regionCrud = regionCrud;
        }

        // GET: Region
        public ActionResult Index()
        {
            IEnumerable<Region> AllRegions = _regionCrud.GetAll();
            return View(AllRegions);
        }

        // GET: Region/Details/5
        public ActionResult Details(int id)
        {
            Region region = _regionCrud.GetRegionByInclude(id);
            return View(region);
        }

        // GET: Region/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Region/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Region/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Region/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Region/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Region/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
