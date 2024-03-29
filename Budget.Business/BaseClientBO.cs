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
    public class BaseClientBO
    {
        public virtual List<ClientDataModel> GetAll(int id=0)
        {
            return ClientDAL.GetAll();
        }

				public virtual List<ClientDataModel> GetClientByCity(int id)
        {
            return ClientDAL.GetClientByCity(id);
        }
		
		public virtual ClientDataModel Get(int id, bool useCache = false)
        {
            return ClientDAL.Get(id);
        }

		public virtual ClientDataModel GetByName(string name, bool useCache = false)
        {
            return ClientDAL.GetByName(name);
        }

		public virtual List<ClientDataModel> Filter(ClientDataModel model)
        {
            return ClientDAL.Filter(model);
        }

        public virtual int CreateOrUpdate(ClientDataModel item)
        {
						

            if (item.ID > 0)
            {
                ClientDAL.Update(item);
            }
            else
            {
                item.ID = ClientDAL.Create(item);
            }

			return Convert.ToInt32(item.ID);           
        }     

		public virtual void Delete(int id)
        {
            ClientDAL.Delete(id);
        }
    }
}