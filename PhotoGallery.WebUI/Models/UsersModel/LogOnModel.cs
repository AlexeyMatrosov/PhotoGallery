﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoGallery.WebUI.Models.UsersModel
{
    public class LogOnModel
    {
        [Required]
        public string Name { get; set; }
        public string Password { get; set; }
    }
}