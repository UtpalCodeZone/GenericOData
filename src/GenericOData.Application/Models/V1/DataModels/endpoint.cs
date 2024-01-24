using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GenericOData.Application.Models.V1.DataModels
{
    [Table("endpoint")]
    [Index("id", Name = "endpoint_id_idx")]
    [Index("row_id", Name = "endpoint_uk", IsUnique = true)]
    public partial class endpoint
    {
        [Key]
        public int id { get; set; }
        public Guid row_id { get; set; }
        public int protocol_id { get; set; }
        [Required]
        [StringLength(200)]
        public string name { get; set; }
        [Required]
        [StringLength(100)]
        public string server_url { get; set; }
        [Required]
        [Column(TypeName = "json")]
        public string setting { get; set; }
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

        [ForeignKey("protocol_id")]
        [InverseProperty("endpoints")]
        public virtual protocol protocol { get; set; }
    }
}
