using System;
using System.Collections;

namespace Code
{
    public enum PowerUpType
    {
        None,
        MultiPomme,
        Glue,
        Ice,
        Repulsive,
        InvertControl,
        BoardRotation,
        SpeedUp,
        StraightTongue,
    }

    public static class PowerUpUtils
    {
        public static int GetScoreFor(PowerUpType powerUp)
        {
            switch (powerUp)
            {
                case PowerUpType.None: return 1;
                case PowerUpType.MultiPomme: return 5;
                case PowerUpType.Glue: return 5;
                case PowerUpType.Ice: return 5;
                case PowerUpType.Repulsive: return -5;
                case PowerUpType.InvertControl: return 5;
                case PowerUpType.BoardRotation: return 5;
                case PowerUpType.SpeedUp: return 5;
                case PowerUpType.StraightTongue: return 5;

                default:
                    return 1;
            }
        }

        

    }
}