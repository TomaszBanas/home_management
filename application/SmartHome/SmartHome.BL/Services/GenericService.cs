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
    public class GenericService<T_model, T_database> : IService<T_model>
        where T_database : class, IDatabaseModel
        where T_model : class
    {
        private readonly IRepository<T_database> _repository;
        private readonly IMapper<T_database, T_model> _mapperTo;
        private readonly IMapper<T_model, T_database> _mapperFrom;
        private readonly DecoratorProviderService _decoratorProviderService;
        private readonly ModelResolver<DecorationModel> _modelResolver;

        public GenericService(
            IRepository<T_database> repository,
            IMapper<T_database, T_model> mapperTo,
            IMapper<T_model, T_database> mapperFrom,
            DecoratorProviderService decoratorProviderService,
            ModelResolver<DecorationModel> modelResolver)
        {
            _repository = repository;
            _mapperTo = mapperTo;
            _mapperFrom = mapperFrom;
            _decoratorProviderService = decoratorProviderService;
            _modelResolver = modelResolver;
        }

        public T_model Add(T_model data)
        {
            var model = _repository.Add(_mapperFrom.Map(data));
            return _mapperTo.Map(model);
        }

        public void Delete(Guid Id)
        {
            _repository.Delete(Id);
        }

        public T_model Get(Guid Id)
        {
            var model = _repository.Get(Id);
            return _mapperTo.Map(model);
        }

        public PaggingResponse<T_model> GetAll()
        {
            var decorators = _decoratorProviderService.GetAll<T_database>(_modelResolver.Model);
            var enumerable = _repository.GetEnumerable();
            foreach (var decorator in decorators.Where(d => d.HandleInCount))
            {
                enumerable = decorator.Decorate(enumerable, _modelResolver.Model);
            }
            var count = enumerable.Count();
            foreach (var decorator in decorators.Where(d => !d.HandleInCount))
            {
                enumerable = decorator.Decorate(enumerable, _modelResolver.Model);
            }
            var list = enumerable.Select(x => _mapperTo.Map(x)).ToList();
            return new PaggingResponse<T_model>()
            {
                Metadata = new PaggingMetadata
                {
                    AllItemsCount = count,
                    ItemsCount = list.Count,
                },
                Items = list
            };
        }

        public T_model Update(T_model data)
        {
            var model = _repository.Update(_mapperFrom.Map(data));
            return _mapperTo.Map(model);
        }

    }
}
