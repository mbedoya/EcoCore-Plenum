using Plenum.Models;
using System;
using System.Collections.Generic;
using System.Web;

namespace Budget.Models
{
    public class ClientDataModel : BaseDataModel
    {   
		public string  Address { get; set; }
		public int?  CityID { get; set; }
						
    }    
}

