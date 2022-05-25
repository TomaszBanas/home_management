using SmartHome.Abstraction.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Models.Interfaces
{
    public interface IRepository<T> where T : class, IDatabaseModel
    {
        IEnumerable<T> GetEnumerable();
        T Get(Guid Id);
        T Add(T data);
        T Update(T data);
        void Delete(Guid Id);
    }
}
