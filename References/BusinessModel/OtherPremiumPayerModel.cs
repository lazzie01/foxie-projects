using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
    public class OtherPremiumPayerModel:Base
    {
        public OtherPremiumPayerModel() : base()
        {

        }

        public OtherPremiumPayerModel(Base b) : base(b)
        {

        }

        public double GetPremium(double years, double sumInsured)
        {
            var otherPremiumPayers = DB.OtherPremiumPayers.FirstOrDefault(x => x.SumInsured == sumInsured);
            double premium = -1;
            if (years >= 18 && years <= 25)
            {
                premium = otherPremiumPayers.Age1;
            }
            else if (years >= 26 && years <= 40)
            {
                premium = otherPremiumPayers.Age2;
            }
            else if (years >= 41 && years <= 45)
            {
                premium = otherPremiumPayers.Age3;
            }
            else if (years >= 46 && years <= 50)
            {
                premium = otherPremiumPayers.Age4;
            }
            else if (years >= 51 && years <= 55)
            {
                premium = otherPremiumPayers.Age5;
            }
            else if (years >= 56 && years <= 60)
            {
                premium = otherPremiumPayers.Age6;
            }
            else if (years >= 61 && years <= 65)
            {
                premium = otherPremiumPayers.Age7;
            }
            return premium;


        }
    }
}
