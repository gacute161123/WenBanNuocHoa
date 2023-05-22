using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanNuocHoa.Controllers
{
    public class BLOGsController : Controller
    {
        // GET: BLOGs
        public ActionResult Index()
        {
            return View();
        }
    }
}