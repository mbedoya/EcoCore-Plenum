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
    public class ProviderBO : BaseProviderBO
    {
        private static ProviderBO instance;

        public static ProviderBO GetInstance()
        {
            if (instance == null)
            {
                instance = new ProviderBO();
            }

            return instance;
        }

		public override List<ProviderDataModel> GetAll(int id = 0)
        {
			HttpContext.Current.Session["ProviderParentID"] = null;
			return base.GetAll(id);            
        }

    }
}
