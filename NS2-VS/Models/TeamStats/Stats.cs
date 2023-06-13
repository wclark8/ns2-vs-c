namespace NS2_VS.Models.TeamDetails
{
    public class Stats
    {
        public int Elo { get; set; }
        public int Accuracy { get; set; }

        public float Kd { get; set; }
        public Stats(int elo, int accuracy, float kd)
        {
            Elo = elo;
            Accuracy = accuracy;
            Kd = kd;
        }
    }
}
