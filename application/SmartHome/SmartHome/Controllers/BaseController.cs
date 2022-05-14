using SmartHome.Database.Models;
using SmartHome.Database.Repositories;

namespace SmartHome.Controllers
{
    public class BaseController<T> where T : BaseModel
    {
        private readonly BaseRepository<T> _repository;

        public BaseController(BaseRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual SetUp
    }
}
