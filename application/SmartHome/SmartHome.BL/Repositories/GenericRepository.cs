using SmartHome.Abstraction.Interfaces;
using SmartHome.Database;
using SmartHome.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.BL.Repositories
{
    public class GenericRepository<T> : IRepository<T> 
        where T : class, IDatabaseModel
    {
        private readonly DatabaseContext _databaseContext;

        public GenericRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public T Add(T data)
        {
            data.Id = Guid.NewGuid();
            data.CreatedOn = DateTime.Now;
            data.UpdatedOn = DateTime.Now;
            _databaseContext.Set<T>().Add(data);
            _databaseContext.SaveChanges();
            return data;
        }

        public void Delete(Guid Id)
        {
            var model = _databaseContext.Set<T>().Single(x => x.Id.ToString() == Id.ToString());
            _databaseContext.Set<T>().Remove(model);
            _databaseContext.SaveChanges();
        }

        public T Get(Guid Id)
        {
            return _databaseContext.Set<T>().Single(x => x.Id.ToString() == Id.ToString());
        }

        public List<T> GetAll()
        {
            return _databaseContext.Set<T>().ToList();
        }

        public IEnumerable<T> GetEnumerable()
        {
            return _databaseContext.Set<T>();
        }

        public T Update(T data)
        {
            data.UpdatedOn = DateTime.Now;
            // TODO update 
            //_databaseContext.Set<T>().ToList().RemoveAll(x => x.Id == data.Id);
            //_databaseContext.Set<T>().ToList().Add(data);
            return data;
        }
    }
}
