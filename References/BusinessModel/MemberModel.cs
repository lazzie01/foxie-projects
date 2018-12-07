using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
    public class MemberModel:Base
    {
        public MemberModel():base()
        {

        }

        public MemberModel(Base b) : base(b)
        {

        }

        public void Create(Member m)
        {
            
            DB.Members.Add(m);         
            DB.SaveChanges();
        }

        public long PremiumPayerId(long id)
        {
            long premiumId = -1;
            Member m = DB.Members.Find(id);
            if(m!=null)
            {
                premiumId = m.PayerId.HasValue ? m.PayerId.Value : id;
            }
            return premiumId;
        }

        public Member Read(long id)
        {
            return DB.Members.Find(id);
        }

        public void Update(Member m)
        {
            Member m1 = DB.Members.Find(m.Id);
            if(m1!=null)
            {
                m1.Name = m.Name;
                m1.PremiumPayer = m.PremiumPayer;
            }
            else //defensive programming
            {
                DB.Members.Add(m);
            }
            DB.SaveChanges();
        }

        public void Delete(long id)
        {
            Member m = DB.Members.Find(id);
            if(m!= null)
            {
                DB.Members.Remove(m);
                DB.SaveChanges();
            }
            
        }

        public List<Member> List()
        {
            return DB.Members.ToList();
        }
    }
}
