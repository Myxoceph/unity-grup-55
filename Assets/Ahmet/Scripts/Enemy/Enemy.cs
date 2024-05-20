using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public Player player;
    public Animator animator;
    public Rigidbody rb;
    private NavMeshAgent agent;
    public Transform target;
    public bool inDistance;
    public bool walk;
    public bool attack;
    public int heal;
    private bool damage;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        walk = false;
        attack = false;
        heal = 100;
    }

    private void Update()
    {
        if (inDistance && !attack && !damage)
        {
            agent.SetDestination(target.position);
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                animator.SetBool("Walk", false);
                animator.SetTrigger("Attack");
            }
            else
            {
                animator.SetBool("Walk", true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (player.Attack && other.gameObject.CompareTag("Sword"))
        {
            Vector3 forceDirection = player.transform.forward.normalized;
            rb.AddForce(forceDirection * 50, ForceMode.Impulse);
            heal -= Random.Range(10, 20);
            if (heal <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
