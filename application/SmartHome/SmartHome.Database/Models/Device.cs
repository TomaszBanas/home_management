using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;

namespace SmartHome.Database.Models
{
    public class Device : BaseModel
    {  
        public string Name { get; set; }
        public string Ip { get; set; }
        public string InstructionManualLink { get; set; }
        public bool State { get; set; }
    }
}
