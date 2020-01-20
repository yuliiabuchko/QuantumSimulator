using System;
using System.Collections.Generic;

namespace BattleShips
{
    class JapanBattleShipGame : BatleShipGame
    {
        public JapanBattleShipGame(EngineFactory factory) : base(factory)
        { }


        void Inicialize()
        {
            for (int player = 0; player < PlayersNumber; player++)
            {
                List<int> _palyerShipsPositions = new List<int>();
                for (int i = 0; i < ShipsNumber; i++)
                {
                    Console.WriteLine((player + 1) + " player choose position for ship " + (i + 1));
                    var input = Console.ReadLine().Trim();
                    int value;
                    if (int.TryParse(input, out value) && value >= 1 && value <= ShipSlotsNumber)
                    {
                        if (_palyerShipsPositions.Contains(value))
                        {
                            --i;
                            Console.WriteLine("Position occupied");
                        }
                        else
                        {
                            _palyerShipsPositions.Add(value);
                            Console.WriteLine(value);
                        }
                    }
                    else
                    {
                        --i;
                        Console.WriteLine("Incorrect input");
                    }
                }
                _shipsPos.Add(_palyerShipsPositions);
                _bombs.Add(new List<int>(new int[ShipSlotsNumber+1]));
                Console.Clear();
            }
        }
        void GameStep()
        {
            for (int player = 0; player < PlayersNumber; player++)
            {

                Console.WriteLine((player + 1) + " player choose position to bomb ");
                var input = Console.ReadLine().Trim();
                int value;
                if (int.TryParse(input, out value) && value >= 1 && value <= ShipSlotsNumber)
                {
                    _bombs[(player + 1) % PlayersNumber][value]++;   // 1 -> 0 ; 0 -> 1
                }
                else
                {
                    --player;
                    Console.WriteLine("Incorrect input");
                }

                Console.Clear();
            }
        }
        void PrintState(List<List<int>> state)
        {
            for (int i = 0; i < PlayersNumber; i++)
            {
                Console.WriteLine((i + 1) + " players ships demage:");
                foreach (var s in state[i])
                {
                    Console.Write(s + " ");
                }
                Console.WriteLine();
            }
        }
        int CheckForLooser(List<List<int>> state)
        {
            List<int> loosers = new List<int>();
            for (int i = 0; i < PlayersNumber; i++)
            {
                bool dead = true;
                foreach (var s in state[i])
                {
                    if (s != 100)
                    {
                        dead = false;
                        break;
                    }
                }
                if (dead)
                {
                    loosers.Add(i);
                }
            }
            if (loosers.Count == 0)
                return 0;
            if (loosers.Count == PlayersNumber)
                return PlayersNumber + 1;
            return (loosers[0] + 1);
        }
        public override void Play()
        {
            Inicialize();
            int looser = 0;
            do
            {
                GameStep();
                var state = CountState();
                PrintState(state);
                looser = CheckForLooser(state);
            }
            while (looser == 0);
            if (looser == PlayersNumber + 1)
                Console.WriteLine("Both dead");
            else
                Console.WriteLine("Player " + looser + " dead");
        }
    }
}