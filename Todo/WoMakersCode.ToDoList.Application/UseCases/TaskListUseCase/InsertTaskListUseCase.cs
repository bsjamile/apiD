using AutoMapper;
using System.Threading.Tasks;
using WoMakersCode.ToDoList.Application.Models.TaskList.InsertTaskList;
using WoMakersCode.ToDoList.Core.Entities;
using WoMakersCode.ToDoList.Core.Repositories;

namespace WoMakersCode.ToDoList.Application.UseCases.TaskListUseCase
{
    public class InsertTaskListUseCase : IUseCaseAsync<InsertTaskListRequest, InsertTaskListResponse>
    {
        private readonly ITaskListRepository _repository;
        private readonly IMapper _mapper;

        public InsertTaskListUseCase(ITaskListRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<InsertTaskListResponse> ExecuteAsync(InsertTaskListRequest request)
        {
            var resp = await _repository.GetF(new Core.Filters.GetFilter {Pesquisa = request.ListName });

            if (resp == null)
            {
                var taskList = _mapper.Map<TaskList>(request);
                await _repository.Insert(taskList);
                return new InsertTaskListResponse();
            }
            else
                return null;
        }
    }
}
