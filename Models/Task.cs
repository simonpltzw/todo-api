using Todo.API.Models.Enums;

namespace Todo.API.Models
{
    public class Task
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public DateOnly? Planned { get; set; }
        public DateOnly? Deadline { get; set; }
        public bool Completed { get; set; }
        public RoutineType Type { get; set; }
        public int TopicId { get; set; }
        public Topic? Topic { get; set; }
        public int? ParentId { get; set; }
        public Task? Parent { get; set; }
        public int? RoutineDefinitionId { get; set; }
        public RoutineDefinition? RoutineDefinition { get; set; }

        public List<Task>? Children { get; set; }
    }
}
