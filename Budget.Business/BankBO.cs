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
    public class BankBO : BaseBankBO
    {
        private static BankBO instance;

        public static BankBO GetInstance()
        {
            if (instance == null)
            {
                instance = new BankBO();
            }

            return instance;
        }

		public override List<BankDataModel> GetAll(int id = 0)
        {
			HttpContext.Current.Session["BankParentID"] = null;
			return base.GetAll(id);            
        }

    }
}
