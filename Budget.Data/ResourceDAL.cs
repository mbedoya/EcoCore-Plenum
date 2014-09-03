using Budget.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

namespace Budget.Data
{
    public class ResourceDAL : BaseResourceDAL
    {
        public static List<ResourceDataModel> GetParentResources()
        {
            List<ResourceDataModel> items = new List<ResourceDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[Plenum.Data.Constants.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetParentResources", connection);
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
    }
}