using Microsoft.AspNetCore.Mvc;
using SmartHome.Models.Dto;
using SmartHome.Models.Interfaces;

namespace SmartHome.Controllers.GenericEndpoints
{
    public class GetSingleEndoint<T> : IEndpoint where T : class
    {
        public void Provide(IEndpointRouteBuilder app, string route, string name)
        {
            app.MapGet(route + "/{id}", Handle).WithDisplayName(name).WithTags(name);
        }
        public T Handle(Guid id, [FromServices] IService<T> service)
        {
            return service.Get(id);
        }
    }
}
