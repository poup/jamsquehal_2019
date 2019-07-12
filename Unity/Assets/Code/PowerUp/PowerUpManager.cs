using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Code
{
    public class PowerUpManager : MonoBehaviour
    {
        [SerializeField] private Board m_board;
        
        public float duration = 4.0f;
        public float interval = 0.1f;
        
        [Header("MultiPomme")]
        public int MultiPommeCountMin = 18;
        public int MultiPommeCountMax = 25;
        public float MultiPommeInterval = 0.08f;
        
        [Header("SpeedUp")]
        public float speedUp = 2.0f;
        public float dragMultiplier = 2.0f;
        
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
                
                case PowerUpType.StraightTongue: 
                    DoStraightTongue(playerId);
                    return;
            }
        }

        private void DoStraightTongue(int playerId)
        {
            // TODO
        }

        private void DoBoardRotation(int playerId)
        {
            // get board
            var nbOfRotations = UnityEngine.Random.Range(5, 9);
            StartCoroutine(RotateBoard(nbOfRotations * 45 * Mathf.Deg2Rad, interval));
            // rotation de Random(5, 8) de quart de tour
        }

        private IEnumerator RotateBoard (float totalAngle, float interval)
        {
            while (totalAngle > 0)
            {
                m_board.transform.Rotate(Vector3.forward, totalAngle * interval);
                totalAngle -= interval;
                yield return new WaitForSecondsRealtime(interval);
            }
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
            var count = UnityEngine.Random.Range(MultiPommeCountMin, MultiPommeCountMax);
            m_board.appleSpawner.StartSpawn(count, MultiPommeInterval);
        }
        
        private void DoSpeedup(int playerId)
        {
            var speedup = new TongueEnd.SpeedUp(speedUp, dragMultiplier);
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
            // Pwaaaah: faire autrement
            yield return m_board.player1.GetComponentInChildren<TongueEnd>();
            yield return m_board.player2.GetComponentInChildren<TongueEnd>();
            yield return m_board.player3.GetComponentInChildren<TongueEnd>();
            yield return m_board.player4.GetComponentInChildren<TongueEnd>();
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