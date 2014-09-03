using Budget.Business;
using Budget.Models;
using EcoCore.WebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcoCore.WebSite.Controllers.Admin
{
    public class ManageResourceController : Controller
    {
        //
        // GET: /ManageRole/

        public ActionResult Index(ResourceDataModel model)
        {
            List<ResourceDataModel> list;
            if (model != null && !String.IsNullOrEmpty(model.Name))
            {
                list = ResourceBO.GetInstance().Filter(model);
            }
            else
            {
				if (model.ID != null && model.ID > 0)
                {
                    list = ResourceBO.GetInstance().GetAll(Convert.ToInt32(model.ID));
                }
                else
                {
                    list = ResourceBO.GetInstance().GetAll();
                }
            }
            
            return View(list);
        }

		public ActionResult Edit(int id = 0)
        {
            if (id == 0)
            {
                return View(new ResourceDataModel());
            }
            else
            {
                return View(ResourceBO.GetInstance().Get(id));
            }
            
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(ResourceDataModel item)
        {
            ResourceBO.GetInstance().CreateOrUpdate(item);

            if (Session["ResourceParentID"] != null)
            {
                return RedirectToAction("Index", new { id = Convert.ToInt32(Session["ResourceParentID"]) });
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

		public ActionResult Delete(int id)
        {
            ResourceBO.GetInstance().Delete(id);

            return Json(new { success=true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetChildren(int? id)
        {
            ResourceTreeModelUI model = new ResourceTreeModelUI();

            if (id == null)
            {
                model.ParentResources = true;
                model.Resources = ResourceBO.GetInstance().GetParentResources();
            }
            else
            {
                model.Resources = ResourceBO.GetInstance().GetResourceByResource(Convert.ToInt32(id));
            }

            return View(model);
        }

    }
}