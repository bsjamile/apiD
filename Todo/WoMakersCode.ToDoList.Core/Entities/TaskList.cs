using System.Collections.Generic;

namespace WoMakersCode.ToDoList.Core.Entities
{
    public class TaskList
    {
        public int Id { get; set; }
        public string ListName { get; set; }
        public List<TaskDetail> Details { get; set; }
    }
}
