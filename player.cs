using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class player : MonoBehaviour
{

    public float moveSpeed = 1f;
    //public float turnSpeed = 1f;
    public float yVelocity = 0.0f;
    public float rotaSpeed = 0.5f;

    private Transform mainCameraTran;
    private Transform cameraDir;
    private Vector3 moveVector;
    private CharacterController charCtrl;

    public ParticleSystem heal;
    public ParticleSystem strong;
    //public ParticleSystem fist1;
    //public ParticleSystem fist2;
    //public ParticleSystem fist3;
    

    public Animator anim;
    private Rigidbody rb;

    //受到攻擊
    public GameObject attacker;//攻擊者
    public GameObject vic;                  //受害者
    private bool dead;
    public float HP = 100;
    //public GameObject AttackObject;

    bool HoldJump;
    bool JumpCheck;

    public GameObject daughter;
    public GameObject Generalblock1;
    public GameObject Generalblock2;

    Vector3 JumpOldPos;



    private float inputH;
    private float inputV;
    private bool run;
    private bool jump;
    private bool roll;
    private bool fight;
    private bool hide;
    private bool kick;
    private bool dodge;
    private bool fist;
    private bool elbow;
    private bool BaQua;
    private bool stabbing;
    private bool leftjump;
    private bool rightjump;
    private bool strongBuff;



    // Use this for initialization
    void Start()
    {
        JumpCheck = true;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        run = false;
        fight = false;
        hide = false;
        dead = false;
        heal.Stop();
        strong.Stop();
        //fist1.Stop();
        //fist2.Stop();
        //fist3.Stop();

        charCtrl = GetComponent<CharacterController>();

        mainCameraTran = Camera.main.gameObject.transform;

        GameObject cameraDir_obj = new GameObject();
        cameraDir_obj.transform.parent = transform;
        cameraDir_obj.transform.localPosition = Vector3.zero;
        cameraDir_obj.name = "CameraDir";
        cameraDir = cameraDir_obj.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mainCameraTran)
        {
            cameraDir.eulerAngles = new Vector3(0, mainCameraTran.eulerAngles.y, 0);
        }


        if (Input.GetKey(KeyCode.UpArrow))
        {
            //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            SmoothRotationY(cameraDir.eulerAngles.y);
            moveVector = cameraDir.forward * moveSpeed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            SmoothRotationY(cameraDir.eulerAngles.y + 180);
            moveVector = cameraDir.forward * -moveSpeed;
            run = false;
            moveSpeed = 1f;
            //transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            SmoothRotationY(cameraDir.eulerAngles.y + 90);
            moveVector = cameraDir.right * -moveSpeed;
            //transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
            if (fight == true)
            {
                leftjump = true;
                StartCoroutine(player.DelayToInvokeDo(() =>
                {
                    leftjump = false;
                }, 1f));//延遲一秒
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            SmoothRotationY(cameraDir.eulerAngles.y - 90);
            moveVector = cameraDir.right * moveSpeed;
            //transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
            if (fight == true)
            {
                rightjump = true;
                StartCoroutine(player.DelayToInvokeDo(() =>
                {
                    rightjump = false;
                }, 1f));//延遲一秒
            }
        }
        charCtrl.Move(moveVector * Time.deltaTime);
        


        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);
        anim.SetBool("run", run);
        anim.SetBool("jump", jump);
        anim.SetBool("roll", roll);
        anim.SetBool("fight", fight);
        anim.SetBool("kick", kick);
        anim.SetBool("dodge", dodge);
        anim.SetBool("fist", fist);
        anim.SetBool("elbow", elbow);
        anim.SetBool("BaQua", BaQua);
        anim.SetBool("hide", hide);
        anim.SetBool("stabbing", stabbing);
        anim.SetBool("leftjump", leftjump);
        anim.SetBool("strongBuff", strongBuff);
        anim.SetBool("dead", dead);


        if (Input.GetKey(KeyCode.LeftShift) && fight == false)
        {
            run = true;
            moveSpeed = 5f;
        }
        else
        {
            run = false;
            moveSpeed = 1f;

        }



        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            heal.Play();
            StartCoroutine(player.DelayToInvokeDo(() =>
            {
                heal.Stop();
            }, 2f));//延遲一秒
        }

        if (Input.GetKey(KeyCode.H))
        {
            hide = true;
        }

        if (Input.GetKey(KeyCode.F))
        {
            fight = true;
            if (hide == true)
            {
                stabbing = true;
            }
        }
        if (stabbing == true)
        {
            
            StartCoroutine(player.DelayToInvokeDo(() =>
            {
                stabbing = false;
                

            }, 1f));//延遲一秒
        }
        if (Input.GetKey(KeyCode.C))
        {
            fight = false;
            hide = false;
            strongBuff = false;
            strong.Stop();
        }

        if (Input.GetKey(KeyCode.K))
        {
            kick = true;

        }
        if (kick == true)
        {
            StartCoroutine(player.DelayToInvokeDo(() =>
            {
                kick = false;

            }, 1f));//延遲一秒
        }
        if (Input.GetKey(KeyCode.Q))
        {
            fight = true;
            dodge = true;

        }
        if (dodge == true)
        {

            StartCoroutine(player.DelayToInvokeDo(() =>
            {
                dodge = false;

            }, 1f));//延遲一秒
        }

        if (Input.GetKey(KeyCode.W) && fight == true)
        {
            fist = true;
            //Instantiate(blast, gameObject.transform.position, gameObject.transform.rotation);

        }
        if (fist == true)
        {
            StartCoroutine(player.DelayToInvokeDo(() =>
            {
                //AttackObject.transform.localPosition = new Vector3(0.15f, 1.5f, 0.75f);
                fist = false;
                /*StartCoroutine(player.DelayToInvokeDo(() =>
                {
                    AttackObject.transform.localPosition = new Vector3(0.15f, 1.5f, 0);
                }, 0.1f));*/

            }, 1f));//延遲一秒

            
        }

        if (Input.GetKey(KeyCode.E))
        {
            fight = true;
            elbow = true;
            //Instantiate(blast, gameObject.transform.position, gameObject.transform.rotation);

        }
        if (elbow == true)
        {
            StartCoroutine(player.DelayToInvokeDo(() =>
            {
                elbow = false;

            }, 1f));//延遲一秒
        }

        if (Input.GetKey(KeyCode.R))
        {
            fight = true;
            strongBuff = true;
            BaQua = true;
            strong.Play();
            //Instantiate(blast, gameObject.transform.position, gameObject.transform.rotation);

        }
        if (BaQua == true)
        {
           
            StartCoroutine(player.DelayToInvokeDo(() =>
            {
              
                BaQua = false;

            }, 1f));//延遲一秒
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            roll = true;
        }
        if (roll == true)
        {
            StartCoroutine(player.DelayToInvokeDo(() =>
            {
                roll = false;

            }, 1f));//延遲一秒
        }

    }
    public void SmoothRotationY(float iTargetAngle)
    {
        transform.eulerAngles = new Vector3(0, Mathf.SmoothDampAngle(transform.eulerAngles.y, iTargetAngle, ref yVelocity, rotaSpeed), 0);
    }

    /*void Move()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.DownArrow))
        {
            run = false;
            moveSpeed = 1f;
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
    }

    void MovementController()
    {
        if (!Talkable.isTalking)
        {
            Move();
        }
    }*/

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && JumpCheck)
        {
            
            
            rb.velocity = Vector3.zero;
            rb.AddForce(0, 3000, 0);
            jump = true;
            
            if (transform.position.y > JumpOldPos.y + 2)
            {
                JumpCheck = false;
                jump = false;

            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            HoldJump = false;
            jump = false;
        }

        if (HP == 0)
        {

            moveSpeed = 0;
            dead = true;
            Destroy(vic, 3);


        }
    }

    void OnCollisionEnter(Collision daughterCol)
    {
        if (daughterCol.gameObject.name == daughter.name)
        {
            Destroy(Generalblock1);
            Destroy(Generalblock2);
        }
    }

    void OnCollisionStay(Collision other)
    {
        JumpCheck = true;
        
    }

    void OnCollisionExit(Collision Other)
    {
        JumpOldPos = transform.position;
        
    }

    void OnTriggerEnter(Collider victim)
    {
        int attack = 1;    //隨機產生攻擊數值
        if (victim.gameObject.name == attacker.name)
        {
            if (HP - attack < 0)            //確認攻擊數值是否導致血量低於0
                HP = 0;
            else
                HP -= attack;
        }

        
    }

    public static IEnumerator DelayToInvokeDo(Action action, float delaySeconds)//時間延遲的定義(要延遲執行的動作,延遲的時間)
    {
        yield return new WaitForSeconds(delaySeconds);//回傳延遲的時間值
        action();//讀取動作
    }
}
