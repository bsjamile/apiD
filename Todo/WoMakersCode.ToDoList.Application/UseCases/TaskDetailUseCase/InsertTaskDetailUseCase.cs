using AutoMapper;
using System.Threading.Tasks;
using WoMakersCode.ToDoList.Application.Models.TaskDetail.InsertTaskDetail;
using WoMakersCode.ToDoList.Core.Entities;
using WoMakersCode.ToDoList.Core.Repositories;

namespace WoMakersCode.ToDoList.Application.UseCases.TaskDetailUseCase
{
    public class InsertTaskDetailUseCase : IUseCaseAsync<InsertTaskDetailRequest, InsertTaskDetailResponse>
    {
        private readonly ITaskDetailRepository _repository;
        private readonly IMapper _mapper;

        public InsertTaskDetailUseCase(ITaskDetailRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<InsertTaskDetailResponse> ExecuteAsync(InsertTaskDetailRequest request)
        {
            if (request == null)
                return null;

            var taskDetails = _mapper.Map<TaskDetail>(request);

            await _repository.Insert(taskDetails);

            return new InsertTaskDetailResponse();
        }
    }
}
