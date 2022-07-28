using System;

namespace WoMakersCode.ToDoList.Application.Models.TaskDetail.InsertTaskDetail
{
    public class InsertTaskDetailRequest
    {
        public string Descricao { get; set; }
        public DateTime DataHora { get; set; }
        public bool Executado { get; set; }
        public int IdTaskList { get; set; }
    }
}
