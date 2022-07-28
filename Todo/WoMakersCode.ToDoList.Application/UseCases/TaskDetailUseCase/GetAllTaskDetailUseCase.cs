using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WoMakersCode.ToDoList.Application.Models.TaskDetail.GetTaskDetail;
using WoMakersCode.ToDoList.Core.Repositories;

namespace WoMakersCode.ToDoList.Application.UseCases.TaskDetailUseCase
{
    public class GetAllTaskDetailUseCase : IUseCaseAsync<GetAllTaskDetailRequest, List<GetAllTaskDetailResponse>>
    {
        public readonly ITaskDetailRepository _repository;
        public readonly IMapper _mapper;
        public GetAllTaskDetailUseCase(ITaskDetailRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<GetAllTaskDetailResponse>> ExecuteAsync(GetAllTaskDetailRequest request)
        {
            var resp = await _repository.GetAll();
            var response = _mapper.Map<List<GetAllTaskDetailResponse>>(resp);

            return response;
        }
    }
}
