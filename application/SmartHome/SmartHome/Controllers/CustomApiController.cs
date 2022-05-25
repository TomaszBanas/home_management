using SmartHome.Controllers.GenericEndpoints;

namespace SmartHome.Controllers
{
    public abstract class CustomApiController
    {
        internal abstract List<IEndpoint> _endpoints { get; }

        public void Handle(IEndpointRouteBuilder app, string route, string name)
        {
            foreach (var endpoint in _endpoints)
            {
                endpoint.Provide(app, route, name);
            }
        }
    }
}
