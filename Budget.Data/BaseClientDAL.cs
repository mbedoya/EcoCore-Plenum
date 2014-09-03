
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
    public class BaseClientDAL
    {
		public static ClientDataModel MapItem(DataRow row)
		{
			ClientDataModel item = null;
			item = new ClientDataModel();

			if (row["ID"].GetType() != typeof(DBNull))
			{
				item.ID = Convert.ToInt32(row["ID"]);
			}
			if (row["Name"].GetType() != typeof(DBNull))
			{
				item.Name = Convert.ToString(row["Name"]);
			}
			if (row["Address"].GetType() != typeof(DBNull))
			{
				item.Address = Convert.ToString(row["Address"]);
			}
			if (row["CityID"].GetType() != typeof(DBNull))
			{
				item.CityID = Convert.ToInt32(row["CityID"]);
			}
			
			return item;
		}

        public static List<ClientDataModel> GetAll()
        {
            List<ClientDataModel> items = new List<ClientDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetAllClient", connection);
			adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow row in results.Rows)
            {
                ClientDataModel item = MapItem(row);
                items.Add(item);
            }

            return items;
        }

		public static List<ClientDataModel> Filter(ClientDataModel model)
        {
            List<ClientDataModel> items = new List<ClientDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            string FilterSelect = "" +
                " SELECT  ID,  Name,  Address,  CityID  " +
                " FROM client " +
                " WHERE Name LIKE '%" + model.Name.Replace("'","").Replace("-","") + "%'";

            MySqlDataAdapter adapter = new MySqlDataAdapter(FilterSelect, connection);
            adapter.SelectCommand.CommandType = CommandType.Text;

            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow row in results.Rows)
            {
                ClientDataModel item = MapItem(row);
                items.Add(item);
            }

            return items;
        }

				 public static List<ClientDataModel> GetClientByCity(int id)
        {
            List<ClientDataModel> items = new List<ClientDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetClientByCity", connection);
			adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

			MySqlParameter paramID = new MySqlParameter("pId", id);
            paramID.Direction = ParameterDirection.Input;            
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow row in results.Rows)
            {
                ClientDataModel item = MapItem(row);
                items.Add(item);
            }

            return items;
        }
		
        public static ClientDataModel Get(int id)
        {
            ClientDataModel item = null;

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetClientByID", connection);
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

		public static ClientDataModel GetByName(string name)
        {
            ClientDataModel item = null;

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetClientByName", connection);
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

        public static void Update(ClientDataModel item)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_UpdateClient", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			
			
						MySqlParameter paramID = new MySqlParameter("pID", item.ID);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);
					MySqlParameter paramName = new MySqlParameter("pName", item.Name);
            paramName.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramName);
					MySqlParameter paramAddress = new MySqlParameter("pAddress", item.Address);
            paramAddress.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramAddress);
					MySqlParameter paramCityID = new MySqlParameter("pCityID", item.CityID);
            paramCityID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramCityID);
		
            DataTable results = new DataTable();
            adapter.Fill(results);
        }

        public static int Create(ClientDataModel item)
        {
           MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_CreateClient", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			
			
						MySqlParameter paramID = new MySqlParameter("pID", item.ID);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);
					MySqlParameter paramName = new MySqlParameter("pName", item.Name);
            paramName.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramName);
					MySqlParameter paramAddress = new MySqlParameter("pAddress", item.Address);
            paramAddress.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramAddress);
					MySqlParameter paramCityID = new MySqlParameter("pCityID", item.CityID);
            paramCityID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramCityID);
		
            DataTable results = new DataTable();
            adapter.Fill(results);

			if(results.Rows.Count > 0)
			{
				return Convert.ToInt32(results.Rows[0]["ID"]);
			}else{
				throw new Exception("Error creating Client");
			}
        }

        public static void Delete(int id)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_DeleteClient", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            MySqlParameter paramID = new MySqlParameter("pID", id);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();
            adapter.Fill(results);
        }
    }
}
