using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineExamProject.Models
{
    public partial class TblAdmin
    {
        public int AdId { get; set; }

        [PersonalData]
        [Display(Name="Teacher Name")]
        [Required(ErrorMessage ="Enter Your Name")]
        public string AdName { get; set; }

        [PersonalData]
        [Display(Name = "Password")]
        [Required(ErrorMessage ="Enter Password")]
        [DataType(DataType.Password)]
        public string AdPassword { get; set; }
    }
}
