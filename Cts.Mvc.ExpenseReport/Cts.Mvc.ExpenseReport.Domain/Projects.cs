using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cts.Mvc.ExpenseReport.Domain
{
    public class Projects
    {
        [ScaffoldColumn(false)]
        public int ProjectsID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} maximum is 50 characters.")]
        public string Project { get; set; }

        [Required(ErrorMessage="A Client must be selected")]
        [Display(Name = "ClientID")]
        public int ClientsID { get; set; }
        public virtual Clients Clients { get; set; }
    }
}