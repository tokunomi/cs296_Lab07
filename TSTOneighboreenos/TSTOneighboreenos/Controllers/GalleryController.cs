using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSTOneighboreenos.DAL;
using TSTOneighboreenos.Models;

namespace TSTOneighboreenos.Controllers
{
    public class GalleryController : Controller
    {
        private NeighboreenoContext db = new NeighboreenoContext();

        // GET: Gallery
        public ActionResult Index()
        {
            return View();
        }
    }
}