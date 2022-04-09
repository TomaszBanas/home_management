using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Database.Models
{
    public sealed class EntityTypes
    {
        [Description("House")]
        public readonly Guid House = new Guid("HOUSE000-5316-4ADB-8D73-765E42559168");

        [Description("Room")]
        public readonly Guid Room = new Guid("ROOMBAAB-E9A4-4416-8BC3-39B7E13AEB72");
    }
}
