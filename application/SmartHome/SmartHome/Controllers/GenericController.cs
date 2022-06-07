using Microsoft.AspNetCore.Mvc;
using SmartHome.BL.Services;
using SmartHome.Controllers.GenericEndpoints;
using SmartHome.Models.Dto;
using SmartHome.Models.Interfaces;

namespace SmartHome.Controllers
{
    public class ReadonlyGenericController<T> : CustomApiController where T : class
    {
        internal override List<IEndpoint> _endpoints => new List<IEndpoint> 
        {
            new GetAllEndoint<T>(),
            new GetSingleEndoint<T>(),
        };
    }
}
