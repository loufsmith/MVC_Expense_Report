using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cts.Mvc.ExpenseReport.Domain
{
    public class Employees
    {
        [ScaffoldColumn(false)]
        public int EmployeesID { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "The {0} maximum is 50 characters.")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "The {0} maximum is 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage="Title must be selected")]
        [Display(Name = "Title")]
        public int TitlesID { get; set; }
        public virtual Titles Titles { get; set; }

        public virtual string FullName {
            get {
                return string.Format("{0}, {1}", LastName, FirstName);
            }
        }
    }
}