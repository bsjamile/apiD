using System.Collections.Generic;
using System.Threading.Tasks;
using WoMakersCode.ToDoList.Core.Entities;
using WoMakersCode.ToDoList.Core.Filters;

namespace WoMakersCode.ToDoList.Core.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> ListById(int id);
        Task Insert(T obj);
        Task Update(T obj);       
        Task Delete(T obj);
    }
}
