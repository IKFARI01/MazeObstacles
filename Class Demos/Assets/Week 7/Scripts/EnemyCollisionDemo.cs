using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;


namespace ClassDemos
{
    public class EnemyCollisionDemo : MonoBehaviour
    {


        public Material materialDamaged;
        public Material materialNormal;

        private MeshRenderer mr;

        public void OnAwake()
        {

            mr = GetComponent<MeshRenderer>();

        }

        //This is for listening to trigger
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == "Bullet")
            {

                mr.material = materialDamaged;

                DOVirtual.DelayedCall(0.1f, () =>
                {

                    mr.material = materialNormal;

                });
            }

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {

        }

        private void OnTriggerStay(Collider other)
        {

        }

        private void OnTriggerExit(Collider other)
        {

        }

        //This is for listening to physiucs
        private void onCollisionEnter(Collider other)
        {

        }

    }
}
