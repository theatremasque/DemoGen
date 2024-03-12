namespace StartProjectOfGen.Entities;

public class LearnUnit
{
    public Teacher Teacher { get; set; }
    
    public Subject Subject { get; set; }

    public LearnUnit(Teacher teacher, Subject subject)
    {
        Teacher = teacher;
        Subject = subject;
    }
}