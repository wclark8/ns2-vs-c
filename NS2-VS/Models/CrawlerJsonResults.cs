/*
 * This is in one place to simplify adapting to
 * the crawlers output when i extend what it scrapes
 */

using System.Numerics;

public class CrawlerJsonResults
{
    public Player[] player { get; set; }
}

public class Player
{
    public _Rounds[] _rounds { get; set; }
    public string _name { get; set; }
    public string _avatarUrl { get; set; }
    public _Elo _elo { get; set; }
    public _Accuracies _accuracies { get; set; }
}

public class _Elo
{
    public string elo { get; set; }
    public string marineElo { get; set; }
    public string alienElo { get; set; }
}

public class _Accuracies
{
    public string marineAcc { get; set; }
    public string alienAcc { get; set; }
}

public class _Rounds
{
    public string _roundId { get; set; }
    public string _winStatus { get; set; }
    public string _team { get; set; }
}

