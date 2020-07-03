using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_script : MonoBehaviour
{
    [SerializeField] private bool isWalking;
    [SerializeField] private bool isCrawling;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject lookpoint;

    private NavMeshAgent agent;


    public float wanderRadius;
    public float wanderTimer;
    private float timer;

    public float freeTimer;
    private float timer2;

    private bool isSpotted;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
        isSpotted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSpotted)
        {
            timer += Time.deltaTime;

            if (timer >= (wanderTimer + Random.RandomRange(0f,5f)))
            {
                Vector3 newPos = RandomNavSphere(this.transform.position, wanderRadius, -1);
                agent.SetDestination(newPos);
                timer = 0;
            }
        }
        if (isSpotted)
        {
            agent.destination = player.transform.position;
            timer2 += Time.deltaTime;
            if (timer2 > freeTimer)
            {
                Vector3 newPos = RandomNavSphere(this.transform.position, wanderRadius, -1);
                agent.SetDestination(newPos);
                isCrawling = false;
                isWalking = true;
                isSpotted = false;
                timer2 = 0;
            }
        }
        RaycastHit hit;
        if (Physics.Raycast(lookpoint.transform.position, this.transform.forward, out hit, 20))
        {
            Debug.DrawLine(lookpoint.transform.position, hit.point, Color.red);
            if (hit.transform.tag == "Player")
            {
                isSpotted = true;
                isCrawling = true;
                isWalking = false;
            }
        }


        if (isWalking)
        {
            agent.speed = 2.5f;
            this.GetComponent<Animator>().SetBool("isWalking", true);
            this.GetComponent<Animator>().SetBool("isCrawling", false);
            this.GetComponent<Animator>().SetBool("isIdle", false);
        }
        if (isCrawling)
        {
            agent.speed = 5;
            this.GetComponent<Animator>().SetBool("isWalking", false);
            this.GetComponent<Animator>().SetBool("isCrawling", true);
            this.GetComponent<Animator>().SetBool("isIdle", false);
        }
        if (!isCrawling && !isWalking)
        {
            agent.speed = 0;
            this.GetComponent<Animator>().SetBool("isWalking", false);
            this.GetComponent<Animator>().SetBool("isCrawling", false);
            this.GetComponent<Animator>().SetBool("isIdle", true);
        }


    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    public void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            Application.LoadLevel(1);
        }
    }
}
