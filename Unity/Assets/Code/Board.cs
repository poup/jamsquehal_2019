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
        
        private void Start()
        {
            player1 = Instantiate(player1Prefab, accr1.position, accr1.rotation, transform);
            player1.board = this;
            
            player2 = Instantiate(player2Prefab, accr2.position, accr2.rotation, transform);
            player2.board = this;
            
            player3 = Instantiate(player3Prefab, accr3.position, accr3.rotation, transform);
            player3.board = this;
            
            player4 = Instantiate(player4Prefab, accr4.position, accr4.rotation, transform);
            player4.board = this;
        }
    }
}
