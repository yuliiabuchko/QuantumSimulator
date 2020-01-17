using System;
using Lachesis.QuantumComputing;

namespace BattleShips
{
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
                    BatleShipGame game = new JapanBattleShipGame(new SimpleConcreteFactory());
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
