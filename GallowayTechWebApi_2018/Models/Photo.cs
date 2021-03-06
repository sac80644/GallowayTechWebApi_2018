﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GallowayTechWebApi_2018.Models
{
    [Table("Photos")]
    public partial class Photo
    {
        [Key, Column(Order = 1)]
        public int PhotoID { get; set; }
        public string FileName { get; set; }
        public string Caption { get; set; }
        public string DirectoryName { get; set; }
        public string FullPath { get; set; }
        public string URL { get; set; }
        [Key, Column(Order = 7)]
        public string Size { get; set; }
        public string SearchText { get; set; }
        public bool IsPublic { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateUpdated { get; set; }

        public int AlbumID { get; set; }
        //public Album Album { get; set; }
    }
}