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

    private void Update()
    {
        _Animator.SetFloat("Speed",Input.GetAxis("Vertical"));

        if (Input.GetMouseButtonDown(0))
        {
        Attack();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
        Death();
        }
    }


    private void Attack()
    {

            int randomIndex = Random.Range(1, 3);
            switch(randomIndex)
            {
                case 1:
                _Animator.SetTrigger("Attack_01");
                    break;
                case 2:
                _Animator.SetTrigger("Attack_02");
                    break;
            }
    }

    private void Death()
    {
        _Animator.SetBool("IsDead", true);
        _Animator.SetTrigger("Death");
    }
    public void IsDead()
    {
            _Animator.enabled = false;

            foreach (Rigidbody rigidbody in _Rigidbodies)
            {
                rigidbody.isKinematic = false;
            }
    }
}
