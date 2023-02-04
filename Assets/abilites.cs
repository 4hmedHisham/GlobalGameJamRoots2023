using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abilites : MonoBehaviour
{
    public int pressCounter = 0;
    public float branchTimeout=0;
    public float branchTimeoutPeriod;
    private float TimeStart;
    private bool FirstTime=true;
    private bool IsPlayerTouchingMe=false;
    public enum Property{
        STONE,
        WEAK_BRANCH,
        HARD_BRANCH,
        THORNS,
        TIMED_BRANCH
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
            case Property.HARD_BRANCH:
            gameObject.GetComponent<SpriteRenderer>().color=new Color(150f/255f,75/255f,0f/255f);
            break;
            case Property.TIMED_BRANCH:
            gameObject.GetComponent<SpriteRenderer>().color=Color.gray;
            break;
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {

        // if(singleProperty==Property.TIMED_BRANCH)
        // {
        //     Debug.Log("Time is "+Time.time);
        // }
        if(singleProperty==Property.TIMED_BRANCH &&IsPlayerTouchingMe){
            if(FirstTime){
            TimeStart=Time.time;

            FirstTime=false;
            }
            if (( Time.time > (TimeStart+branchTimeoutPeriod))){
                        Destroy(gameObject);

                        gameManager.platforms.Remove(gameObject);
                        
                    }
        }
        
        
    }
    void OnCollisionEnter2D(Collision2D other){
		//Debug.Log("Player-Platfrom Collision!");
		if(other.gameObject.tag==KillBehaviour.PLAYER_TAG){
			Movement.IsGrounded=true;
            if(singleProperty==Property.TIMED_BRANCH){
                IsPlayerTouchingMe=true;

            }

            //Debug.Log("Grounded set to true");
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
    void OnTriggerExit2D(Collider2D other){
        IsPlayerTouchingMe=false;
        }

}
