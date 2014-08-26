using Budget.Business;
using Budget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcoCore.WebSite.Controllers.Admin
{
    public class ManageBankController : Controller
    {
        //
        // GET: /ManageRole/

        public ActionResult Index(BankDataModel model)
        {
            List<BankDataModel> list;
            if (model != null && !String.IsNullOrEmpty(model.Name))
            {
                list = BankBO.GetInstance().Filter(model);
            }
            else
            {
				if (model.ID != null && model.ID > 0)
                {
                    list = BankBO.GetInstance().GetAll(Convert.ToInt32(model.ID));
                }
                else
                {
                    list = BankBO.GetInstance().GetAll();
                }
            }
            
            return View(list);
        }

		public ActionResult Edit(int id = 0)
        {
            if (id == 0)
            {
                return View(new BankDataModel());
            }
            else
            {
                return View(BankBO.GetInstance().Get(id));
            }
            
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(BankDataModel item)
        {
            BankBO.GetInstance().CreateOrUpdate(item);

            if (Session["BankParentID"] != null)
            {
                return RedirectToAction("Index", new { id = Convert.ToInt32(Session["BankParentID"]) });
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

		public ActionResult Delete(int id)
        {
            BankBO.GetInstance().Delete(id);

            return Json(new { success=true }, JsonRequestBehavior.AllowGet);
        }

    }
}