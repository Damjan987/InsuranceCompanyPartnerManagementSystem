using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessPartnerManagementSystem.WebUI.Models
{
    public class Policy: BaseEntity
    {
        [Required]
        [MinLength(10, ErrorMessage = "Policy number must be at least 10 characters long")]
        [MaxLength(15, ErrorMessage = "Policy number can only be up to 15 characters long")]
        public string PolicyNumber { get; set; }

        [Required]
        public decimal PolicyPrice { get; set; }

        public ICollection<Partner> Partners { get; set; }
    }
}