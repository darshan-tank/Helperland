using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Sample.Models
{
    public partial class ExtraService
    {
        public ExtraService()
        {
            ServiceRequestExtras = new HashSet<ServiceRequestExtra>();
        }

        [Key]
        public int ServiceExtraId { get; set; }
        [StringLength(100)]
        public string ServiceExtraName { get; set; }

        [InverseProperty(nameof(ServiceRequestExtra.ServiceExtra))]
        public virtual ICollection<ServiceRequestExtra> ServiceRequestExtras { get; set; }
    }
}
