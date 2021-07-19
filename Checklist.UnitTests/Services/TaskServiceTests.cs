using System.Linq;
using System.Threading.Tasks;
using Checklist.DAL;
using Checklist.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace Checklist.UnitTests.Services
{
    public class TaskServiceTests
    {
        private XTaskService _service;
        
        [SetUp]
        public void Setup()
        {
            _service = new XTaskService();
        }
        
        [Test]
        public async Task should_add_new_task()
        {
            var beforeTasksCount = (await _service.GetAllTasks()).Count;

            var description = "New Task To Test";
            await _service.AddXTask(description);

            var postTestTasks = await _service.GetAllTasks();
            postTestTasks.Should().HaveCountGreaterThan(beforeTasksCount);
            postTestTasks.Any(x => x.Description == description).Should().BeTrue();
        }

        [Test]
        public async Task should_complete_task()
        {
            var tasks = await _service.GetAllTasks();
            var beforeTestCount = tasks.Count(x=> x.Completed);
            var taskToComplete = tasks.First(x => !x.Completed);

            await _service.CompleteXTask(taskToComplete.Id);

            var postTestTasks = await _service.GetAllTasks();
            var postTestCount = postTestTasks.Count(x=> x.Completed);
            postTestCount.Should().BeGreaterThan(beforeTestCount);
            postTestTasks.Any(x => x.Id == taskToComplete.Id && x.Completed).Should().BeTrue();
        }
        
        [Test]
        public async Task should_remove_existing_task()
        {
            var tasks = await _service.GetAllTasks();
            var beforeTasksCount = tasks.Count;
            var taskToRemove = tasks.First();

            await _service.DeleteXTask(taskToRemove.Id);

            var postTestTasks = await _service.GetAllTasks();
            postTestTasks.Should().HaveCountLessThan(beforeTasksCount);
            postTestTasks.Any(x => x.Id == taskToRemove.Id).Should().BeFalse();
        }
    }
}