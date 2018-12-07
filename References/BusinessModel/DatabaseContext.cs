using DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext()
            :base("DefaultConnection")
        {
            Database.SetInitializer(new SeedDatabase());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>()
                .HasRequired(m => m.PremiumPayer)
                .WithRequiredPrincipal(m => m.Member);
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<EnumPolicyFee> EnumPolicyFees { get; set; }

        public virtual DbSet<EnumInsuredSum> EnumInsuredSums { get; set; }

        public virtual DbSet<History> Histories { get; set; }

        public virtual DbSet<Member> Members { get; set; }

        public virtual DbSet<OtherPremiumPayer> OtherPremiumPayers { get; set; }

        public virtual DbSet<OwnPremiumPayer> OwnPremiumPayers { get; set; }

        public virtual DbSet<PremiumPayer> PremiumPayers { get; set; }
    }
}
