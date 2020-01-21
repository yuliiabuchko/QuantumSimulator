using System.Collections.Generic;

namespace BattleShips
{
    public interface IEngine
    {
        List<List<int>> CountState(List<List<int>> shipsPos, List<List<int>> bomb);
    }
}