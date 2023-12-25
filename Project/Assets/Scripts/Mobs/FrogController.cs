using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float speed, jump;
    private bool right;

    [Header("Component")]
    private Rigidbody2D rb;
    private Animator anim;

    [Header("Grunded")]
    private bool Grounded;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] private float GroundRadios = .2f;

    [Header("SettingsTimeJump")]
    private float timeJump;
    [SerializeField] private float MinStartTimeJump, MaxStartTimeJump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        timeJump = Random.Range(MinStartTimeJump, MaxStartTimeJump);
    }


    private void Update()
    {
        if(timeJump <= 0)
        {
            timeJump = Random.Range(MinStartTimeJump, MaxStartTimeJump);
            Jump();
        } else
        {
            timeJump -= Time.deltaTime;
        }

        if(Grounded)
            anim.SetBool("jump", false);
        else
            anim.SetBool("jump", true);

    }

    private void Jump()
    {
        int rot;
        rot = Random.Range(-2, 3);

        if (rot < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            right = false;
        }
        else if (rot > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            right = true;
        }

        if (Grounded)
            rb.velocity = Vector2.up * jump;

        StartCoroutine(speedJumpIE());
    }

    IEnumerator speedJumpIE()
    {
        yield return new WaitForSeconds(0.1f);
        if (!Grounded)
        {
            if (right)
                rb.velocity = Vector2.right * speed;
            else
                rb.velocity = Vector2.left * speed;
        }
    }

    private void FixedUpdate()
    {
        Grounded = Physics2D.OverlapCircle(GroundCheck.position, GroundRadios, GroundLayer);
    }
}
