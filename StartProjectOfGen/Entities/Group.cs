namespace StartProjectOfGen.Entities;

public class Group
{
    public int Id { get; set; }
    
    public string Title { get; set; }

    public Group()
    {
        Id = 1;
        Title = "AT-191";
    }
}