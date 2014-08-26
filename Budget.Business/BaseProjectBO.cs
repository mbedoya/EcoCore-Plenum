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
    public class BaseProjectBO
    {
        public virtual List<ProjectDataModel> GetAll(int id=0)
        {
            return ProjectDAL.GetAll();
        }

				public virtual List<ProjectDataModel> GetProjectByClient(int id)
        {
            return ProjectDAL.GetProjectByClient(id);
        }
		
		public virtual ProjectDataModel Get(int id, bool useCache = false)
        {
            return ProjectDAL.Get(id);
        }

		public virtual ProjectDataModel GetByName(string name, bool useCache = false)
        {
            return ProjectDAL.GetByName(name);
        }

		public virtual List<ProjectDataModel> Filter(ProjectDataModel model)
        {
            return ProjectDAL.Filter(model);
        }

        public virtual void CreateOrUpdate(ProjectDataModel item)
        {
						

            if (item.ID > 0)
            {
                ProjectDAL.Update(item);
            }
            else
            {
                ProjectDAL.Create(item);
            }            
        }     

		public virtual void Delete(int id)
        {
            ProjectDAL.Delete(id);
        }
    }
}