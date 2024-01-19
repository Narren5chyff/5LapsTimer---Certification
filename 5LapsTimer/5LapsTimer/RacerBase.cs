namespace _5LapsTimer;
public abstract class RacerBase : IRacer
{
    protected string Name { get; set; }
    protected string Surname { get; set; }
    protected string Number { get; set; }
    protected List<TimeSpan?> LapTimes { get; } = new List<TimeSpan?>();

    public void SetDriverInfo(string name, string surname, string number)
    {
        Name = name;
        Surname = surname;
        Number = number;
    }

    public void AddLapTime(TimeSpan? LapTime)
    {
        LapTimes.Add(LapTime);
    }

    public abstract void DisplayRaceStats();
}
