namespace StartProjectOfGen.Entities;

public class Schedule
{
    public int Id { get; set; }

    public ICollection<SchedulePart>? ScheduleParts { get; set; }
}