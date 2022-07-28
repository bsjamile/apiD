using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoMakersCode.ToDoList.Application.Models.DeleteAlarm;
using WoMakersCode.ToDoList.Core.Repositories;

namespace WoMakersCode.ToDoList.Application.UseCases.AlarmUseCase
{
    public class DeleteAlarmUseCase : IUseCaseAsync<DeleteAlarmRequest, DeleteAlarmResponse>
    {
        public readonly IAlarmRepository _repository;
        public DeleteAlarmUseCase(IAlarmRepository repository)
        {
            _repository = repository;
        }
        public async Task<DeleteAlarmResponse> ExecuteAsync(DeleteAlarmRequest request)
        {
            var delete = await _repository.ListById(request.Id);
            await _repository.Delete(delete);
            return new DeleteAlarmResponse();
        }

    }
}
