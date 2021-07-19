namespace Checklist.Domain
{
    public class XTask
    {
        public long Id { get; private set; }
        public string Description { get; private set; }
        public bool Completed { get; private set; }

        public XTask(long id, string description): this(id, description, false)
        {
            Id = id;
            Description = description;
        }

        public XTask(long id, string description, bool completed)
        {
            Id = id;
            Description = description;
            Completed = completed;
        }

        public void MarkAsComplete()
        {
            Completed = true;
        }
    }
}