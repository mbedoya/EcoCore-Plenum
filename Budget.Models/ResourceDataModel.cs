using Plenum.Models;
using System;
using System.Collections.Generic;
using System.Web;

namespace Budget.Models
{
    public class ResourceDataModel : BaseDataModel
    {   
		public int?  ParentResourceID { get; set; }
		public int  SortIndex { get; set; }
						
    }    
}

