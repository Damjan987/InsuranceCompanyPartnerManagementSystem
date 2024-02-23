using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BusinessPartnerManagementSystem.WebUI.Models
{
    public enum PartnerType { Personal = 1, Legal = 2 }
    public enum Gender { M, F, N }

    public class Partner: BaseEntity
    {
        // DONE
        [Required]
        [MinLength(2, ErrorMessage = "First name must be at least 2 characters long")]
        [MaxLength(255, ErrorMessage = "First name can only be up to 255 characters long")]
        public string FirstName { get; set; }

        // DONE
        [Required]
        [MinLength(2, ErrorMessage = "Last name must be at least 2 characters long")]
        [MaxLength(255, ErrorMessage = "Last name can only be up to 255 characters long")]
        public string LastName { get; set; }

        // DONE
        public string Address { get; set; }

        [Required]
        public int PartnerNumber { get; set; }

        // DONE
        public string CroatianPIN { get; set; }

        // DONE
        [Required]
        public PartnerType PartnerTypeId { get; set; }

        // DONE
        [Required]
        public DateTime CreatedAtUtc { get; set; } = DateTime.Now;

        // DONE
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [MaxLength(20, ErrorMessage = "Email can only be up to 255 characters long")]
        public string CreateByUser { get; set; }

        // DONE
        [Required]
        public bool IsForeign { get; set; }

        // DONE
        [Index(IsUnique = true)]
        [MinLength(10, ErrorMessage = "External code must be at least 10 characters long")]
        [MaxLength(20, ErrorMessage = "External code can only be up to 255 characters long")]
        public string ExternalCode { get; set; }

        // DONE
        [Required]
        public Gender Gender { get; set; }

        public ICollection<Policy> Policies { get; set; }
    }
}