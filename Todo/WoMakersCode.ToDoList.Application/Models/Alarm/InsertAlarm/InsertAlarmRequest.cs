using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoMakersCode.ToDoList.Application.Models.Alarm.InsertAlarm
{
    public class InsertAlarmRequest
    {
        public DateTime DataHora { get; set; }
        public int IdTaskDetail { get; set; }
    }
}
