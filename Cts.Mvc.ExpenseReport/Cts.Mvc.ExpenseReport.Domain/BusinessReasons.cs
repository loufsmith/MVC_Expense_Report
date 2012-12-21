using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cts.Mvc.ExpenseReport.Domain
{
    public class BusinessReasons
    {
        [ScaffoldColumn(false)]
        public int BusinessReasonsID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} maximum is 50 characters.")]
        public string Reason { get; set; }
    }
}