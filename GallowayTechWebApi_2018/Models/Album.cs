using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GallowayTechWebApi_2018.Models
{
    [Table("Albums")]
    public partial class Album
    {
        [Key]
        public int AlbumID { get; set; }
        public string AlbumName { get; set; }
        public string Caption { get; set; }
        public string SearchText { get; set; }
        public bool IsPublic { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateUpdated { get; set; }

        public List<Photo> Photos { get; set; }
    }
}
