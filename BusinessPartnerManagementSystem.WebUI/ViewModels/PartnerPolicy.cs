using BusinessPartnerManagementSystem.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessPartnerManagementSystem.WebUI.ViewModels
{
    public class PartnerPolicy
    {
        public Partner Partner { get; set; }

        public Policy SelectedPolicy { get; set; }
        public IEnumerable<Policy> Policies { get; set; }
    }
}