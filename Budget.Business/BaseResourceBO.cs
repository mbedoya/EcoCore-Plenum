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
    public class BaseResourceBO
    {
        public virtual List<ResourceDataModel> GetAll(int id=0)
        {
            return ResourceDAL.GetAll();
        }

				public virtual List<ResourceDataModel> GetResourceByResource(int id)
        {
            return ResourceDAL.GetResourceByResource(id);
        }
		
		public virtual ResourceDataModel Get(int id, bool useCache = false)
        {
            return ResourceDAL.Get(id);
        }

		public virtual ResourceDataModel GetByName(string name, bool useCache = false)
        {
            return ResourceDAL.GetByName(name);
        }

		public virtual List<ResourceDataModel> Filter(ResourceDataModel model)
        {
            return ResourceDAL.Filter(model);
        }

        public virtual void CreateOrUpdate(ResourceDataModel item)
        {
						

            if (item.ID > 0)
            {
                ResourceDAL.Update(item);
            }
            else
            {
                ResourceDAL.Create(item);
            }            
        }     

		public virtual void Delete(int id)
        {
            ResourceDAL.Delete(id);
        }
    }
}