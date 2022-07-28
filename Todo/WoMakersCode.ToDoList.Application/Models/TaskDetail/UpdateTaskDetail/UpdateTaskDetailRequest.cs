using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoMakersCode.ToDoList.Application.Models.TaskDetail.UpdateTaskDetail
{
    public class UpdateTaskDetailRequest
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataHora { get; set; }
        public bool Executado { get; set; }
        public int IdTaskList { get; set; }
    }
}
