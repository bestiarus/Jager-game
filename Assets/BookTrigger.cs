using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookTrigger : MonoBehaviour
{
    public GameObject BookToggle;
    public GameObject CrosshairToggle;
    void Start()
    {
       BookToggle.SetActive(false); 
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player") {
            BookToggle.SetActive(true);  
            CrosshairToggle.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player") {
            BookToggle.SetActive(false);
            CrosshairToggle.SetActive(true);
        }
    }
}

