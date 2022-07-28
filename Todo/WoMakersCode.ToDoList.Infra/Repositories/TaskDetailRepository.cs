using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoMakersCode.ToDoList.Core.Entities;
using WoMakersCode.ToDoList.Core.Filters;
using WoMakersCode.ToDoList.Core.Repositories;
using WoMakersCode.ToDoList.Infra.Database;

namespace WoMakersCode.ToDoList.Infra.Repositories
{
    public class TaskDetailRepository : ITaskDetailRepository
    {
        private readonly ApplicationContext _context;
        public TaskDetailRepository(ApplicationContext context)
        {
            _context = context;
        }        

        public async Task<IEnumerable<TaskDetail>> GetAll()
        {
            var result =  _context
                .TaskDetails
                .Include(id => id.Alarms)
                .AsNoTracking()
                .ToListAsync();

            return await result;
        }        

        public async Task Insert(TaskDetail taskDetail)
        {
            _context.Add(taskDetail);
            await _context.SaveChangesAsync();
        }

        public async Task Update(TaskDetail taskDetail)
        {
            _context.Entry(taskDetail).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task Delete(TaskDetail taskDetail)
        {
            _context.Remove(taskDetail);
            await _context.SaveChangesAsync();
        }

        public async Task<TaskDetail> ListById(int id)
        {
            return await Task.FromResult(_context.Find<TaskDetail>(id));
        }
    }
}
