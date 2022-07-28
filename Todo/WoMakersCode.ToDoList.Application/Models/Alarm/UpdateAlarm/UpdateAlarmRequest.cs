using System;

namespace WoMakersCode.ToDoList.Application.Models.Alarm.UpdateAlarm
{
    public class UpdateAlarmRequest
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public int IdTaskDetail { get; set; }
    }
}
