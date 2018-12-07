using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
    public class OwnPremiumPayerModel:Base
    {
        public OwnPremiumPayerModel() : base()
        {

        }

        public OwnPremiumPayerModel(Base b) : base(b)
        {

        }

        public double GetPremium(double years, double sumInsured)
        {
            var ownPremiumPayers = DB.OwnPremiumPayers.FirstOrDefault(x => x.SumInsured == sumInsured);
            double premium = -1;
            if (years >= 18 && years <= 25)
            {
                premium = ownPremiumPayers.Age1;
            }
            else if (years >= 26 && years <= 40)
            {
                premium = ownPremiumPayers.Age2;
            }
            else if (years >= 41 && years <= 45)
            {
                premium = ownPremiumPayers.Age3;
            }
            else if (years >= 46 && years <= 50)
            {
                premium = ownPremiumPayers.Age4;
            }
            else if (years >= 51 && years <= 55)
            {
                premium = ownPremiumPayers.Age5;
            }
            else if (years >= 56 && years <= 60)
            {
                premium = ownPremiumPayers.Age6;
            }
            else if (years >= 61 && years <= 65)
            {
                premium = ownPremiumPayers.Age7;
            }
            return premium;


        }
    }
}
