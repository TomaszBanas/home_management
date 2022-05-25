using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SmartHome.Models.Dto;
using SmartHome.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityType = SmartHome.Database.Models.EntityType;

namespace SmartHome.BL.Mappers
{
    public class ModelTypeToDtoMapper : IMapper<EntityType, ModelType>
    {
        public ModelType Map(EntityType model)
        {
            return new ModelType
            {
                Id = model.Id,
                Code = model.Key,
                Name = model.Name,
            };
        }
    }
}
