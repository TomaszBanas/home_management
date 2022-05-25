using SmartHome.Abstraction.Interfaces;
using SmartHome.Models.Dto;
using SmartHome.Models.Interfaces;
using SmartHome.Utility.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.BL.Decorators
{
    public class FilterDecorator : IDecorator
    {
        public bool HandleInCount => true;

        private readonly string Key = "Id";

        public bool CanDecorate(DecorationModel model, Type type)
        {
            if (!type.GetInterfaces().Any(i => i == typeof(IDatabaseModel)))
                return false;

            if (model.Parameters.Get(Key) == null || !Guid.TryParse(model.Parameters.Get(Key), out _))
                return false;

            return true;
        }

        public IEnumerable<T> Decorate<T>(IEnumerable<T> list, DecorationModel model) where T : class, IDatabaseModel
        {
            Guid.TryParse(model.Parameters.Get(Key), out var id);
            return list.Where(x => x.Id == id);
        }
    }
}
