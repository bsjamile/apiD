using AutoMapper;
using System.Threading.Tasks;
using WoMakersCode.ToDoList.Application.Models.TaskList.GetTaskList;
using WoMakersCode.ToDoList.Core.Filters;
using WoMakersCode.ToDoList.Core.Repositories;

namespace WoMakersCode.ToDoList.Application.UseCases.TaskListUseCase
{
    public class GetTaskListIdUseCase : IUseCaseAsync<GetFilter, GetTaskListIdResponse>
    {
        private readonly ITaskListRepository _taskListRepository;
        private readonly IMapper _mapper;
        public GetTaskListIdUseCase(ITaskListRepository taskListRepository, IMapper mapper)
        {
            _taskListRepository = taskListRepository;
            _mapper = mapper;
        }

        public Task<GetTaskListIdResponse> ExecuteAsync(GetFilter request)
        {
            var resposta = _taskListRepository.GetF(request).Result;

            var response = (GetTaskListIdResponse)null;

            if (resposta != null)
            {
                response = _mapper.Map<GetTaskListIdResponse>(resposta);
            }

            return Task.FromResult(response);
        }
    }
}
