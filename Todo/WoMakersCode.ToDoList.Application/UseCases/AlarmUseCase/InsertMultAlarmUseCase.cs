using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoMakersCode.ToDoList.Application.Models.Alarm.InsertAlarm;
using WoMakersCode.ToDoList.Core.Entities;
using WoMakersCode.ToDoList.Core.Repositories;

namespace WoMakersCode.ToDoList.Application.UseCases.AlarmUseCase
{
    public class InsertMultAlarmUseCase : IUseCaseAsync<List<InsertAlarmRequest>, List<InsertAlarmResponse>>
    {
        private readonly IAlarmRepository _alarmRepository;
        private readonly IMapper _mapper;

        public InsertMultAlarmUseCase(IAlarmRepository alarmRepository, IMapper mapper)
        {
            _alarmRepository = alarmRepository;
            _mapper = mapper;
        }
        public async Task<List<InsertAlarmResponse>> ExecuteAsync(List<InsertAlarmRequest> request)
        {
            if (request == null)
                return null;

            var alarm = _mapper.Map<List<Alarm>>(request);

            await _alarmRepository.InsertM(alarm);
            return new List<InsertAlarmResponse>();
        }

    }
}
