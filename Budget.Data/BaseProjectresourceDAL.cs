
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
    public class BaseProjectresourceDAL
    {
		public static ProjectresourceDataModel MapItem(DataRow row)
		{
			ProjectresourceDataModel item = null;
			item = new ProjectresourceDataModel();

			if (row["ID"].GetType() != typeof(DBNull))
			{
				item.ID = Convert.ToInt32(row["ID"]);
			}
			if (row["Name"].GetType() != typeof(DBNull))
			{
				item.Name = Convert.ToString(row["Name"]);
			}
			if (row["ProjectID"].GetType() != typeof(DBNull))
			{
				item.ProjectID = Convert.ToInt32(row["ProjectID"]);
			}
			if (row["ResourceID"].GetType() != typeof(DBNull))
			{
				item.ResourceID = Convert.ToInt32(row["ResourceID"]);
			}
			if (row["ProviderID"].GetType() != typeof(DBNull))
			{
				item.ProviderID = Convert.ToInt32(row["ProviderID"]);
			}
			if (row["Detail"].GetType() != typeof(DBNull))
			{
				item.Detail = Convert.ToString(row["Detail"]);
			}
			if (row["Quantity"].GetType() != typeof(DBNull))
			{
				item.Quantity = Convert.ToInt32(row["Quantity"]);
			}
			if (row["Duration"].GetType() != typeof(DBNull))
			{
				item.Duration = Convert.ToInt32(row["Duration"]);
			}
			if (row["UnitCost"].GetType() != typeof(DBNull))
			{
				item.UnitCost = Convert.ToDouble(row["UnitCost"]);
			}
			if (row["SalePrice"].GetType() != typeof(DBNull))
			{
				item.SalePrice = Convert.ToDouble(row["SalePrice"]);
			}
			
			return item;
		}

        public static List<ProjectresourceDataModel> GetAll()
        {
            List<ProjectresourceDataModel> items = new List<ProjectresourceDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetAllProjectresource", connection);
			adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow row in results.Rows)
            {
                ProjectresourceDataModel item = MapItem(row);
                items.Add(item);
            }

            return items;
        }

		public static List<ProjectresourceDataModel> Filter(ProjectresourceDataModel model)
        {
            List<ProjectresourceDataModel> items = new List<ProjectresourceDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            string FilterSelect = "" +
                " SELECT  ID,  Name,  ProjectID,  ResourceID,  ProviderID,  Detail,  Quantity,  Duration,  UnitCost,  SalePrice  " +
                " FROM projectresource " +
                " WHERE Name LIKE '%" + model.Name.Replace("'","").Replace("-","") + "%'";

            MySqlDataAdapter adapter = new MySqlDataAdapter(FilterSelect, connection);
            adapter.SelectCommand.CommandType = CommandType.Text;

            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow row in results.Rows)
            {
                ProjectresourceDataModel item = MapItem(row);
                items.Add(item);
            }

            return items;
        }

				 public static List<ProjectresourceDataModel> GetProjectresourceByResource(int id)
        {
            List<ProjectresourceDataModel> items = new List<ProjectresourceDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetProjectresourceByResource", connection);
			adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

			MySqlParameter paramID = new MySqlParameter("pId", id);
            paramID.Direction = ParameterDirection.Input;            
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow row in results.Rows)
            {
                ProjectresourceDataModel item = MapItem(row);
                items.Add(item);
            }

            return items;
        }
				 public static List<ProjectresourceDataModel> GetProjectresourceByProvider(int id)
        {
            List<ProjectresourceDataModel> items = new List<ProjectresourceDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetProjectresourceByProvider", connection);
			adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

			MySqlParameter paramID = new MySqlParameter("pId", id);
            paramID.Direction = ParameterDirection.Input;            
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow row in results.Rows)
            {
                ProjectresourceDataModel item = MapItem(row);
                items.Add(item);
            }

            return items;
        }
				 public static List<ProjectresourceDataModel> GetProjectresourceByProject(int id)
        {
            List<ProjectresourceDataModel> items = new List<ProjectresourceDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetProjectresourceByProject", connection);
			adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

			MySqlParameter paramID = new MySqlParameter("pId", id);
            paramID.Direction = ParameterDirection.Input;            
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow row in results.Rows)
            {
                ProjectresourceDataModel item = MapItem(row);
                items.Add(item);
            }

            return items;
        }
		
        public static ProjectresourceDataModel Get(int id)
        {
            ProjectresourceDataModel item = null;

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetProjectresourceByID", connection);
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

		public static ProjectresourceDataModel GetByName(string name)
        {
            ProjectresourceDataModel item = null;

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetProjectresourceByName", connection);
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

        public static void Update(ProjectresourceDataModel item)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_UpdateProjectresource", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			
			
						MySqlParameter paramID = new MySqlParameter("pID", item.ID);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);
					MySqlParameter paramName = new MySqlParameter("pName", item.Name);
            paramName.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramName);
					MySqlParameter paramProjectID = new MySqlParameter("pProjectID", item.ProjectID);
            paramProjectID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramProjectID);
					MySqlParameter paramResourceID = new MySqlParameter("pResourceID", item.ResourceID);
            paramResourceID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramResourceID);
					MySqlParameter paramProviderID = new MySqlParameter("pProviderID", item.ProviderID);
            paramProviderID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramProviderID);
					MySqlParameter paramDetail = new MySqlParameter("pDetail", item.Detail);
            paramDetail.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramDetail);
					MySqlParameter paramQuantity = new MySqlParameter("pQuantity", item.Quantity);
            paramQuantity.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramQuantity);
					MySqlParameter paramDuration = new MySqlParameter("pDuration", item.Duration);
            paramDuration.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramDuration);
					MySqlParameter paramUnitCost = new MySqlParameter("pUnitCost", item.UnitCost);
            paramUnitCost.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramUnitCost);
					MySqlParameter paramSalePrice = new MySqlParameter("pSalePrice", item.SalePrice);
            paramSalePrice.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramSalePrice);
		
            DataTable results = new DataTable();
            adapter.Fill(results);
        }

        public static int Create(ProjectresourceDataModel item)
        {
           MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_CreateProjectresource", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			
			
						MySqlParameter paramID = new MySqlParameter("pID", item.ID);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);
					MySqlParameter paramName = new MySqlParameter("pName", item.Name);
            paramName.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramName);
					MySqlParameter paramProjectID = new MySqlParameter("pProjectID", item.ProjectID);
            paramProjectID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramProjectID);
					MySqlParameter paramResourceID = new MySqlParameter("pResourceID", item.ResourceID);
            paramResourceID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramResourceID);
					MySqlParameter paramProviderID = new MySqlParameter("pProviderID", item.ProviderID);
            paramProviderID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramProviderID);
					MySqlParameter paramDetail = new MySqlParameter("pDetail", item.Detail);
            paramDetail.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramDetail);
					MySqlParameter paramQuantity = new MySqlParameter("pQuantity", item.Quantity);
            paramQuantity.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramQuantity);
					MySqlParameter paramDuration = new MySqlParameter("pDuration", item.Duration);
            paramDuration.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramDuration);
					MySqlParameter paramUnitCost = new MySqlParameter("pUnitCost", item.UnitCost);
            paramUnitCost.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramUnitCost);
					MySqlParameter paramSalePrice = new MySqlParameter("pSalePrice", item.SalePrice);
            paramSalePrice.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramSalePrice);
		
            DataTable results = new DataTable();
            adapter.Fill(results);

			if(results.Rows.Count > 0)
			{
				return Convert.ToInt32(results.Rows[0]["ID"]);
			}else{
				throw new Exception("Error creating Projectresource");
			}
        }

        public static void Delete(int id)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_DeleteProjectresource", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            MySqlParameter paramID = new MySqlParameter("pID", id);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();
            adapter.Fill(results);
        }
    }
}
