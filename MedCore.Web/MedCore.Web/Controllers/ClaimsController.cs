using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedCore.Web.Controllers
{
    public class ClaimsController : Controller
    {
        // GET: Claims/Gp
        public ActionResult Gp()
        {
            return View(new GpClaim());
        }
    }
}