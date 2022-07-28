using System.Threading.Tasks;
using WoMakersCode.ToDoList.Application.Models.TaskDetail.DeleteTaskDetail;
using WoMakersCode.ToDoList.Core.Repositories;

namespace WoMakersCode.ToDoList.Application.UseCases.TaskDetailUseCase
{
    public class DeleteTaskDetailUseCase : IUseCaseAsync<DeleteTaskDetailRequest, DeleteTaskDetailResponse>
    {
        public readonly ITaskDetailRepository _repository;
        public DeleteTaskDetailUseCase(ITaskDetailRepository repository)
        {
            _repository = repository;
        }
        public async Task<DeleteTaskDetailResponse> ExecuteAsync(DeleteTaskDetailRequest request)
        {
            var delete = await _repository.ListById(request.Id);
            await _repository.Delete(delete);
            return new DeleteTaskDetailResponse();
        }
    }
}
