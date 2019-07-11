using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public class Player : MonoBehaviour
    {
        public Board board;
        public SpriteRenderer sr;
        // Start is called before the first frame update
        void Start()
        {
            int randomPlacement;
            do
            {
                randomPlacement = Random.Range(1, 5);
            }
            while (board.accrUsed[randomPlacement - 1]);
            board.accrUsed[randomPlacement - 1] = true;
            string name = "Accroche" + randomPlacement;
            print(name);
            Transform t = board.transform.Find(name).transform;
            transform.position = t.position;
            transform.rotation = t.rotation;
            transform.localScale = new Vector3(transform.localScale.x * 0.1f, transform.localScale.y * 0.1f, 0);
            
            do
            {
                randomPlacement = Random.Range(0, 4);
            }
            while (board.colors[randomPlacement] == Color.white);
            sr.color = board.colors[randomPlacement];
            print(sr.color.ToString());
            board.colors[randomPlacement] = Color.white;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
