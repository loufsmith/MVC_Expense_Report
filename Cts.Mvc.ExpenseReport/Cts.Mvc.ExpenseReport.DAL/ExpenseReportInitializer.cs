using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Cts.Mvc.ExpenseReport.Domain;

namespace Cts.Mvc.ExpenseReport.DAL
{
    public class ExpenseReportInitializer : DropCreateDatabaseIfModelChanges<ExpenseReportContext>
    {
        protected override void Seed(ExpenseReportContext context)
        {
            var reason = new List<BusinessReasons> { 
                new BusinessReasons {Reason = "Business Lunch"},
                new BusinessReasons {Reason = "Business Dinner"},
                new BusinessReasons {Reason = "Travel"},
                new BusinessReasons {Reason = "Gift"},
                new BusinessReasons {Reason = "Business Breakfast"},
                new BusinessReasons {Reason = "Conference"},
                new BusinessReasons {Reason = "Parking Fee"},
                new BusinessReasons {Reason = "Toll Road"},
                new BusinessReasons {Reason = "Conference Registration"},
            };
            reason.ForEach(s => context.BusinessReasons.Add(s));
            //context.SaveChanges();

            var titles = new List<Titles> { 
                new Titles {Title = "Analyst"},
                new Titles {Title = "Consultant"},
                new Titles {Title = "Senior Consultant"},
                new Titles {Title = "Project Manager"},
                new Titles {Title = "Senior Manager"},
                new Titles {Title = "Support Staff"},
                new Titles {Title = "Accountant"},
                new Titles {Title = "CEO"},
                new Titles {Title = "Director"},
            };
            titles.ForEach(s => context.Titles.Add(s));
            context.SaveChanges();

            var employee = new List<Employees> { 
                new Employees {FirstName = "Malcolm", LastName = "Frye", TitlesID = 1},
                new Employees {FirstName = "Louis", LastName = "Smith", TitlesID = 2},
                new Employees {FirstName = "Zoe", LastName = "Book", TitlesID = 3},
                new Employees {FirstName = "Inara", LastName = "Tam", TitlesID = 4},
                new Employees {FirstName = "Kaylee", LastName = "Reynolds", TitlesID = 5},
                new Employees {FirstName = "Simon", LastName = "Cobb", TitlesID = 7},
                new Employees {FirstName = "River", LastName = "Serra", TitlesID = 8},
                new Employees {FirstName = "Derrial", LastName = "Washburne", TitlesID = 9},
            };
            employee.ForEach(s => context.Employees.Add(s));
            context.SaveChanges();

            var client = new List<Clients> { 
                new Clients{Client = "Ariel"},
                new Clients{Client = "Beaumonde"},
                new Clients{Client = "Bellerophon"},
                new Clients{Client = "Haven"},
                new Clients{Client = "Hera"},
                new Clients{Client = "Higgins' Moon"},
            };
            client.ForEach(s => context.Clients.Add(s));
            context.SaveChanges();

            var projects = new List<Projects> { 
                new Projects{Project = "Lilac", ClientsID = 1},
                new Projects{Project = "Miranda", ClientsID = 2},
                new Projects{Project = "Osiris", ClientsID = 3},
                new Projects{Project = "Persephone", ClientsID = 4},
                new Projects{Project = "Whitefall", ClientsID = 6},
            };
            projects.ForEach(s => context.Projects.Add(s));
            context.SaveChanges();

            var expenseCategory = new List<ExpenseCategories> { 
                new ExpenseCategories{Category = "Meal"},
                new ExpenseCategories{Category = "Travel"},
                new ExpenseCategories{Category = "Gift"},
                new ExpenseCategories{Category = "Mileage"},
                new ExpenseCategories{Category = "Fees"},
                new ExpenseCategories{Category = "Miscellaneous"},
            };
            expenseCategory.ForEach(s => context.ExpenseCategories.Add(s));
            context.SaveChanges();

            //var expenseReport = new List<ExpenseReports> { 
            //    new ExpenseReports{
            //        EmployeesID = 1, TitleID = 1, MonthYear = "08 - 2012",
            //        ClientID = 1, ProjectID = 1, Billable = true
            //    },
            //    new ExpenseReports{
            //        EmployeesID = 2, TitleID = 2, MonthYear = "09 - 2012",
            //        ClientID = 2, ProjectID = 2, Billable = true
            //    },
            //    new ExpenseReports{
            //        EmployeesID = 3, TitleID = 3, MonthYear = "10 - 2012",
            //        ClientID = 3, ProjectID = 3, Billable = false
            //    },
            //    new ExpenseReports{
            //        EmployeesID = 4, TitleID = 4, MonthYear = "07 - 2012",
            //        ClientID = 4, ProjectID = 4, Billable = false
            //    },
            //    new ExpenseReports{
            //        EmployeesID = 5, TitleID = 5, MonthYear = "07 - 2012",
            //        ClientID = 5, ProjectID = 5, Billable = true
            //    },
            //};
            //expenseReport.ForEach(s => context.ExpenseReports.Add(s));
            //context.SaveChanges();

            var entries = new List<Entries> { 
                new Entries{
                    EmployeesID = 1, ExpenseID = 1, DateIncurred = DateTime.Parse("08-01-2012"),
                    Guests = "Malcolm Frye", NumPeople = 2, Affiliation = "Ariel", 
                    Vendor = "Pu Pu Hot Pot", ProjectsID = 1, BusinessReasonsID = 1, ExpenseCategoriesID = 1, 
                    Amount = 44, Miles = 0, Mileage = 0, Billable = true, Total = 0.00M
                },
                new Entries{
                    EmployeesID = 2, ExpenseID = 2, DateIncurred = DateTime.Parse("08-02-2012"),
                    Guests = "Louis Smith", NumPeople = 1, Affiliation = "Beaumonde", 
                    Vendor = "Amy’s Winehouse", ProjectsID = 2, BusinessReasonsID = 2, ExpenseCategoriesID = 2, 
                    Amount = 33, Miles = 0, Mileage = 0, Billable = true, Total = 0.00M
                },
                new Entries{
                    EmployeesID = 3, ExpenseID = 3, DateIncurred = DateTime.Parse("08-01-2012"),
                    Guests = "Zoe Book", NumPeople = 2, Affiliation = "Bellerophon", 
                    Vendor = "EN Thai Sing Airways", ProjectsID = 3, BusinessReasonsID = 3, ExpenseCategoriesID = 3, 
                    Amount = 19, Miles = 45, Mileage = 12, Billable = true, Total = 0.00M
                },
                new Entries{
                    EmployeesID = 4, ExpenseID = 2, DateIncurred = DateTime.Parse("09-01-2012"),
                    Guests = "Inara Tam", NumPeople = 3, Affiliation = "Haven", 
                    Vendor = "Misohapi", ProjectsID = 4, BusinessReasonsID = 1, ExpenseCategoriesID = 1, 
                    Amount = 150, Miles = 65, Mileage = 30, Billable = false, Total = 0.00M
                },
                new Entries{
                    EmployeesID = 1, ExpenseID = 2, DateIncurred = DateTime.Parse("09-01-2012"),
                    Guests = "Kaylee Reynolds", NumPeople = 1, Affiliation = "Hera", 
                    Vendor = "L’Idiot", ProjectsID = 5, BusinessReasonsID = 2, ExpenseCategoriesID = 2, 
                    Amount = 100, Miles = 55, Mileage = 25, Billable = false, Total = 0.00M
                },
            };
            entries.ForEach(s => context.Entries.Add(s));
            context.SaveChanges();

        }
    }
}