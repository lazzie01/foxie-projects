using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
    public class EnumInsuredSumModel:Base
    {
        public EnumInsuredSumModel() : base()
        {

        }

        public EnumInsuredSumModel(Base b) : base(b)
        {

        }

        public double GetInsuredSum(long id)
        {
            EnumInsuredSum eis= DB.EnumInsuredSums.Find(id);
            if(eis!= null)
            {
                return eis.Value;
            }
            return 0;
        }

        public List<EnumInsuredSum> InsuredSumList(bool ownPremiumPayer)
        {
            return DB.EnumInsuredSums.Where(e=>e.OwnPremium == ownPremiumPayer).ToList();
        }

    }
}
