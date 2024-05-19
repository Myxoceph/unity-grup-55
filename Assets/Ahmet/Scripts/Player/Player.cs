using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Enemy enemy;
    private Animator animator;
    public CharacterController characterController;

    public bool Attack;
    public int heal;
    public bool death;

    private void Start()
    {
        animator = GetComponent<Animator>();
        Attack = false;
        heal = 100;
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !Attack && characterController.isGrounded)
        {
            animator.SetTrigger("Attack");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyBase"))
        {
            enemy.inDistance = true;
        }
        if (other.gameObject.CompareTag("EnemyAttack"))
        {
            Vector3 forceDirection = enemy.transform.forward;
            characterController.Move(40 * Time.deltaTime * forceDirection);
            heal -= 20;
            if (heal <= 0)
            {
                death = true;
                Time.timeScale = 0;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyBase"))
        {
            enemy.inDistance = false;
        }
    }
}
