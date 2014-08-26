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
    public class ProjectresourceBO : BaseProjectresourceBO
    {
        private static ProjectresourceBO instance;

        public static ProjectresourceBO GetInstance()
        {
            if (instance == null)
            {
                instance = new ProjectresourceBO();
            }

            return instance;
        }

		public override List<ProjectresourceDataModel> GetAll(int id = 0)
        {
			HttpContext.Current.Session["ProjectresourceParentID"] = null;
			return base.GetAll(id);            
        }

    }
}
