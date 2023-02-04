using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]GameObject platform;

    [SerializeField]GameObject Player;
    [SerializeField]float platform_Speed=0.02f;

    public static List <GameObject> platforms= new List<GameObject>();
    Time timenow;
    Time last_checkpoint;
    int fpsTimeNow=0;
    int fpsTimeLast=0;
    float size=3;


    public GameObject projectile;
    [SerializeField]public float SpawnRate;
    private float nextSpawn = 0.0f;

    const float PLATFORM_LIMIT = 10;

    void Start()
    {
        platforms.Add(Instantiate(platform,new Vector3(0,-5,0), Quaternion.identity));
        
    }



    // Update is called once per frame
    void FixedUpdate()
    {


        if ( Time.time > nextSpawn)
        {
            nextSpawn = Time.time + (SpawnRate);
            size=Random.Range(3,8);
             GameObject singlePlaftorm;
            singlePlaftorm=Instantiate(platform,new Vector3(Random.Range((-PLATFORM_LIMIT+(size/2)),(+PLATFORM_LIMIT-(size/2))),-10,0), Quaternion.identity);
            singlePlaftorm.transform.localScale=new Vector3(size,.5f,1);
            if(Random.Range(0,4)==2){
                singlePlaftorm.GetComponent<abilites>().singleProperty=abilites.Property.THORNS;
            }
            platforms.Add(singlePlaftorm);
        }
        foreach(GameObject singlePlatform in platforms){
            Debug.Log("InsideForEach!");
            singlePlatform.transform.position+=new Vector3(0,platform_Speed,0);
        }
       
        if(Player.transform.position.y<-3){
            platform_Speed=0.3f+Player.transform.position.y*-1f*.01f;
        }
        else{
            platform_Speed=0.05f;
        }
        SpawnRate=0.025f/platform_Speed;

        fpsTimeNow++;
    }
}
