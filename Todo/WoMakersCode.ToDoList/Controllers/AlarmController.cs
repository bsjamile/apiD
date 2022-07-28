using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WoMakersCode.ToDoList.Application.Models.Alarm.GetAlarm;
using WoMakersCode.ToDoList.Application.Models.Alarm.InsertAlarm;
using WoMakersCode.ToDoList.Application.Models.Alarm.UpdateAlarm;
using WoMakersCode.ToDoList.Application.Models.DeleteAlarm;
using WoMakersCode.ToDoList.Application.UseCases;

namespace WoMakersCode.ToDoList.API.Controllers
{
    [ApiController]
    [Route("api/alarms")]
    public class AlarmController : ControllerBase
    {
        private readonly IUseCaseAsync<GetAllAlarmRequest, List<GetAllAlarmResponse>> _getAllUseCase;
        private readonly IUseCaseAsync<InsertAlarmRequest, InsertAlarmResponse> _postUseCase;
        private readonly IUseCaseAsync<UpdateAlarmRequest, UpdateAlarmResponse> _putUseCase;
        private readonly IUseCaseAsync<DeleteAlarmRequest, DeleteAlarmResponse> _deleteUseCase;
        private readonly IUseCaseAsync<List<InsertAlarmRequest>, List<InsertAlarmResponse>> _postMultUseCase;


        public AlarmController(IUseCaseAsync<GetAllAlarmRequest, List<GetAllAlarmResponse>> getAllUseCase,
            IUseCaseAsync<InsertAlarmRequest, InsertAlarmResponse> postUseCase,
            IUseCaseAsync<UpdateAlarmRequest, UpdateAlarmResponse> putUseCase,
            IUseCaseAsync<DeleteAlarmRequest, DeleteAlarmResponse> deleteUseCase,
            IUseCaseAsync<List<InsertAlarmRequest>, List<InsertAlarmResponse>> postMultUseCase)
        {
            _postMultUseCase = postMultUseCase;
            _postUseCase = postUseCase;
            _getAllUseCase = getAllUseCase;
            _putUseCase = putUseCase;
            _deleteUseCase = deleteUseCase;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetAllAlarmResponse>>> Get([FromQuery] GetAllAlarmRequest request)
        {
            return await _getAllUseCase.ExecuteAsync(request);
        }
        /*
        [HttpPost]
        public async Task<ActionResult<InsertAlarmResponse>> Post([FromBody] InsertAlarmRequest request)
        {
            var resp = await _postUseCase.ExecuteAsync(request);
            return Ok(resp);
        }*/

        [HttpPost]
        public async Task<ActionResult<List<InsertAlarmResponse>>> PostMultiplus([FromBody] List<InsertAlarmRequest> request)
        {
            var resp = await _postMultUseCase.ExecuteAsync(request);
            return Ok(resp);
        }

        [HttpPut]
        public async Task<ActionResult<UpdateAlarmResponse>> Put([FromBody] UpdateAlarmRequest request)
        {
            await _putUseCase.ExecuteAsync(request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteAlarmResponse>> Delete([FromRoute] int id)
        {
            var delete = await _deleteUseCase.ExecuteAsync(new DeleteAlarmRequest() { Id = id });

            if (delete == null)
                return new NotFoundObjectResult("Não encontrado");

            return NoContent();
        }

    }
}


