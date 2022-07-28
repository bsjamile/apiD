using AutoMapper;
using System.Threading.Tasks;
using WoMakersCode.ToDoList.Application.Models.TaskDetail.UpdateTaskDetail;
using WoMakersCode.ToDoList.Core.Entities;
using WoMakersCode.ToDoList.Core.Repositories;

namespace WoMakersCode.ToDoList.Application.UseCases.TaskDetailUseCase
{
    public class UpdateTaskDetailUseCase : IUseCaseAsync<UpdateTaskDetailRequest, UpdateTaskDetailResponse>
    {
        public readonly ITaskDetailRepository _repository;
        public readonly IMapper _mapper;
        public UpdateTaskDetailUseCase(ITaskDetailRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdateTaskDetailResponse> ExecuteAsync(UpdateTaskDetailRequest request)
        {
            if (request == null)
                return null;

            var resp = _mapper.Map<TaskDetail>(request);

            await _repository.Update(resp);

            return new UpdateTaskDetailResponse();
        }
    }
}
