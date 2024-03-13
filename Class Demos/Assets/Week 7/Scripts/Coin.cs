using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClassDemos
{

    public class Coin : MonoBehaviour
    {
        [SerializeField] int Score = 0;
        [SerializeField] GameObject Coins;

        private void Start()
        {

        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == "Player")
            {

                Destroy(Coins);
                Score++;

            }
        }
    }
}
