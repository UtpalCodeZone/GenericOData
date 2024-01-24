using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GenericOData.Application.Models.V1.DataModels
{
    [Table("edge")]
    [Index("code", Name = "edge_uk_code", IsUnique = true)]
    [Index("row_id", Name = "edge_uk_row_id", IsUnique = true)]
    public partial class edge
    {
        [Key]
        public int id { get; set; }
        public Guid row_id { get; set; }
        public int site_id { get; set; }
        [Required]
        [StringLength(200)]
        public string name { get; set; }
        [Required]
        [StringLength(400)]
        public string code { get; set; }
        [StringLength(400)]
        public string make { get; set; }
        [StringLength(400)]
        public string model { get; set; }
        [StringLength(100)]
        public string mac_id { get; set; }
        [StringLength(100)]
        public string ip_address { get; set; }
        public int os_id { get; set; }
        [StringLength(1500)]
        public string comments { get; set; }
        [Required]
        public bool? status { get; set; }
        public bool deleted { get; set; }
        public DateTime created_date { get; set; }
        public DateTime? modified_date { get; set; }
        public int created_user { get; set; }
        public int? modified_user { get; set; }
        public int tenant_id { get; set; }
        public bool is_provisioned { get; set; }
        [Required]
        [Column(TypeName = "json")]
        public string audit { get; set; }

        [ForeignKey("os_id")]
        [InverseProperty("edges")]
        public virtual o os { get; set; }
    }
}
