using SmartHome.Abstraction.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Database.Models
{
    public class BaseModel : IDatabaseModel
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        public void SetCreated(string user)
        {
            Id = Guid.NewGuid();
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
