using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class moveCanvasImage : MonoBehaviour
{
    private float speed = 5f;
    public int direction = 1;
    RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        //print(gameObject.GetComponent<RectTransform>().localPosition);
        //print(gameObject.transform.position);
        if (rectTransform.localPosition.y > -450f)
        {
            direction = -1;
        }
        else if (rectTransform.localPosition.y < -1115f)
        {
            direction = 1;
        }
        gameObject.transform.Translate(Vector3.up * Time.deltaTime * speed * direction);

    }
}
