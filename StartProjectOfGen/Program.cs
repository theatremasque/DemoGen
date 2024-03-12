using System.Text;
using StartProjectOfGen.Entities;

namespace StartProjectOfGen;

class Program
{
    static void Main(string[] args)
    {
        Console.WindowWidth = 150;
        Console.WindowHeight = 40;
        
        Teacher teacher = new Teacher();

        Subject subject = new Subject();

        LearnUnit[] units =
        [
            new LearnUnit(teacher, subject)
        ];
        
        Group group = new Group();
        
        DayOfWeek[] week =
        [
            DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday
        ];

        List<SchedulePart> parts = new List<SchedulePart>();
        
        foreach (var day in week)
        {
            SchedulePart part = new SchedulePart()
            {
                Day = day,
                Group = group,
                Lessons = GenerateLesson(units, 4),
            };
            parts.Add(part);
        }
        
        Schedule schedule = new Schedule()
        {
            Id = 1,
            ScheduleParts = parts
        };
        
        
        var leftPosition = 1;
        var defaultTopPosition = -1;
        var topPosition = defaultTopPosition;
        
        Console.SetCursorPosition(75, topPosition += 1);
        Console.WriteLine($"Schedule: {schedule.Id}");
        
        Console.SetCursorPosition(75, topPosition += 1);
        Console.WriteLine($"{schedule.ScheduleParts.First().Group.Title}");
        defaultTopPosition = topPosition;
        foreach (var parted in schedule.ScheduleParts)
        {
            try
            {
                Console.SetCursorPosition(leftPosition, topPosition += 1);
            }
            catch (Exception)
            {
                leftPosition = 0;
                defaultTopPosition = 15;
                topPosition = defaultTopPosition;
                Console.SetCursorPosition(leftPosition, topPosition += 1);
            }
            
            Console.WriteLine($"Day: {parted.Day}");
            

            foreach (var lessonOfDay in parted.Lessons)
            {
                Console.SetCursorPosition(leftPosition, topPosition += 1);
                Console.WriteLine($"Interval: {lessonOfDay.Interval}");
                
                foreach (var learnUnit in lessonOfDay.LearnUnits!)
                {
                    
                    string sub = $"Subject: {learnUnit.Subject.Title}";
                    
                    string teach = $"Teacher: {learnUnit.Teacher.Name}";
                    
                    Console.SetCursorPosition(leftPosition, topPosition += 1);
                    Console.WriteLine($"{sub}");
                    Console.SetCursorPosition(leftPosition, topPosition += 1);
                    Console.WriteLine($"{teach}");
                }
            }

            topPosition = defaultTopPosition;
            leftPosition += 30;
            
        }
        
    }

    private static Lesson[] GenerateLesson(LearnUnit[] units, int count)
    {
        Lesson[] lessons = new Lesson[count];
        
        for (int i = 0; i < count; i++)
        {
            lessons[i] = CreateLesson(units, i);
        }

        return lessons;
    }

    private static Lesson CreateLesson(LearnUnit[] units, int iteration)
    {
         var lesson = iteration switch
        {
            0 => new Lesson()
            {
                Start = new TimeSpan(8, 0, 0),
                End = new TimeSpan(9, 35, 0),
                LearnUnits = units
            },
            1 => new Lesson()
            {
                Start = new TimeSpan(9, 50, 0),
                End = new TimeSpan(11, 25, 0),
                LearnUnits = units
            },
            2 => new Lesson()
            {
                Start = new TimeSpan(11, 40, 0),
                End = new TimeSpan(13, 15, 0),
                LearnUnits = units
            },
            3 => new Lesson()
            {
                Start = new TimeSpan(13, 30, 0),
                End = new TimeSpan(15, 05, 0),
                LearnUnits = units
            },
            _ => throw new ArgumentOutOfRangeException(nameof(iteration), iteration, null)
        };

        return lesson;
    }
}