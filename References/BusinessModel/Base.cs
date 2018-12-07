using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
    public abstract class Base:IDisposable
    {
        public DatabaseContext DB { get; }

        public Base()
        {
            DB = new DatabaseContext();
        }

        public Base(Base b)
        {
            DB = b.DB;
        }

        public bool isDisposed = false;
        public void Dispose()
        {
            if(!isDisposed)
            {
                DB.Dispose();
                isDisposed = true;
            }
        }
    }
}
