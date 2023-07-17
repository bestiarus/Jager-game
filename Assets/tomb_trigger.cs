using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tomb_trigger : MonoBehaviour
{
    public GameObject TombToggle;
    public GameObject CrosshairToggle;
    void Start()
    {
       TombToggle.SetActive(false); 
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player") {
            TombToggle.SetActive(true);  
            CrosshairToggle.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player") {
            TombToggle.SetActive(false);
            CrosshairToggle.SetActive(true);
        }
    }
}

