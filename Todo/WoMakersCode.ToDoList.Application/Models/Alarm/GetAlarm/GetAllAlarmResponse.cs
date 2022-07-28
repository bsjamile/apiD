using System;

namespace WoMakersCode.ToDoList.Application.Models.Alarm.GetAlarm
{
    public class GetAllAlarmResponse
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public int IdTaskDetail { get; set; }
    }
}
