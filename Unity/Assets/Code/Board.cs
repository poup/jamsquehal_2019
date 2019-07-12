using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Code
{
    public class Board : MonoBehaviour
    {
        [SerializeField] private Transform accr1;
        [SerializeField] private Transform accr2;
        [SerializeField] private Transform accr3;
        [SerializeField] private Transform accr4;

        [SerializeField] private Player player1Prefab;
        [SerializeField] private Player player2Prefab;
        [SerializeField] private Player player3Prefab;
        [SerializeField] private Player player4Prefab;

        [SerializeField] public AppleSpawner appleSpawner;

        [HideInInspector] public Player player1;
        [HideInInspector] public Player player2;
        [HideInInspector] public Player player3;
        [HideInInspector] public Player player4;

        public int StartPommeCount = 20;
        public float timeBeforePomme = 1.0f;

        private Player CreatePlayer(Player prefab, Transform target)
        {
            var player = Instantiate(prefab, target.position, target.rotation, transform);
            player.board = this;
            return player;
        }

        public void Clear()
        {
            appleSpawner.Clear();

            if (player1 != null)
                Destroy(player1.gameObject);
            if (player2 != null)
                Destroy(player2.gameObject);
            if (player3 != null)
                Destroy(player3.gameObject);
            if (player4 != null)
                Destroy(player4.gameObject);
            
            player1 = CreatePlayer(player1Prefab, accr1);
            player2 = CreatePlayer(player2Prefab, accr2);
            player3 = CreatePlayer(player3Prefab, accr3);
            player4 = CreatePlayer(player4Prefab, accr4);

        }

        private void OnTriggerEnter(Collider other)
        {
            Destroy(other.gameObject);
        }
    }
}