using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineExamProject.Models
{
    public partial class Questions
    {
        public int QuestionId { get; set; }

        [Required(ErrorMessage ="*")]
        [Display(Name="Question Text")]
        public string QText { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Option A")]
        public string Opa { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Option B")]
        public string Opb { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Option C")]
        public string Opc { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Option D")]
        public string Opd { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Correct Answer")]
        public string Cop { get; set; }
    }
}
