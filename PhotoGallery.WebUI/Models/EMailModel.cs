using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoGallery.WebUI.Models
{
    public class EMailModel
    {
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a email address")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Please enter a body of letter")]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
    }
}