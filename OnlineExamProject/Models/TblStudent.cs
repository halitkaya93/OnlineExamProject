using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineExamProject.Models
{
    public partial class TblStudent
    {
        public TblStudent()
        {
            TblSetexam = new HashSet<TblSetexam>();
        }

        public int SId { get; set; }

        [Display(Name = "Student Name")]
        [Required(ErrorMessage = "Enter Your Name")]
        public string SName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Enter Password")]
        public string SPassword { get; set; }


        public virtual ICollection<TblSetexam> TblSetexam { get; set; }
    }
}
