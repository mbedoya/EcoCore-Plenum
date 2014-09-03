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
		public string  CommercialName { get; set; }
		public string  Regimen { get; set; }
		public string  NIT { get; set; }
		public string  DV { get; set; }
		public int  ActivityCode { get; set; }
		public string  Address { get; set; }
		public int?  CityID { get; set; }
		public string  Phone { get; set; }
		public string  MobilePhone { get; set; }
		public string  Email { get; set; }
		public string  Representative { get; set; }
		public string  ContactName { get; set; }
						
    }    
}

