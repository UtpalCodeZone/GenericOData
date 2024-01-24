using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GenericOData.Application.Models.V1.DataModels
{
    [Table("protocol")]
    [Index("code", Name = "protocol_uk_code", IsUnique = true)]
    [Index("row_id", Name = "protocol_uk_row_id", IsUnique = true)]
    public partial class protocol
    {
        public protocol()
        {
            endpoints = new HashSet<endpoint>();
        }

        [Key]
        public int id { get; set; }
        public Guid row_id { get; set; }
        [Required]
        [StringLength(200)]
        public string name { get; set; }
        [Required]
        [StringLength(400)]
        public string code { get; set; }
        [Required]
        public bool? status { get; set; }
        public bool deleted { get; set; }
        public int created_user { get; set; }
        public DateTime created_date { get; set; }
        public int? modified_user { get; set; }
        public DateTime? modified_date { get; set; }
        public int tenant_id { get; set; }
        [Required]
        [Column(TypeName = "json")]
        public string audit { get; set; }

        [InverseProperty("protocol")]
        public virtual ICollection<endpoint> endpoints { get; set; }
    }
}
