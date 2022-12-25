int eventsNumber = int.Parse(Console.ReadLine());


WindowsEvent[] events = new WindowsEvent[eventsNumber];
for (var i = 0; i < eventsNumber; i++)
{
    WindowsEvent windowsEvent = new WindowsEvent();
    windowsEvent.appName = Console.ReadLine();
    windowsEvent.eventLevel = (Levels)int.Parse(Console.ReadLine());
    windowsEvent.eventCode = int.Parse(Console.ReadLine());
    windowsEvent.eventDate = new DateOnly(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()),
        int.Parse(Console.ReadLine()));
    windowsEvent.eventTime = new TimeOnly(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
    events[i] = windowsEvent;
}

// 1 Задание
foreach (var windowsEvent in events)
{
    if (windowsEvent.eventLevel != Levels.Warning && windowsEvent.eventDate != DateOnly.FromDateTime(DateTime.Now))
        continue;
    Console.WriteLine(windowsEvent.appName);
    Console.WriteLine(windowsEvent.eventCode);
    Console.WriteLine(windowsEvent.eventTime);
    Console.WriteLine();
}

// 2 задание
WindowsEvent task2Event = events
    .Where(e => e.eventDate.Month == (DateTime.Now.Month + 12) % 13)
    .Where(e => e.eventLevel == Levels.Error)
    .MaxBy(e => e.eventTime);
Console.WriteLine(task2Event.appName);
Console.WriteLine(task2Event.eventCode);
Console.WriteLine(task2Event.eventTime);


enum Levels
{
    Error,
    Warning,
    Debug,
    Log
}

struct WindowsEvent
{
    public string appName;
    public Levels eventLevel;
    public int eventCode;
    public DateOnly eventDate;
    public TimeOnly eventTime;

    public WindowsEvent(string appName, Levels eventLevel, int eventCode, DateOnly eventDate, TimeOnly eventTime)
    {
        this.appName = appName;
        this.eventLevel = eventLevel;
        this.eventCode = eventCode;
        this.eventDate = eventDate;
        this.eventTime = eventTime;
    }
}