using Budget.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcoCore.WebSite.Controllers.Admin
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View(ClientBO.GetInstance().GetAll());
        }

        public ActionResult Account()
        {
            return View(ClientBO.GetInstance().GetAll());
        }

    }
}
