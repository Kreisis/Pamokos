using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeFights.model;

namespace CodeFights
{
    class MyFighter : IFighter
    {
        public enum Strategies
        {
            Counter,
            Mimic,
            Random,
            Other
        }
        Random _random;

        int turn = 0;

        public MyFighter()
        {
            _random = new Random();
        }

        Strategies strategy = Strategies.Other;

        public Move MakeNextMove(Move opponentsLastMove, int myLastScore, int opponentsLastScore)
        {

            Move thisMove = new Move();

            if (turn % 2 == 0)
            {
                ActRandom(thisMove);
            }   
                 
            else
            {
                MimicOppenentsLastMove(thisMove, opponentsLastMove);
                //CounterOpponentsLastMove(thisMove, opponentsLastMove);
            }

            /*if(opponentsLastMove != null)
            {
                MimicOppenentsLastMove(thisMove, opponentsLastMove);
            }
            else
            {
                ActRandom(thisMove);
            }*/

            turn++;
            return thisMove;
        }

        private void ActRandom(Move thisMove)
        {
            List<Area> defenses = new List<Area>();

            for (int x = 0; x < 3; x++)
            {
                int rnd = _random.Next(0, 11);

                if (rnd < 8)
                {
                    int temp = _random.Next(0, 3);
                    if (temp == 0)
                    {
                        thisMove.AddAttack(Area.Belly);
                    }

                    else if (temp == 1)
                    {
                        thisMove.AddAttack(Area.Jaw);
                    }

                    else if (temp == 2)
                    {
                        thisMove.AddAttack(Area.Nose);
                    }
                }
                else
                {
                    int temp = _random.Next(0, 3);
                    if (temp == 0)
                    {
                        if (!defenses.Contains(Area.Belly))
                        {
                            thisMove.AddDefence(Area.Belly);
                            defenses.Add(Area.Belly);
                        }
                        else
                        {
                            if (!defenses.Contains(Area.Nose))
                            {
                                thisMove.AddDefence(Area.Nose);
                                defenses.Add(Area.Nose);
                            }
                            else
                            {
                                thisMove.AddDefence(Area.Jaw);
                                defenses.Add(Area.Jaw);
                            }
                        }
                    }

                    else if (temp == 1)
                    {
                        if (!defenses.Contains(Area.Jaw))
                        {
                            thisMove.AddDefence(Area.Jaw);
                            defenses.Add(Area.Jaw);
                        }
                        else
                        {
                            if (!defenses.Contains(Area.Nose))
                            {
                                thisMove.AddDefence(Area.Nose);
                                defenses.Add(Area.Nose);
                            }
                            else
                            {
                                thisMove.AddDefence(Area.Belly);
                                defenses.Add(Area.Belly);
                            }
                        }
                    }

                    else if (temp == 2)
                    {
                        if (!defenses.Contains(Area.Nose))
                        {
                            thisMove.AddDefence(Area.Nose);
                            defenses.Add(Area.Nose);
                        }
                        else
                        {
                            if (!defenses.Contains(Area.Jaw))
                            {
                                thisMove.AddDefence(Area.Jaw);
                                defenses.Add(Area.Jaw);
                            }
                            else
                            {
                                thisMove.AddDefence(Area.Belly);
                                defenses.Add(Area.Belly);
                            }
                        }
                    }
                }
            }
        }

        private void MimicOppenentsLastMove(Move thisMove, Move opponentsLastMove)
        {
            List <Area> hisAttacks = opponentsLastMove.Attacks.ToList<Area>();
            List <Area> hisDefenses = opponentsLastMove.Defences.ToList<Area>();

            foreach (Area ar in hisAttacks)
            {
                thisMove.AddAttack(ar);
            }
            foreach (Area ar in hisDefenses)
            {
                thisMove.AddDefence(ar);
            }

        }

        private void CounterOpponentsLastMove(Move thisMove, Move opponentsLastMove)
        {
            List<Area> hisAttacks = opponentsLastMove.Attacks.ToList<Area>();
            List<Area> hisDefenses = opponentsLastMove.Defences.ToList<Area>();

            foreach (Area ar in hisAttacks)
            {
                thisMove.AddDefence(ar);
            }
            foreach (Area ar in hisDefenses)
            {
                thisMove.AddAttack(ar);
            }
        }

        private void PunchHard(Move thisMove, Move opponentsLastMove)
        {
            thisMove.AddAttack(Area.Nose);
            thisMove.AddAttack(Area.Jaw);
            thisMove.AddDefence(Area.Nose);
        }
        
    }
}
