using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WoMakersCode.ToDoList.Core.Entities;
using WoMakersCode.ToDoList.Core.Filters;
using WoMakersCode.ToDoList.Core.Repositories;
using WoMakersCode.ToDoList.Infra.Database;

namespace WoMakersCode.ToDoList.Infra.Repositories
{
    public class AlarmRepository : IAlarmRepository
    {
        private readonly ApplicationContext _context;
        public AlarmRepository(ApplicationContext context)
        {
            _context = context;
        }        

        public async Task<IEnumerable<Alarm>> GetAll()
        {
            return await _context
                .Alarms
                .AsNoTracking()
                .ToListAsync();
        }       

        public async Task Insert(Alarm alarm)
        {
            _context.Add(alarm);
            await _context.SaveChangesAsync();
        }

        public async Task InsertM(List<Alarm> alarm)
        {
            _context.AddRange(alarm);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Alarm alarm)
        {
            _context.Entry(alarm).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task Delete(Alarm alarm)
        {
            _context.Remove(alarm);
            await _context.SaveChangesAsync();
        }

        public async Task<Alarm> ListById(int id)
        {
            return await Task.FromResult(_context.Find<Alarm>(id));
        }
    }
}
