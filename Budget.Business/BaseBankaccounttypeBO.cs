using Budget.Data;
using Budget.Models;
using Plenum.Utilities.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Budget.Business
{
    public class BaseBankaccounttypeBO
    {
        public virtual List<BankaccounttypeDataModel> GetAll(int id=0)
        {
            return BankaccounttypeDAL.GetAll();
        }

		
		public virtual BankaccounttypeDataModel Get(int id, bool useCache = false)
        {
            return BankaccounttypeDAL.Get(id);
        }

		public virtual BankaccounttypeDataModel GetByName(string name, bool useCache = false)
        {
            return BankaccounttypeDAL.GetByName(name);
        }

		public virtual List<BankaccounttypeDataModel> Filter(BankaccounttypeDataModel model)
        {
            return BankaccounttypeDAL.Filter(model);
        }

        public virtual void CreateOrUpdate(BankaccounttypeDataModel item)
        {
						

            if (item.ID > 0)
            {
                BankaccounttypeDAL.Update(item);
            }
            else
            {
                BankaccounttypeDAL.Create(item);
            }            
        }     

		public virtual void Delete(int id)
        {
            BankaccounttypeDAL.Delete(id);
        }
    }
}