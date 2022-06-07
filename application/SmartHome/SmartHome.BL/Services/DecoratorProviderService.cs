using Microsoft.Extensions.DependencyInjection;
using SmartHome.Abstraction.Interfaces;
using SmartHome.Models.Dto;
using SmartHome.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.BL.Services
{
    public class DecoratorProviderService
    {
        private readonly IServiceProvider _serviceProvider;

        public DecoratorProviderService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IEnumerable<IDecorator> GetAll<T>(DecorationModel model) where T : class, IDatabaseModel
        {
            var decorators = _serviceProvider.GetServices<IDecorator>();

            decorators = decorators.Where(decorator => decorator.CanDecorate(model, typeof(T))).ToList();

            return decorators;
        }
    }
}
