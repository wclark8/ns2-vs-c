using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace NS2_VS.Models
{
    public class PlayerResults : PlayerMetadata
    {
        private int _playerAlienWins;

        private int _playerMarineWins;

        private Dictionary<string, string> _wonRounds;
        public PlayerResults(string name, _Elo elo, string avatarUri, _Accuracies accuracies)
            : base(name, elo, avatarUri, accuracies)
        {
            _playerAlienWins = 0;
            _playerMarineWins = 0;
            _wonRounds = new Dictionary<string, string>();
        }

        public int playerAlienWins { get => _playerAlienWins; }

        public int playerMarineWins { get => _playerAlienWins; }

        public Dictionary<string, string> wonRounds { get => _wonRounds; }

        public int totalWins
        {
            get
            {
                return _playerAlienWins + _playerMarineWins;
            }
        }
        // TODO: FIx
        private void addWonRound(string roundId, string team)
        {
            _wonRounds.Add(roundId, team);
        }

        public void incrementPlayerWin(_Rounds round)
        {
            if(round._team == "Aliens")
            {
                _playerAlienWins++;
            } else
            {
                _playerMarineWins++;
            }

            addWonRound(round._roundId, round._team);
        }
    }
}
