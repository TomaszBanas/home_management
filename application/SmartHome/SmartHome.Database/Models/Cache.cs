using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Database.Models
{
    public class Cache : BaseModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Value { get; set; }
    }
}
