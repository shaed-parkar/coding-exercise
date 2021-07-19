namespace Checklist.Contracts.Response
{
    public class TaskResponse
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
    }
}