using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;


public class Movement : MonoBehaviour
{
    KeyCode Left=KeyCode.A;
    KeyCode Right=KeyCode.D;
    KeyCode Jump=KeyCode.W;
    KeyCode Eat=KeyCode.S;
    [SerializeField]float jumpAmount=1f;
    public static bool IsGrounded=false;

    [SerializeField]float speed =0.02f;
    private int pressCounter = 0;

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
        if(Input.GetKeyDown(Eat))
        {

            List<Collider2D> collidedObjects = new();
            // gameObject.GetComponent<Collider2D>().OverlapCollider(ContactFilter2D.NoFilter(),collidedObjects);
            gameObject.GetComponent<Collider2D>().OverlapCollider(new ContactFilter2D().NoFilter(), collidedObjects);
            var weakCollider = collidedObjects.FirstOrDefault(x =>
                x.gameObject.GetComponent<abilites>().singleProperty == abilites.Property.WEAK_BRANCH);
            var HardCollider = collidedObjects.FirstOrDefault(x =>
                x.gameObject.GetComponent<abilites>().singleProperty == abilites.Property.HARD_BRANCH);
            if (HardCollider is not null)
            {
                pressCounter++;
                if (pressCounter > 2)
                {
                    pressCounter = 0;
                    HardCollider.enabled = false;
                }
            }
            if (weakCollider is not null) weakCollider.enabled = false;
        }
        if(Input.GetKey(Right)){
            gameObject.transform.position+=new Vector3(speed,0,0);
        }

    }
}
