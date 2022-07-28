using System.Threading.Tasks;
using WoMakersCode.ToDoList.Core.Entities;
using WoMakersCode.ToDoList.Core.Filters;

namespace WoMakersCode.ToDoList.Core.Repositories
{
    public interface ITaskListRepository : IRepository<TaskList>
    {
        Task<TaskList> GetF(GetFilter filter);
    }
}
