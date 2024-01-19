namespace _5LapsTimer
{
    interface IRacer
    {
        void SetDriverInfo(string name, string surname, string number);
        void AddLapTime(TimeSpan? LapTime);
        void DisplayRaceStats();
    }
}