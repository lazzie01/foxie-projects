using DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
    public class SeedDatabase:CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            EnumPolicyFee policyFee = new EnumPolicyFee()
            {
                Id = 1,
                 MonthlyPolicyFee = 10.00
            };

            List<EnumInsuredSum> enumInsuredSums = new List<EnumInsuredSum>()
            {
                new EnumInsuredSum(){ Value=10000.00, OwnPremium=true },
                new EnumInsuredSum(){ Value=15000.00, OwnPremium=true },
                new EnumInsuredSum(){ Value=18000.00, OwnPremium=true },
                new EnumInsuredSum(){ Value=20000.00, OwnPremium=true },
                new EnumInsuredSum(){ Value=30000.00, OwnPremium=true },
                new EnumInsuredSum(){ Value=5000.00, OwnPremium=false },
                new EnumInsuredSum(){ Value=12000.00, OwnPremium=false },
                new EnumInsuredSum(){ Value=18000.00, OwnPremium=false },
                new EnumInsuredSum(){ Value=22000.00, OwnPremium=false },
                new EnumInsuredSum(){ Value=25000.00, OwnPremium=false }
            };

            List<OwnPremiumPayer> ownPremiumPayers = new List<OwnPremiumPayer>()
            {
                new OwnPremiumPayer()
                {
                     Age1 = 36.00,
                     Age2 = 47.00,
                     Age3 = 52.00,
                     Age4 = 57.00,
                     Age5 = 64.00,
                     Age6 = 74.00,
                     Age7 = 90.00,
                     SumInsured = 10000.00
                },

                new OwnPremiumPayer()
                {
                     Age1 = 49.05,
                     Age2 = 64.95,
                     Age3 = 73.05,
                     Age4 = 79.95,
                     Age5 = 90.00,
                     Age6 = 106.05,
                     Age7 = 130.05,
                     SumInsured = 15000.00
                },

                new OwnPremiumPayer()
                {
                     Age1 = 57.06,
                     Age2 = 75.42,
                     Age3 = 85.32,
                     Age4 = 93.42,
                     Age5 = 105.84,
                     Age6 = 125.46,
                     Age7 = 154.26,
                     SumInsured = 18000.00
                },

                new OwnPremiumPayer()
                {
                     Age1 = 62.00,
                     Age2 = 82.00,
                     Age3 = 93.00,
                     Age4 = 102.00,
                     Age5 = 116.00,
                     Age6 = 138.00,
                     Age7 = 170.00,
                     SumInsured = 20000.00
                },

                new OwnPremiumPayer()
                {
                     Age1 = 93.00,
                     Age2 = 123.00,
                     Age3 = 139.50,
                     Age4 = 153.00,
                     Age5 = 174.00,
                     Age6 = 207.00,
                     Age7 = 255.00,
                     SumInsured = 30000.00
                }
            };

            List<OtherPremiumPayer> otherPremiumPayers = new List<OtherPremiumPayer>()
            {
                new OtherPremiumPayer()
                {
                     Age1 = 30.00,
                     Age2 = 38.00,
                     Age3 = 42.00,
                     Age4 = 46.00,
                     Age5 = 51.00,
                     Age6 = 61.00,
                     Age7 = 74.00,
                     SumInsured = 5000.00
                },

                new OtherPremiumPayer()
                {
                     Age1 = 36.00,
                     Age2 = 48.00,
                     Age3 = 54.00,
                     Age4 = 58.95,
                     Age5 = 67.95,
                     Age6 = 82.05,
                     Age7 = 103.05,
                     SumInsured = 12000.00
                },

                new OtherPremiumPayer()
                {
                     Age1 = 39.96,
                     Age2 = 54.36,
                     Age3 = 61.56,
                     Age4 = 67.68,
                     Age5 = 78.48,
                     Age6 = 95.58,
                     Age7 = 120.24,
                     SumInsured = 18000.00
                },

                new OtherPremiumPayer()
                {
                     Age1 = 42.00,
                     Age2 = 58.00,
                     Age3 = 66.00,
                     Age4 = 73.00,
                     Age5 = 85.00,
                     Age6 = 104.00,
                     Age7 = 131.00,
                     SumInsured = 22000.00
                },

                new OtherPremiumPayer()
                {
                     Age1 = 63.00,
                     Age2 = 87.00,
                     Age3 = 99.00,
                     Age4 = 109.50,
                     Age5 = 127.50,
                     Age6 = 156.00,
                     Age7 = 196.50,
                     SumInsured = 25000.00
                }
            };

            Member member = new Member()
            {
                Id = 1,
                Name = "Lazarus",
                DateOfBirth = new DateTime(1992, 1, 20)
            };

            context.EnumPolicyFees.AddOrUpdate(policyFee);
            context.EnumInsuredSums.AddOrUpdate(enumInsuredSums.ToArray());
            context.OwnPremiumPayers.AddOrUpdate(ownPremiumPayers.ToArray());
            context.OtherPremiumPayers.AddOrUpdate(otherPremiumPayers.ToArray());
            context.Members.AddOrUpdate(member);
            base.Seed(context);
        }
    }
    
}
