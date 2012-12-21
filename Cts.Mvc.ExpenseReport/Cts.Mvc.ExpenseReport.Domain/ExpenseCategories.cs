using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cts.Mvc.ExpenseReport.Domain
{
    public class ExpenseCategories
    {
        [ScaffoldColumn(false)]
        public int ExpenseCategoriesID { get; set; }

        [Required]
        [Display(Name = "Expense Category")]
        public string Category { get; set; }
    }
}