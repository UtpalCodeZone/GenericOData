using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GenericOData.Application.Models.V1.DataModels
{
    [Table("uom")]
    [Index("row_id", Name = "uom_uk_row_id", IsUnique = true)]
    public partial class uom
    {
        [Key]
        public int id { get; set; }
        public Guid row_id { get; set; }
        [Required]
        [StringLength(200)]
        public string name { get; set; }
        [Required]
        [StringLength(50)]
        public string code { get; set; }
        [StringLength(1000)]
        public string description { get; set; }
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
    }
}
