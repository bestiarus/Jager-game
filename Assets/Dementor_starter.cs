using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dementor_starter : MonoBehaviour
{
    public GameObject Dementor;
    void Start()
    {
        Dementor.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 0f;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player") {
            Debug.Log("Dementor started");
            Dementor.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 2f;
        }
    }
}

