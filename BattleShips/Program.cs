﻿using System;

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
                    return;
                }

                if (input.Equals("1", StringComparison.OrdinalIgnoreCase))
                {
                    BatleShipGame game = new JapanBattleShipGame(new QuantumConcreteFactory());
                    game.Play();
                }
                else
                {
                    //Console.Clear();
                    Console.WriteLine(input);
                    Console.WriteLine("Incorrect input.");   
                }
            }
        }
    }
}
