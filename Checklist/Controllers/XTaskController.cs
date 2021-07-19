using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Checklist.Contracts.Request;
using Checklist.Contracts.Response;
using Checklist.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Checklist.Controllers
{
    [Produces("application/json")]
    [Route("api/tasks")]
    [ApiController]
    public class XTaskController : ControllerBase
    {
        private readonly IXTaskManager _taskManager;

        public XTaskController(IXTaskManager taskManager)
        {
            _taskManager = taskManager;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<TaskResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks =  await _taskManager.GetAllTasks();
            var response = tasks.Select(x => new TaskResponse
            {
                Id = x.Id,
                Description = x.Description,
                Completed = x.Completed
            });
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(TaskResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateANewTask([FromBody] NewTaskRequest body)
        {
            var newTask = await _taskManager.AddXTask(body.Description);
            var response = new TaskResponse
            {
                Id = newTask.Id,
                Description = newTask.Description,
                Completed = newTask.Completed
            };
            return Ok(response);
        }

        [HttpPost("{id}/complete")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> CompleteATask(long id)
        {
            await _taskManager.CompleteXTask(id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteATask(long id)
        {
            await _taskManager.DeleteXTask(id);
            return NoContent();
        }
    }
}
