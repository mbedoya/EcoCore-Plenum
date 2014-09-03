using Budget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcoCore.WebSite.Models
{
    public class ResourceTreeModelUI
    {
        public bool ParentResources { get; set; }
        public List<ResourceDataModel> Resources { get; set; }
    }
}