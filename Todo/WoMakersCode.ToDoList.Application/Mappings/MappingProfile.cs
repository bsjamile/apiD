using AutoMapper;
using System.Collections.Generic;
using WoMakersCode.ToDoList.Application.Models.Alarm.GetAlarm;
using WoMakersCode.ToDoList.Application.Models.Alarm.InsertAlarm;
using WoMakersCode.ToDoList.Application.Models.Alarm.UpdateAlarm;
using WoMakersCode.ToDoList.Application.Models.TaskDetail.GetTaskDetail;
using WoMakersCode.ToDoList.Application.Models.TaskDetail.InsertTaskDetail;
using WoMakersCode.ToDoList.Application.Models.TaskDetail.UpdateTaskDetail;
using WoMakersCode.ToDoList.Application.Models.TaskList.GetTaskList;
using WoMakersCode.ToDoList.Application.Models.TaskList.InsertTaskList;
using WoMakersCode.ToDoList.Application.Models.TaskList.UpdateTaskList;
using WoMakersCode.ToDoList.Core.Entities;

namespace WoMakersCode.ToDoList.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskList, GetTaskListIdResponse>()
                .ForMember(dest => dest.ListName, fonte => fonte.MapFrom(src => src.ListName))
                .ForMember(dest => dest.Id, fonte => fonte.MapFrom(src => src.Id))
                .ForMember(dest => dest.Tasks, fonte => fonte.MapFrom(src => src.Details));

            CreateMap<TaskList, GetAllTaskListResponse>()
                .ForMember(dest => dest.ListName, fonte => fonte.MapFrom(src => src.ListName))
                .ForMember(dest => dest.Id, fonte => fonte.MapFrom(src => src.Id));

            CreateMap<InsertTaskListRequest, TaskList>()
                .ForMember(dest => dest.ListName, fonte => fonte.MapFrom(src => src.ListName));

            CreateMap<UpdateTaskListRequest, TaskList>()
                .ForMember(dest => dest.ListName, fonte => fonte.MapFrom(src => src.ListName))
                .ForMember(dest => dest.Id, fonte => fonte.MapFrom(src => src.Id));

            CreateMap<TaskDetail, GetAllTaskDetailResponse>()
                .ForMember(dest => dest.Id, fonte => fonte.MapFrom(src => src.Id))
                .ForMember(dest => dest.Executado, fonte => fonte.MapFrom(src => src.Executado))
                .ForMember(dest => dest.DataHora, fonte => fonte.MapFrom(src => src.DataHora))
                .ForMember(dest => dest.Descricao, fonte => fonte.MapFrom(src => src.Descricao))
                .ForMember(dest => dest.IdTaskList, fonte => fonte.MapFrom(src => src.IdTaskList))
                .ForMember(dest => dest.Alarms, fonte => fonte.MapFrom(src => src.Alarms));

            CreateMap<InsertTaskDetailRequest, TaskDetail>()
                .ForMember(dest => dest.IdTaskList, fonte => fonte.MapFrom(src => src.IdTaskList))
                .ForMember(dest => dest.Executado, fonte => fonte.MapFrom(src => src.Executado))
                .ForMember(dest => dest.DataHora, fonte => fonte.MapFrom(src => src.DataHora))
                .ForMember(dest => dest.Descricao, fonte => fonte.MapFrom(src => src.Descricao));

            CreateMap<UpdateTaskDetailRequest, TaskDetail>()
                .ForMember(dest => dest.DataHora, fonte => fonte.MapFrom(src => src.DataHora))
                .ForMember(dest => dest.Executado, fonte => fonte.MapFrom(src => src.Executado))
                .ForMember(dest => dest.Id, fonte => fonte.MapFrom(src => src.Id))
                .ForMember(dest => dest.Descricao, fonte => fonte.MapFrom(src => src.Descricao))
                .ForMember(dest => dest.IdTaskList, fonte => fonte.MapFrom(src => src.IdTaskList));

            CreateMap<Alarm, GetAllAlarmResponse>()
                .ForMember(dest => dest.DataHora, fonte => fonte.MapFrom(src => src.DataHora))
                .ForMember(dest => dest.Id, fonte => fonte.MapFrom(src => src.Id))
                .ForMember(dest => dest.IdTaskDetail, fonte => fonte.MapFrom(src => src.IdTaskDetail));


            CreateMap<InsertAlarmRequest, Alarm>()
                .ForMember(dest => dest.DataHora, fonte => fonte.MapFrom(src => src.DataHora))
                .ForMember(dest => dest.IdTaskDetail, fonte => fonte.MapFrom(src => src.IdTaskDetail));

            CreateMap<UpdateAlarmRequest, Alarm>()
            .ForMember(dest => dest.DataHora, fonte => fonte.MapFrom(src => src.DataHora))
            .ForMember(dest => dest.Id, fonte => fonte.MapFrom(src => src.Id))
            .ForMember(dest => dest.IdTaskDetail, fonte => fonte.MapFrom(src => src.IdTaskDetail));

            CreateMap<TaskDetail, GetTaskDetailInfos>()
                .ForMember(dest => dest.DataHora, fonte => fonte.MapFrom(src => src.DataHora))
                .ForMember(dest => dest.Executado, fonte => fonte.MapFrom(src => src.Executado))
                .ForMember(dest => dest.Id, fonte => fonte.MapFrom(src => src.Id))
                .ForMember(dest => dest.Descricao, fonte => fonte.MapFrom(src => src.Descricao));

            CreateMap<Alarm, GetAlarmInfos>()
            .ForMember(dest => dest.DataHora, fonte => fonte.MapFrom(src => src.DataHora))
            .ForMember(dest => dest.Id, fonte => fonte.MapFrom(src => src.Id));
        }
    }
}
