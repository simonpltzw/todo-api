namespace Todo.API.Models.Enums
{
    [Flags] // Flags indicates the weekdays will be represented by bits. For example 5 = 0000101 = Monday & Wednesday
    public enum DaysOfWeek
    {
        Monday      = 1 << 0,
        Tuesday     = 1 << 1,
        Wednesday   = 1 << 2,
        Thursday    = 1 << 3,
        Friday      = 1 << 4,
        Saturday    = 1 << 5,
        Sunday      = 1 << 6
    }
}
