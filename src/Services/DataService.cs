using Microsoft.AspNetCore.Http;
using Syncfusion.core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Syncfusion.core.Services
{
    public interface IDataService<TEntity, TKey> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> Save(TEntity entity);

        Task<bool> Delete(TEntity entity);

        Task<TEntity> Modify(TEntity entity);

        Task<TEntity> GetPostById(TKey id);
    }

    public class EmployeeService : IDataService<Employee, string>
    {
        protected List<Employee> Cache { get; set; }
        
        public EmployeeService()
        {
            Initialize();
        }

        private void Initialize()
        {
            Cache = new List<Employee> { new Employee { Name = "Petr", Title = "Vedoucí" }, new Employee { Name = "Pavel", Title = "Nosič vody" } };
        }

        public Task<bool> Delete(Employee entity)
        {
            Cache.Remove(entity);
            return Task.FromResult(true);
        }

        public Task<IEnumerable<Employee>> GetAll()
        {
            return Task.FromResult(Cache.AsEnumerable());
        }

        public Task<Employee> GetPostById(string id)
        {
            return Task.FromResult(Cache.FirstOrDefault(x=>x.Name == id));
        }

        public Task<Employee> Modify(Employee entity)
        {
            return Task.FromResult(entity);
        }

        public Task<Employee> Save(Employee entity)
        {
            Cache.Add(entity);
            return Task.FromResult(entity);
        }
    }
}
