
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
    public class BaseProviderDAL
    {
		public static ProviderDataModel MapItem(DataRow row)
		{
			ProviderDataModel item = null;
			item = new ProviderDataModel();

			if (row["ID"].GetType() != typeof(DBNull))
			{
				item.ID = Convert.ToInt32(row["ID"]);
			}
			if (row["Name"].GetType() != typeof(DBNull))
			{
				item.Name = Convert.ToString(row["Name"]);
			}
			if (row["BankID"].GetType() != typeof(DBNull))
			{
				item.BankID = Convert.ToInt32(row["BankID"]);
			}
			if (row["BankAccountNumber"].GetType() != typeof(DBNull))
			{
				item.BankAccountNumber = Convert.ToString(row["BankAccountNumber"]);
			}
			if (row["BankAccountTypeID"].GetType() != typeof(DBNull))
			{
				item.BankAccountTypeID = Convert.ToInt32(row["BankAccountTypeID"]);
			}
			if (row["BankAccountOwner"].GetType() != typeof(DBNull))
			{
				item.BankAccountOwner = Convert.ToString(row["BankAccountOwner"]);
			}
			if (row["IdNumber"].GetType() != typeof(DBNull))
			{
				item.IdNumber = Convert.ToString(row["IdNumber"]);
			}
			if (row["Notes"].GetType() != typeof(DBNull))
			{
				item.Notes = Convert.ToString(row["Notes"]);
			}
			
			return item;
		}

        public static List<ProviderDataModel> GetAll()
        {
            List<ProviderDataModel> items = new List<ProviderDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetAllProvider", connection);
			adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow row in results.Rows)
            {
                ProviderDataModel item = MapItem(row);
                items.Add(item);
            }

            return items;
        }

		public static List<ProviderDataModel> Filter(ProviderDataModel model)
        {
            List<ProviderDataModel> items = new List<ProviderDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            string FilterSelect = "" +
                " SELECT  ID,  Name,  BankID,  BankAccountNumber,  BankAccountTypeID,  BankAccountOwner,  IdNumber,  Notes  " +
                " FROM provider " +
                " WHERE Name LIKE '%" + model.Name.Replace("'","").Replace("-","") + "%'";

            MySqlDataAdapter adapter = new MySqlDataAdapter(FilterSelect, connection);
            adapter.SelectCommand.CommandType = CommandType.Text;

            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow row in results.Rows)
            {
                ProviderDataModel item = MapItem(row);
                items.Add(item);
            }

            return items;
        }

				 public static List<ProviderDataModel> GetProviderByBank(int id)
        {
            List<ProviderDataModel> items = new List<ProviderDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetProviderByBank", connection);
			adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

			MySqlParameter paramID = new MySqlParameter("pId", id);
            paramID.Direction = ParameterDirection.Input;            
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow row in results.Rows)
            {
                ProviderDataModel item = MapItem(row);
                items.Add(item);
            }

            return items;
        }
				 public static List<ProviderDataModel> GetProviderByBankaccounttype(int id)
        {
            List<ProviderDataModel> items = new List<ProviderDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetProviderByBankaccounttype", connection);
			adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

			MySqlParameter paramID = new MySqlParameter("pId", id);
            paramID.Direction = ParameterDirection.Input;            
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow row in results.Rows)
            {
                ProviderDataModel item = MapItem(row);
                items.Add(item);
            }

            return items;
        }
		
        public static ProviderDataModel Get(int id)
        {
            ProviderDataModel item = null;

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetProviderByID", connection);
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

		public static ProviderDataModel GetByName(string name)
        {
            ProviderDataModel item = null;

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetProviderByName", connection);
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

        public static void Update(ProviderDataModel item)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_UpdateProvider", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			
			
						MySqlParameter paramID = new MySqlParameter("pID", item.ID);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);
					MySqlParameter paramName = new MySqlParameter("pName", item.Name);
            paramName.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramName);
					MySqlParameter paramBankID = new MySqlParameter("pBankID", item.BankID);
            paramBankID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramBankID);
					MySqlParameter paramBankAccountNumber = new MySqlParameter("pBankAccountNumber", item.BankAccountNumber);
            paramBankAccountNumber.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramBankAccountNumber);
					MySqlParameter paramBankAccountTypeID = new MySqlParameter("pBankAccountTypeID", item.BankAccountTypeID);
            paramBankAccountTypeID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramBankAccountTypeID);
					MySqlParameter paramBankAccountOwner = new MySqlParameter("pBankAccountOwner", item.BankAccountOwner);
            paramBankAccountOwner.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramBankAccountOwner);
					MySqlParameter paramIdNumber = new MySqlParameter("pIdNumber", item.IdNumber);
            paramIdNumber.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramIdNumber);
					MySqlParameter paramNotes = new MySqlParameter("pNotes", item.Notes);
            paramNotes.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramNotes);
		
            DataTable results = new DataTable();
            adapter.Fill(results);
        }

        public static int Create(ProviderDataModel item)
        {
           MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_CreateProvider", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			
			
						MySqlParameter paramID = new MySqlParameter("pID", item.ID);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);
					MySqlParameter paramName = new MySqlParameter("pName", item.Name);
            paramName.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramName);
					MySqlParameter paramBankID = new MySqlParameter("pBankID", item.BankID);
            paramBankID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramBankID);
					MySqlParameter paramBankAccountNumber = new MySqlParameter("pBankAccountNumber", item.BankAccountNumber);
            paramBankAccountNumber.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramBankAccountNumber);
					MySqlParameter paramBankAccountTypeID = new MySqlParameter("pBankAccountTypeID", item.BankAccountTypeID);
            paramBankAccountTypeID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramBankAccountTypeID);
					MySqlParameter paramBankAccountOwner = new MySqlParameter("pBankAccountOwner", item.BankAccountOwner);
            paramBankAccountOwner.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramBankAccountOwner);
					MySqlParameter paramIdNumber = new MySqlParameter("pIdNumber", item.IdNumber);
            paramIdNumber.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramIdNumber);
					MySqlParameter paramNotes = new MySqlParameter("pNotes", item.Notes);
            paramNotes.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramNotes);
		
            DataTable results = new DataTable();
            adapter.Fill(results);

			if(results.Rows.Count > 0)
			{
				return Convert.ToInt32(results.Rows[0]["ID"]);
			}else{
				throw new Exception("Error creating Provider");
			}
        }

        public static void Delete(int id)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_DeleteProvider", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            MySqlParameter paramID = new MySqlParameter("pID", id);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();
            adapter.Fill(results);
        }
    }
}
