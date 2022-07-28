using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoMakersCode.ToDoList.Application.Models.Alarm.UpdateAlarm;
using WoMakersCode.ToDoList.Core.Entities;
using WoMakersCode.ToDoList.Core.Repositories;

namespace WoMakersCode.ToDoList.Application.UseCases.AlarmUseCase
{
    public class UpdateAlarmUseCase : IUseCaseAsync<UpdateAlarmRequest, UpdateAlarmResponse>
    {
        private readonly IAlarmRepository _repository;
        public readonly IMapper _mapper;
        public UpdateAlarmUseCase(IAlarmRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<UpdateAlarmResponse> ExecuteAsync(UpdateAlarmRequest request)
        {
            if (request == null)
                return null;

            var resp = _mapper.Map<Alarm>(request);

            await _repository.Update(resp);

            return new UpdateAlarmResponse();

        }
    }
}
