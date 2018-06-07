using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GallowayTechWebApi_2018.Models
{
    [Table("Albums")]
    public partial class Albums
    {
        [Key]
        public int AlbumID { get; set; }
        public string Caption { get; set; }
        public bool IsPublic { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateUpdated { get; set; }
    }
}
