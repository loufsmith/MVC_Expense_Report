using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cts.Mvc.ExpenseReport.Domain
{
    public class ExpenseReports
    {
        [ScaffoldColumn(false)]
        public int ExpenseReportsID { get; set; }

        [Required]
        [Display(Name = "Employee")]
        public int EmployeesID { get; set; }

        [Display(Name = "Title")]
        public int TitleID { get; set; }

        [Required]
        [Display(Name = "Month/Year")]
        public string MonthYear { get; set; }

        [Display(Name = "Client")]
        public int ClientID { get; set; }

        [Display(Name = "Project")]
        public int ProjectID { get; set; }

        [Required]
        public bool Billable { get; set; }
        public virtual ICollection<Employees> Employees { get; set; }
        public virtual Clients Clients { get; set; }
        public virtual Projects Projects { get; set; }

    }
}