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
    public class ModelTypeFromDtoMapper : IMapper<ModelType, EntityType>
    {
        public EntityType Map(ModelType model)
        {
            return new EntityType
            {
                Id = model.Id,
                Key = model.Code,
                Name = model.Name,
            };
        }
    }
}
