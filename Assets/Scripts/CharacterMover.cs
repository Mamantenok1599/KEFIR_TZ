using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    private Animator _Animator;
    private Rigidbody[] _Rigidbodies;

    private void Start()
    {
        _Animator = GetComponent<Animator>();
        _Rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rigidbody in _Rigidbodies)
        {
            rigidbody.isKinematic = true;
        }
    }

    private void FixedUpdate()
    {
        Move();

        if (Input.GetMouseButtonDown(0))
        {
        Attack();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
        Death();
        }
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _Animator.SetFloat("Speed", 1.0f);
        }
        else
        {
            _Animator.SetFloat("Speed", 0.0f);
        }
    }

    private void Attack()
    {

            int randomIndex = Random.Range(0, 1);
            switch(randomIndex)
            {
                case 0:
                _Animator.SetTrigger("Attack_01");
                    break;
                case 1:
                _Animator.SetTrigger("Attack_02");
                    break;
            }
    }

    private void Death()
    {
            _Animator.enabled = false;

            foreach (Rigidbody rigidbody in _Rigidbodies)
            {
                rigidbody.isKinematic = false;
            }
    }
}
