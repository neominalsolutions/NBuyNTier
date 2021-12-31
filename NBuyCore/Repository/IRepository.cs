using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBuyCore.Repository
{
    public interface IRepository<T> where T:class
    {
        void Save();
    }
}
