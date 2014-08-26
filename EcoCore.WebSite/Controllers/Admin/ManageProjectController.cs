using Budget.Business;
using Budget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcoCore.WebSite.Controllers.Admin
{
    public class ManageProjectController : Controller
    {
        //
        // GET: /ManageRole/

        public ActionResult Index(ProjectDataModel model)
        {
            List<ProjectDataModel> list;
            if (model != null && !String.IsNullOrEmpty(model.Name))
            {
                list = ProjectBO.GetInstance().Filter(model);
            }
            else
            {
				if (model.ID != null && model.ID > 0)
                {
                    list = ProjectBO.GetInstance().GetAll(Convert.ToInt32(model.ID));
                }
                else
                {
                    list = ProjectBO.GetInstance().GetAll();
                }
            }
            
            return View(list);
        }

		public ActionResult Edit(int id = 0)
        {
            if (id == 0)
            {
                return View(new ProjectDataModel());
            }
            else
            {
                return View(ProjectBO.GetInstance().Get(id));
            }
            
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(ProjectDataModel item)
        {
            ProjectBO.GetInstance().CreateOrUpdate(item);

            if (Session["ProjectParentID"] != null)
            {
                return RedirectToAction("Index", new { id = Convert.ToInt32(Session["ProjectParentID"]) });
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

		public ActionResult Delete(int id)
        {
            ProjectBO.GetInstance().Delete(id);

            return Json(new { success=true }, JsonRequestBehavior.AllowGet);
        }

    }
}