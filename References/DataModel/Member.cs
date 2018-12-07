using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Member
    {
        public Member()
        {
            History = new HashSet<History>();
        }

        public long Id { get; set; }

        public string Name { get; set; }

        [Column(TypeName ="Date")]
        public DateTime DateOfBirth { get; set; }

        
        public long? PayerId { get; set; }
        public virtual PremiumPayer PremiumPayer { get; set; }

        public virtual ICollection<History> History { get; set; }
    }
}
