namespace _5LapsTimer;
public class RacerMemory : RacerBase
{
    public override void DisplayRaceStats()
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

                Console.WriteLine("Statystyki czasów okrążeń:");
                Console.WriteLine($"Najlepszy czas: {LapTimeFormat(bestTime)}");
                Console.WriteLine($"Najgorszy czas: {LapTimeFormat(worstTime)}");
                Console.WriteLine($"Średni czas: {LapTimeFormat(avgTime)}");
                Console.WriteLine($"Długość całego wyścigu: {LapTimeFormat(totalTime)}");

            }
            else
            {
                Console.WriteLine("Brak ukończonych okrążeń.");
            }
        }
        else
        {
            Console.WriteLine("Brak danych do wyświetlenia.");
        }
    }

    private string LapTimeFormat(TimeSpan time)
    {
        return time.ToString(@"hh\:mm\:ss");
    }
}