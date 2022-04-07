using SmartHome.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Database.Repositories
{
    public class CacheRepository : BaseRepository<Cache>
    {
        public CacheRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
