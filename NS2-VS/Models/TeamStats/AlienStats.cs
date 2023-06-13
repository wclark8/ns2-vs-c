namespace NS2_VS.Models.TeamDetails
{
    public class AlienStats : Stats
    {
        // unimplemented in scraper, maybe acc for wep instance
        public string? MainLifeform { get; set; }

        public AlienStats(int elo, int acc, float kd) : base (elo, acc, kd)
        {
        }
    }
}
