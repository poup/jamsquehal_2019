using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public class PowerUpManager : MonoBehaviour
    {
        public const float duration = 4.0f;
        
        public static PowerUpManager instance;

        private readonly List<IPowerUp> m_powerUps = new List<IPowerUp>();

        private void Awake()
        {
            instance = this;
        }
        
        
        public void Activate(PowerUpType powerUp, int playerId)
        {
            switch (powerUp)
            {
                case PowerUpType.None: 
                    return;
                
                case PowerUpType.MultiPomme:
                    DoMultiPomme(playerId);
                    return;
                
                case PowerUpType.Glue:
                    DoGlue(playerId);
                    return;
                
                case PowerUpType.Ice:
                    DoIce(playerId);
                    return;
                
                case PowerUpType.Repulsive: 
                    DoRepulsive(playerId);
                    return;
                
                case PowerUpType.InvertControl: 
                    DoInvertControl(playerId);
                    return;
                
                case PowerUpType.BoardRotation: 
                    DoBoardRotation(playerId);
                    return;
                
                case PowerUpType.SpeedUp: 
                    DoSpeedup(playerId);
                    return;
            }
        }

        private void DoBoardRotation(int playerId)
        {
            // get board
            
            // rotation de Random(5, 8) de quart de tour
        }

        

        private void DoRepulsive(int playerId)
        {
            // get player
            // ajouter un gros collier au bout de la langue qui repouse les fruits
        }
       
        
        private void DoGlue(int playerId)
        {
            // TODO
        }

        private void DoMultiPomme(int playerId)
        {
            // get board
            // ajouter des pommes
        }
        
        
        
        private void DoSpeedup(int playerId)
        {
            var speedup = new TongueEnd.SpeedUp();
            RegisterPowerUp(speedup);
            
            foreach (var player in GetPlayersMover())
            {
                if (player.playerId == playerId)
                {
                    player.AddModifier(speedup);
                    return;
                }
            }
        }

        private void DoInvertControl(int playerId)
        {
            var invertControl = new TongueEnd.InvertMove();
            RegisterPowerUp(invertControl);
            
            foreach (var player in GetPlayersMover())
            {
                if (player.playerId != playerId)
                {
                    player.AddModifier(invertControl);
                }
            }
        }
        
        private void DoIce(int playerId)
        {
            var noMove = new TongueEnd.NoMove();
            RegisterPowerUp(noMove);
            
            foreach (var player in GetPlayersMover())
            {
                if (player.playerId != playerId)
                {
                    player.AddModifier(noMove);
                }
            }
        }
        

        private IEnumerable<TongueEnd> GetPlayersMover()
        {
            yield break;
        }
        

        private void RegisterPowerUp(IPowerUp power)
        {
            power.startTime = Time.time;
        }

        private void FixedUpdate()
        {
            var time = Time.fixedTime;
            
            for (int i = m_powerUps.Count - 1; i >= 0; --i)
            {
                if (time - m_powerUps[i].startTime > duration)
                {
                    m_powerUps[i].terminated = false;
                    m_powerUps.RemoveAt(i);
                }
            }
        }
    }
}