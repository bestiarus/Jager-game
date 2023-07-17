using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBiter : MonoBehaviour
{
    public float attackRate = 0.5f;
    public float npcDamage = 15;
    public AudioSource attackSound;
    //[HideInInspector]
    float nextAttackTime = 0;
    void Start()
    {
       
    }
    private void OnTriggerStay(Collider col)
    {
        GameObject[] players;
        players = GameObject.FindGameObjectsWithTag("Player");
        if (col.gameObject.tag == "Player") {
            Debug.Log("spider attack range enter");
            if(Time.time > nextAttackTime)
                {  
                    foreach (GameObject player in players) {
                        Debug.Log("SPIDER ATTACK!");
                        nextAttackTime = Time.time + attackRate;
                        IEntity target = player.GetComponent<IEntity>();
                        target.ApplyDamage(npcDamage);
                        attackSound.Play();
                    }
                }
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player") {
            Debug.Log("spider attack range exit");
        }
    }
}
