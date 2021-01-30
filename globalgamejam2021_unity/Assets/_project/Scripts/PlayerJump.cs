using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce = 250.0f;

    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    public void OnJump() {
        animator.SetTrigger("Jump");
        GetComponent<Rigidbody>().AddForce(new Vector3(0,jumpForce,0));
    }
}
