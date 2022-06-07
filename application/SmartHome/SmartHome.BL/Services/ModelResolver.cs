using Microsoft.AspNetCore.Http;
using SmartHome.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.BL.Services
{
    public class ModelResolver<T>
    {
        public T Model { get; private set; }

        public ModelResolver(IHttpContextAccessor httpContextAccessor, IMapper<HttpContext, T> mapper)
        {
            Model = mapper.Map(httpContextAccessor.HttpContext);
        }
    }
}
