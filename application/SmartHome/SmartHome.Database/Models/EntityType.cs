using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Database.Models
{
    public  class EntityType : EnumModel { }

    public enum EntityTypeEnum
    {
        None = 0,
        House = 1,
        Room = 2,
        Device = 3,
    }
}
