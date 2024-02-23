﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessPartnerManagementSystem.WebUI.Models
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public BaseEntity()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedAt = DateTime.Now;
        }
    }
}