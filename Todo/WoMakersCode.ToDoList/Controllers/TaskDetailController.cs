using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WoMakersCode.ToDoList.Application.Models.TaskDetail.DeleteTaskDetail;
using WoMakersCode.ToDoList.Application.Models.TaskDetail.GetTaskDetail;
using WoMakersCode.ToDoList.Application.Models.TaskDetail.InsertTaskDetail;
using WoMakersCode.ToDoList.Application.Models.TaskDetail.UpdateTaskDetail;
using WoMakersCode.ToDoList.Application.UseCases;

namespace WoMakersCode.ToDoList.API.Controllers
{
    [ApiController]
    [Route("api/tasksDetails")]
    public class TasksDetailsController : ControllerBase
    {
        private readonly IUseCaseAsync<GetAllTaskDetailRequest, List<GetAllTaskDetailResponse>> _getAllUseCase;
        private readonly IUseCaseAsync<InsertTaskDetailRequest, InsertTaskDetailResponse> _postUseCase;
        private readonly IUseCaseAsync<UpdateTaskDetailRequest, UpdateTaskDetailResponse> _putUseCase;
        private readonly IUseCaseAsync<DeleteTaskDetailRequest, DeleteTaskDetailResponse> _deleteUseCase;


        public TasksDetailsController(IUseCaseAsync<GetAllTaskDetailRequest, List<GetAllTaskDetailResponse>> getAllUseCase,
            IUseCaseAsync<InsertTaskDetailRequest, InsertTaskDetailResponse> postUseCase,
            IUseCaseAsync<UpdateTaskDetailRequest, UpdateTaskDetailResponse> putUseCase,
            IUseCaseAsync<DeleteTaskDetailRequest, DeleteTaskDetailResponse> deleteUseCase)
        {
            _postUseCase = postUseCase;
            _getAllUseCase = getAllUseCase;
            _putUseCase = putUseCase;
            _deleteUseCase = deleteUseCase;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetAllTaskDetailResponse>>> Get([FromQuery] GetAllTaskDetailRequest request)
        {
            return await _getAllUseCase.ExecuteAsync(request);
        }

        [HttpPost]
        public async Task<ActionResult<InsertTaskDetailResponse>> Post([FromBody] InsertTaskDetailRequest request)
        {
            var resp = await _postUseCase.ExecuteAsync(request);
            return Ok(resp);
        }
        [HttpPut]
        public async Task<ActionResult<UpdateTaskDetailResponse>> Put([FromBody] UpdateTaskDetailRequest request)
        {
            await _putUseCase.ExecuteAsync(request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteTaskDetailResponse>> Delete([FromRoute] int id)
        {
            var delete = await _deleteUseCase.ExecuteAsync(new DeleteTaskDetailRequest() { Id = id });

            if (delete == null)
                return new NotFoundObjectResult("Não encontrado");

            return NoContent();
        }
    }
}
