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
    public class BaseProjectresourceBO
    {
        public virtual List<ProjectresourceDataModel> GetAll(int id=0)
        {
            return ProjectresourceDAL.GetAll();
        }

				public virtual List<ProjectresourceDataModel> GetProjectresourceByResource(int id)
        {
            return ProjectresourceDAL.GetProjectresourceByResource(id);
        }
				public virtual List<ProjectresourceDataModel> GetProjectresourceByProvider(int id)
        {
            return ProjectresourceDAL.GetProjectresourceByProvider(id);
        }
				public virtual List<ProjectresourceDataModel> GetProjectresourceByProject(int id)
        {
            return ProjectresourceDAL.GetProjectresourceByProject(id);
        }
		
		public virtual ProjectresourceDataModel Get(int id, bool useCache = false)
        {
            return ProjectresourceDAL.Get(id);
        }

		public virtual ProjectresourceDataModel GetByName(string name, bool useCache = false)
        {
            return ProjectresourceDAL.GetByName(name);
        }

		public virtual List<ProjectresourceDataModel> Filter(ProjectresourceDataModel model)
        {
            return ProjectresourceDAL.Filter(model);
        }

        public virtual void CreateOrUpdate(ProjectresourceDataModel item)
        {
						

            if (item.ID > 0)
            {
                ProjectresourceDAL.Update(item);
            }
            else
            {
                ProjectresourceDAL.Create(item);
            }            
        }     

		public virtual void Delete(int id)
        {
            ProjectresourceDAL.Delete(id);
        }
    }
}