using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GenericOData.Application.Models.V1.DataModels
{
    [Table("site")]
    [Index("code", Name = "site_uk_code", IsUnique = true)]
    [Index("prefix", Name = "site_uk_prefix", IsUnique = true)]
    [Index("row_id", Name = "site_uk_row_id", IsUnique = true)]
    public partial class site
    {
        [Key]
        public int id { get; set; }
        public Guid row_id { get; set; }
        [Required]
        [StringLength(400)]
        public string name { get; set; }
        [StringLength(20)]
        public string prefix { get; set; }
        [Required]
        [StringLength(200)]
        public string code { get; set; }
        [StringLength(1500)]
        public string description { get; set; }
        [StringLength(1500)]
        public string comments { get; set; }
        [Required]
        public bool? status { get; set; }
        public bool? deleted { get; set; }
        public int created_user { get; set; }
        public DateTime created_date { get; set; }
        public int? modified_user { get; set; }
        public DateTime? modified_date { get; set; }
    }
}
