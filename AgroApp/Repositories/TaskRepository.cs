using AgroApp.Data;
using AgroApp.Models;

namespace AgroApp.Repositories.Interfaces
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddTask(TaskModel task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void DeleteTask(int taskId)
        {
            throw new NotImplementedException();
        }

        public TaskModel GetTaskById(int taskId)
        {
            return _context.Tasks.SingleOrDefault(x => x.TaskId == taskId);
        }

        public IEnumerable<TaskModel> GetTasks()
        {
            return _context.Tasks;
        }

        public IEnumerable<TaskModel> GetTasksByFarmId(int farmId)
        {
            List<TaskModel> tasks = new List<TaskModel>();
            foreach(TaskModel task in _context.Tasks)
            {
                if(task.FarmId == farmId)
                {
                    tasks.Add(task);
                }
            }
            return tasks;
        }

        public IEnumerable<TaskModel> GetTasksByUserId(string userId)
        {
            List<TaskModel> tasks = new List<TaskModel>();
            foreach(TaskModel task in _context.Tasks)
            {
                if(task.UserId == userId)
                {
                    tasks.Add(task);
                }
            }
            return tasks;
        }
        public void UpdateTask(int taskId, TaskModel task)
        {
            throw new NotImplementedException();
        }
    }
}
