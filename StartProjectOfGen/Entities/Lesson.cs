namespace StartProjectOfGen.Entities;

public class Lesson
{
    public TimeSpan Start { get; set; }
    public TimeSpan End { get; set; }
    public string Interval => $"{Start:hh\\:mm} - {End:hh\\:mm}"; // 8:00 - 9:35
    public LearnUnit[]? LearnUnits { get; set; }
}