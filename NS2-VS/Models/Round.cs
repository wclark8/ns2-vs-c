namespace NS2_VS.Models
{
    public class Round
    {
        public int Id { get; set; }
        public string WinStatus { get; set; }
        public string Team { get; set; }

        //unimplemented in crawler
        public string? roundUrl { get; set; }
    }
}
