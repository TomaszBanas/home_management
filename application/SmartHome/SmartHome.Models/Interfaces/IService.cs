using SmartHome.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Models.Interfaces
{
    public interface IService<T> where T : class
    {
        PaggingResponse<T> GetAll();
        T Get(Guid Id);
        T Add(T data);
        T Update(T data);
        void Delete(Guid Id);
    }
}
