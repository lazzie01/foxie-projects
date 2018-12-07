using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class History
    {
        public long Id { get; set; }

        public DateTime Date { get; set; }

        public double PolicyFee { get; set; }

        public double Premium { get; set; }

        public double Insured { get; set; }

        public bool PremiumPayer { get; set; }

        [ForeignKey("Member")]
        public long MemberId { get; set; }
        public virtual Member Member { get; set; }
    }
}
