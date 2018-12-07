using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
    public class EnumPolicyFeeModel:Base
    {
        public EnumPolicyFeeModel() : base()
        {

        }

        public EnumPolicyFeeModel(Base b) : base(b)
        {

        }
        public double PolicyFee()
        {
            var policeFee = DB.EnumPolicyFees.FirstOrDefault();
            if(policeFee!=null)
            {
                return policeFee.MonthlyPolicyFee;
            }
            return -1;
        }
    }
}
