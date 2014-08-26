using Budget.Business;
using Budget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcoCore.WebSite.Controllers.Admin
{
    public class ManageClientController : Controller
    {
        //
        // GET: /ManageRole/

        public ActionResult Index(ClientDataModel model)
        {
            List<ClientDataModel> list;
            if (model != null && !String.IsNullOrEmpty(model.Name))
            {
                list = ClientBO.GetInstance().Filter(model);
            }
            else
            {
				if (model.ID != null && model.ID > 0)
                {
                    list = ClientBO.GetInstance().GetAll(Convert.ToInt32(model.ID));
                }
                else
                {
                    list = ClientBO.GetInstance().GetAll();
                }
            }
            
            return View(list);
        }

		public ActionResult Edit(int id = 0)
        {
            if (id == 0)
            {
                return View(new ClientDataModel());
            }
            else
            {
                return View(ClientBO.GetInstance().Get(id));
            }
            
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(ClientDataModel item)
        {
            ClientBO.GetInstance().CreateOrUpdate(item);

            if (Session["ClientParentID"] != null)
            {
                return RedirectToAction("Index", new { id = Convert.ToInt32(Session["ClientParentID"]) });
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

		public ActionResult Delete(int id)
        {
            ClientBO.GetInstance().Delete(id);

            return Json(new { success=true }, JsonRequestBehavior.AllowGet);
        }

    }
}