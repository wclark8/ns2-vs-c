using Newtonsoft.Json.Linq;
using NS2_VS.Models;
using System.Linq;

namespace NS2_VS.Services
{
    public class PlayerComparisonService : IPlayerComparisonService
    {

        public PlayerComparisonResults ProcessPlayerComparison(Player[] players)
        {
            List<PlayerResults> playerResultsArr = new List<PlayerResults>();

            foreach (Player curPlayer in players)
            {
                playerResultsArr.Add(new PlayerResults(curPlayer._name, curPlayer._elo, curPlayer._avatarUrl,
                    curPlayer._accuracies));
            }

            //process rounds
            List<PlayerResults> processedPlayerResults = ProcessPlayedRounds(players, playerResultsArr);
            
            // calculate win rates etc etc 

            return new PlayerComparisonResults(); // stub
        }

        private List<PlayerResults> ProcessPlayedRounds(Player[] players, List<PlayerResults> playerResultsArr)
        {
            // sort by id
            _Rounds[] playerOneRounds = players[0]._rounds;
            _Rounds[] playerTwoRounds = players[1]._rounds;
            /*
            List<_Rounds> matchedRoundsPlayerOneWins = playerOneRounds.ExceptBy(playerTwoRounds
                .Select(r => r._roundId), r1 => r1._roundId).Where(i => i._winStatus == "Win").ToList();
            List<_Rounds> matchedRoundsPlayerTwoWins = playerTwoRounds.ExceptBy(playerOneRounds
                .Select(r => r._roundId), r1 => r1._roundId).Where(i => i._winStatus == "Win").ToList();
            */

            PlayerResults playerOneResults = playerResultsArr[0];
            PlayerResults playerTwoResults = playerResultsArr[1];


            foreach (var playerOneRound in playerOneRounds)
            {
                foreach(var playerTwoRound in playerTwoRounds)
                {
                    if (playerOneRound._winStatus == "Win" && playerOneRound._winStatus == playerTwoRound._winStatus)
                    {
                        // todo: support coop wins
                      //  playerOneResults.incrementPlayerWin(playerOneRound);
                       // playerTwoResults.incrementPlayerWin(playerTwoRound);

                        break;
                    }
                    if (playerOneRound._winStatus == "Loss" && playerOneRound._winStatus == playerTwoRound._winStatus)
                    {
                        // extend playerresults model to support collective losses
                        break;
                    }

                    if (playerOneRound._winStatus == "Win")
                    {
                        playerOneResults.incrementPlayerWin(playerOneRound);
                        break;
                    }
                    else if (playerTwoRound._winStatus == "Win")
                    {
                        playerTwoResults.incrementPlayerWin(playerTwoRound);
                        break;
                    }
                    else
                    {
                        // support draws
                        break;
                    }
                }
            }

            List<PlayerResults> results = new List<PlayerResults>();

            results.Add(playerOneResults);
            results.Add(playerTwoResults);

            return results;
        }

    }
}
