using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cts.Mvc.ExpenseReport.Domain
{
    public class Entries
    {
        [ScaffoldColumn(false)]
        public int EntriesID { get; set; }

        [Required]
        [Display(Name = "Employee")]
        public int EmployeesID { get; set; }

        [Required]
        [Display(Name = "Receipt#")]
        public int ExpenseID { get; set;  }

        [Required]
        [Display(Name = "Date Incurred")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date in the format dd/mm/yyyy")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateIncurred { get; set; }

        public string Guests { get; set; }

        [Display(Name = "# of People")]
        public int NumPeople { get; set; }

        [Display(Name = "Company(s) Affiliation")]
        public string Affiliation { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} maximum is 50 characters.")]
        public string Vendor { get; set; }

        [Display(Name = "Project")]
        public int ProjectsID { get; set; }

        [Required]
        [Display(Name = "Business Reason")]
        public int BusinessReasonsID { get; set; }

        [Required]
        [Display(Name = "Expense Category")]
        public int ExpenseCategoriesID { get; set; }

        [DataType(DataType.Currency)]
        public decimal? Amount { get; set; }

        [RegularExpression("([0-9]+)", ErrorMessage = "Miles must be a number.")] 
        public int? Miles { get; set; }

        [DataType(DataType.Currency)]
        public decimal? Mileage { get; set; }

        [DataType(DataType.Currency)]
        public decimal Total { get; set; }

        [Display(Name = "Billable")]
        public bool Billable { get; set; }

        public virtual Employees Employees { get; set; }
        public virtual ExpenseReports ExpenseReport { get; set; }
        public virtual Projects Project { get; set; }
        public virtual BusinessReasons Reason { get; set; }
        public virtual ExpenseCategories Category { get; set; }
    }
}