using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GallowayTechWebApi_2018.Models
{
    [Table("Photos")]
    public partial class Photos
    {
        [Key]
        public int PhotoID { get; set; }
        public int AlbumID { get; set; }
        public string Caption { get; set; }
        public string FileName { get; set; }
        public string DirectoryName { get; set; }
        public string FullPath { get; set; }
        public string URL { get; set; }
        public string Size { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateUpdated { get; set; }
    }
}