namespace Todo.API.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool IsBaseTopic { get; set; }
        public int ProjectId { get; set; }
        public Project? Project { get; set; }

        public List<Task>? Tasks { get; set; }

        public DateTime CreatedAt { get; set; }
        public int CreatedById { get; set; }
        public User? CreatedBy { get; set; }
        public bool Active { get; set; }
    }
}
