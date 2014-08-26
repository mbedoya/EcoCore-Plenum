using Budget.Business;
using Budget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcoCore.WebSite.Controllers.Admin
{
    public class ManageBankaccounttypeController : Controller
    {
        //
        // GET: /ManageRole/

        public ActionResult Index(BankaccounttypeDataModel model)
        {
            List<BankaccounttypeDataModel> list;
            if (model != null && !String.IsNullOrEmpty(model.Name))
            {
                list = BankaccounttypeBO.GetInstance().Filter(model);
            }
            else
            {
				if (model.ID != null && model.ID > 0)
                {
                    list = BankaccounttypeBO.GetInstance().GetAll(Convert.ToInt32(model.ID));
                }
                else
                {
                    list = BankaccounttypeBO.GetInstance().GetAll();
                }
            }
            
            return View(list);
        }

		public ActionResult Edit(int id = 0)
        {
            if (id == 0)
            {
                return View(new BankaccounttypeDataModel());
            }
            else
            {
                return View(BankaccounttypeBO.GetInstance().Get(id));
            }
            
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(BankaccounttypeDataModel item)
        {
            BankaccounttypeBO.GetInstance().CreateOrUpdate(item);

            if (Session["BankaccounttypeParentID"] != null)
            {
                return RedirectToAction("Index", new { id = Convert.ToInt32(Session["BankaccounttypeParentID"]) });
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

		public ActionResult Delete(int id)
        {
            BankaccounttypeBO.GetInstance().Delete(id);

            return Json(new { success=true }, JsonRequestBehavior.AllowGet);
        }

    }
}