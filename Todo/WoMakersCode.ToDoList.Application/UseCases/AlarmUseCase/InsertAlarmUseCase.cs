using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WoMakersCode.ToDoList.Application.Models.Alarm.InsertAlarm;
using WoMakersCode.ToDoList.Core.Entities;
using WoMakersCode.ToDoList.Core.Repositories;

namespace WoMakersCode.ToDoList.Application.UseCases.AlarmUseCase
{
    public class InsertAlarmUseCase : IUseCaseAsync<InsertAlarmRequest, InsertAlarmResponse>
    {
        private readonly IAlarmRepository _alarmRepository;
        private readonly IMapper _mapper;

        public InsertAlarmUseCase(IAlarmRepository alarmRepository, IMapper mapper)
        {
            _alarmRepository = alarmRepository;
            _mapper = mapper;
        }

        public async Task<InsertAlarmResponse> ExecuteAsync(InsertAlarmRequest request)
        {
            if (request == null)
                return null;

            var alarm = _mapper.Map<Alarm>(request);

            await _alarmRepository.Insert(alarm);
            return new InsertAlarmResponse();
        }

        
    }
}
