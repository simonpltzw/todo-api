namespace Todo.API.Models
{
    public class UserProject
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int ProjectId { get; set; }
        public Project? Project { get; set; }

        public DateTime CreatedAt { get; set; }
        public bool Active { get; set; }
    }
}
