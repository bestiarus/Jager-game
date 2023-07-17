using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone_trigger : MonoBehaviour
{
    public GameObject OathToggle;
    public GameObject CrosshairToggle;
    void Start()
    {
       OathToggle.SetActive(false); 
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player") {
            OathToggle.SetActive(true);  
            CrosshairToggle.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player") {
            OathToggle.SetActive(false);
            CrosshairToggle.SetActive(true);
        }
    }
}

