using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelBlog.Entity.Abstract;
using TravelBlog.Models;

namespace TravelBlog.Controllers
{
    public class CityController : Controller
    {
       private readonly ICityCrud _cityCrud;

        public CityController(ICityCrud cityCrud)
        {
            _cityCrud = cityCrud;
        }


        // GET: City/Details/5
        public ActionResult Details(int id)
        {
            City city = _cityCrud.GetCityByInclude(id);
            return View(city);
         
        }

       
    }
}
