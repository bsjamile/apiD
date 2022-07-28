using System;
using System.Collections.Generic;
using WoMakersCode.ToDoList.Application.Models.Alarm.InsertAlarm;
using WoMakersCode.ToDoList.Application.Models.TaskList.GetTaskList;

namespace WoMakersCode.ToDoList.Application.Models.TaskDetail.GetTaskDetail
{
    public class GetAllTaskDetailResponse
    {
        public int IdTaskList { get; set; }
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataHora { get; set; }
        public bool Executado { get; set; }        
        public List<GetAlarmInfos> Alarms {get;set;}
    }
}
