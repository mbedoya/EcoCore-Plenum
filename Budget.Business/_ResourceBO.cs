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
    public class ResourceBO : BaseResourceBO
    {
        private static ResourceBO instance;

        public static ResourceBO GetInstance()
        {
            if (instance == null)
            {
                instance = new ResourceBO();
            }

            return instance;
        }

		public override List<ResourceDataModel> GetAll(int id = 0)
        {
			HttpContext.Current.Session["ResourceParentID"] = null;
			return base.GetAll(id);            
        }

    }
}
