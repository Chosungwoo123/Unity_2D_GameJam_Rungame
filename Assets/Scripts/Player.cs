using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float baseJumpPower;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private float magnetItemTime;

    [SerializeField] private Transform groundCheck;

    [SerializeField] private LayerMask whatIsGround;

    [SerializeField] private GameObject magnetObj;

    private int amountOfJumps = 2;
    private int amountOfJumpsLeft;

    private float curJumpPower;
    private float magnetItemStartTiem;

    private bool canJump = true;
    private bool isGround;
    private bool isSliding;

    Animator anim;
    Rigidbody2D rigid;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckSurroundings();
        UpdateAnimations();
        Jump();
        SlidingCheck();
        CheckIfCanJump();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            Die();
        }
        if (collision.gameObject.CompareTag("DeadLine"))
        {
            Die();
        }
        if(collision.gameObject.CompareTag("Magnet"))
        {
            StartCoroutine(UseMagnetCoroutine());
            EffectManager.Instance.MakeMagnetEatEffect(this.gameObject.transform);
            Destroy(collision.gameObject);
        }
    }

    IEnumerator UseMagnetCoroutine()
    {
        magnetObj.SetActive(true);

        yield return new WaitForSeconds(3);

        magnetObj.SetActive(false);
    }

    private void SlidingCheck()
    {
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.LeftControl) && isGround)
        {
            isSliding = true;
        }
        else
        {
            isSliding = false;
        }
    }

    private void Die()
    {
        anim.SetTrigger("Die");
        GameManager.Instance.TimeStop();
        rigid.gravityScale = 0;
    }

    private void LoadGameOverImage()
    {
        GameManager.Instance.LoadGameOverImage();
    }

    private void CheckSurroundings()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
    
    private void UpdateAnimations()
    {
        anim.SetBool("isGround", isGround);
        anim.SetFloat("yVelocity", rigid.velocity.y);
        anim.SetBool("isSliding", isSliding);
    }

    private void CheckIfCanJump()
    {
        //Jump Count Initialize
        if (isGround && rigid.velocity.y <= 0.15f)
        {
            amountOfJumpsLeft = amountOfJumps;
        }

        //canJump Check
        if (amountOfJumpsLeft <= 0)
        {
            canJump = false;
        }
        else
        {
            canJump = true;
        }
    }

    private void Jump()
    {
        if (!Input.GetKeyDown(KeyCode.Space) && !Input.GetKeyDown(KeyCode.W) || !canJump || isSliding)
            return;

        curJumpPower = baseJumpPower - rigid.velocity.y;

        rigid.AddForce(Vector2.up * curJumpPower, ForceMode2D.Impulse);

        amountOfJumpsLeft--;
    }

    private void StartMagnetic()
    {
        magnetItemStartTiem = Time.time;
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
