namespace StartProjectOfGen.Entities;

public class Subject
{
    public int Id { get; set; }

    public string Title { get; set; }

    public Subject()
    {
        Id = 1;
        Title = "Math";
    }
}