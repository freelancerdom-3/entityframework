﻿using System.ComponentModel.DataAnnotations;
using HMSAPI.Model.GenericModel;

namespace HMSAPI.Model.TblUser
{
    public class TblUserModel : SecurityModel
    {
        [Key]
        public int UserId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public string? MobileNumber { get; set; }

        public int RoleId { get; set; }

        public string? ProfileImagePath { get; set; }
        public string? ProfileImageThumbnailPath { get; set; }  
    }
}
