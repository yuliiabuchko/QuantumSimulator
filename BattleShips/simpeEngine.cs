using System.Collections.Generic;

namespace BattleShips
{
    public class simpeEngine : IEngine
    {
        public List<List<int>> CountState(List<List<int>> shipsPos, List<List<int>> bomb)
        {
            List<List<int>> state = new List<List<int>>();
            for (int player = 0; player < shipsPos.Count; player++)
            {
                state.Add(new List<int>());
                for (int ship = 0; ship < shipsPos[player].Count; ship++)
                {
                    int lives = (bomb[player][(shipsPos[player][ship])] * 100) / (ship + 1);
                    if (lives >= 95)
                        lives = 100;
                    state[player].Add(lives);
                }
            }
            return state;
        }
    }
}