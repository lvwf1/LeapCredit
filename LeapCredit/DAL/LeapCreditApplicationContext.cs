using System.Data.Entity;
using SlarkInc.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SlarkInc.DAL
{
    public class LeapCreditApplicationContext : DbContext
    {
        public LeapCreditApplicationContext()  : base("LeapCreditApplicationContext")
        { 
        }

        public DbSet<LeapCreditApplication> LeapCreditApplications { get;set;}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}