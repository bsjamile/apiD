using System;

namespace WoMakersCode.ToDoList.Application.Models.TaskList.GetTaskList
{
    public class GetTaskDetailInfos
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataHora { get; set; }
        public bool Executado { get; set; }
    }
}
