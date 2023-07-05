using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   public float speed =8f; //탄알 이동 속력
    private Rigidbody bulletRigidbody; //이동에 사용할 리지드바디 컴포넌트
    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>(); //리지드바디 컴포넌트를 찾아 bullet에 할당

        bulletRigidbody.velocity = transform.forward*speed; //앞으로 speed만큼 속력 할당

        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player"){
            PlayerController playerController = other.GetComponent<PlayerController>();
            if(playerController != null){
                playerController.Die();
            }
        }
    }
    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
