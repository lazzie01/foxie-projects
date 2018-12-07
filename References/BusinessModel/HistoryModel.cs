using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
    public class HistoryModel:Base
    {
        public HistoryModel() : base()
        {

        }

        public HistoryModel(Base b) : base(b)
        {

        }

        public void Create(History h)
        {
            DB.Histories.Add(h);
            DB.SaveChanges();
        }

        public List<History> List(long id)
        {
            return DB.Histories.Where(h=>h.MemberId==id).ToList();
        }

        public void Update(History h)
        {
            History h1 = DB.Histories.Find(h.Id);
            if (h1 != null)
            {
                h1.MemberId = h.MemberId;
                h1.Insured = h.Insured;
                h1.PolicyFee = h.PolicyFee;
                h1.Premium = h.Premium;
                DB.SaveChanges();
            }
        }

        public void Delete(long id)
        {
            History h = DB.Histories.Find(id);
            if (h != null)
            {
                DB.Histories.Remove(h);
                DB.SaveChanges();
            }
        }
    }
}
