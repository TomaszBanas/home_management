using SmartHome.Abstraction.Interfaces;
using SmartHome.Models.Dto;
using SmartHome.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHome.Utility.Extensions;

namespace SmartHome.BL.Decorators
{
    public class PaggingDecorator : IDecorator
    {
        public bool HandleInCount => false;

        private readonly string KeyPageSize = "PageSize";
        private readonly string KeyPageIndex = "PageIndex";
        private readonly string KeyOrderBy = "OrderBy";
        private readonly string KeyOrderByDesc = "OrderByDescending";

        public bool CanDecorate(DecorationModel model, Type type)
        {
            if (!type.GetInterfaces().Any(i => i == typeof(IDatabaseModel)))
                return false;

            return true;
        }

        public IEnumerable<T> Decorate<T>(IEnumerable<T> list, DecorationModel model) where T : class, IDatabaseModel
        {
            var desc = bool.TryParse(model.Parameters.Get(KeyOrderByDesc), out var d) ? d : false;
            var orderBy = model.Parameters.Get(KeyOrderBy);

            list = HandleOrderBy(list, orderBy, desc);

            var size = int.TryParse(model.Parameters.Get(KeyPageSize), out var s) ? s : 0;
            var index = int.TryParse(model.Parameters.Get(KeyPageIndex), out var i) ? i : 0;

            if (size > 0 && index >= 0)
                list = list.Take(size).Skip(size * index);

            return list;
        }


        public IEnumerable<T> HandleOrderBy<T>(IEnumerable<T> list, string prop, bool desc) where T : class, IDatabaseModel
        {
            if (string.IsNullOrWhiteSpace(prop) || string.Compare(prop, "ID", true) == 0)
                return list.OrderBy(x => x.Id, desc);

            if (string.Compare(prop, "CreatedOn", true) == 0)
                return list.OrderBy(x => x.CreatedOn, desc);

            if (string.Compare(prop, "UpdatedOn", true) == 0)
                return list.OrderBy(x => x.UpdatedOn, desc);

            return list;
        }
    }
}
