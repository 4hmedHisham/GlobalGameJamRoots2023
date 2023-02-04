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


    public float venusTimerFlipFlop=0;
    public float VenusFlyTrapFlipFlopPeriod;
    public enum Property{
        STONE,
        WEAK_BRANCH,
        HARD_BRANCH,
        THORNS,
        TIMED_BRANCH,
        VENUS_FLYTRAP

    }
    public Property singleProperty=Property.STONE;
    public Property CurrentVenusFlyTrapProperty=Property.STONE;
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
            case Property.VENUS_FLYTRAP:
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
        else  if(singleProperty==Property.VENUS_FLYTRAP){//Venus FlyTrap is basically a mix between stone and thorns in periodic times

            if (( Time.time > (venusTimerFlipFlop))){
                venusTimerFlipFlop=Time.time+VenusFlyTrapFlipFlopPeriod;
                if(CurrentVenusFlyTrapProperty==Property.STONE){
                    CurrentVenusFlyTrapProperty=Property.THORNS;
                    gameObject.GetComponent<SpriteRenderer>().color=Color.red;
                }
                else{
                    gameObject.GetComponent<SpriteRenderer>().color=Color.white;
                    CurrentVenusFlyTrapProperty=Property.STONE;
                }




            }
        }

        
        
    }
    void OnCollisionEnter2D(Collision2D other){
		//Debug.Log("Player-Platfrom Collision!");
		if(other.gameObject.tag==KillBehaviour.PLAYER_TAG){
			Movement.IsGrounded=true;

            //Debug.Log("Grounded set to true");
            switch(singleProperty) 

            {
                case Property.THORNS: 
                    Destroy(other.gameObject);
                    break;
                case Property.TIMED_BRANCH:
                    IsPlayerTouchingMe=true;
                    break;
                case Property.VENUS_FLYTRAP:
                    if(CurrentVenusFlyTrapProperty==Property.THORNS){
                        Destroy(other.gameObject);
                        break; 
                    }
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
