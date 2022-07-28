using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoMakersCode.ToDoList.Application.Models.Alarm.GetAlarm;
using WoMakersCode.ToDoList.Core.Repositories;

namespace WoMakersCode.ToDoList.Application.UseCases.AlarmUseCase
{
    public class GetAllAlarmUseCase : IUseCaseAsync<GetAllAlarmRequest, List<GetAllAlarmResponse>>
    {
        public readonly IAlarmRepository _repository;
        public readonly IMapper _mapper;
        public GetAllAlarmUseCase(IAlarmRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<GetAllAlarmResponse>> ExecuteAsync(GetAllAlarmRequest request)
        {
            var resp = await _repository.GetAll();
            var response = _mapper.Map<List<GetAllAlarmResponse>>(resp);

            return response;
        }
    
    }
}
