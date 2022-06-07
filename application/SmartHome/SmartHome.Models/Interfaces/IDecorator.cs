using SmartHome.Abstraction.Interfaces;
using SmartHome.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Models.Interfaces
{
    public interface IDecorator
    {
        public bool HandleInCount { get; }
        public IEnumerable<T> Decorate<T>(IEnumerable<T> list, DecorationModel model) where T : class, IDatabaseModel;
        public bool CanDecorate(DecorationModel model, Type type);
    }
}
