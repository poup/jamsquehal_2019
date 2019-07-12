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
            transform.SetParent(t);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
            
            do
            {
                randomPlacement = Random.Range(0, 4);
            }
            while (board.colors[randomPlacement] == Color.white);
            sr.color = board.colors[randomPlacement];
            print(sr.color.ToString());
            board.colors[randomPlacement] = Color.white;
        }
    }
}
