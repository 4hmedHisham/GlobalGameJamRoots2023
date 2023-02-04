using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBehaviour : MonoBehaviour
{
    public const string PLATFORM_TAG="Platform";
    public const string PLAYER_TAG="Player";
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
		
        
    }
	void OnTriggerExit2D(Collider2D other){
		//Debug.Log("Exited!");
		if(other.tag==PLATFORM_TAG){
			Destroy(other.gameObject);
			//Debug.Log("EnteredIFConditionPLatform!");
			gameManager.platforms.Remove(other.gameObject);
			
		}
	}

    void OnTriggerEnter2D(Collider2D other){
		//Debug.Log("Collided!");
		if(other.tag==PLAYER_TAG){
			Destroy(other.gameObject);
			//Debug.Log("EnteredIFConditionPlayer!");
			
		}
	}

}
