namespace StartProjectOfGen.Entities;

public class SchedulePart
{
    public Group? Group { get; set; }
    public DayOfWeek Day { get; set; }
    
    public Lesson[] Lessons = Array.Empty<Lesson>();
}