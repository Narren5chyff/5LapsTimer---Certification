// Aplikacja zbiera dane dotyczące czasów kierowców wyścigowych na pięciu okrążeniach na torze.
// Każdy z kierowców ma wprowadzany wynik w postaci czasu jakiego potrzebował na przejechanie jednego okrążenia.
// Aplikacja pokaże najlepszy i najgorszy wynik oraz średnią ze wszystkich przejechanych okrążeń.
// Jeśli kierowca nie zdoła ukończyć wyścigu na którymkolwiek etapie - dostaje wynik "DNF", który ukaże się w
// podsumowaniu wyniku (statystyki tak czy siak będzie miał dostępne) i wymusza zakończenie procesowania wyniku.

using _5LapsTimer;

Console.WriteLine("5 Laps Timer");
Console.WriteLine("Program do wyliczania statystyk na torze wyścigowym");
Console.WriteLine("---------------------------------------------------");
Console.WriteLine("Wybierz, czy program ma pracować na pamięci wew., czy zapisywać dane w pliku");
Console.WriteLine("Wybierz -M- aby wybrać pamięć wew., lub -F- aby wybrać plik");

char choice;
if (char.TryParse(Console.ReadLine(), out choice))
{
    RacerBase raceStats;

    switch (choice)
    {
        case 'M':
            raceStats = new RacerMemory();
            break;
        case 'F':
            string fileName = "czasy_zawodnika.txt";
            raceStats = new RacerFile(fileName);
            break;
        default:
            Console.WriteLine("Nieprawidłowy wybór.");
            return;
    }

    Console.Write("Podaj imię kierowcy: ");
    string name = Console.ReadLine();

    Console.Write("Podaj nazwisko kierowcy: ");
    string surname = Console.ReadLine();

    Console.Write("Podaj numer kierowcy: ");
    string number = Console.ReadLine();

    raceStats.SetDriverInfo(name, surname, number);

    for (int i = 1; i <= 5; i++)
    {
        Console.Write($"Podaj czas okrążenia {i} (w formacie HH:mm:ss lub wpisz -DNF- jeśli nie ukończył wyścigu): ");
        string input = Console.ReadLine();

        if (input.ToUpper() == "DNF")
        {
            raceStats.AddLapTime(null);
            break;
        }

        if (TimeSpan.TryParse(input, out TimeSpan LapTime))
        {
            raceStats.AddLapTime(LapTime);
        }
        else
        {
            Console.WriteLine("Błędny format czasu.");
            i--;
        }
    }
    raceStats.DisplayRaceStats();
}
else
{
    Console.WriteLine("Błędne dane wejściowe.");
}