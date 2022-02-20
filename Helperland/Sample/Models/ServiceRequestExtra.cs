using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Sample.Models
{
    [Table("ServiceRequestExtra")]
    public partial class ServiceRequestExtra
    {
        [Key]
        public int ServiceRequestExtraId { get; set; }
        public int ServiceRequestId { get; set; }
        public int ServiceExtraId { get; set; }

        [ForeignKey(nameof(ServiceExtraId))]
        [InverseProperty(nameof(ExtraService.ServiceRequestExtras))]
        public virtual ExtraService ServiceExtra { get; set; }
        [ForeignKey(nameof(ServiceRequestId))]
        [InverseProperty("ServiceRequestExtras")]
        public virtual ServiceRequest ServiceRequest { get; set; }
    }
}
