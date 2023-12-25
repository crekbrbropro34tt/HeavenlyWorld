using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class PlayerController : MonoBehaviour
{
    [Header("SettingsPlayer")]
    [SerializeField] private float walkSpeed, runSpeed, sidSpeed;
    private float speed;
    [SerializeField] private float jump;

    [Header("ComponentsPlayer")]
    private Rigidbody2D rb;
    private Animator anim;

    [Header("VabrialesPlayer")]
    private bool walk; //проверка ходьбы или бега

    [Header("Jump")]
    private bool Grounded;
    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] private Transform GroundCheck;
    private float GroundRadius = .2f;

    [Header("Camera")]
    private Camera cam;
    private Vector3 pos;
    [SerializeField] private CinemachineVirtualCamera cinimachineCamera;
    [SerializeField] private float shakeRun;
    [SerializeField] private float shakeWalk;

    [Header("Sid")]
    private bool sid;
    private bool nonWalk;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }


    void FixedUpdate()
    {
        if (!nonWalk && !sid)
        {
            Walk();
            Jump();
        }

        Sid();

        Flip();

        Grounded = Physics2D.OverlapCircle(GroundCheck.position, GroundRadius, GroundLayer);
        pos = cam.WorldToScreenPoint(transform.position);
    }

    private void Sid()
    {
        if(Input.GetKey(KeyCode.LeftControl) && Grounded && walk && !nonWalk)
        {
            sid = !sid;
            StartCoroutine(SidIE());
        }

        if(sid && !nonWalk)
        {
            speed = sidSpeed;
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);

            anim.SetBool("idle", false);
            anim.SetBool("walk", false);
            anim.SetBool("run", false);

            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannel = cinimachineCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            cinemachineBasicMultiChannel.m_AmplitudeGain = 0f;


            if (Input.GetAxis("Horizontal") != 0) //проверка ходьбы
            {
                anim.SetBool("sidIdle", false);
                anim.SetBool("sidWalk", true);
            }
 

            if (Input.GetAxis("Horizontal") == 0)
            {
                anim.SetBool("sidIdle", true);
                anim.SetBool("sidWalk", false);
            }
        } else if(!sid)
        {
            anim.SetBool("sidIdle", false);
            anim.SetBool("sidWalk", false);
        }
    }

    IEnumerator SidIE()
    {
        nonWalk = true;
        yield return new WaitForSeconds(.19f);
        nonWalk = false;
    }

    private void Jump()
    {
        if(Input.GetKey(KeyCode.Space) && Grounded)
        {
            rb.velocity = Vector2.up * jump;
        } 

        if(!Grounded)
        {
            anim.SetBool("idle", false);
            anim.SetBool("jump", true);
            anim.SetBool("walk", false);
            anim.SetBool("run", false);
        } else
        {
            anim.SetBool("jump", false);
        }
    }

    private void Walk()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y );

        if (Input.GetAxis("Horizontal") != 0 && walk && !sid) //проверка ходьбы и бега
        {
            anim.SetBool("idle", false);
            anim.SetBool("idleRun", false);
            anim.SetBool("walk", true);
            anim.SetBool("run", false);

            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannel = cinimachineCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            cinemachineBasicMultiChannel.m_AmplitudeGain = shakeWalk;

            speed = walkSpeed;
        }
        else if (Input.GetAxis("Horizontal") != 0 && !walk)
        {
            anim.SetBool("idle", false);
            anim.SetBool("idleRun", false);
            anim.SetBool("walk", false);
            anim.SetBool("run", true);

            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannel = cinimachineCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            cinemachineBasicMultiChannel.m_AmplitudeGain = shakeRun;

            speed = runSpeed;
        }



        if (Input.GetAxis("Horizontal") == 0 && walk)
        {
            anim.SetBool("idle", true);
            anim.SetBool("idleRun", false);
            anim.SetBool("walk", false);
            anim.SetBool("run", false);


            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannel = cinimachineCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            cinemachineBasicMultiChannel.m_AmplitudeGain = 0f;

        }
        else if (Input.GetAxis("Horizontal") == 0 && !walk)
        {
            anim.SetBool("idle", false);
            anim.SetBool("idleRun", true);
            anim.SetBool("walk", false);
            anim.SetBool("run", false);


            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannel = cinimachineCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            cinemachineBasicMultiChannel.m_AmplitudeGain = 0f;
        }
    }

    private void Flip() //поворот персонажа
    {
        if(Input.mousePosition.x < pos.x)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);

            if (Input.GetAxis("Horizontal") > .1f)
            {
                anim.SetFloat("walkFloat", -1);
                walk = true;
            }
            else
            {
                anim.SetFloat("walkFloat", 1);

                if (Input.GetKey(KeyCode.LeftShift)) //проверка нажатия шифта для бега
                    walk = false;
                else
                    walk = true;
            }

        }

        if (Input.mousePosition.x > pos.x)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);

            if (Input.GetAxis("Horizontal") < -.1f)
            {
                anim.SetFloat("walkFloat", -1);
                walk = true;
            }
            else
            {
                anim.SetFloat("walkFloat", 1);

                if (Input.GetKey(KeyCode.LeftShift)) //проверка нажатия шифта для бега
                    walk = false;
                else
                    walk = true;
            }

        }
    }
}
