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
    public class BankaccounttypeBO : BaseBankaccounttypeBO
    {
        private static BankaccounttypeBO instance;

        public static BankaccounttypeBO GetInstance()
        {
            if (instance == null)
            {
                instance = new BankaccounttypeBO();
            }

            return instance;
        }

		public override List<BankaccounttypeDataModel> GetAll(int id = 0)
        {
			HttpContext.Current.Session["BankaccounttypeParentID"] = null;
			return base.GetAll(id);            
        }

    }
}
