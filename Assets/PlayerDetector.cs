using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public GameObject Spider;
    void Start()
    {
       Spider.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 0f;
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player") {
            Spider.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 4f;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player") {
            Spider.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 0f;
        }
    }
}

