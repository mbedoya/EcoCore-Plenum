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
    public class BaseProviderBO
    {
        public virtual List<ProviderDataModel> GetAll(int id=0)
        {
            return ProviderDAL.GetAll();
        }

				public virtual List<ProviderDataModel> GetProviderByCity(int id)
        {
            return ProviderDAL.GetProviderByCity(id);
        }
				public virtual List<ProviderDataModel> GetProviderByBank(int id)
        {
            return ProviderDAL.GetProviderByBank(id);
        }
				public virtual List<ProviderDataModel> GetProviderByBankaccounttype(int id)
        {
            return ProviderDAL.GetProviderByBankaccounttype(id);
        }
		
		public virtual ProviderDataModel Get(int id, bool useCache = false)
        {
            return ProviderDAL.Get(id);
        }

		public virtual ProviderDataModel GetByName(string name, bool useCache = false)
        {
            return ProviderDAL.GetByName(name);
        }

		public virtual List<ProviderDataModel> Filter(ProviderDataModel model)
        {
            return ProviderDAL.Filter(model);
        }

        public virtual int CreateOrUpdate(ProviderDataModel item)
        {
						

            if (item.ID > 0)
            {
                ProviderDAL.Update(item);
            }
            else
            {
                item.ID = ProviderDAL.Create(item);
            }

			return Convert.ToInt32(item.ID);           
        }     

		public virtual void Delete(int id)
        {
            ProviderDAL.Delete(id);
        }
    }
}