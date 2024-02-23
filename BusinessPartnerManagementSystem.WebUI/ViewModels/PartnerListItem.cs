using BusinessPartnerManagementSystem.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessPartnerManagementSystem.WebUI.ViewModels
{
    public class PartnerListItem
    {
        public Partner Partner { get; set; }
        public bool HasFiveOrMorePolicies { get; set; }
    }
}