using Microsoft.AspNetCore.Mvc;
using SmartHome.Models.Dto;
using SmartHome.Models.Interfaces;

namespace SmartHome.Controllers.GenericEndpoints
{
    public class GetAllEndoint<T> : IEndpoint where T : class
    {
        public void Provide(IEndpointRouteBuilder app, string route, string name)
        {
            app.MapGet(Path.Combine(route), Handle).WithDisplayName(name).WithTags(name);
        }
        public PaggingResponse<T> Handle([FromServices] IService<T> service)
        {
            return service.GetAll();
        }
    }
}
