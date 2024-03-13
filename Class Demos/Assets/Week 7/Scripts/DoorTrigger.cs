using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] GameObject Door;

    Vector3 origin;

    bool isOpening;
    float alpha;

    private void Awake()
    {
        origin = transform.position;
    }

    private void Update()
    {

        //alpha += isOpening ? Time.deltaTime

    }

    private void OnTriggerEnter(Collider other)
    {
        Door.gameObject.SetActive(false);
        //Door.transform.position = transform.position + (Vector3.up * 10);
    }

    private void OnTriggerExit(Collider other)
    {
        Door.gameObject.SetActive(true);
        //Door.transform.position = origin;
    }

}
