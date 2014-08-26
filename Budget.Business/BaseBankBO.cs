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
    public class BaseBankBO
    {
        public virtual List<BankDataModel> GetAll(int id=0)
        {
            return BankDAL.GetAll();
        }

		
		public virtual BankDataModel Get(int id, bool useCache = false)
        {
            return BankDAL.Get(id);
        }

		public virtual BankDataModel GetByName(string name, bool useCache = false)
        {
            return BankDAL.GetByName(name);
        }

		public virtual List<BankDataModel> Filter(BankDataModel model)
        {
            return BankDAL.Filter(model);
        }

        public virtual void CreateOrUpdate(BankDataModel item)
        {
						

            if (item.ID > 0)
            {
                BankDAL.Update(item);
            }
            else
            {
                BankDAL.Create(item);
            }            
        }     

		public virtual void Delete(int id)
        {
            BankDAL.Delete(id);
        }
    }
}