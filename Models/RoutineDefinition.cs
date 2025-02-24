using Todo.API.Models.Enums;

namespace Todo.API.Models
{
    public class RoutineDefinition
    {
        public int Id { get; set; }
        public RoutineType Type { get; set; }
        public int? Day { get; set; } // Represents the day of month/year if Type != Week.
        public DaysOfWeek? DaysOfWeek { get; set; }
    }
}
