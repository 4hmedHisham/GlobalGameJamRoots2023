using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abilites : MonoBehaviour
{
    
    public enum Property{
        STONE,
        WEAK_BRANCH,
        HARD_BRANCH,
        THORNS,
        //TIMED_BRANCH
    }
    public Property singleProperty=Property.STONE;
    // Start is called before the first frame update
    void Start()
    {
        switch(singleProperty) 

        {   
            case Property.THORNS: 
            gameObject.GetComponent<SpriteRenderer>().color=Color.red;
            break;
            case Property.WEAK_BRANCH:
            gameObject.GetComponent<SpriteRenderer>().color=Color.green;
            
            break;
        }
        if(singleProperty==Property.THORNS){
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other){
		Debug.Log("Player-Platfrom Collision!");
		if(other.gameObject.tag==KillBehaviour.PLAYER_TAG){
			Movement.IsGrounded=true;
            Debug.Log("Grounded set to true");
            switch(singleProperty) 

            {
                case Property.THORNS: 
                    Destroy(other.gameObject);
                    break;
                // case Property.WEAK_BRANCH:
                //     gameObject.GetComponent<Collider2D>().
            }
           
		}

        
	}
}
