using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Movement : MonoBehaviour
{
    KeyCode Left=KeyCode.A;
    KeyCode Right=KeyCode.D;
    KeyCode Jump=KeyCode.W;
    KeyCode Eat=KeyCode.S;
    [SerializeField]float jumpAmount=1f;
    public static bool IsGrounded=false;

    [SerializeField]float speed =0.02f;

    void jump(){

    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //KillBehaviour.PLATFORM_TAG;
        if(Input.GetKey(Jump)&&IsGrounded){
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            IsGrounded=false;
            Debug.Log("Jump_registerd!");
        }
        if(Input.GetKey(Left)){
            gameObject.transform.position+=new Vector3(-speed,0,0);
        }
        if(Input.GetKey(Eat)){
            
            // Collider2D[] collidedObjects;
            // gameObject.GetComponent<Collider2D>().OverlapCollider(ContactFilter2D.NoFilter(),collidedObjects);

        }
        if(Input.GetKey(Right)){
            gameObject.transform.position+=new Vector3(speed,0,0);
        }

    }
}
