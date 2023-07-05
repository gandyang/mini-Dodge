using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody PlayerRigidbody; 
    public float speed = 8f;
    // // Start is called before the first frame update
    void Start()
    {
     PlayerRigidbody = GetComponent<Rigidbody>();
    }

    // // Update is called once per frame
    void Update()
    {
        //방향키 조작
    //  if (Input.GetKey(KeyCode.UpArrow) == true )   {
    //     PlayerRigidbody.AddForce(0f, 0f, speed);
    //  }
     
    //  if (Input.GetKey(KeyCode.DownArrow) == true )   {
    //     PlayerRigidbody.AddForce(0f, 0f, -speed);
    //  }
     
    //  if (Input.GetKey(KeyCode.RightArrow) == true )   {
    //     PlayerRigidbody.AddForce(speed, 0f, 0f);
    //  }
     
    //  if (Input.GetKey(KeyCode.LeftArrow) == true )   {
    //     PlayerRigidbody.AddForce(-speed, 0f, 0f);
    //  }

        //수평축과 수직축     
     float xInput = Input.GetAxis("Horizontal");
     float zInput = Input.GetAxis("Vertical");

        //실제 이동속도 = 입력값*이동속력 
    float xSpeed = xInput*speed;
    float zSpeed = zInput*speed;

    Vector3 newVelocity =new Vector3(xSpeed, 0f, zSpeed);
    //리지드바디 속도에 newVelocity 할당

    PlayerRigidbody.velocity = newVelocity;
    }


    public void Die(){
        gameObject.SetActive(false);
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }
}
