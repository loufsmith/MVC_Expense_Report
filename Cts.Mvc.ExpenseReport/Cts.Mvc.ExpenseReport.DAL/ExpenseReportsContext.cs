using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Cts.Mvc.ExpenseReport.Domain;

namespace Cts.Mvc.ExpenseReport.DAL
{
    public class ExpenseReportContext : DbContext
    {
        public DbSet<Employees> Employees { get; set; }
        public DbSet<BusinessReasons> BusinessReasons { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Entries> Entries { get; set; }
        public DbSet<ExpenseCategories> ExpenseCategories { get; set; }
        public DbSet<ExpenseReports> ExpenseReports { get; set; }
        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Titles> Titles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}