﻿using System.Collections.Generic;
using Lachesis.QuantumComputing;
using System;
namespace BattleShips
{
    public class QuantumEngine : IEngine
    {
        double CountShipLive(int lives, int bombs)
        {
            double ones = 0;
            double zeros = 0;
            int trise = 102400;
            for (int i = 0; i < trise; i++)
            {
                QuantumRegister zero = Qubit.Zero;
                if (bombs > lives)
                    bombs = lives;
                QuantumRegister one = QuantumGate.Rotation((double)bombs * Math.PI / (double)lives) * zero;
                Random random = new Random();
                one.Collapse(random);
                if (one.GetValue() == 1)
                    ones++;
                else
                    zeros++;
            }

            return ones / (double)trise;
        }
        public List<List<int>> CountState(List<List<int>> shipsPos, List<List<int>> bomb)
        {
            List<List<int>> state = new List<List<int>>();

            for (int player = 0; player < shipsPos.Count; player++)
            {
                state.Add(new List<int>());
                for (int ship = 0; ship < shipsPos[player].Count; ship++)
                {
                    double lives = CountShipLive(ship + 1, bomb[player][(shipsPos[player][ship])]);
                    lives *= 100;
                    if (lives >= 90)
                        lives = 100;
                    state[player].Add((int)lives);
                }
            }

            return state;
        }
    }
}