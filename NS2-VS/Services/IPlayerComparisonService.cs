using NS2_VS.Models;

namespace NS2_VS.Services
{
    public interface IPlayerComparisonService
    {
        PlayerComparisonResults ProcessPlayerComparison(Player[] players);

    }
}
