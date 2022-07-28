using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoMakersCode.ToDoList.Application.Models.TaskList.UpdateTaskList;
using WoMakersCode.ToDoList.Core.Entities;
using WoMakersCode.ToDoList.Core.Repositories;

namespace WoMakersCode.ToDoList.Application.UseCases.TaskListUseCase
{
    public class UpdateTaskListUseCase : IUseCaseAsync<UpdateTaskListRequest, UpdateTaskListResponse>
    {
        public readonly ITaskListRepository _repository;
        public readonly IMapper _mapper;
        public UpdateTaskListUseCase(ITaskListRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdateTaskListResponse> ExecuteAsync(UpdateTaskListRequest request)
        {
            if (request == null)
                return null;

            var resp = _mapper.Map<TaskList>(request);

            await _repository.Update(resp);

            return new UpdateTaskListResponse();
        }
    }
}