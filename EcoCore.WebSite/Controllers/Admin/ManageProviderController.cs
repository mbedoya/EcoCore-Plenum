using Budget.Business;
using Budget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcoCore.WebSite.Controllers.Admin
{
    public class ManageProviderController : Controller
    {
        //
        // GET: /ManageRole/

        public ActionResult Index(ProviderDataModel model)
        {
            List<ProviderDataModel> list;
            if (model != null && !String.IsNullOrEmpty(model.Name))
            {
                list = ProviderBO.GetInstance().Filter(model);
            }
            else
            {
				if (model.ID != null && model.ID > 0)
                {
                    list = ProviderBO.GetInstance().GetAll(Convert.ToInt32(model.ID));
                }
                else
                {
                    list = ProviderBO.GetInstance().GetAll();
                }
            }
            
            return View(list);
        }

		public ActionResult Edit(int id = 0)
        {
            if (id == 0)
            {
                return View(new ProviderDataModel());
            }
            else
            {
                return View(ProviderBO.GetInstance().Get(id));
            }
            
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(ProviderDataModel item)
        {
            ProviderBO.GetInstance().CreateOrUpdate(item);

            if (Session["ProviderParentID"] != null)
            {
                return RedirectToAction("Index", new { id = Convert.ToInt32(Session["ProviderParentID"]) });
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

		public ActionResult Delete(int id)
        {
            ProviderBO.GetInstance().Delete(id);

            return Json(new { success=true }, JsonRequestBehavior.AllowGet);
        }

    }
}