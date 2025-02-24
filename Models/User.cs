namespace Todo.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string FederatedAccountId { get; set; }
        public string? Name { get; set; }

        public List<UserProject>? UserProjects { get; set; }

        public DateTime CreatedAt { get; set; }
        public bool Active { get; set; }
    }
}
