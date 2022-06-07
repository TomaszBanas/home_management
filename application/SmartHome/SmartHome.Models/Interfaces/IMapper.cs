using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Models.Interfaces
{
    public interface IMapper<T1, T2>
    {
        public T2 Map(T1 model);
    }
}
