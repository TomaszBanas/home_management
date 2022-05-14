using SmartHome.Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Database.Common
{
    public sealed class EntityTypes
    {
        public static readonly Guid House = new Guid("CA1208D3-A5E0-4426-97E7-C073DBCAF472");

        public static readonly Guid Room = new Guid("5D32BEE4-2BD9-40D5-8662-DDD1DC328050");

        
        public static List<EnumModel> ToModels()
        {
            var list = new List<EnumModel>();
            var house = new EnumModel()
            {
                Id = House,
                Name = "House",
                CreatedOn = DateTime.Now,
                CreatedBy = "System",
                UpdatedOn = DateTime.Now,
                UpdatedBy = "System"
            };
            var room = new EnumModel()
            {
                Id = Room,
                Name = "Room",
                CreatedOn = DateTime.Now,
                CreatedBy = "System",
                UpdatedOn = DateTime.Now,
                UpdatedBy = "System"
            };
            list.Add(house);
            list.Add(room);
            return list;
        }
    }
}
