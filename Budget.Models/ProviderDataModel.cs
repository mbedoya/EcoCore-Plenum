using Plenum.Models;
using System;
using System.Collections.Generic;
using System.Web;

namespace Budget.Models
{
    public class ProviderDataModel : BaseDataModel
    {   
		public int  BankID { get; set; }
		public string  BankAccountNumber { get; set; }
		public int  BankAccountTypeID { get; set; }
		public string  BankAccountOwner { get; set; }
		public string  IdNumber { get; set; }
		public string  Notes { get; set; }
						
    }    
}

