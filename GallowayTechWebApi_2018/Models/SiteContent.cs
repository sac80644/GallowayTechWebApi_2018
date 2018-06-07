using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GallowayTechWebApi_2018.Models
{
    [Table("SiteContent")]
    public partial class SiteContent
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}
