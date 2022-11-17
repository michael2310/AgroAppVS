using AgroApp.Models;

namespace AgroApp.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        TaskModel GetTaskById (int taskId);
        IEnumerable<TaskModel> GetTasks();
        IEnumerable<TaskModel> GetTasksByFarmId(int taskId);
        IEnumerable<TaskModel> GetTasksByUserId(string userId);
        void AddTask(TaskModel task);
        void UpdateTask(int taskId, TaskModel task);
        void DeleteTask(int taskId);
    }
}
