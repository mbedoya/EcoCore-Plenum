using Plenum.Models;
using System;
using System.Collections.Generic;
using System.Web;

namespace Budget.Models
{
    public class ProjectresourceDataModel : BaseDataModel
    {   
		public int  ProjectID { get; set; }
		public int  ResourceID { get; set; }
		public int  ProviderID { get; set; }
		public string  Detail { get; set; }
		public int  Quantity { get; set; }
		public int  Duration { get; set; }
		public double  UnitCost { get; set; }
		public double  SalePrice { get; set; }
						
    }    
}

