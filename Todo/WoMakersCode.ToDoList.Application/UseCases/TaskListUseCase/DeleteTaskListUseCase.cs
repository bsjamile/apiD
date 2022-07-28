using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoMakersCode.ToDoList.Application.Models.TaskList.DeleteTaskList;
using WoMakersCode.ToDoList.Core.Repositories;

namespace WoMakersCode.ToDoList.Application.UseCases.TaskListUseCase
{
    public class DeleteTaskListUseCase : IUseCaseAsync<DeleteTaskListRequest, DeleteTaskListResponse>
    {
        public readonly ITaskListRepository _repository;
        public DeleteTaskListUseCase(ITaskListRepository repository)
        {
            _repository = repository;
        }
        public async Task<DeleteTaskListResponse> ExecuteAsync(DeleteTaskListRequest request)
        {
            var delete = await _repository.ListById(request.Id);
            await _repository.Delete(delete);
            return new DeleteTaskListResponse();
        }
    }
}
