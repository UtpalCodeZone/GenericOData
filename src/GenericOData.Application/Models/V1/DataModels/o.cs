using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GenericOData.Application.Models.V1.DataModels
{
    public partial class o
    {
        public o()
        {
            edges = new HashSet<edge>();
        }

        [Key]
        public int id { get; set; }
        public Guid row_id { get; set; }
        [Required]
        [Column(TypeName = "character varying")]
        public string name { get; set; }
        [Required]
        [Column(TypeName = "character varying")]
        public string code { get; set; }
        public bool? status { get; set; }
        public int created_user { get; set; }
        public DateTime created_date { get; set; }
        public int? modified_user { get; set; }
        public DateTime? modified_date { get; set; }
        public bool deleted { get; set; }

        [InverseProperty("os")]
        public virtual ICollection<edge> edges { get; set; }
    }
}
