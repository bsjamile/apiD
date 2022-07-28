using System.Collections.Generic;
using WoMakersCode.ToDoList.Application.Models.TaskDetail.InsertTaskDetail;

namespace WoMakersCode.ToDoList.Application.Models.TaskList.GetTaskList
{
    public class GetTaskListIdResponse
    {
        public int Id { get; set; }
        public string ListName { get; set; }
        public List<GetTaskDetailInfos> Tasks { get; set; }
    }
}
