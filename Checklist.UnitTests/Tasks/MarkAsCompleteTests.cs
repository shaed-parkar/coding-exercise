using Checklist.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace Checklist.UnitTests.Tasks
{
    public class MarkAsCompleteTests
    {
        [Test]
        public void should_update_completed_to_true()
        {
            var task = new XTask(1, "Test Complete");
            task.Completed.Should().BeFalse();
            
            task.MarkAsComplete();
            
            task.Completed.Should().BeTrue();
        }
    }
}