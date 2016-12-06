using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeFights.model;

namespace CodeFights
{
    class MyFighter : IFighter
    {
        Random _random;
        public MyFighter()
        {
            _random = new Random();
        }
        public Move MakeNextMove(Move opponentsLastMove, int myLastScore, int opponentsLastScore)
        {

            Move thisMove = new Move();

            List<Area> defenses = new List<Area>();
            for (int x = 0; x < 3; x++)
            {
                int rnd = _random.Next(0, 11);
                
                if(rnd < 8)
                {
                    int temp = _random.Next(0, 3);
                    if(temp == 0)
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
            
            return thisMove;
        }
    }
}
