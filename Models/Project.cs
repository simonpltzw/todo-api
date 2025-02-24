namespace Todo.API.Models
{
    public class Project
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }

        public List<Topic>? Topics { get; set; }
        public List<UserProject>? UserProjects { get; set; }

        public DateTime CreatedAt { get; set; }
        public int CreatedById { get; set; }
        public User? CreatedBy { get; set; }
        public bool Active { get; set; }
    }
}
