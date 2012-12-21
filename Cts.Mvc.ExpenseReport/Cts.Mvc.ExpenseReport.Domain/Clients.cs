using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cts.Mvc.ExpenseReport.Domain
{
    public class Clients
    {
        [ScaffoldColumn(false)]
        public int ClientsID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} maximum is 50 characters.")]
        public string Client { get; set; }
    }
}