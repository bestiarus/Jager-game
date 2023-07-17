using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dementor_biter : MonoBehaviour
{
    public float attackRate = 0.5f;
    public float npcDamage = 1;
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
            Debug.Log("Dementor attack range enter");
            if(Time.time > nextAttackTime)
                {  
                    foreach (GameObject player in players) {
                        Debug.Log("DEMENTOR ATTACK!");
                        nextAttackTime = Time.time + attackRate;
                        IEntity target = player.GetComponent<IEntity>();
                        target.ApplyDamage(npcDamage);
                        if (attackSound.isPlaying) {
                            } else {
                                attackSound.Play();
                            }

                    }
                }
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player") {
            Debug.Log("Dementor attack range exit");
            attackSound.Stop();
        }
    }
}
