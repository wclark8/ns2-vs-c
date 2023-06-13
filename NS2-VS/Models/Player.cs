using NS2_VS.Models.TeamDetails;

namespace NS2_VS.Models
{
    public class Player
    {
        public string Name { get; private set; }
        public int TotalELo { get; private set; }
        public string PlayerAvatarMetadata { get; private set; }

        public Stats MarineStats { get; private set; }

        public AlienStats AlienStats { get; private set; }

        public Dictionary<int, Round> Rounds {
            get
            {
                return Rounds;
            }
            private set 
            { 
                Rounds = value;
            }
        }

        public Player(string name, int totalElo, string playerAvatarMetadata,
            int marineElo, int marineAccuracy, float marineKd, int alienElo, int alienAccuracy,
            float alienKd)
        {
            Name = name;
            TotalELo = totalElo;
            PlayerAvatarMetadata = playerAvatarMetadata;

            MarineStats = new Stats(marineElo, marineAccuracy, marineKd);
            AlienStats = new AlienStats(alienElo, alienAccuracy, alienKd);

            Rounds = new Dictionary<int, Round>();

            // loop through rounds adding to Rounds
        }
    }
}

// extract main lifeform
// extract kds

// matchedRounds Dictionary<'roundID',Round> ONLY STORE MATCHED ROUNDS?
// define Round obj
//
//