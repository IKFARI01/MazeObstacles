using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace ClassDemos
{
    public class Bullet : MonoBehaviour
    {


        [SerializeField] float speed;

        private void OnTriggerEnter(Collider other)
        {

            Destroy(gameObject);

        }

        public void Damage()
        {

            Debug.Log("Damage!");

        }
    }
}
