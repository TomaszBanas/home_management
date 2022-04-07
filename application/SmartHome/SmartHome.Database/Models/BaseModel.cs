using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Database.Models
{
    public class BaseModel
    {
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        public void SetCreated(string user)
        {
            CreatedOn = DateTime.Now;
            CreatedBy = user;
            SetUpdated(user);
        }

        public void SetUpdated(string user)
        {
            UpdatedOn = DateTime.Now;
            UpdatedBy = user;
        }
    }
}
