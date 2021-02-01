using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce = 250.0f;
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private float groundCheckRadius = 0.1f;

    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }



    public void OnJump()
    {
        if(Physics.OverlapSphere(groundCheckTransform.position, groundCheckRadius, groundLayer).Length > 0) {
            Jump();
        }
    }

    private void Jump()
    {
        animator.SetTrigger("Jump");
        GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0));
        PlayerSounds.instance.Jump();
    }
}
