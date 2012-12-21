using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cts.Mvc.ExpenseReport.Domain
{
    public class Expenses
    {
        [ScaffoldColumn(false)]
        public int ExpensesID { get; set; }
        
        [Required]
        public DateTime ExpenseDate { get; set; }
        public virtual ICollection<ExpenseCategories> Expense { get; set; }
    }
}