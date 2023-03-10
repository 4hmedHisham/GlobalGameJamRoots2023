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
    bool isJumpPressed=false;
    bool isEatPressed=false;
    bool isRightPressed=false;
    bool isLeftPressed=false;
    private Animator animator;

    [SerializeField]float speed =0.02f;
    

    void jump(){

    }
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame

    void Update()
    {
        animator.enabled = false;
        //KillBehaviour.PLATFORM_TAG;
        if(Input.GetKey(Jump)&&IsGrounded){
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            IsGrounded=false;
            Debug.Log("Jump_registerd!");
        }
        if(Input.GetKey(Left)){
            gameObject.transform.position+=new Vector3(-speed,0,0);
            gameObject.transform.rotation=Quaternion.Euler(0,180,0);
            animator.enabled = true;
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
                HardCollider.gameObject.GetComponent<abilites>().pressCounter++;
                Debug.Log("Counter is "+HardCollider.gameObject.GetComponent<abilites>().pressCounter);
                if (HardCollider.gameObject.GetComponent<abilites>().pressCounter > 2)
                {
                    HardCollider.gameObject.GetComponent<abilites>().pressCounter = 0;
                    HardCollider.enabled = false;
                }
            }
            if (weakCollider is not null) weakCollider.enabled = false;
        }
        if(Input.GetKey(Right)){
            gameObject.transform.position+=new Vector3(speed,0,0);
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.enabled = true;
        }

    }
}
