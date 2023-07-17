using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class Dementor : MonoBehaviour, IEntity
{
    public float attackDistance = 3f;
    public float movementSpeed = 4f;
    public float npcHP = 100000;
    public SC_DamageReceiver player;
    public GameObject npcDeadPrefab;
    public Transform playerTransform;
    [HideInInspector]
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] players;
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = attackDistance;
        agent.speed = movementSpeed;
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players) {
            playerTransform = player.transform;
        }
        //Set Rigidbody to Kinematic to prevent hit register bug
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().isKinematic = true;
        }
        agent.speed = 0f;
    }
    void Update()
    {
        agent.destination = playerTransform.position;
        transform.LookAt(new Vector3(playerTransform.transform.position.x, transform.position.y, playerTransform.transform.position.z));
    }

    public void ApplyDamage(float points)
    {
        // just nope
    }
}