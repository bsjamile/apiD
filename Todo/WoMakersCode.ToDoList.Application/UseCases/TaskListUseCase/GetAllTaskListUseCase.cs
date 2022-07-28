using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WoMakersCode.ToDoList.Application.Models.TaskList.GetTaskList;
using WoMakersCode.ToDoList.Core.Repositories;

namespace WoMakersCode.ToDoList.Application.UseCases.TaskListUseCase
{
    public class GetAllTaskListUseCase : IUseCaseAsync<GetAllTaskListRequest, List<GetAllTaskListResponse>>
    {
        public readonly ITaskListRepository _repository;
        public readonly IMapper _mapper;
        public GetAllTaskListUseCase(ITaskListRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<GetAllTaskListResponse>> ExecuteAsync(GetAllTaskListRequest request)
        {
            var resp = await _repository.GetAll();
            var response = _mapper.Map<List<GetAllTaskListResponse>>(resp);

            return response;
        }
    }
}