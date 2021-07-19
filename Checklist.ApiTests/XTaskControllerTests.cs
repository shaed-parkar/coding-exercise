using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Checklist.Contracts.Request;
using Checklist.Contracts.Response;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Checklist.ApiTests
{
    public class XTaskControllerTests : ControllerTestsBase
    {
        private string BaseRoutePath => "api/tasks";
        
        [Test]
        public async Task should_get_all_tasks()
        {
            var httpResponse = await SendGetRequestAsync(BaseRoutePath);
            
            httpResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            
            var responseBody = await httpResponse.Content.ReadAsStringAsync();
            var task = JsonConvert.DeserializeObject<List<TaskResponse>>(responseBody);
            task.Should().NotBeNullOrEmpty();
        }
        
        [Test]
        public async Task should_complete_task_by_id()
        {
            var taskId = 1;
            var uri = $"{BaseRoutePath}/{taskId}/complete";
            var httpResponse = await SendPostRequestAsync(uri, null);
            httpResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);
            httpResponse.IsSuccessStatusCode.Should().BeTrue();
        }
        
        [Test]
        public async Task should_add_new_task()
        {
            var createUserRequest = new NewTaskRequest
            {
               Description = "Creating a task via API test"
            };
            var createUserHttpRequest = new StringContent(
                JsonConvert.SerializeObject(createUserRequest),
                Encoding.UTF8, "application/json");
            var httpResponse = await SendPostRequestAsync(BaseRoutePath, createUserHttpRequest);
            httpResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            httpResponse.IsSuccessStatusCode.Should().BeTrue();
            
            var responseBody = await httpResponse.Content.ReadAsStringAsync();
            var task = JsonConvert.DeserializeObject<TaskResponse>(responseBody);
            task.Should().NotBeNull();
            task.Completed.Should().BeFalse();
            task.Id.Should().BeGreaterThan(0);
            task.Description.Should().Be(createUserRequest.Description);
        }
        
        
    }
}