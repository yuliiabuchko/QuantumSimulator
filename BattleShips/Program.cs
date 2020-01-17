using System;
using System.Collections.Generic;

using Lachesis.QuantumComputing;

namespace BattleShips
{

    public interface IEngine
    {
        List<List<int>> CountState(List<List<int>> shipsPos, List<List<int>> bomb);
    }
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
    public class QuantumEngine : IEngine
    {
        public List<List<int>> CountState(List<List<int>> shipsPos, List<List<int>> bomb)
        {
            List<List<int>> state = new List<List<int>>();

            return state;
        }
    }
    public abstract class BatleShipGame
    {
        IEngine _engine;
        protected BatleShipGame(IEngine engine)
        {
            _engine = engine;
        }
        protected List<List<int>> _shipsPos = new List<List<int>>();
        protected List<List<int>> _bombs = new List<List<int>>();
        public abstract void Play();
        protected List<List<int>> CountState()
        {
            return _engine.CountState(_shipsPos, _bombs);
        }

    }
    class JapanBatleShipGame : BatleShipGame
    {
        public JapanBatleShipGame(IEngine engine) : base(engine)
        { }


        void Inicialize()
        {
            for (int player = 0; player < 2; player++)
            {
                List<int> _palyerShipsPositions = new List<int>();
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine((player + 1) + " player choose position for ship " + (i + 1));
                    var input = Console.ReadLine().Trim();
                    int value;
                    if (int.TryParse(input, out value) && value >= 1 && value <= 5)
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
                _bombs.Add(new List<int>(new int[5]));
                Console.Clear();
            }
        }
        void GameStep()
        {
            for (int player = 0; player < 2; player++)
            {

                Console.WriteLine((player + 1) + " player choose position to bomb ");
                var input = Console.ReadLine().Trim();
                int value;
                if (int.TryParse(input, out value) && value >= 1 && value <= 5)
                {
                    _bombs[(player + 1) % 2][value]++;   // 1 -> 0 ; 0 -> 1
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
            for (int i = 0; i < 2; i++)
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
            for (int i = 0; i < 2; i++)
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
            if (loosers.Count == 2)
                return 3;
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
            if (looser == 3)
                Console.WriteLine("Both dead");
            else
                Console.WriteLine("Player " + looser + " dead");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Battle Ships Quantum \nIt's game for 2 players each will have 3 ships in 5 positions. First ship has 1 life, second ship - 2 and third - 3");
            
            while (true)
            {
                Console.WriteLine("Menu\n1.Start game \nx.End.");
                var input = Console.ReadLine().Trim();
                if (input.Equals("x", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                if (input.Equals("1", StringComparison.OrdinalIgnoreCase))
                {
                    BatleShipGame game = new JapanBatleShipGame(new simpeEngine());
                    game.Play();
                }
                //Console.Clear();
                Console.WriteLine(input);
                Console.WriteLine("Incorrect input.");
            }
            /*
            int ones = 0;
            int zeros = 0;
            for (int i = 0; i < 102400; i++)
            {
                QuantumRegister zero = Qubit.Zero;
                QuantumRegister one = QuantumGate.Rotation(Math.PI / 2) * zero;
                Random random = new Random();
                one.Collapse(random);
                if (one.GetValue() == 1)
                    ones++;
                else
                    zeros++;
            }
            Console.WriteLine(ones + "  " + zeros);
            Console.ReadKey();
            */
        }

    }
}
