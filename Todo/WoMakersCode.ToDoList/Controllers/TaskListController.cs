using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WoMakersCode.ToDoList.Application.Models.TaskList.DeleteTaskList;
using WoMakersCode.ToDoList.Application.Models.TaskList.GetTaskList;
using WoMakersCode.ToDoList.Application.Models.TaskList.InsertTaskList;
using WoMakersCode.ToDoList.Application.Models.TaskList.UpdateTaskList;
using WoMakersCode.ToDoList.Application.UseCases;
using WoMakersCode.ToDoList.Core.Filters;

namespace WoMakersCode.ToDoList.API.Controllers
{
    [ApiController]
    [Route("api/tasksLists")]
    public class TasksListsController : ControllerBase
    {
        private readonly IUseCaseAsync<GetFilter, GetTaskListIdResponse> _getFUseCase;
        private readonly IUseCaseAsync<GetAllTaskListRequest, List<GetAllTaskListResponse>> _getAllUseCase;
        private readonly IUseCaseAsync<InsertTaskListRequest, InsertTaskListResponse> _postUseCase;
        private readonly IUseCaseAsync<UpdateTaskListRequest, UpdateTaskListResponse> _putUseCase;
        private readonly IUseCaseAsync<DeleteTaskListRequest, DeleteTaskListResponse> _deleteUseCase;


        public TasksListsController(IUseCaseAsync<GetFilter, GetTaskListIdResponse> getFUseCase,
            IUseCaseAsync<GetAllTaskListRequest, List<GetAllTaskListResponse>> getAllUseCase,
            IUseCaseAsync<InsertTaskListRequest, InsertTaskListResponse> postUseCase,
            IUseCaseAsync<UpdateTaskListRequest, UpdateTaskListResponse> putUseCase,
            IUseCaseAsync<DeleteTaskListRequest, DeleteTaskListResponse> deleteUseCase)
        {
            _postUseCase = postUseCase;
            _getFUseCase = getFUseCase;
            _getAllUseCase = getAllUseCase;
            _putUseCase = putUseCase;
            _deleteUseCase = deleteUseCase;
        }

        [HttpGet("id")]
        public async Task<ActionResult<GetTaskListIdResponse>> Get([FromQuery] GetFilter filter)
        {
            var response = await _getFUseCase.ExecuteAsync(filter);
            if (response == null)
                return new NotFoundObjectResult("Não encontrado");

            return new OkObjectResult(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<GetAllTaskListResponse>>> Get([FromQuery] GetAllTaskListRequest request)
        {
            return await _getAllUseCase.ExecuteAsync(request);
        }

        [HttpPost]
        public async Task<ActionResult<InsertTaskListResponse>> Post([FromBody] InsertTaskListRequest request)
        {
            var resp = await _postUseCase.ExecuteAsync(request);

            if (resp != null)                
                return Ok(resp);
            else
                return new BadRequestObjectResult("Lista já existente");
        }
        [HttpPut]
        public async Task<ActionResult<UpdateTaskListResponse>> Put([FromBody] UpdateTaskListRequest request)
        {
            await _putUseCase.ExecuteAsync(request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteTaskListResponse>> Delete([FromRoute] int id)
        {
            var delete = await _deleteUseCase.ExecuteAsync(new DeleteTaskListRequest() { Id = id });

            if (delete == null)
                return new NotFoundObjectResult("Não encontrado");

            return NoContent();
        }
    }
}
