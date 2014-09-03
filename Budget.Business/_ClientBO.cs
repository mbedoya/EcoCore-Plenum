using Budget.Data;
using Budget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Plenum.Utilities;
using Plenum.Utilities.Security;
using Plenum.Utilities.Cache;

namespace Budget.Business
{
    public class ClientBO : BaseClientBO
    {
        private static ClientBO instance;

        public static ClientBO GetInstance()
        {
            if (instance == null)
            {
                instance = new ClientBO();
            }

            return instance;
        }

		public override List<ClientDataModel> GetAll(int id = 0)
        {
			HttpContext.Current.Session["ClientParentID"] = null;
			return base.GetAll(id);            
        }

    }
}
