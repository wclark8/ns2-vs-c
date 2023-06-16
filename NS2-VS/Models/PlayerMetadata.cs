namespace NS2_VS.Models
{
    public class PlayerMetadata
    {
        public PlayerMetadata(string name, _Elo elo, string avatarUri, _Accuracies accuracies)
        {
            this.name = name;
            this.elo = elo;
            this.avatarUri = avatarUri;
            this.accuracies = accuracies;
        }
        public string name { get; set; }
        public _Elo elo { get; set; }
        public string avatarUri { get; set; }
        public _Accuracies accuracies { get; set; }
    }
}
