using Microsoft.AspNetCore.Http;
using SmartHome.Models.Dto;
using SmartHome.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SmartHome.BL.Mappers
{
    public class DecorationModelMapper : IMapper<HttpContext, DecorationModel>
    {
        public DecorationModel Map(HttpContext model)
        {
            var queryString = HttpUtility.ParseQueryString(model.Request.QueryString.ToString());

            return new DecorationModel
            {
                Parameters = queryString.AllKeys.ToDictionary(x => x, x => queryString[x])
            };
        }
    }
}
