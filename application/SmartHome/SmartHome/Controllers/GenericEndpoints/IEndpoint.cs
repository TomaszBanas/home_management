namespace SmartHome.Controllers.GenericEndpoints
{
    public interface IEndpoint
    {
        public void Provide(IEndpointRouteBuilder app, string route, string name);
    }
}
