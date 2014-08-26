using Budget.Business;
using Budget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcoCore.WebSite.Controllers.Admin
{
    public class ManageProjectresourceController : Controller
    {
        //
        // GET: /ManageRole/

        public ActionResult Index(ProjectresourceDataModel model)
        {
            List<ProjectresourceDataModel> list;
            if (model != null && !String.IsNullOrEmpty(model.Name))
            {
                list = ProjectresourceBO.GetInstance().Filter(model);
            }
            else
            {
				if (model.ID != null && model.ID > 0)
                {
                    list = ProjectresourceBO.GetInstance().GetAll(Convert.ToInt32(model.ID));
                }
                else
                {
                    list = ProjectresourceBO.GetInstance().GetAll();
                }
            }
            
            return View(list);
        }

		public ActionResult Edit(int id = 0)
        {
            if (id == 0)
            {
                return View(new ProjectresourceDataModel());
            }
            else
            {
                return View(ProjectresourceBO.GetInstance().Get(id));
            }
            
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(ProjectresourceDataModel item)
        {
            ProjectresourceBO.GetInstance().CreateOrUpdate(item);

            if (Session["ProjectresourceParentID"] != null)
            {
                return RedirectToAction("Index", new { id = Convert.ToInt32(Session["ProjectresourceParentID"]) });
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

		public ActionResult Delete(int id)
        {
            ProjectresourceBO.GetInstance().Delete(id);

            return Json(new { success=true }, JsonRequestBehavior.AllowGet);
        }

    }
}