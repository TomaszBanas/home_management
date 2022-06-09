using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Database.Models
{
    public class Schedule : BaseModel
    {
        public Guid DeviceId { get; set; }
        public bool State { get; set; }
        public bool IsRecurring { get; set; }
        public string? ExecutionTime { get; set; } // CRON or DateTime depend on IsRecurring

        [ForeignKey("DeviceId")]
        public Device Device { get; set; }

    }
}
