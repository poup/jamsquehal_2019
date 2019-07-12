using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Code
{
    public class Board : MonoBehaviour
    {
        public Transform accr1;
        public Transform accr2;
        public Transform accr3;
        public Transform accr4;
        public Player player1Prefab;
        public Player player2Prefab;
        public Player player3Prefab;
        public Player player4Prefab;

        private void Start()
        {
            Player player1 = Instantiate(player1Prefab, accr1.position, accr1.rotation, transform);
            player1.board = this;
            Player player2 = Instantiate(player2Prefab, accr2.position, accr2.rotation, transform);
            player2.board = this;
            Player player3 = Instantiate(player3Prefab, accr3.position, accr3.rotation, transform);
            player3.board = this;
            Player player4 = Instantiate(player4Prefab, accr4.position, accr4.rotation, transform);
            player4.board = this;
        }
    }
}
