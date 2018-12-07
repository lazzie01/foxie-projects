using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class PremiumPayer
    {
       
        
        public long Id { get; set; }

        [Key]
        [ForeignKey("Member")]
        public long MemberId { get; set; }
        public virtual Member Member { get; set; }

    }
}
