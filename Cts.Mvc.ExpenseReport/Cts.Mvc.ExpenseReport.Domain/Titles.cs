using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cts.Mvc.ExpenseReport.Domain
{
    public class Titles
    {
        [ScaffoldColumn(false)]
        public int TitlesID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} maximum is 50 characters.")]
        public string Title { get; set; }
    }
}