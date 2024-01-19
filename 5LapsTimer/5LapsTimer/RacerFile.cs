namespace _5LapsTimer;
class RacerFile : RacerBase
{
    private readonly string fileName;

    public RacerFile(string fileName)
    {
        this.fileName = fileName;
    }

    public override void DisplayRaceStats()
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            if (LapTimes.Count > 0)
            {
                var completedLapTimes = LapTimes.Where(time => time.HasValue).ToList();

                if (completedLapTimes.Count > 0)
                {
                    TimeSpan bestTime = completedLapTimes.Min(time => time.Value);
                    TimeSpan worstTime = completedLapTimes.Max(time => time.Value);
                    TimeSpan avgTime = TimeSpan.FromTicks((long)completedLapTimes.Average(time => time.Value.Ticks));
                    TimeSpan totalTime = TimeSpan.FromTicks(completedLapTimes.Sum(time => time.Value.Ticks));

                    writer.WriteLine("Statystyki czasów okrążeń:");
                    writer.WriteLine($"Najlepszy czas: {LapTimeFormat(bestTime)}");
                    writer.WriteLine($"Najgorszy czas: {LapTimeFormat(worstTime)}");
                    writer.WriteLine($"Średni czas: {LapTimeFormat(avgTime)}");
                    writer.WriteLine($"Długość całego wyścigu: {LapTimeFormat(totalTime)}");

                    DisplayDriverInfo(writer);

                }
                else
                {
                    writer.WriteLine("Brak ukończonych okrążeń.");
                    DisplayDriverInfo(writer);
                }
            }
            else
            {
                writer.WriteLine("Brak danych do wyświetlenia.");
            }
        }

        Console.WriteLine($"Statystyki zapisano w pliku: {fileName}");
    }

    private string LapTimeFormat(TimeSpan time)
    {
        return time.ToString(@"hh\:mm\:ss");
    }

    private void DisplayDriverInfo(StreamWriter writer)
    {
        writer.WriteLine("Informacje o kierowcy:");
        writer.WriteLine($"Imię: {Name}");
        writer.WriteLine($"Nazwisko: {Surname}");
        writer.WriteLine($"Numer kierowcy: {Number}");
    }
}