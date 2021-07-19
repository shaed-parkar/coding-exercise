using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Checklist.Domain;

namespace Checklist.DAL
{
    public interface IXTaskManager
    {
        Task<List<XTask>> GetAllTasks();
        Task<XTask> AddXTask(string description);
        Task CompleteXTask(long xTaskId);
        Task DeleteXTask(long xTaskId);

    }
    
    public class XTaskService : IXTaskManager
    {
        private List<XTask> _tasks;

        public XTaskService()
        {
            InitTasks();
        }

        private void InitTasks()
        {
            _tasks = new List<XTask>()
            {
                new XTask(1, "Go to the gym"),
                new XTask(2, "Shower"),
                new XTask(3, "Eat breakfast"),
                new XTask(4, "Call doctor")
            };
        }

        public Task<List<XTask>> GetAllTasks()
        {
            return Task.FromResult(_tasks);
        }

        public Task<XTask> AddXTask(string description)
        {
            var nextId = _tasks.Select(x => x.Id).Max() + 1;
            var task = new XTask(nextId, description);
            
            // TODO: should check if task already exists
            _tasks.Add(task);
            return Task.FromResult(task);
        }

        public Task CompleteXTask(long xTaskId)
        {
            var existingTask = _tasks.SingleOrDefault(x => x.Id == xTaskId);
            existingTask?.MarkAsComplete();
            return Task.CompletedTask;
        }

        public Task DeleteXTask(long xTaskId)
        {
            var existingTaskId = _tasks.FindIndex(x => x.Id == xTaskId);
            if (existingTaskId >= 0)
            {
                _tasks.RemoveAt(existingTaskId);
            }
            
            return Task.CompletedTask;
        }
    }
}