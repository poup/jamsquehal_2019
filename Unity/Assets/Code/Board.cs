using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Code
{
    public class Board : MonoBehaviour
    {
        [HideInInspector] public bool[] accrUsed;
        [HideInInspector] public Color[] colors;
        [HideInInspector] public Transform accr1;
        [HideInInspector] public Transform accr2;
        [HideInInspector] public Transform accr3;
        [HideInInspector] public Transform accr4;
        public Player playerPrefab;

        // Start is called before the first frame update
        void Awake()
        {
            accrUsed = new bool[4];
            accrUsed = new[] { false, false, false, false };
            colors = new Color[4];
            colors = new []{ Color.yellow, Color.red, Color.green, Color.gray };
            print("type : " + colors.GetType());
            accr1 = transform.Find("Accroche1");
            accr2 = transform.Find("Accroche2");
            accr3 = transform.Find("Accroche3");
            accr4 = transform.Find("Accroche4");
        }

        private void Start()
        {
            Player player1 = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity, transform);
            player1.board = this;
            Player player2 = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity, transform);
            player2.board = this;
            Player player3 = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity, transform);
            player3.board = this;
            Player player4 = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity, transform);
            player4.board = this;
        }
    }
}
