
using Budget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Budget.Data
{
    public class BaseResourceDAL
    {
		public static ResourceDataModel MapItem(DataRow row)
		{
			ResourceDataModel item = null;
			item = new ResourceDataModel();

			if (row["ID"].GetType() != typeof(DBNull))
			{
				item.ID = Convert.ToInt32(row["ID"]);
			}
			if (row["Name"].GetType() != typeof(DBNull))
			{
				item.Name = Convert.ToString(row["Name"]);
			}
			if (row["ParentResourceID"].GetType() != typeof(DBNull))
			{
				item.ParentResourceID = Convert.ToInt32(row["ParentResourceID"]);
			}
			
			return item;
		}

        public static List<ResourceDataModel> GetAll()
        {
            List<ResourceDataModel> items = new List<ResourceDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetAllResource", connection);
			adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow row in results.Rows)
            {
                ResourceDataModel item = MapItem(row);
                items.Add(item);
            }

            return items;
        }

		public static List<ResourceDataModel> Filter(ResourceDataModel model)
        {
            List<ResourceDataModel> items = new List<ResourceDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            string FilterSelect = "" +
                " SELECT  ID,  Name,  ParentResourceID  " +
                " FROM resource " +
                " WHERE Name LIKE '%" + model.Name.Replace("'","").Replace("-","") + "%'";

            MySqlDataAdapter adapter = new MySqlDataAdapter(FilterSelect, connection);
            adapter.SelectCommand.CommandType = CommandType.Text;

            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow row in results.Rows)
            {
                ResourceDataModel item = MapItem(row);
                items.Add(item);
            }

            return items;
        }

				 public static List<ResourceDataModel> GetResourceByResource(int id)
        {
            List<ResourceDataModel> items = new List<ResourceDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetResourceByResource", connection);
			adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

			MySqlParameter paramID = new MySqlParameter("pId", id);
            paramID.Direction = ParameterDirection.Input;            
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow row in results.Rows)
            {
                ResourceDataModel item = MapItem(row);
                items.Add(item);
            }

            return items;
        }
		
        public static ResourceDataModel Get(int id)
        {
            ResourceDataModel item = null;

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetResourceByID", connection);
            MySqlParameter paramID = new MySqlParameter("pId", id);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();

            adapter.Fill(results);			

            if (results.Rows.Count > 0)
            {
                DataRow row = results.Rows[0];
                item = MapItem(row);
            }

            return item;
        }

		public static ResourceDataModel GetByName(string name)
        {
            ResourceDataModel item = null;

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetResourceByName", connection);
            MySqlParameter paramID = new MySqlParameter("pName", name);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();

            adapter.Fill(results);			

            if (results.Rows.Count > 0)
            {
                DataRow row = results.Rows[0];
                item = MapItem(row);
            }

            return item;
        }

        public static void Update(ResourceDataModel item)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_UpdateResource", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			
			
						MySqlParameter paramID = new MySqlParameter("pID", item.ID);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);
					MySqlParameter paramName = new MySqlParameter("pName", item.Name);
            paramName.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramName);
					MySqlParameter paramParentResourceID = new MySqlParameter("pParentResourceID", item.ParentResourceID);
            paramParentResourceID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramParentResourceID);
		
            DataTable results = new DataTable();
            adapter.Fill(results);
        }

        public static int Create(ResourceDataModel item)
        {
           MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_CreateResource", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			
			
						MySqlParameter paramID = new MySqlParameter("pID", item.ID);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);
					MySqlParameter paramName = new MySqlParameter("pName", item.Name);
            paramName.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramName);
					MySqlParameter paramParentResourceID = new MySqlParameter("pParentResourceID", item.ParentResourceID);
            paramParentResourceID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramParentResourceID);
		
            DataTable results = new DataTable();
            adapter.Fill(results);

			if(results.Rows.Count > 0)
			{
				return Convert.ToInt32(results.Rows[0]["ID"]);
			}else{
				throw new Exception("Error creating Resource");
			}
        }

        public static void Delete(int id)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_DeleteResource", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            MySqlParameter paramID = new MySqlParameter("pID", id);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();
            adapter.Fill(results);
        }
    }
}
