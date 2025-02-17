using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]

public class Fighting : MonoBehaviour {

    public GameObject playerObj;
    public float moveSpeed = 5f;
    public float turnSpeed = 60f;
    private bool run;
    private bool jump;
    bool HoldJump;
    bool JumpCheck = true;
    bool ImmortalTrigger = false;
    private Rigidbody rb;
    private float inputH;
    private float inputV;
    Vector3 JumpOldPos;


    private Animator anim;						// Animator
    private AnimatorStateInfo currentState;		// 當前狀態
    private AnimatorStateInfo previousState;	// 先前狀態


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // 各参照の初期化
        anim = GetComponent<Animator>();
        currentState = anim.GetCurrentAnimatorStateInfo(0);
        previousState = currentState;


    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
          
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }


        if (Input.GetKey(KeyCode.LeftShift))
        {
            run = true;
            moveSpeed = 8f;

        }
        else
        {
            run = false;
            moveSpeed = 5f;
        }

        
        if (ImmortalTrigger == true)//無敵的持續時間
        {
            StartCoroutine(player.DelayToInvokeDo(() =>
            {
                ImmortalTrigger = false;

            }, 10f));
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && JumpCheck)
        {
 
            rb.velocity = Vector3.zero;
            rb.AddForce(0, 190, 0);

            if (transform.position.y > JumpOldPos.y + 4)
            {
                JumpCheck = false;

            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            HoldJump = false;
        }
    }



    void OnCollisionStay(Collision other)
    {
        JumpCheck = true;

        //if (Other.gameObject.name == "Terrain")
        //{
        //JumpCheck = true;
        //HoldJump = true;
        //}




    }

    void OnCollisionExit(Collision Other)
    {
        if (Other.gameObject.name == "Terrain")
        {
            JumpOldPos = transform.position;
        }
    }

    void OnTriggerEnter(Collider col) //aaa為自定義碰撞事件
    {
        if (col.gameObject.name == "Dead") //如果aaa碰撞事件的物件名稱是CubeA
        {
            Destroy(playerObj);
        }

        if (col.gameObject.name == "Item") //如果aaa碰撞事件的物件名稱是CubeA
        {
            ImmortalTrigger = true;//無敵狀態打開
            print("You Are Immortal");

        }
        if (col.gameObject.name == "Item1") //如果aaa碰撞事件的物件名稱是CubeA
        {
            ImmortalTrigger = true;//無敵狀態打開

        }
        if (col.gameObject.name == "Hit_Point0") //如果aaa碰撞事件的物件名稱是CubeA
        {
            if (ImmortalTrigger == false)//如果不是無敵狀態
            {
                Destroy(playerObj);
            }
        }
        if (col.gameObject.name == "Hit_Point1") //如果aaa碰撞事件的物件名稱是CubeA
        {
            if (ImmortalTrigger == false)//如果不是無敵狀態
            {
                Destroy(playerObj);
            }
        }
        if (col.gameObject.name == "Hit_Point2") //如果aaa碰撞事件的物件名稱是CubeA
        {
            if (ImmortalTrigger == false)//如果不是無敵狀態
            {
                Destroy(playerObj);
            }
        }
        if (col.gameObject.name == "Hit_Point3") //如果aaa碰撞事件的物件名稱是CubeA
        {
            if (ImmortalTrigger == false)//如果不是無敵狀態
            {
                Destroy(playerObj);
            }
        }
        if (col.gameObject.name == "Hit_Point4") //如果aaa碰撞事件的物件名稱是CubeA
        {
            if (ImmortalTrigger == false)//如果不是無敵狀態
            {
                Destroy(playerObj);
            }
        }
        if (col.gameObject.name == "Hit_Point5") //如果aaa碰撞事件的物件名稱是CubeA
        {
            if (ImmortalTrigger == false)//如果不是無敵狀態
            {
                Destroy(playerObj);
            }
        }
        if (col.gameObject.name == "Hit_Point6") //如果aaa碰撞事件的物件名稱是CubeA
        {
            if (ImmortalTrigger == false)//如果不是無敵狀態
            {
                Destroy(playerObj);
            }
        }
        if (col.gameObject.name == "Hit_Point7") //如果aaa碰撞事件的物件名稱是CubeA
        {
            if (ImmortalTrigger == false)//如果不是無敵狀態
            {
                Destroy(playerObj);
            }
        }
        if (col.gameObject.name == "Hit_Point8") //如果aaa碰撞事件的物件名稱是CubeA
        {
            if (ImmortalTrigger == false)//如果不是無敵狀態
            {
                Destroy(playerObj);
            }
        }
    }

    public static IEnumerator DelayToInvokeDo(Action action, float delaySeconds)//時間延遲的定義(要延遲執行的動作,延遲的時間)
    {
        yield return new WaitForSeconds(delaySeconds);//回傳延遲的時間值
        action();//讀取動作
    }

}
